CREATE PROCEDURE PERFIL_USUARIO_CONSULTAR  
  
 @PFU_Tid INT = NULL,  
 @PFU_Nome VARCHAR(50) = NULL,  
 @PFU_Ativo BIT  
  
AS  
BEGIN  
  
 IF(@PFU_Tid IS NOT NULL)  
 BEGIN  
  SELECT  
   PFU.PFU_Tid,  
   PFU.PFU_Nome,  
   PFU.PFU_Ativo  
  
  FROM PERFIL_USUARIO PFU  
  
  WHERE PFU.PFU_Tid = @PFU_Tid  
  AND PFU.PFU_Ativo = @PFU_Ativo  
 END   
 ELSE IF(@PFU_Nome IS NOT NULL)  
 BEGIN  
  SELECT  
   PFU.PFU_Tid,  
   PFU.PFU_Nome,  
   PFU.PFU_Ativo  
  
  FROM PERFIL_USUARIO PFU  
  
  WHERE PFU.PFU_Nome LIKE CONCAT('%',@PFU_Nome,'%')  
  AND PFU.PFU_Ativo = @PFU_Ativo  
 END  
 ELSE IF (@PFU_Nome IS NULL AND @PFU_Nome IS NULL)  
 BEGIN  
  SELECT  
   PFU.PFU_Tid,  
   PFU.PFU_Nome,  
   PFU.PFU_Ativo  
  
  FROM PERFIL_USUARIO PFU  
  
  WHERE PFU.PFU_Ativo = @PFU_Ativo  
 END  
  
END