/****** Script for SelectTopNRows command from SSMS  ******/
-- Get Duty code
SELECT  
      [DutyCode] + '-' + [Description] [Duty Code]
       
  FROM [TMSDAT].[dbo].[DutyCode] order by [WorkType], DutyCode 
  
  
  ----
  
 -- get project No 
  select  
  ProjectNo from vw_projectno
order by  ProjectNo desc

---
 -- get ET  No 
select * from [vw_ETNumber]
order by ETTicketNo

--------
 -- get project List
select * from vw_ProjectDetailList
order by [ProjectName]

-------