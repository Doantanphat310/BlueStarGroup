﻿namespace SQLAuto
{
    public static class SPFormat
    {
        public const string INSERT = @"DROP PROCEDURE IF EXISTS {0}Insert;
GO
CREATE PROCEDURE {0}Insert (
{1}
    ,@UpdateUser varchar(20)
)
AS
	INSERT INTO {0}(
{2}
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
{3}
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
";

        public const string UPDATE = @"DROP PROCEDURE IF EXISTS {0}Update;
GO
CREATE PROCEDURE {0}Update (
{1}
    ,@UpdateUser varchar(20)
)
AS
	UPDATE {0}
	SET
{2}
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UpdateUser
	WHERE 
{3}
";

        public const string DELETE = @"DROP PROCEDURE IF EXISTS {0}Delete;
GO
CREATE PROCEDURE {0}Delete (
{1}
)
AS
	DELETE {0}
	WHERE 
{2}
";

        public const string DELETE_LOGIC = @"DROP PROCEDURE IF EXISTS {0}Delete;
GO
CREATE PROCEDURE {0}Delete (
{1}
    ,@UpdateUser varchar(20)
)
AS
	UPDATE {0}
	SET
		UpdateDate = GETDATE()
		,UpdateUser = @UpdateUser
		,IsDelete = 1
	WHERE 
{2}
";

        public const string ParamFormat = @"@{0} {1}";
    }

    public static class ModelFormat
    {
        public const string Class_Format = @"using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace {0}
{{
    /// <summary>
    /// {1} infomation
    /// </summary>        
    [Table(""{1}"")]
    public class {1} : BaseModel
    {{
{2}
    }}
}}
";

        public const string Column_Format = @"
        /// <summary>
        /// {0}
        /// </summary>{3}
        public {1}{2} {0} {{ get; set; }}";
    }

    public static class DAOFormat
    {
        /// <summary>
        /// 
        /// </summary>
        public const string File_Format = @"using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Context;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace {0}
{{
    public class {1}DAO : BaseDAO
    {{
        public {1}DAO(BSContext context) : base(context)
        {{
        }}
        
{2}

{3}

{4}
    }}
}}
";

        /// <summary>
        /// 
        /// </summary>
        public const string Class_Format = @"
public bool {2}{0}({0} data)
{{
        SqlParameter[] sqlParameters = new SqlParameter[]
        {{
{1}
        }};

        this.Context.ExecuteDataFromProcedure(""{0}{2}"", sqlParameters);

        return true;
}}";

        /// <summary>
        /// 
        /// </summary>
        public const string Param_Format = @"new SqlParameter(""@{0}"", data.{0}),";

        public const string User_Format = @"new SqlParameter(""@UpdateUser"", CommonInfo.UserInfo.UserID)";
    }
}
