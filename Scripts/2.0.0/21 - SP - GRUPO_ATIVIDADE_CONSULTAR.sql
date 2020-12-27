CREATE PROCEDURE GRUPO_ATIVIDADE_CONSULTAR  
  
 @GPA_Tid INT = NULL,  
 @GPA_Descricao VARCHAR(20) = NULL,  
 @GPA_Ativo BIT  
  
AS  
BEGIN  
  
 IF (@GPA_Tid IS NOT NULL)  
 BEGIN  
    
  SELECT   
   GPA_Tid,  
   GPA_Descricao,  
   GPA_Observacao,  
   GPA_Ativo  
  
  FROM GRUPO_ATIVIDADE GPA  
  
  WHERE GPA_Tid = @GPA_Tid  
  AND   GPA_Ativo = @GPA_Ativo  
 END  
 ELSE IF (@GPA_Descricao IS NOT NULL)  
 BEGIN  
  
  SELECT   
   GPA_Tid,  
   GPA_Descricao,  
   GPA_Observacao,  
   GPA_Ativo  
  
  FROM GRUPO_ATIVIDADE GPA  
  
  WHERE GPA_Descricao LIKE CONCAT('%',@GPA_Descricao,'%')  
  AND   GPA_Ativo = @GPA_Ativo  
  
 END  
  
END  