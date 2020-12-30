CREATE PROCEDURE PERFIL_USUARIO_INSERIR  
  
 @PFU_Nome VARCHAR(20),  
 @PFU_Ativo BIT  
  
AS  
BEGIN  
  
 DECLARE @ERRO VARCHAR(MAX)  
  
 BEGIN TRY  
  BEGIN TRANSACTION  
  
   IF (EXISTS(SELECT USU.USU_Login FROM USUARIO USU WHERE USU.USU_Login = @PFU_Nome))  
    RAISERROR('Não foi possível inserir o Perfil de Usuário. Motivo: "%s" já existe no banco de dados.',16,1,@PFU_Nome)  
  
   INSERT INTO PERFIL_USUARIO  
   (  
    PFU_Nome,  
    PFU_Ativo  
   )  
   VALUES  
   (  
    @PFU_Nome,  
    @PFU_Ativo  
   )  
  
   SELECT @@IDENTITY AS Retorno  
  
  COMMIT TRANSACTION  
 END TRY  
 BEGIN CATCH  
  
  ROLLBACK TRANSACTION  
    
  SET @ERRO = ERROR_MESSAGE()  
  
  EXEC LOG_ERRO_INSERIR @ERRO, 'PERFIL_USUARIO_INSERIR'  
  
  SELECT ERROR_MESSAGE() AS RETORNO  
  
 END CATCH  
  
END