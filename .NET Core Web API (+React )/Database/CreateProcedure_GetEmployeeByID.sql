USE [TravelDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetEmployeeById] 
	@id INT
AS
BEGIN
	SET NOCOUNT ON;

    SELECT
		Employee.ID,
		Employee.Name,
		Employee.LastName
	FROM
		Employee
	WHERE
		Employee.ID = @id

END