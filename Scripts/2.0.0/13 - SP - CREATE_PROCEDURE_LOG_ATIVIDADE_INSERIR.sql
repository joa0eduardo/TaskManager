CREATE PROCEDURE LOG_ATIVIDADE_INSERIR  
  
 @LGA_ATV_TidAtividade INTEGER,  
 @LGA_USU_TidUsuario INTEGER,  
 @LGA_Observacao VARCHAR(MAX)  
  
AS  
BEGIN  
  
 DECLARE @ERRO VARCHAR(MAX)  
  
 BEGIN TRY  
    
  BEGIN TRANSACTION  
  
   INSERT INTO LOG_ATIVIDADE  
   (  
     LGA_ATV_TidAtividade  
    ,LGA_USU_TidUsuario  
    ,LGA_DataHoraCadastro  
    ,LGA_Observacao  
   )  
   VALUES  
   (  
    @LGA_ATV_TidAtividade,  
    @LGA_USU_TidUsuario,  
    GETDATE(),  
    @LGA_Observacao  
   )  
  
  COMMIT TRANSACTION  
   
 END TRY  
 BEGIN CATCH  
  
  ROLLBACK TRANSACTION  
  
  SET @ERRO = ERROR_MESSAGE()  
  
  EXEC LOG_ERRO_INSERIR @ERRO, 'LOG_ATIVIDADE_INSERIR'  
  
 END CATCH  
  
END