CREATE PROCEDURE ClassSummaryGetList (
	@UserId nvarchar(128)
) AS

SELECT c.ClassId, c.Name, c.IsArchived, 
	(SELECT count(*) AS NumberOfStudents FROM Roster r WHERE r.ClassId = c.ClassId AND r.IsDeleted = 0) AS NumberOfStudents
FROM Class c
WHERE c.UserId = @UserId