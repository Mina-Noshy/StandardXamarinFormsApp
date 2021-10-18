using MyApplication.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyApplication.SQLite
{
    public class SQLiteHelper
    {
        public SQLiteConnection Connection { get; set; }

        private static string databaseName = "MyApplicationDb.db3";

        public static string DatabasePath
        {
            get
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(folderPath, databaseName);
            }
        }

        public SQLiteHelper()
        {
            Connection = new SQLiteConnection(DatabasePath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);

            Connection.CreateTable<User>(CreateFlags.None);

            InitialDb();

        }

        private void InitialDb()
        {
            if (Connection.Table<User>().FirstOrDefault() == null)
            {
                Connection.Insert(new User
                {
                    UserName = "Mina",
                    Password = "Tena"
                });
            }
        }
    }
}
