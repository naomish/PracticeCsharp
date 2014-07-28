USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[RosterSearchByLastNameAndGradeLevel]    Script Date: 7/28/2014 11:25:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[RosterSearchByLastNameAndGradeLevel] (
	@ClassId int,
	@LastName nvarchar(25),
	@GradeLevel tinyint
) AS
SELECT u.FirstName, u.LastName, u.GradeLevel, u.Id AS UserId
FROM AspNetUsers u 
	INNER JOIN AspNetUserRoles ur on u.Id = ur.UserId
	INNER JOIN AspNetRoles ro ON ur.RoleId = ro.Id
WHERE ro.Name='Student' 
	AND u.Id NOT IN (SELECT UserId FROM Roster WHERE ClassId = @ClassId and isDeleted =0) 
	AND u.LastName LIKE @LastName + '%' 
	AND u.GradeLevel = @GradeLevel


GO

