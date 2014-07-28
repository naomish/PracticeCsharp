USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[RosterSearchByLastName]    Script Date: 7/28/2014 11:26:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RosterSearchByLastName] (
	@ClassId int,
	@LastName nvarchar(25)
) AS
SELECT u.FirstName, u.LastName, u.GradeLevel, u.Id AS UserId
FROM AspNetUsers u 
	INNER JOIN AspNetUserRoles ur on u.Id = ur.UserId
	INNER JOIN AspNetRoles ro ON ur.RoleId = ro.Id
WHERE ro.Name='Student' AND u.Id NOT IN (SELECT UserId FROM Roster WHERE ClassId = @ClassId and isDeleted =0) AND u.LastName LIKE @LastName + '%'


GO

