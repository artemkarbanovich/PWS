using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace lab_6_odata
{    
    public partial class WsKakEntities : DbContext
    {
        public WsKakEntities() : base("name=WsKakEntities") { }

        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) => throw new UnintentionalCodeFirstException();
    }
}
