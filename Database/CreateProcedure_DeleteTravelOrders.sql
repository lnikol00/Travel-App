USE [TravelDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteTravelOrders] 
	@id INT
AS
BEGIN

	DELETE FROM
		TravelOrders
	WHERE
		TravelOrders.ID = @id
END