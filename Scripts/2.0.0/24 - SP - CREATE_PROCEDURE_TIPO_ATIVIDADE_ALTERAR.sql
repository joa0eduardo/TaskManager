CREATE PROCEDURE TIPO_ATIVIDADE_ALTERAR  
  
 @TPA_Tid INT,  
 @TPA_Descricao VARCHAR(50),  
 @TPA_Obervacao VARCHAR(300) = NULL,  
 @TPA_Ativo BIT  
  
AS  
BEGIN  
  
 DECLARE @ERRO VARCHAR(MAX)  
  
 BEGIN TRY  
  BEGIN TRANSACTION  
  
   IF (@TPA_Tid IS NULL)  
    RAISERROR('Necessário informar o Tid do Tipo de Atividade a ser alterado.',16,1)  
  
   UPDATE TIPO_ATIVIDADE  
   SET TPA_Descricao  = @TPA_Descricao,  
    TPA_Observacao = @TPA_Obervacao,  
    TPA_Ativo    = @TPA_Ativo  
  
   WHERE TPA_Tid = @TPA_Tid  
  
   IF (@@ROWCOUNT) = 0  
   BEGIN  
    SELECT 'Nenhum registro alterado' as Retorno  
   END  
   ELSE  
   BEGIN  
    SELECT CONCAT('Grupo "', CAST(@TPA_Tid AS VARCHAR(100)), ' - ', @TPA_Descricao, '" alterado com sucesso') as Retorno  
   END  
  
  COMMIT TRANSACTION  
 END TRY  
 BEGIN CATCH  
  
  ROLLBACK TRANSACTION  
    
  SET @ERRO = ERROR_MESSAGE()  
  
  EXEC LOG_ERRO_INSERIR @ERRO, 'TIPO_ATIVIDADE_ALTERAR'  
  
  SELECT ERROR_MESSAGE() AS RETORNO  
  
 END CATCH  
  
END