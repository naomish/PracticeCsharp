USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[AssignmentGrade_Insert]    Script Date: 7/28/2014 11:18:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[AssignmentGrade_Insert](
@RosterId int,
@AssignmentID int,
@Points int,
@Score decimal
)as

Insert into Grade (RosterId, AssignmentId, Points, Score)
values (@RosterId, @AssignmentID, @Points, @Score)


GO

