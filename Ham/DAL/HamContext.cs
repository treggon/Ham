using Ham.Lib.Models;
using Ham.Models;
using System.Data.Entity;

namespace Ham.DAL
{
    public class HamContext : DbContext
    {
        public HamContext() : base("HamContext")
        {
            //Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CallSign> CallSigns { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Frequency> Frequencies { get; set; }

        public DbSet<QSO> QSOes { get; set; }
    }
}
