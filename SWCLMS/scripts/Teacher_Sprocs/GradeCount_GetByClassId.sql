USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[GradeCount_GetByClassId]    Script Date: 7/28/2014 11:31:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GradeCount_GetByClassId]( --removed rosterID from select
@Classid int)as
Select  g.rosterId, (sum(cast(g.points as decimal))/sum(a.PossiblePoints)) as CurrentGrade
from assignment a
inner join grade g on g.AssignmentId= a.AssignmentId
where a.classId = @classId
group by g.rosterId  -- should I do something more complex where I am getting number of each grade in Sql?
GO

