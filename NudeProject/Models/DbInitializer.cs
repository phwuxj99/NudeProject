using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace NudeProject.Models
{
    public static class DbInitializer
    {
        public static void Initialize(NudeDBContext context)
        {
            string sqlScript = @" 
INSERT INTO [dbo].[Products] VALUES ('Electronics','TV',2000)
INSERT INTO [dbo].[Products] VALUES ('Electronics','Playstation',400)
INSERT INTO [dbo].[Products] VALUES ('Electronics','Stereo',1600)

INSERT INTO [dbo].[Products] VALUES ('Clothing','Shirts',1100)
INSERT INTO [dbo].[Products] VALUES ('Clothing','Jeans',1100)

INSERT INTO [dbo].[Products] VALUES ('Kitchen','Pots and Pans',3000)
INSERT INTO [dbo].[Products] VALUES ('Kitchen','Flatware',500)
INSERT INTO [dbo].[Products] VALUES ('Kitchen','Knife Set',500)
INSERT INTO [dbo].[Products] VALUES ('Kitchen','Misc',1000)
";
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TableName] go");
                context.Database.ExecuteSqlRaw($"TRUNCATE TABLE [Products] ");
                context.Database.ExecuteSqlRaw(sqlScript);
                return;   // DB has been seeded
            }
            else
            {
                context.Database.ExecuteSqlRaw(sqlScript);
                return;   // DB has been seeded
            }

//            var students = new Product[]
//            {
//                new Product{ ItemName="TV", CategoryName="Electronics", Price=2000},
//                new Product{ ItemName="Playstation", CategoryName="Electronics", Price=400},
//                new Product{ ItemName="Stereo", CategoryName="Electronics", Price=1600},
//                new Product{ ItemName="Shirts", CategoryName="Clothing", Price=1100},
//                new Product{ ItemName="Jeans", CategoryName="Clothing", Price=1100},
//                new Product{ ItemName="Pots and Pans", CategoryName="Kitchen", Price=3000},
//                new Product{ ItemName="Flatware", CategoryName="Kitchen", Price=500},
//                new Product{ ItemName="Knife Set", CategoryName="Kitchen", Price=500},
//                new Product{ ItemName="Misc", CategoryName="Kitchen", Price=1000}


////INSERT INTO [dbo].[Products] VALUES ('Electronics','TV',2000)
////INSERT INTO [dbo].[Products] VALUES ('Electronics','Playstation',400)
////INSERT INTO [dbo].[Products] VALUES ('Electronics','Stereo',1600)

////INSERT INTO [dbo].[Products] VALUES ('Clothing','Shirts',1100)
////INSERT INTO [dbo].[Products] VALUES ('Clothing','Jeans',1100)

////INSERT INTO [dbo].[Products] VALUES ('Kitchen','Pots and Pans',3000)
////INSERT INTO [dbo].[Products] VALUES ('Kitchen','Flatware',500)
////INSERT INTO [dbo].[Products] VALUES ('Kitchen','Knife Set',500)
////INSERT INTO [dbo].[Products] VALUES ('Kitchen','Misc',1000)

//            };
//            foreach (Product s in students)
//            {
//                context.Products.Add(s);
//            }
//            context.SaveChanges();

        }
    }
}
