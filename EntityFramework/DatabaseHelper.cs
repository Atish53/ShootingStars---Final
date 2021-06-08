using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EntityFramework
{
    public class DatabaseHelper
    {
        public DatabaseHelper()
        {
        }

        public static bool Insert<T>(ref T data, string db_path)
        {
            using (var conn = new SQLite.SQLiteConnection(db_path))
            {
                conn.CreateTable<T>();

                if (conn.Insert(data) != 0)
                    return true;
            }

                return false;
        }

        public static List<Student> Read(string db_path)
        {
            List<Student> students = new List<Student>();
            using (var conn = new SQLite.SQLiteConnection(db_path))
            {
                students = conn.Table<Student>().ToList();
            }
            return students;
        }
    }
}
