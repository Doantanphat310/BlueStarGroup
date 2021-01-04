DROP PROCEDURE IF EXISTS SP_GetCompanyRoleByUser;
GO
CREATE PROCEDURE SP_GetCompanyRoleByUser
	@UserID VARCHAR(50) = NULL
AS
	SELECT
		USR.UserID 
		,COM.CompanyID
		,COM.CompanyName
		,ROL.RoleID AS UserRoleID	
		,INFO.Value UserRoleName
		,INFO.Value2 UserRoleValue
	FROM 
		UserList USR
		INNER JOIN UserRoleCompany ROL
			ON USR.UserID = @UserID
				AND USR.UserID = ROL.UserID
		INNER JOIN Company COM
			ON COM.CompanyID = ROL.CompanyID
		INNER JOIN MasterInfo INFO
			ON ROL.RoleID = INFO.DetailCd
				AND INFO.MasterCd = 'USERROLE'
	WHERE 1 = 1 		
		AND (@UserID IS NULL 
			OR (@UserID IS NOT NULL AND USR.UserID = @UserID))
	ORDER BY 
		CompanyName