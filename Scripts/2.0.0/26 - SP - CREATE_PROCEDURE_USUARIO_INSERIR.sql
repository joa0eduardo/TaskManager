CREATE PROCEDURE USUARIO_INSERIR  
  
 @USU_Nome VARCHAR(50),  
 @USU_Login VARCHAR(20),  
 @USU_Senha NVARCHAR(100),  
 @USU_Ativo BIT = 1,  
 @USU_PFU_TidPerfilUsuario INT  
  
AS  
BEGIN  
  
 DECLARE @ERRO VARCHAR(MAX)  
  
 BEGIN TRY  
  BEGIN TRANSACTION  
  
   IF (EXISTS(SELECT USU.USU_Login FROM USUARIO USU WHERE USU.USU_Login = @USU_Login))  
    RAISERROR('"%s" já existe no banco de dados.',16,1,@USU_Login)  
  
   INSERT INTO USUARIO  
   (  
    USU_Nome,  
    USU_Login,  
    USU_Senha,  
    USU_Ativo,  
    USU_PFU_TidPerfilUsuario  
   )  
   VALUES  
   (  
    @USU_Nome,  
    @USU_Login,  
    PWDENCRYPT(@USU_Senha),  
    @USU_Ativo,  
    @USU_PFU_TidPerfilUsuario  
   )  
  
   SELECT @@IDENTITY AS Retorno  
  
  COMMIT TRANSACTION  
 END TRY  
 BEGIN CATCH  
  
  ROLLBACK TRANSACTION  
    
  SET @ERRO = ERROR_MESSAGE()  
  
  EXEC LOG_ERRO_INSERIR @ERRO, 'USUARIO_INSERIR'  
  
  SELECT ERROR_MESSAGE() AS RETORNO  
  
 END CATCH  
  
END