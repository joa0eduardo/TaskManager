CREATE PROCEDURE ATIVIDADE_INSERIR

	@ATV_GPA_TidGrupoAtividade INTEGER,
	@ATV_TPA_TidTipoAtividade INTEGER,
	@ATV_USU_TidUsuarioAtividade INTEGER,
	@ATV_Descricao VARCHAR(100),
	@ATV_TempoTotal TIME = '00:00'

AS
BEGIN

	DECLARE @ERRO VARCHAR(MAX)
	DECLARE @ATV_Observacao VARCHAR(MAX)

	BEGIN TRY
		BEGIN TRANSACTION

			INSERT INTO ATIVIDADE
			(
				 ATV_GPA_TidGrupoAtividade
				,ATV_TPA_TidTipoAtividade
				,ATV_USU_TidUsuarioAtividade
				,ATV_Descricao
				,ATV_DataHoraCadastro
				,ATV_DataHoraInicio
				,ATV_DataHoraPausa
				,ATV_DataHoraConclusao
				,ATV_SAT_TidStatusAtividade
				,ATV_TempoTotal
			)
			VALUES
			(
				 @ATV_GPA_TidGrupoAtividade
				,@ATV_TPA_TidTipoAtividade
				,@ATV_USU_TidUsuarioAtividade
				,@ATV_Descricao
				,GETDATE()
				,NULL
				,NULL
				,NULL
				,1
				,@ATV_TempoTotal
			)

			SELECT @@IDENTITY AS Retorno

			IF(@@IDENTITY > 0)
			BEGIN

				SET @ATV_Observacao = CONCAT('Criada a atividade de código ',@@IDENTITY,'.')

				IF(@@IDENTITY) >= 1
					EXEC LOG_ATIVIDADE_INSERIR @@IDENTITY, @ATV_USU_TidUsuarioAtividade, @ATV_Observacao
			END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH

		ROLLBACK TRANSACTION

		SET @ERRO = ERROR_MESSAGE()

		EXEC LOG_ERRO_INSERIR @ERRO, 'ATIVIDADE_INSERIR'

	END CATCH
	
END