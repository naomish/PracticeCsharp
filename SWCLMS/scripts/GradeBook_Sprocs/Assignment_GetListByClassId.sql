USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[Assignment_GetListByClassId]    Script Date: 7/28/2014 11:11:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[Assignment_GetListByClassId] (
@ClassId int
) as
select AssignmentId, ClassId, Name, PossiblePoints, DueDate, [Description]
from Assignment a
where classId = @ClassId
order by DueDate, a.PossiblePoints, a.Name


GO

