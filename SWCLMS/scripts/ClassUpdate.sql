CREATE PROCEDURE ClassUpdate (
	@ClassId int,
	@UserId varchar(128),
	@Name varchar(50),
	@GradeLevel tinyint,
	@IsArchived bit,
	@Subject varchar(50),
	@StartDate date,
	@EndDate date,
	@Description varchar(255)
) AS

UPDATE Class SET
	UserId = @UserId, 
	Name = @Name, 
	GradeLevel = @GradeLevel, 
	IsArchived = @IsArchived, 
	[Subject] = @Subject, 
	StartDate = @StartDate, 
	EndDate = @EndDate, 
	[Description] = @Description
WHERE @ClassId = @ClassId

GO