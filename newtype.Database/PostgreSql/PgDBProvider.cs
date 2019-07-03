using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace newtype.Database
{
    /// <summary>
    /// 構造体:DBアクセス関連
    /// </summary>
    public class PgDBProvider
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PgDBProvider()
        {
            adapter = new NpgsqlDataAdapter();
            dataSet = new DataSet();
        }

        /// <summary>
        /// SQLデータアダプター
        /// </summary>
        public NpgsqlDataAdapter adapter;

        /// <summary>
        /// SQLデータセット
        /// </summary>
        public DataSet dataSet;

        /// <summary>
        /// SQLコネクション
        /// </summary>
        public NpgsqlConnection sqlConnection { get; set; }

        /// <summary>
        /// 接続フラグ
        /// </summary>
        public bool conFlg { get; set; }

        /// <summary>
        /// トランザクションフラグ
        /// </summary>
        public bool transFlag { get; set; } 

        /// <summary>
        /// リトライフラグ
        /// </summary>
        public bool retryFlag { get; set; } 

        /// <summary>
        /// 処理レコード件数
        /// </summary>
        public long recCount { get; set; }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Clear()
        {
            transFlag = false;
            retryFlag = false;
            recCount = 0;
            sqlConnection = null;
            conFlg = false;
            adapter.Dispose();
            dataSet.Dispose();
        }


        #region 追加メソッド

        // Version 1.11.29.1720 から追加

        /// <summary>
        /// 接続中のデータソースを参照する
        /// </summary>
        public string DataSource { get { return sqlConnection.DataSource; } }

        /// <summary>
        /// 接続中のデータベースを参照する
        /// </summary>
        public string DataBase { get { return sqlConnection.Database; } }

        /// <summary>
        /// 接続中のデータベースを参照する
        /// </summary>
        public string ConnectionString { get { return sqlConnection.ConnectionString; } }

        /// <summary>
        /// データテーブルコレクションを参照する
        /// </summary>
        public DataTableCollection Tables { get { return dataSet.Tables; } }

        #endregion
    }
}
