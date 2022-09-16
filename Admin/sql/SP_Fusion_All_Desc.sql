USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Fusion_All]    Script Date: 06/09/2012 11:15:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Fusion_All_Desc]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Fusion_All_Desc]
GO

USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Fusion_All]    Script Date: 06/09/2012 11:15:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Ken>
-- ALTER  date: <2009-10-22>
-- Description:	<炼化表:显示全部炼化>
-- =============================================
CREATE Procedure [dbo].[SP_Fusion_All_Desc]
as
SELECT *
  FROM [Db_Tank].[dbo].[Item_Fusion] order by [FusionID] desc

GO


