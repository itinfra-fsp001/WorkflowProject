/****** Script for SelectTopNRows command from SSMS  ******/

--and (UpdateBy='tcuot01' or UpdateBy='cmuot01') 
--and (DivCode in ('pjv','inv')) and (UpdateBy='tcuot01' or UpdateBy='cmuot01') 
--SELECT * FROM [TMSDAT].[dbo].[OTEntry] where OTDate>=20180501 and (DivCode in ('pjv','inv')) order by RecID asc
--SELECT * FROM [TMSDAT].[dbo].[OTEntry] where Status='E' and HRStatus='E' and (DivCode in ('pjv','inv')) 
--and RecID not in (SELECT RecID FROM [TMSDAT].[dbo].[OTEntry] where OTDate>=20180501 and (DivCode in ('pjv','inv')))


SELECT * FROM [TMSDAT].[dbo].[OTEntry] where OTDate>=20180501 and (DivCode in ('pjv','inv'))
SELECT * FROM [TMSDAT].[dbo].[OTApproval] where OTDate>=20180501 

DELETE FROM [TMSDAT].[dbo].[OTEntry] where OTDate>=20180501 and (DivCode in ('pjv','inv'))
DELETE FROM [TMSDAT].[dbo].[OTApproval] where OTDate>=20180501 

SELECT * FROM [TMSDAT].[dbo].[OTEntry] where OTDate>=20180501 and (DivCode in ('pjv','inv'))
SELECT * FROM [TMSDAT].[dbo].[OTApproval] where OTDate>=20180501 




  
alter table [TMSDAT].[dbo].[OTEntry] alter column WBSENo nvarchar(100)
go

alter table [TMSDAT].[dbo].[OTFinal] alter column WBSENo nvarchar(100)
go


-- ALTER PROCEDURE SP_GetContract, SP_UpdateOTEntry, SP_InsertOTEntry