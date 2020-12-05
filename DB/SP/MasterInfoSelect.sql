ALTER PROCEDURE MasterInfoSelect 
AS
	SELECT 
		MasterCd [Key],
		DetailCd Id,
		[Value],
		Value2,
		Value3,
		Value4,
		Value5
	FROM MasterInfo
	ORDER BY 
		MasterCd,
		[Value]