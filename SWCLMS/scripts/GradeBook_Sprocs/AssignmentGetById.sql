USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[AssignmentGetById]    Script Date: 7/28/2014 11:05:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[AssignmentGetById](
@AssignmentId int
) AS
Select * from Assignment where AssignmentId = @AssignmentId

GO

