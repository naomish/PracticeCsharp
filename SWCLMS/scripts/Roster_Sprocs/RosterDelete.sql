USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[RosterDelete]    Script Date: 7/28/2014 11:20:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RosterDelete] (
	@RosterId int
) AS

UPDATE Roster
	SET IsDeleted = 1
WHERE RosterId = @RosterId
GO

