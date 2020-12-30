CREATE PROCEDURE USUARIO_LOGAR  
  
 @USU_Login VARCHAR(20),  
 @USU_Senha NVARCHAR(100)  
  
AS  
BEGIN  
 IF(NOT EXISTS(SELECT USU.USU_Login FROM USUARIO USU WHERE USU_Login = @USU_Login))  
 BEGIN  
  SELECT 'Usu�rio inexistente.' as Retorno  
 END  
 ELSE IF(EXISTS(SELECT USU.USU_Login FROM USUARIO USU WHERE USU_Login = @USU_Login AND USU_Ativo = 1))  
 BEGIN  
  IF(PWDCOMPARE(@USU_Senha, (SELECT USU.USU_Senha FROM USUARIO USU WHERE USU_Login = @USU_Login),0)) = 1  
  BEGIN  
   SELECT 1 AS Retorno  
  END  
  ELSE  
  BEGIN  
   SELECT 'Senha incorreta' as Retorno  
  END  
 END  
 ELSE  
 BEGIN  
   SELECT 'N�o � poss�vel fazer login com usu�rio inativo.' as Retorno  
 END  
END