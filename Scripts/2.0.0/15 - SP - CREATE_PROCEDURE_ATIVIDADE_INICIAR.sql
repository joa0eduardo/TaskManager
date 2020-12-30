CREATE PROCEDURE ATIVIDADE_INICIAR

	@ATV_Tid INTEGER,
	@ATV_USU_TidUsuario INTEGER

AS
BEGIN

	DECLARE @ERRO VARCHAR(MAX)
	DECLARE @ATV_Observacao VARCHAR(MAX)

	BEGIN TRY
		BEGIN TRANSACTION

			IF(SELECT ATV_SAT_TidStatusAtividade FROM ATIVIDADE WHERE ATV_Tid = @ATV_Tid) IN (2,4,5)
			BEGIN	
				RAISERROR('Não é possível iniciar uma atividade Em andamento, cancelada ou concluída.',1,16)
			END
			ELSE
			BEGIN

				IF(SELECT ATV_DataHoraInicio FROM ATIVIDADE WHERE ATV_Tid = @ATV_Tid) IS NULL
				BEGIN

					UPDATE ATIVIDADE
					SET ATV_DataHoraInicio = GETDATE(),
						ATV_SAT_TidStatusAtividade = 2
				
					WHERE ATV_Tid = @ATV_Tid

					SET @ATV_Observacao = CONCAT('Iniciada a atividade de código ',@ATV_Tid,'.')

					IF(@@ROWCOUNT >= 1)
						EXEC LOG_ATIVIDADE_INSERIR @ATV_Tid, @ATV_USU_TidUsuario, @ATV_Observacao

				END
				ELSE
				BEGIN

					UPDATE ATIVIDADE
					SET ATV_DataHoraReinicio = GETDATE(),
						ATV_SAT_TidStatusAtividade = 2

					WHERE ATV_Tid = @ATV_Tid

					SET @ATV_Observacao = CONCAT('Reiniciada a atividade de código ',@ATV_Tid,'.')

					IF(@@ROWCOUNT >= 1)
						EXEC LOG_ATIVIDADE_INSERIR @ATV_Tid, @ATV_USU_TidUsuario, @ATV_Observacao

				END
			END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH

		ROLLBACK TRANSACTION

		SET @ERRO = ERROR_MESSAGE()

		EXEC LOG_ERRO_INSERIR @ERRO, 'ATIVIDADE_INICIAR'

	END CATCH
	
END