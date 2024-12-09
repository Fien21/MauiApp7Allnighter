using SQLite;
using System.Collections.Generic;

namespace MauiApp7Allnighter
{
    public class StudentRepository
    {
        private string _dbPath;
        private SQLiteConnection conn;

        public string StatusMessage { get; set; }

        public StudentRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (conn != null) return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Student>();
        }

        public void AddNewStudent(string name)
        {
            try
            {
                Init();

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                conn.Insert(new Student { Name = name });
                StatusMessage = $"Record added (Name: {name})";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to add {name}. Error: {ex.Message}";
            }
        }

        public List<Student> GetSection()
        {
            try
            {
                Init();
                return conn.Table<Student>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve data. {ex.Message}";
                return new List<Student>();
            }
        }
    }
}
