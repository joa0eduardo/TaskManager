CREATE PROCEDURE USUARIO_TEMPO_DIA_ATUALIZAR  
  
 @UTD_USU_TidUsuario INTEGER,  
 @TempoAtual TIME  
  
AS  
BEGIN  
  
 DECLARE @ERRO VARCHAR(MAX)  
 DECLARE @UTD_TempoTotalDia TIME  
 DECLARE @MINUTOS INT  
  
  
 BEGIN TRY  
  
  BEGIN TRANSACTION  
  
   IF(NOT EXISTS(SELECT UTD.UTD_Tid FROM USUARIO_TEMPO_DIA UTD WHERE UTD_USU_TidUsuario = @UTD_USU_TidUsuario AND CONVERT(DATE, UTD.UTD_DataAtividade) = CONVERT(DATE, GETDATE())))  
   BEGIN  
  
    INSERT INTO USUARIO_TEMPO_DIA  
    (  
     UTD_USU_TidUsuario,  
     UTD_DataAtividade,  
     UTD_TempoTotalDia  
    )  
    VALUES  
    (  
     @UTD_USU_TidUsuario,  
     CONVERT(DATE, GETDATE()),  
     '00:00'  
    )  
  
    IF(@@IDENTITY) > 0  
    BEGIN  
  
     SELECT @UTD_TempoTotalDia = UTD.UTD_TempoTotalDia   
     FROM USUARIO_TEMPO_DIA UTD   
     WHERE UTD.UTD_USU_TidUsuario = @UTD_USU_TidUsuario  
     AND CONVERT(DATE, UTD.UTD_DataAtividade) = CONVERT(DATE, GETDATE())  
       
     SET @MINUTOS = DATEDIFF(MINUTE,@TempoAtual,@UTD_TempoTotalDia)  
     IF(@MINUTOS) <=0  
     BEGIN  
      UPDATE USUARIO_TEMPO_DIA  
      SET UTD_TempoTotalDia = DATEADD(MINUTE,@MINUTOS*-1,@UTD_TempoTotalDia)  
      WHERE UTD_USU_TidUsuario = @UTD_USU_TidUsuario  
      AND CONVERT(DATE, UTD_DataAtividade) = CONVERT(DATE, GETDATE())  
     END  
     ELSE  
     BEGIN  
      UPDATE USUARIO_TEMPO_DIA  
      SET UTD_TempoTotalDia = DATEADD(MINUTE,@MINUTOS,@UTD_TempoTotalDia)  
      WHERE UTD_USU_TidUsuario = @UTD_USU_TidUsuario  
      AND CONVERT(DATE, UTD_DataAtividade) = CONVERT(DATE, GETDATE())  
     END       
    END  
  
   END  
   ELSE  
   BEGIN  
  
     SELECT @UTD_TempoTotalDia = UTD.UTD_TempoTotalDia   
     FROM USUARIO_TEMPO_DIA UTD   
     WHERE UTD.UTD_USU_TidUsuario = @UTD_USU_TidUsuario  
     AND CONVERT(DATE, UTD.UTD_DataAtividade) = CONVERT(DATE, GETDATE())  
       
     SET @MINUTOS = DATEDIFF(MINUTE,@TempoAtual,@UTD_TempoTotalDia)  
     IF(@MINUTOS) <=0  
     BEGIN  
      UPDATE USUARIO_TEMPO_DIA  
      SET UTD_TempoTotalDia = DATEADD(MINUTE,@MINUTOS*-1,@UTD_TempoTotalDia)  
      WHERE UTD_USU_TidUsuario = @UTD_USU_TidUsuario  
      AND CONVERT(DATE, UTD_DataAtividade) = CONVERT(DATE, GETDATE())  
     END  
     ELSE  
     BEGIN  
      UPDATE USUARIO_TEMPO_DIA  
      SET UTD_TempoTotalDia = DATEADD(MINUTE,@MINUTOS,@UTD_TempoTotalDia)  
      WHERE UTD_USU_TidUsuario = @UTD_USU_TidUsuario  
      AND CONVERT(DATE, UTD_DataAtividade) = CONVERT(DATE, GETDATE())  
     END  
   END  
  
  COMMIT TRANSACTION  
  
 END TRY  
  
 BEGIN CATCH  
  
  ROLLBACK TRANSACTION  
  
  SET @ERRO = ERROR_MESSAGE()  
  
  EXEC LOG_ERRO_INSERIR @ERRO, 'USUARIO_TEMPO_DIA_ATUALIZAR'  
  
 END CATCH  
  
END