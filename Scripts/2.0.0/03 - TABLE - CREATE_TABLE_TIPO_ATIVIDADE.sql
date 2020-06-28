IF NOT EXISTS(SELECT * FROM SYS.TABLES WHERE NAME = 'TIPO_ATIVIDADE')
BEGIN

	CREATE TABLE TIPO_ATIVIDADE
	(
		TPA_Tid INTEGER NOT NULL IDENTITY,
		TPA_Descricao VARCHAR(50) NOT NULL,
		TPA_Observacao VARCHAR(300),
		TPA_Ativo BIT,
		PRIMARY KEY(TPA_Tid)
	)

END
ELSE
BEGIN

	SELECT 'J� existe a tabela TIPO_ATIVIDADE no banco de dados' as Retorno

END