USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[AssignmentInsert]    Script Date: 7/28/2014 11:03:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AssignmentInsert] (
	@AssignmentId int output,
	@ClassId int,
	@Name varchar(50),
	@PossiblePoints int,
	@DueDate date,
	@Description varchar(255)
) AS

INSERT INTO Assignment(ClassId, Name, PossiblePoints, DueDate, [Description])
VALUES (@ClassId, @Name, @PossiblePoints,@DueDate,@Description);

SET @AssignmentId = SCOPE_IDENTITY();


GO

