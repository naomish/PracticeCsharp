USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[AssignmentUpdate]    Script Date: 7/28/2014 11:11:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[AssignmentUpdate] (
	@AssignmentId int,
	@ClassId int,	
	@Name varchar(50),
	@PossiblePoints int,	
	@DueDate date,
	@Description varchar(255)
) AS

UPDATE Assignment SET
	ClassId = @ClassId, 
	Name = @Name, 
	PossiblePoints=@PossiblePoints,
	DueDate = @DueDate, 
	[Description] = @Description
WHERE AssignmentId = @AssignmentId




GO

