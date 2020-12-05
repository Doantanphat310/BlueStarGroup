using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAuto
{
    public static class SPFormat
    {
        public const string INSERT = @"DROP PROCEDURE IF EXISTS {0}Insert;
GO
CREATE PROCEDURE {0}Insert (
{1}
    ,@UserId varchar(20)
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
        ,@UserId
        ,@UserId)
";

        public const string UPDATE = @"DROP PROCEDURE IF EXISTS {0}Update;
GO
CREATE PROCEDURE {0}Update (
{1}
    ,@UserID varchar(20)
)
AS
	UPDATE {0}
	SET
{2}
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UserId
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
    ,@UserID varchar(20)
)
AS
	UPDATE {0}
	SET
		UpdateDate = GETDATE()
		,UpdateUser = @UserId
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
}
