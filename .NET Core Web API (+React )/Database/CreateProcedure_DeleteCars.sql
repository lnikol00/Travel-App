USE [TravelDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteCars] 
	@id INT
AS
BEGIN

	DELETE FROM
		Cars
	WHERE
		Cars.ID = @id
END