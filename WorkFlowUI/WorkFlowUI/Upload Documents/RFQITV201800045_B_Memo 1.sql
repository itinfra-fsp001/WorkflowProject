/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2012 (11.0.6020)
    Source Database Engine Edition : Microsoft SQL Server Standard Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [Memodat]
GO
/****** Object:  StoredProcedure [dbo].[SP_RptBudgetSummary]    Script Date: 21/2/2018 12:03:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
SP_RptBudgetSummary 'PFAV-08-00229'
*/
ALTER PROC [dbo].[SP_RptBudgetSummary]
	@ReferenceNo varchar(15)
as
Begin
		select  
			MD.ReferenceNo,
			MD.GLAccount + ' - ' + GLM.GLDesc + ' (' + MD.ObjectNo + '-' + (select Dept from CostCenters where CostCenter = MD.ObjectNo) + ')' GLAccount, 
			sum(MD.LocalCurrAmt) LocalCurrAmt,
			MD.ActualAmt,
			MD.BudgetAmt,
			MD.ActualAmt + MD.CommitAmt Balance,
			MD.SuppBudgetAmt as SuppleBud	
		from 
			MemoDetails MD
		inner join GLMaster GLM
			on MD.GLAccount=GLM.GLAccount
			where MD.ReferencenO = @ReferenceNo and CostObject = 'CC'
			Group by MD.ReferenceNo,MD.GLAccount, GLM.GLDesc, MD.ObjectNo, MD.ActualAmt, MD.BudgetAmt,MD.SuppBudgetAmt,MD.CommitAmt
	union
		select  
			MD.ReferenceNo,
			MD.GLAccount + ' - ' + GLM.GLDesc GLAccount, 
			sum(MD.LocalCurrAmt) LocalCurrAmt,
			MD.ActualAmt,
			MD.BudgetAmt,
			MD.ActualAmt + MD.CommitAmt Balance,
			MD.SuppBudgetAmt as SuppleBud	
		from 
			MemoDetails MD
		inner join GLMaster GLM
			on MD.GLAccount=GLM.GLAccount
		where MD.ReferencenO = @ReferenceNo and CostObject in ('CS' ,  'ET', 'NW','SO','WBSE')
		Group by MD.ReferenceNo,MD.GLAccount, GLM.GLDesc, MD.ActualAmt, MD.BudgetAmt,MD.SuppBudgetAmt, MD.CommitAmt
End


/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2012 (11.0.6020)
    Source Database Engine Edition : Microsoft SQL Server Standard Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [Memodat]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetERPBudgetValue]    Script Date: 21/2/2018 12:03:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
SP_GetERPBudgetValue '100200','51220100','2017','[FSPERPDB1\sql2008].[ErpByNetR1100]'
*/
ALTER PROCEDURE [dbo].[SP_GetERPBudgetValue]
	@CostCenter VARCHAR(20),
	@GLAccount	VARCHAR(20),
	@Year		VARCHAR(4),
	@Database VARCHAR(200)
AS
--DECLARE @Database VARCHAR(200),
--@Query      NVARCHAR(MAX),
--@GLAccount  VARCHAR(20),
--@Year		VARCHAR(4)

--SET @GLAccount = '51290100'
--SET @Year = '2013'
--SET @Database = '[FSPERPDB1\sql2008].[ErpByNetR1100]'
BEGIN
DECLARE @Query      NVARCHAR(MAX)
DECLARE @ParmDefinition NVARCHAR(500)
--SET @Query = N'SELECT [ActualAmountWOAllocation] AS ActualAmt,
--		[SecondaryEntityBudgetApproved] AS BudgetAmt,
--		[SupplementaryBudget1Approved] + [SupplementaryBudget2Approved] AS SuppBudgetAmt,
--        [COARequisitionAmount] AS CommitAmt FROM ' + @Database + '.dbo.fsp_vw_INTRFSG_CostCentreBudget WHERE [CostCentreCode] = @CostCenter1 AND [ChartOfAccountSetDetailValueCode] ='+@GLAccount+' AND [BudgetYear] ='+ @Year

	
--SET @Query = N'SELECT ActualAmountWOAllocation  AS ActualAmt,
--		SecondaryEntityBudgetApproved AS BudgetAmt,
--		[SupplementaryBudget1Approved] + [SupplementaryBudget2Approved] AS SuppBudgetAmt,
--        COARequisitionAmount AS CommitAmt FROM ' + @Database + '.dbo.fsp_vw_INTRFSG_CostCentreBudget WHERE [CostCentreCode] = @CostCenter1 AND [ChartOfAccountSetDetailValueCode] ='+@GLAccount+' AND [BudgetYear] ='+ @Year
        
SET @Query = N'SELECT [ActualAmount] AS ActualAmt,
		[ApprovedBudgetAmount] AS BudgetAmt,
		[SupplementaryBudget1Approved] + [SupplementaryBudget2Approved] AS SuppBudgetAmt,
        [CommitedAmount] AS CommitAmt FROM ' + @Database + '.dbo.vw_INTRFSG_CostCentreBudget WHERE [CostCentreCode] = @CostCenter1 AND [ChartOfAccountSetDetailValueCode] ='+@GLAccount+' AND [BudgetYear] ='+ @Year
		        
SET @ParmDefinition = N'@CostCenter1 VARCHAR(20)'

EXEC sp_executesql @Query, @ParmDefinition, @CostCenter1 = @CostCenter

END
	




