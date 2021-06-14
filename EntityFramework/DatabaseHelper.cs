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

        //Insert Object
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

        //Read Students
        public static List<Student> Read(string db_path)
        {
            List<Student> students = new List<Student>();
            using (var conn = new SQLite.SQLiteConnection(db_path))
            {
                students = conn.Table<Student>().ToList();
            }
            return students;
        }
        //Read Queries
        public static List<Query> ReadQueries(string db_path, int id)
        {
            List<Query> queries = new List<Query>();
            using (var conn = new SQLite.SQLiteConnection(db_path))
            {
                queries = conn.Table<Query>().Where(s => s.StudentID == id).ToList();
            }
            return queries;
        }

        //Read Queries Admin
        public static List<Query> ReadQueriesAdmin(string db_path)
        {
            List<Query> queries = new List<Query>();
            using (var conn = new SQLite.SQLiteConnection(db_path))
            {
                queries = conn.Table<Query>().ToList();
            }
            return queries;
        }

        //Read Subjects
        public static List<Subject> ReadSubjects(string db_path)
        {
            List<Subject> subjects = new List<Subject>();
            using (var conn = new SQLite.SQLiteConnection(db_path))
            {
                subjects = conn.Table<Subject>().ToList();
            }
            return subjects;
        }
        //Read Materials
        public static List<SubjectMaterial> ReadMaterials(string db_path)
        {
            List<SubjectMaterial> subjectmaterials = new List<SubjectMaterial>();
            using (var conn = new SQLite.SQLiteConnection(db_path))
            {
                subjectmaterials = conn.Table<SubjectMaterial>().ToList();
            }
            return subjectmaterials;
        }

        //Read a single student
        public static Student ReadSingle(string db_path, string email)
        {
            Student student = new Student();
            using (var conn = new SQLite.SQLiteConnection(db_path))
            {
                student = conn.Find<Student>(s => s.StudentEmail == email);
            }
            return student;
        }

        //Read a single Material
        public static SubjectMaterial ReadSingleMaterials(string db_path, string id)
        {
            int ids = int.Parse(id);
            SubjectMaterial subjectMaterial = new SubjectMaterial();
            using (var conn = new SQLite.SQLiteConnection(db_path))
            {
                subjectMaterial = conn.Find<SubjectMaterial>(i => i.SubjectMaterialID == ids);
            }
            return subjectMaterial;
        }


        public static string CheckLogin(string db_path, string email, string password)
        {
            List<Student> students = new List<Student>();
            using (var conn = new SQLite.SQLiteConnection(db_path))
            {
                students = conn.Table<Student>().ToList();
            }
            foreach (var student in students)
            {
                if (student.StudentEmail == email && student.StudentPassword == password)
                {
                    return "Success";
                }
                else if (student.StudentEmail == email && student.StudentPassword != password)
                {
                    return "Invalid";
                }
            }
            return "NotFound";
            
        }

        /*
        //Generate a list of queries by student
        public static List<Query> ReadQueries(string db_path, string email)
        {
            Student student = new Student();
            using (var conn = new SQLite.SQLiteConnection(db_path))
            {
                student = conn.Find<Student>(s => s.StudentEmail == email);
            }
            List<Query> studentQueries = new List<Query>();
            using (var conn = new SQLite.SQLiteConnection(db_path))
            {
                studentQueries = conn.Table<Query>().Where(s => s.StudentID == student.StudentID).ToList();
            }
            return studentQueries;
        }
        */


    }
}
