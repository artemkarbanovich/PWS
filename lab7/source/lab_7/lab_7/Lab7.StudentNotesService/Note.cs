using System;

namespace lab_6_odata
{    
    public partial class Note
    {
        public int Id { get; set; }
        public Nullable<int> StudentId { get; set; }
        public string Subject { get; set; }
        public Nullable<int> Note1 { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
