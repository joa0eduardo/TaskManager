CREATE PROCEDURE LOG_ERRO_INSERIR

	@LER_DescricaoErro VARCHAR(MAX),
	@LER_ProcedureErro VARCHAR(MAX)

AS
BEGIN

	INSERT INTO LOG_ERRO
	(
		LER_DataErro,
		LER_DescricaoErro,
		LER_ProcedureErro
	)
	VALUES
	(
		GETDATE(),
		@LER_DescricaoErro,
		@LER_ProcedureErro
	)

END