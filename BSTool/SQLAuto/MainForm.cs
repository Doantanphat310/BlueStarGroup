using BSCommon.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SQLAuto
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Execute_Button_Click(object sender, System.EventArgs e)
        {

        }

		private List<Voucher> GetData()
		{
			using (MyContext context = new MyContext())
			{
				string sql = @"
SELECT
	COL.TABLE_NAME TableName
	,COL.COLUMN_NAME ColumnName
	,CAST(CASE WHEN COL.IS_NULLABLE = 'YES' THEN 1 ELSE 0 END as bit) IsNullable
	,COL.DATA_TYPE TypeName
	,COL.CHARACTER_MAXIMUM_LENGTH TypeSize
	,CAST(CASE 
		WHEN KEYS.COLUMN_NAME IS NULL THEN 0
		ELSE 1 
	END as  bit)  AS IsKey
	,KEYS.ORDINAL_POSITION KeyOrder
    ,COL.COLUMN_DEFAULT DefaultValue
FROM
	INFORMATION_SCHEMA.COLUMNS COL
	LEFT JOIN 
	(
		SELECT
			TBL.TABLE_NAME,
			KEYS.COLUMN_NAME,
			KEYS.ORDINAL_POSITION
		FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS TBL
			INNER JOIN  INFORMATION_SCHEMA.KEY_COLUMN_USAGE KEYS
		ON TBL.CONSTRAINT_NAME = KEYS.CONSTRAINT_NAME
			AND TBL.CONSTRAINT_TYPE = 'PRIMARY KEY'
	) AS KEYS
		ON COL.TABLE_NAME = KEYS.TABLE_NAME
			AND COL.COLUMN_NAME = KEYS.COLUMN_NAME
WHERE COL.COLUMN_NAME NOT IN ('RowID')
ORDER BY
	TableName
	,IsKey DESC
	,KeyOrder
";
				return context.Database.SqlQuery<ColumnInfo>(sql).ToList();
			}
		}
	}
}
