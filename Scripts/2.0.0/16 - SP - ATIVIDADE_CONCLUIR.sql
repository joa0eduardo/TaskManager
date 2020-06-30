CREATE PROCEDURE ATIVIDADE_CONCLUIR

	@ATV_Tid INTEGER,
	@ATV_USU_TidUsuario INTEGER

AS
BEGIN

	DECLARE @ERRO VARCHAR(MAX)
	DECLARE @ATV_Observacao VARCHAR(MAX)
	DECLARE @ATV_DataHoraInicioOuReinicio DATETIME
	DECLARE @ATV_SAT_TidStatusAtividade INT
	DECLARE @ATV_DataHoraConclusao DATETIME
	DECLARE @ATV_DataHoraPausa DATETIME
	DECLARE @ATV_TempoTotal TIME
	DECLARE @MINUTOS INT

	BEGIN TRY
		BEGIN TRANSACTION

				SELECT 
					@ATV_DataHoraInicioOuReinicio = ISNULL(ATV_DataHoraReinicio,ATV_DataHoraInicio),
					@ATV_DataHoraPausa = ATV_DataHoraPausa,
					@ATV_SAT_TidStatusAtividade = ATV_SAT_TidStatusAtividade,
					@ATV_TempoTotal = ATV_TempoTotal,
					@ATV_DataHoraConclusao = GETDATE()

				FROM ATIVIDADE ATV

				WHERE ATV.ATV_Tid = @ATV_Tid

				IF(@ATV_SAT_TidStatusAtividade) = 1
				BEGIN

					UPDATE ATIVIDADE
					SET ATV_DataHoraConclusao = @ATV_DataHoraConclusao,
						ATV_SAT_TidStatusAtividade = 4

					WHERE ATV_Tid = @ATV_Tid

				END

				IF(@ATV_SAT_TidStatusAtividade) = 2
				BEGIN

					SET @MINUTOS = DATEDIFF(MINUTE,@ATV_DataHoraInicioOuReinicio,@ATV_DataHoraConclusao)

					UPDATE ATIVIDADE
					SET ATV_DataHoraConclusao = @ATV_DataHoraConclusao,
						ATV_TempoTotal = DATEADD(MINUTE,@MINUTOS,@ATV_TempoTotal),
						ATV_SAT_TidStatusAtividade = 4

					WHERE ATV_Tid = @ATV_Tid

				END

				IF(@ATV_SAT_TidStatusAtividade) = 3
				BEGIN
					
					SET @MINUTOS = DATEDIFF(MINUTE,@ATV_DataHoraPausa,@ATV_DataHoraConclusao)
					
					UPDATE ATIVIDADE
					SET ATV_DataHoraConclusao = @ATV_DataHoraConclusao,
						ATV_TempoTotal = DATEADD(MINUTE,@MINUTOS,@ATV_TempoTotal),
						ATV_SAT_TidStatusAtividade = 4
					
					WHERE ATV_Tid = @ATV_Tid

				END

				SET @ATV_Observacao = CONCAT('Concluída a atividade de código ',@ATV_Tid,'.')

				IF(@@ROWCOUNT >= 1)
					EXEC LOG_ATIVIDADE_INSERIR @ATV_Tid, @ATV_USU_TidUsuario, @ATV_Observacao
					SET @ATV_TempoTotal = (SELECT ATV_TempoTotal FROM ATIVIDADE WHERE ATV_Tid = @ATV_Tid)
					EXEC USUARIO_TEMPO_DIA_ATUALIZAR @ATV_USU_TidUsuario, @ATV_TempoTotal


		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH

		ROLLBACK TRANSACTION

		SET @ERRO = ERROR_MESSAGE()

		EXEC LOG_ERRO_INSERIR @ERRO, 'ATIVIDADE_CONCLUIR'

	END CATCH
	
END