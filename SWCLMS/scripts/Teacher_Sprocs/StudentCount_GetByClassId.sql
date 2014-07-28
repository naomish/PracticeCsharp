USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[StudentCount_GetByClassId]    Script Date: 7/28/2014 11:33:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[StudentCount_GetByClassId](
@ClassId int) as
Select count(classid) as StudentCount
from Roster
where classId=@ClassId
GO

