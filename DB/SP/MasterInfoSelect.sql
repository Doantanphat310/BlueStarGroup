ALTER PROCEDURE [dbo].[MasterInfoSelect] 
AS
	SELECT * 
	FROM MasterInfo
	ORDER BY 
		MasterCd,
		DetailCd