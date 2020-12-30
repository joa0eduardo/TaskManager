CREATE PROCEDURE TIPO_ATIVIDADE_INSERIR  
  
 @TPA_Descricao VARCHAR(50),  
 @TPA_Obervacao VARCHAR(300) = NULL,  
 @TPA_Ativo BIT = 1  
  
AS  
BEGIN  
  
 DECLARE @ERRO VARCHAR(MAX)  
  
 BEGIN TRY  
  BEGIN TRANSACTION  
  
   IF (EXISTS(SELECT TPA.TPA_Descricao FROM TIPO_ATIVIDADE TPA WHERE TPA.TPA_Descricao = @TPA_Descricao))  
    RAISERROR('Não foi possível inserir o Tipo de Atividade. Motivo: "%s" já existe no banco de dados.',16,1,@TPA_Descricao)  
  
   INSERT INTO TIPO_ATIVIDADE  
   (  
    TPA_Descricao,  
    TPA_Observacao,  
    TPA_Ativo  
   )  
   VALUES  
   (  
    @TPA_Descricao,  
    @TPA_Obervacao,  
    @TPA_Ativo  
   )  
  
   SELECT @@IDENTITY AS Retorno  
  
  COMMIT TRANSACTION  
 END TRY  
 BEGIN CATCH  
  
  ROLLBACK TRANSACTION  
    
  SET @ERRO = ERROR_MESSAGE()  
  
  EXEC LOG_ERRO_INSERIR @ERRO, 'TIPO_ATIVIDADE_INSERIR'  
  
  SELECT ERROR_MESSAGE() AS RETORNO  
  
 END CATCH  
  
END