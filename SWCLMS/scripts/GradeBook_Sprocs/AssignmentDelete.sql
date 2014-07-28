USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[AssignmentDelete]    Script Date: 7/28/2014 11:10:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AssignmentDelete] (
	@AssignmentId int
) AS

delete from assignment 
WHERE AssignmentId = @AssignmentId

GO

