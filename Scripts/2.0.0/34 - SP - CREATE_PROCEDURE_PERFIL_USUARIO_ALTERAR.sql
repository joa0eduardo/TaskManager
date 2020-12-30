CREATE PROCEDURE PERFIL_USUARIO_ALTERAR  
  
 @PFU_Tid INTEGER,  
 @PFU_Nome VARCHAR(20),  
 @PFU_Ativo BIT  
   
AS  
BEGIN  
  
 DECLARE @ERRO VARCHAR(MAX)  
  
 BEGIN TRY  
  
  BEGIN TRANSACTION  
  
   UPDATE PERFIL_USUARIO  
   SET PFU_Nome = @PFU_Nome,  
    PFU_Ativo = @PFU_Ativo  
     
   WHERE PFU_Tid = @PFU_Tid  
     
   IF(@@ROWCOUNT = 0)  
    SELECT 'Não foi possível alterar o perfil de usuário, talvez o mesmo não exista.' as Retorno  
   ELSE   
    SELECT @PFU_Tid as Retorno  
  
  COMMIT TRANSACTION  
  
 END TRY  
 BEGIN CATCH  
  
  ROLLBACK TRANSACTION  
  SET @ERRO = ERROR_MESSAGE()  
  
  EXEC LOG_ERRO_INSERIR @ERRO, 'PERFIL_USUARIO_ALTERAR'  
  
  SELECT @ERRO AS Retorno  
  
 END CATCH  
  
END