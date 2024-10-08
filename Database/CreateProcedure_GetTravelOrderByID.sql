USE [TravelDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetTravelOrderById] 
	@id INT
AS
BEGIN
	SET NOCOUNT ON;

    SELECT
		TravelOrders.ID,
		EMP.Name AS Name,
		EMP.LastName AS LastName,
		CAR.Name AS Brand,
		CAR.Registration AS Registration,
		[Date],
		[Mileage],
		[Route],
		TravelOrders.EmployeeID AS EmployeeId,
        TravelOrders.CarsID AS CarsId
	FROM
		TravelOrders
	INNER JOIN
		Employee AS EMP
	ON
		TravelOrders.EmployeeID = EMP.ID
	INNER JOIN 
		Cars AS CAR
	ON 
		TravelOrders.CarsID = CAR.ID
	WHERE
		TravelOrders.ID = @id

END