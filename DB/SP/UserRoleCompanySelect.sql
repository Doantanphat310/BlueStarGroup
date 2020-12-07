DROP PROCEDURE IF EXISTS UserRoleCompanySelect;
GO
CREATE PROCEDURE UserRoleCompanySelect
AS
	SELECT 
		USR.UserID
		,USR.UserName
		,COM.CompanyID
		,COM.CompanyName
		,ROL.RoleID AS UserRoleID
		,INFO.Value UserRoleName
	FROM UserList USR
		INNER JOIN UserRoleCompany ROL
			ON USR.UserID = ROL.UserID
		INNER JOIN Company COM
			ON COM.CompanyID = ROL.CompanyID
		LEFT JOIN MasterInfo INFO
			ON ROL.RoleID = INFO.DetailCd
				AND INFO.MasterCd = 'USERROLE'
	WHERE 
		USR.IsDelete IS NULL
		AND COM.IsDelete IS NULL
	ORDER BY 
		USR.UserID,
		COM.CompanyID,
		ROL.RoleID