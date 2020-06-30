IF (NOT EXISTS(SELECT SAT_Descricao FROM STATUS_ATIVIDADE WHERE SAT_Descricao = 'Planejada'))
BEGIN

	INSERT INTO STATUS_ATIVIDADE (SAT_Descricao) VALUES ('Planejada')

END

IF (NOT EXISTS(SELECT SAT_Descricao FROM STATUS_ATIVIDADE WHERE SAT_Descricao = 'Em Andamento'))
BEGIN

	INSERT INTO STATUS_ATIVIDADE (SAT_Descricao) VALUES ('Em Andamento')

END

IF (NOT EXISTS(SELECT SAT_Descricao FROM STATUS_ATIVIDADE WHERE SAT_Descricao = 'Pausada'))
BEGIN

	INSERT INTO STATUS_ATIVIDADE (SAT_Descricao) VALUES ('Pausada')

END

IF (NOT EXISTS(SELECT SAT_Descricao FROM STATUS_ATIVIDADE WHERE SAT_Descricao = 'Conclu�da'))
BEGIN

	INSERT INTO STATUS_ATIVIDADE (SAT_Descricao) VALUES ('Conclu�da')

END

IF (NOT EXISTS(SELECT SAT_Descricao FROM STATUS_ATIVIDADE WHERE SAT_Descricao = 'Cancelada'))
BEGIN

	INSERT INTO STATUS_ATIVIDADE (SAT_Descricao) VALUES ('Cancelada')

END