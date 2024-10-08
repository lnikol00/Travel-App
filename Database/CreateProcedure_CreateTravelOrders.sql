USE [TravelDB]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateTravelOrders] 

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

	INSERT INTO TravelOrders([EmployeeID], [CarsID], [Date], [Mileage], [Route]) VALUES (@EmployeeID, @CarsID, @Date, @Mileage, @Route);

	COMMIT TRANSACTION;
END TRY
BEGIN CATCH
	SELECT ERROR_MESSAGE() AS e;
	ROLLBACK TRANSACTION
END CATCH
END