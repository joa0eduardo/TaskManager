CREATE PROCEDURE GRUPO_ATIVIDADE_ALTERAR  
   
 @GPA_Tid INTEGER,  
 @GPA_Descricao VARCHAR(20),  
 @GPA_Observacao VARCHAR(300),  
 @GPA_Ativo BIT  
  
AS  
BEGIN  
 BEGIN TRY  
  BEGIN TRAN  
  
   DECLARE @ERRO VARCHAR(MAX)  
  
   UPDATE GRUPO_ATIVIDADE  
  
   SET GPA_Descricao  = @GPA_Descricao,  
    GPA_Observacao = @GPA_Observacao,  
    GPA_Ativo    = @GPA_Ativo  
  
   WHERE GPA_TID = @GPA_Tid  
  
   IF @@ROWCOUNT = 0  
   BEGIN  
    SELECT 'Nenhum registro alterado' as Retorno  
   END  
   ELSE  
   BEGIN  
    SELECT CONCAT('Grupo "', CAST(@GPA_Tid AS VARCHAR(100)), ' - ', @GPA_Descricao, '" alterado com sucesso') as Retorno  
   END  
  
  COMMIT TRAN  
 END TRY  
 BEGIN CATCH  
  
  ROLLBACK TRAN  
    
  SET @ERRO = ERROR_MESSAGE()  
  
  EXEC LOG_ERRO_INSERIR @ERRO, 'GRUPO_ATIVIDADE_ALTERAR'  
  
  SELECT ERROR_MESSAGE() AS RETORNO  
  
 END CATCH  
END