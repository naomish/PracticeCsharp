CREATE PROCEDURE ClassInsert (
	@ClassId int output,
	@UserId varchar(128),
	@Name varchar(50),
	@GradeLevel tinyint,
	@Subject varchar(50),
	@StartDate date,
	@EndDate date,
	@Description varchar(255)
) AS

INSERT INTO Class (UserId, Name, GradeLevel, IsArchived, [Subject], StartDate, EndDate, [Description])
VALUES (@UserId, @Name, @GradeLevel, 0, @Subject, @StartDate, @EndDate, @Description);

SET @ClassId = SCOPE_IDENTITY();

GO