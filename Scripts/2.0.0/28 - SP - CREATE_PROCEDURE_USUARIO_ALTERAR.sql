CREATE PROCEDURE USUARIO_ALTERAR  
  
 @USU_Tid INTEGER,  
 @USU_Nome VARCHAR(50),  
 @USU_Login VARCHAR(20),  
 @USU_Senha NVARCHAR(100),  
 @USU_Ativo BIT,  
 @USU_PFU_TidPerfilUsuario INTEGER  
   
AS  
BEGIN  
  
 DECLARE @ERRO VARCHAR(MAX)  
  
 BEGIN TRY  
  
  BEGIN TRANSACTION  
  
   IF(@USU_Senha IS NULL OR @USU_Senha = '')  
   BEGIN  
  
    UPDATE USUARIO  
    SET USU_Nome = @USU_Nome,  
     USU_Login = @USU_Login,  
     USU_Ativo = @USU_Ativo,  
     USU_PFU_TidPerfilUsuario = @USU_PFU_TidPerfilUsuario  
     
    WHERE USU_Tid = @USU_Tid  
     
    IF(@@ROWCOUNT = 0)  
     SELECT 'Não foi possível alterar o usuário, talvez o mesmo não exista.' as Retorno  
    ELSE   
     SELECT @USU_Tid as Retorno  
  
   END  
   ELSE  
   BEGIN  
  
    UPDATE USUARIO  
    SET USU_Nome = @USU_Nome,  
     USU_Login = @USU_Login,  
     USU_Senha = PWDENCRYPT(@USU_Senha),  
     USU_Ativo = @USU_Ativo,  
     USU_PFU_TidPerfilUsuario = @USU_PFU_TidPerfilUsuario  
     
    WHERE USU_Tid = @USU_Tid  
     
    IF(@@ROWCOUNT = 0)  
     SELECT 'Não foi possível alterar o usuário, talvez o mesmo não exista.' as Retorno  
    ELSE   
     SELECT @USU_Tid as Retorno  
  
   END  
  
  COMMIT TRANSACTION  
  
 END TRY  
 BEGIN CATCH  
  
  ROLLBACK TRANSACTION  
  SET @ERRO = ERROR_MESSAGE()  
  
  EXEC LOG_ERRO_INSERIR @ERRO, 'USUARIO_ALTERAR'  
  
  SELECT @ERRO AS Retorno  
  
 END CATCH  
  
END