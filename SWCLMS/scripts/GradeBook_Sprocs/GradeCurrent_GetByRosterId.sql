USE [SWC_LMS]
GO

/****** Object:  StoredProcedure [dbo].[GradeCurrent_GetByRosterId]    Script Date: 7/28/2014 11:14:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[GradeCurrent_GetByRosterId] (
@RosterId int) as
select r.rosterId, (sum(cast(g.points as decimal))/sum(cast(a.PossiblePoints as decimal))) as CurrentGrade
from roster r
inner join AspNetUsers u on  u.id = r.userId
inner join assignment a on a.ClassId = r.ClassId
inner join class c on c.ClassId = a.ClassId
left join grade g on g.AssignmentId = a.AssignmentId and g.RosterId = r.RosterId
where @RosterId =r.rosterid and r.IsDeleted=0 and g.points is not null
group by r.rosterId


GO

