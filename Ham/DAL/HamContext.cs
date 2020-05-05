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
        public DbSet<CallSign> CallSign { get; set; }
        public DbSet<Station> Station { get; set; }
        public DbSet<Type> Type { get; set; }

    }
}
