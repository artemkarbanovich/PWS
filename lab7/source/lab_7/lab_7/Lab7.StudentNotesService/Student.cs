using System.Collections.Generic;

namespace lab_6_odata
{    
    public partial class Student
    {
        public Student() => Notes = new HashSet<Note>();

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
