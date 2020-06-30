CREATE PROCEDURE ATIVIDADE_GRID_CONSULTAR
	
	@ATV_USU_TidUsuarioAtividade INT

AS
BEGIN

	SELECT
		ATV.ATV_Tid,
		GPA_Descricao,
		TPA_Descricao,
		ATV_Descricao,
		ATV_DataHoraCadastro,
		SAT.SAT_Descricao,
		ATV_TempoTotal

	FROM ATIVIDADE ATV
	INNER JOIN GRUPO_ATIVIDADE GPA ON GPA.GPA_Tid = ATV.ATV_GPA_TidGrupoAtividade
	INNER JOIN TIPO_ATIVIDADE TPA ON TPA.TPA_Tid = ATV.ATV_TPA_TidTipoAtividade
	INNER JOIN STATUS_ATIVIDADE SAT ON SAT.SAT_Tid = ATV.ATV_SAT_TidStatusAtividade

	WHERE ATV.ATV_USU_TidUsuarioAtividade = @ATV_USU_TidUsuarioAtividade

END