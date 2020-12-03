using SQLAuto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SQLAuto
{
    public partial class MainForm : Form
    {
        public Dictionary<string, string> IgnoreColumn = new Dictionary<string, string>
        {
            { "CreateDate", "GETDATE()" },
            { "UpdateDate", "GETDATE()" },
            { "CreateUser", "UserId" },
            { "UpdateUser", "UserId" }
        };
        public BindingList<ColumnInfo> ColumnData { get; set; }

        public MainForm()
        {
            InitializeComponent();

            ColumnData = new BindingList<ColumnInfo>(GetData());
            Main_GridView.DataSource = ColumnData;
        }

        private void Load_Button_Click(object sender, EventArgs e)
        {
            ColumnData = new BindingList<ColumnInfo>(GetData());
            Main_GridView.DataSource = ColumnData;

            MessageBox.Show("Load data success!");
        }

        private List<ColumnInfo> GetData()
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

        private void TableName_TextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Run_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (ColumnData == null || ColumnData.Count <= 0)
                {
                    return;
                }

                GeneralSPs();
                GeneralModels();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xử lý thất bại: " + ex.Message);
                MessageBox.Show("Xử lý thất bại!");
                return;
            }

            MessageBox.Show("Xử lý hoàn thành!");
        }

        private void GeneralSPs()
        {
            var data = ColumnData.GroupBy(o => o.TableName).ToDictionary(o => o.Key, o => o.ToList());
            string path = Path.Combine(Environment.CurrentDirectory, "OUTPUT", "SP");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var item in data)
            {
                this.GeneralInsertSP(path, item.Key, item.Value);
                this.GeneralUpdateSP(path, item.Key, item.Value);


                this.GeneralDeleteSP(path, item.Key, item.Value);
            }
        }

        private void GeneralInsertSP(string path, string tableName, List<ColumnInfo> columnInfos)
        {
            string fileName = $"{tableName}Insert.sql";
            string sqlSP = CommonUtility.GeneralInsertSP(tableName, columnInfos);
            string filePath = Path.Combine(path, fileName);

            File.WriteAllText(filePath, sqlSP);
        }

        private void GeneralUpdateSP(string path, string tableName, List<ColumnInfo> columnInfos)
        {
            string fileName = $"{tableName}Update.sql";
            string sqlSP = CommonUtility.GeneralUpdateSP(tableName, columnInfos);
            string filePath = Path.Combine(path, fileName);

            File.WriteAllText(filePath, sqlSP);
        }

        private void GeneralDeleteSP(string path, string tableName, List<ColumnInfo> columnInfos)
        {
            string fileName = $"{tableName}Delete.sql";

            string sqlSP;

            if (columnInfos.Find(o => o.ColumnName == "IsDelete") != null)
            {
                sqlSP = CommonUtility.GeneralDeleteLogicSP(tableName, columnInfos);
            }
            else
            {
                sqlSP = CommonUtility.GeneralDeleteSP(tableName, columnInfos);
            }

            string filePath = Path.Combine(path, fileName);

            File.WriteAllText(filePath, sqlSP);
        }

        private void GeneralModels()
        {
            var data = ColumnData.GroupBy(o => o.TableName).ToDictionary(o => o.Key, o => o.ToList());
            string path = Path.Combine(Environment.CurrentDirectory, "OUTPUT", "Models");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var item in data)
            {
                this.General1Model(path, item.Key, item.Value);
            }
        }

        private void General1Model(string path, string tableName, List<ColumnInfo> columnInfos)
        {
            string fileName = $"{tableName}.cs";
            string content = CommonUtility.GeneralModel(tableName, columnInfos);
            string filePath = Path.Combine(path, fileName);

            File.WriteAllText(filePath, content);
        }
    }
}
