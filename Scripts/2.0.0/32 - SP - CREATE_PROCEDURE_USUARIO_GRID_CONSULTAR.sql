CREATE PROCEDURE USUARIO_GRID_CONSULTAR  
  
 @USU_Tid AS INT = NULL,  
 @USU_Nome AS VARCHAR(100) = NULL,  
 @USU_Ativo AS BIT  
  
AS  
BEGIN  
  
 IF(@USU_Tid IS NOT NULL OR @USU_Tid <> '')  
 BEGIN  
  
  SELECT  
   USU_Tid,  
   USU_Nome,  
   USU_Login,  
   USU_Ativo,  
   PFU_Nome  
  
  FROM USUARIO USU  
  INNER JOIN PERFIL_USUARIO PFU ON PFU.PFU_Tid = USU_PFU_TidPerfilUsuario  
  WHERE USU_Tid = @USU_Tid  
  AND USU_Ativo = @USU_Ativo  
  
 END  
  
 ELSE IF(@USU_Nome IS NOT NULL OR @USU_Nome <> '')  
 BEGIN  
  
  SELECT  
   USU_Tid,  
   USU_Nome,  
   USU_Login,  
   USU_Ativo,  
   PFU_Nome  
  
  FROM USUARIO USU  
  INNER JOIN PERFIL_USUARIO PFU ON PFU.PFU_Tid = USU_PFU_TidPerfilUsuario  
  WHERE USU_Nome LIKE '%'+@USU_Nome+'%'  
  AND USU_Ativo = @USU_Ativo  
  
 END  
  
 ELSE IF ((@USU_NOME IS NULL OR @USU_NOME = '') AND (@USU_Tid IS NULL OR @USU_Tid = ''))  
 BEGIN  
  
  SELECT  
   USU_Tid,  
   USU_Nome,  
   USU_Login,  
   USU_Ativo,  
   PFU_Nome  
  
  FROM USUARIO USU  
  INNER JOIN PERFIL_USUARIO PFU ON PFU.PFU_Tid = USU_PFU_TidPerfilUsuario  
  WHERE USU_Ativo = @USU_Ativo  
  
 END  
  
END