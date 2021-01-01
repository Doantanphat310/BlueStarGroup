DROP PROC IF EXISTS SP_GetUsers
GO
CREATE PROC SP_GetUsers
	@CompanyID	VARCHAR(50)
AS
	SELECT
		Usr.*
	FROM UserList Usr
		INNER JOIN UserRoleCompany Rol
			ON Usr.UserID = Rol.UserID
	WHERE Rol.CompanyID = @CompanyID
	ORDER BY
		Usr.UserID