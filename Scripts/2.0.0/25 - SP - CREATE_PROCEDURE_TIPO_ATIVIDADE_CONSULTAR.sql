CREATE PROCEDURE TIPO_ATIVIDADE_CONSULTAR  
  
 @TPA_Tid INT = NULL,  
 @TPA_Descricao VARCHAR(50) = NULL,  
 @TPA_Ativo BIT  
  
AS  
BEGIN  
  
 IF (@TPA_Tid IS NOT NULL)  
 BEGIN  
  
  SELECT  
   TPA.TPA_Tid,  
   TPA.TPA_Descricao,  
   TPA.TPA_Observacao,  
   tpa.TPA_Ativo  
  
  FROM TIPO_ATIVIDADE TPA  
  
  WHERE TPA_Tid = @TPA_Tid  
  AND   TPA_Ativo = @TPA_Ativo  
  
 END  
 ELSE IF (@TPA_Descricao IS NOT NULL)  
 BEGIN  
  
  SELECT  
   TPA.TPA_Tid,  
   TPA.TPA_Descricao,  
   TPA.TPA_Observacao,  
   tpa.TPA_Ativo  
  
  FROM TIPO_ATIVIDADE TPA  
  
  WHERE TPA_Descricao LIKE CONCAT('%',@TPA_Descricao,'%')  
  AND   TPA_Ativo = @TPA_Ativo  
  
 END  
END