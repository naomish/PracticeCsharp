USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[AssignmentGrade_UpdateScore]    Script Date: 7/28/2014 11:17:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[AssignmentGrade_UpdateScore](
@RosterId int,
@AssignmentID int,
@Points int,
@Score decimal
)as

Update Grade Set

Points = @Points,
Score = @Score
Where RosterId = @RosterId and
AssignmentId = @AssignmentID

GO

