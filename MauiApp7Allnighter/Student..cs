using SQLite;

namespace MauiApp7Allnighter
{
    [Table("section")]
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }
    }
}
