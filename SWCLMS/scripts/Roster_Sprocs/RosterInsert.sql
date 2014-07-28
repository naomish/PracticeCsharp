USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[RosterInsert]    Script Date: 7/28/2014 11:28:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RosterInsert] (
	@UserId nvarchar(128),
	@ClassId int,
	@RosterId int output
) AS

INSERT INTO Roster(ClassId, UserId, IsDeleted)
VALUES (@ClassId, @UserId, 0);

SET @RosterId = SCOPE_IDENTITY();
GO

