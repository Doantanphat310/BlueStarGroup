CREATE PROCEDURE [dbo].[UserRoleCompanySelect] 
AS
	SELECT 
		INFO.S_Cd RoleID
		,INFO.Value RoleName
	FROM MasterInfo INFO
	WHERE 
		INFO.M_Cd = 'USERROLE'
	ORDER BY 
		INFO.Value