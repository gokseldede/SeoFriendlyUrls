using Faker.Extensions;
using FizzWare.NBuilder;
using Microsoft.SqlServer.Server;
using SeoFriendlyUrls.Models;

namespace SeoFriendlyUrls.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SeoFriendlyUrls.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SeoFriendlyUrls.Models.ApplicationDbContext context)
        {
            string[] productNames = new[]
            {
                "Sony W800/B 20.1 MP Digital Camera",
                "Kodak Easyshare C195 Digital Camera",
                "Sony Cyber-shot DSC-RX100 IV",
                "Panasonic Lumix DMC-GX8",
                "Panasonic Lumix DMC-FZ300",
                "Panasonic Lumix DMC-G7",
                "Fujifilm X-T10",
                "Canon EOS 5DS and 5DS R",
                "Canon EOS 750D (EOS Rebel T6i / Kiss X8i)",
                "Canon PowerShot G3 X",
                "Leica Q (Typ 116)",
                "Sony Alpha 7R II",
                "Nikon D7200",
                "Leica M Monochrom (Typ 246)",
                "Metz mecablitz 26 AF-1",
                "Sony SLT-A77 II",
                "Samsung NX1",
                "Fujifilm X30",
                "Fujifilm X100T",
                "Olympus OM-D E-M5 II"
            };
            var priceGenerator = new RandomGenerator();

            var products = Builder<Product>.CreateListOfSize(20)
                .All()
                .With(p => p.Name = Pick<string>.RandomItemFrom(productNames))
                .With(p => p.Description = Faker.Lorem.Sentence())
                .With(p => p.Price = priceGenerator.Next(50, 500))
                .Build();

            context.Products.AddOrUpdate(p => p.Id, products.ToArray());
        }
    }
}
