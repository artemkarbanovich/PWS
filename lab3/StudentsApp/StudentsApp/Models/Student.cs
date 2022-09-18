using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsApp.Models
{
    [Table("STUDENTS")]
    public class Student
    {
        public static readonly string[] Columns = new string[] { "ID", "NAME", "PHONE" };

        public Student(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public Student() { }


        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("PHONE")]
        public string Phone { get; set; }


        public void Update(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
    }
}