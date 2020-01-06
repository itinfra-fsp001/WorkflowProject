select docid, min(workflowid)  from tbl_DocumentWorkFlow where  docid in (
SELECT  docid  
 FROM [WorkFlowDB].[dbo].[tbl_Documents] where status ='P' 
 and docid not in (select docid from tbl_DocumentWorkFlow where status in ('P', 'H','D'))
) and status ='N' group by docid  
update tbl_DocumentWorkFlow 
set status ='P' , Submitdate = getdate()
where WorkFlowID in (
select   min(workflowid)  from tbl_DocumentWorkFlow where  docid in (
SELECT  docid  
 FROM [WorkFlowDB].[dbo].[tbl_Documents] where status ='P' 
 and docid not in (select docid from tbl_DocumentWorkFlow where status in ('P', 'H','D'))
) and status ='N' group by docid   )