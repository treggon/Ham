namespace Ham.Migrations
{
    using Ham.Lib.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ham.DAL.HamContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Ham.DAL.HamContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


                context.Categories.AddOrUpdate(
                    p => p.Name,
                    new Category { Name = "Station" },
                    new Category { Name = "Technician" },
                    new Category { Name = "Extra" },
                    new Category { Name = "General" }
                    );

            

                context.CallSigns.AddOrUpdate(
                    p => p.Name,
                    new CallSign { Name = "K6XI",   CategoryID = context.Categories.Single(s => s.Name == "Station").ID },
                    new CallSign { Name = "KK6RJK", CategoryID = context.Categories.Single(s => s.Name == "Technician").ID},
                    new CallSign { Name = "KN6GXO", CategoryID = context.Categories.Single(s => s.Name == "Technician").ID },
                    new CallSign { Name = "KJ6RMP", CategoryID = context.Categories.Single(s => s.Name == "Technician").ID }
                    );            

            


                context.Contacts.AddOrUpdate(
                    p => p.Name,
                    new Contact { Name = "Otay", CallSignID = context.Categories.Single(s => s.Name == "K6XI").ID },
                    new Contact { Name = "Austin Blue", CallSignID = context.Categories.Single(s => s.Name == "KK6RJK").ID },
                    new Contact { Name = "Cory Ramsay", CallSignID = context.Categories.Single(s => s.Name == "KN6GXO").ID },
                    new Contact { Name = "Treggon Owens", CallSignID = context.Categories.Single(s => s.Name == "KJ6RMP").ID }
                    );
            


                context.Frequencies.AddOrUpdate(
                    p => p.Name,
                    new Frequency { Hz = 94900.0, Name = "FM 949" },
                    new Frequency { Hz = 449440.0, Name = "Otay Repeater K6XI" }
                    );
            



                context.Stations.AddOrUpdate(
                    p => p.Note,
                    new Station { CallSignID = context.CallSigns.Single(s => s.Name == "K6XI").ID, Power = "100 Watts"}
                    );
            
            
            /*
            if (!context.QSOs.Any())
            {
                context.QSOs.AddOrUpdate(
                    p => p.Note,
                    new QSO { Note = "Contact Cory to Treggon, Teaching how to QSO",
                        //FrequencyID = context.Frequencies.Single(s => s.Name == "Otay Repeater K6XI").ID,
                        
                    }
                    );
            }
            */
            
            

        }
    }
}
