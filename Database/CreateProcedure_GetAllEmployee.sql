USE [TravelDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllEmployee] 
AS
BEGIN
	SET NOCOUNT ON;

    SELECT
		Employee.ID,
		Employee.Name,
		Employee.LastName
	FROM
		Employee
END