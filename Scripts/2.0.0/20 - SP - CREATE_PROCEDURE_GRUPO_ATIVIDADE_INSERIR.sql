CREATE PROCEDURE GRUPO_ATIVIDADE_INSERIR  
  
 @GPA_Descricao VARCHAR(20),  
 @GPA_Observacao VARCHAR(300),  
 @GPA_Ativo BIT = 1  
  
AS  
BEGIN  
   
 DECLARE @ERRO VARCHAR(MAX)  
  
 BEGIN TRY  
  BEGIN TRANSACTION  
  
   IF (EXISTS(SELECT RTRIM(LTRIM(GPA.GPA_Descricao)) FROM GRUPO_ATIVIDADE GPA WHERE GPA.GPA_Descricao = @GPA_Descricao))  
    RAISERROR(N'Não foi possível inserir o Grupo Atividade. Motivo: "%s" já existe no banco de dados.',16,1,@GPA_Descricao)  
  
  
    INSERT INTO GRUPO_ATIVIDADE  
    (  
     GPA_Descricao,  
     GPA_Observacao,  
     GPA_Ativo  
    )  
    VALUES  
    (  
     RTRIM(LTRIM(@GPA_Descricao)),  
     RTRIM(LTRIM(@GPA_Observacao)),  
     @GPA_Ativo  
    )  
      
    SELECT @@IDENTITY as Retorno;  
  
  COMMIT TRANSACTION  
 END TRY  
 BEGIN CATCH  
  
  ROLLBACK TRAN  
    
  SET @ERRO = ERROR_MESSAGE()  
  
  EXEC LOG_ERRO_INSERIR @ERRO, 'GRUPO_ATIVIDADE_INSERIR'  
  
  SELECT ERROR_MESSAGE() AS RETORNO  
  
 END CATCH  
END