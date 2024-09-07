USE [TravelDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateTravelOrders] 
	@id INT,
	@EmployeeID INT,
	@CarsID INT,
	@Date VARCHAR(MAX),
	@Mileage INT,
	@Route VARCHAR(MAX)

AS
BEGIN

	SET NOCOUNT ON;

BEGIN TRANSACTION
BEGIN TRY

	UPDATE TravelOrders
	SET 
		TravelOrders.EmployeeID = @EmployeeID,
		TravelOrders.CarsID = @CarsID,
		TravelOrders.Date = @Date,
		TravelOrders.Mileage = @Mileage,
		TravelOrders.Route = @Route
	WHERE
		TravelOrders.ID = @id

	COMMIT TRANSACTION;
END TRY
BEGIN CATCH
	SELECT ERROR_MESSAGE() AS e;
	ROLLBACK TRANSACTION
END CATCH
END