USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[RosterGetStudents]    Script Date: 7/28/2014 11:19:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RosterGetStudents] (
	@ClassId int
) AS

SELECT r.RosterId, u.FirstName, u.LastName, u.UserName 
FROM Roster r 
	INNER JOIN AspNetUsers u ON r.UserId = u.Id
WHERE r.IsDeleted = 0 AND r.ClassId = @ClassId


GO

