/******************************************************************************
 * 作者:      ee4ga9d@gmail.com
 * 日期:      2024-07-18
 * 描述:      可新建数据库并初始化
 * 版本:      1.0
 * 版权:      x.com/0EE4GA9d © 2024
 ******************************************************************************/
using System;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Management;
using System.Reflection;
using System.Windows.Forms;

namespace EbbinghausMemoryApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            string dbFilePath = ConfigurationManager.AppSettings["DatabaseFileName"];
            //"study.db";

            if (!File.Exists(dbFilePath))
            {
                LoggingService.Info("Database file does not exist. Creating a new database...");

                System.Data.SQLite.SQLiteConnection.CreateFile(dbFilePath);
                InitializeDatabase(dbFilePath);

                //using (var db = new AppDbContext())
                //{
                //    db.Database.CreateIfNotExists();

                //}
            }
            //using (var db = new AppDbContext())
            //{
            //    // 检查是否存在用户
            //    if (!db.Users.Any())
            //    {
            //        db.Users.Add(new User { UserNo = GetUniqueUserId() });
            //        db.SaveChanges();
            //    }
            //}
            Application.Run(new FormMain());
        }

        private static void InitializeDatabase(string dbFilePath)
        {
            string connectionString = $"Data Source={dbFilePath};Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = GetEmbeddedResource("CreateTable.sql");
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }

                // 初始数据
                string seedSql = @"
 INSERT INTO CATEGORIES (ID,NAME) VALUES (1,'英语');
 INSERT INTO CATEGORIES (ID,NAME) VALUES (2,'未命名');

 INSERT INTO BOOKITEMS (ID,CONTENT,CATEGORYID) VALUES (1,'新概念1',1);
 INSERT INTO BOOKITEMS (ID,CONTENT,CATEGORYID) VALUES (2,'新概念2',1);
            ";

                using (var seedCommand = new SQLiteCommand(seedSql, connection))
                {
                    seedCommand.ExecuteNonQuery();
                }
            }
        }
        static string GetEmbeddedResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string assemblyName = assembly.GetName().Name;
            string fullResourceName = $"{assemblyName}.{resourceName}";

            using (Stream stream = assembly.GetManifestResourceStream(fullResourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        static string GetUniqueUserId()
        {
            string uniqueId = "";
            var mc = new ManagementClass("Win32_ComputerSystemProduct");
            var moc = mc.GetInstances();
            foreach (var mo in moc)
            {
                uniqueId = mo.Properties["UUID"].Value.ToString();
                break;
            }
            return uniqueId;
        }
    }
}
