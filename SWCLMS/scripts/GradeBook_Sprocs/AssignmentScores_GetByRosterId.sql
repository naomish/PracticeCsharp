USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[AssignmentScores_GetByRosterId]    Script Date: 7/28/2014 11:13:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[AssignmentScores_GetByRosterId] (
@RosterId int
) as
select r.rosterId, r.classId, a.AssignmentId, u.FirstName,  a.name, a.PossiblePoints, g.Points, g.score, c.Name
from roster r
inner join AspNetUsers u on  u.id = r.userId
inner join assignment a on a.ClassId = r.ClassId
inner join class c on c.ClassId = a.ClassId
left join grade g on g.AssignmentId = a.AssignmentId and g.RosterId = r.RosterId
where r.IsDeleted=0 and @RosterId=r.RosterId
order by DueDate, a.PossiblePoints, a.Name
GO

