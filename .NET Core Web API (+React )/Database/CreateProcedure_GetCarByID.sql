
USE [TravelDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetCarById] 
	@id INT
AS
BEGIN
	SET NOCOUNT ON;

    SELECT
		Cars.ID,
		Cars.Name,
		Cars.Registration
	FROM
		Cars
	WHERE	
		Cars.ID = @id
END
