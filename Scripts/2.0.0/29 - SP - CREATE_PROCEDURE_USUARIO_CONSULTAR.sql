CREATE PROCEDURE USUARIO_CONSULTAR  
  
 @USU_Tid INT = NULL,  
 @USU_Nome VARCHAR(50) = NULL,  
 @USU_Ativo BIT  
  
AS  
BEGIN  
  
 IF(@USU_Tid IS NOT NULL)  
 BEGIN  
  SELECT  
   USU_Tid,  
   USU_Nome,  
   USU_Login,  
   USU_Ativo,  
   USU_PFU_TidPerfilUsuario  
  
  FROM USUARIO USU  
  
  WHERE USU.USU_Tid = @USU_Tid  
  AND USU.USU_Ativo = @USU_Ativo  
 END   
 ELSE IF(@USU_Nome IS NOT NULL)  
 BEGIN  
  SELECT  
   USU_Tid,  
   USU_Nome,  
   USU_Login,  
   USU_Ativo,  
   USU_PFU_TidPerfilUsuario  
  
  FROM USUARIO USU  
  
  WHERE USU.USU_Nome LIKE CONCAT('%',@USU_Nome,'%')  
  AND USU.USU_Ativo = @USU_Ativo  
 END  
 ELSE IF (@USU_Tid IS NULL AND @USU_Nome IS NULL)  
 BEGIN  
  SELECT  
   USU_Tid,  
   USU_Nome,  
   USU_Login,  
   USU_Ativo,  
   USU_PFU_TidPerfilUsuario  
  
  FROM USUARIO USU  
  
  WHERE USU.USU_Ativo = @USU_Ativo  
 END  
  
END