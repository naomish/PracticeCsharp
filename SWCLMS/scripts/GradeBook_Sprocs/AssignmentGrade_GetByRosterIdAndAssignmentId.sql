USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[AssignmentGrade_GetByRosterIdAndAssignmentId]    Script Date: 7/28/2014 11:16:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[AssignmentGrade_GetByRosterIdAndAssignmentId] (
@RosterId int,
@AssignmentId int,
@Points int,
@Score decimal --added in score and points to avoid: too many arguments error.
) as
select* from Grade
where @RosterId = RosterId and @AssignmentId = AssignmentId
GO

