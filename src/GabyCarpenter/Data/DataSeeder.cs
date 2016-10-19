using GabyCarpenter.Models.Carpentry;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNet.Identity;

namespace GabyCarpenter.Data
{
    public static class DataSeeder
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            var db = (GabyCarpenterContext)app.ApplicationServices.GetService(typeof(GabyCarpenterContext));
            
            if (db.Items.FirstOrDefault(m => m.Name == "Pink Shelf") == null)
            {
                db.Items.Add(new Models.Carpentry.ItemModel()
                {
                    Name = "Pink Shelf",
                    Description = "Pink shelf for kitchen or living room with with 3 hangers",
                    Height = 45,
                    Width = 70,
                    Depth = 20,
                    Color = "Pink",
                    Price = 750,
                    amountInStock = 3,
                    tags = "Kitchen,Hangers,Shelf",
                    Image = createImage("001.jpg", "002.jpg", "003.jpg")
                });

                db.Items.Add(new Models.Carpentry.ItemModel()
                {
                    Name = "Kids Book shelf",
                    Description = "Pink books shelf for kids with hearts on the sides",
                    Height = 120,
                    Width = 70,
                    Depth = 20,
                    Color = "Pink",
                    Price = 1400,
                    amountInStock = 1,
                    tags = "Kids,Books,Girls",
                    Image = createImage("004.jpg", "005.jpg", "2626.jpg", "2628.jpg", "2629.jpg")
                });

                db.Items.Add(new Models.Carpentry.ItemModel()
                {
                    Name = "Small shelf",
                    Description = "Small shelf with hanger, might be ordered in variose colors",
                    Height = 20,
                    Width = 35,
                    Depth = 20,
                    Color = "White",
                    Price = 350,
                    amountInStock = 10,
                    tags = "Hangers,shelf,small",
                    Image = createImage("013.jpg", "018.jpg", "019.jpg")
                });

                db.Items.Add(new Models.Carpentry.ItemModel()
                {
                    Name = "Diper chnager",
                    Description = "Yellow utility shelf with white basket for diper changeing needs",
                    Height = 45,
                    Width = 60,
                    Depth = 20,
                    Color = "Yellow",
                    Price = 1800,
                    amountInStock = 0,
                    tags = "Kids,Boys,Girls,Utility",
                    Image = createImage("028.jpg", "038.jpg", "040.jpg")
                });

                db.Items.Add(new Models.Carpentry.ItemModel()
                {
                    Name = "Kitchen Cabinet",
                    Description = "Kitchen cabinet for jurs",
                    Height = 60,
                    Width = 55,
                    Depth = 15,
                    Color = "Blue",
                    Price = 1200,
                    amountInStock = 0,
                    tags = "Kitchen,Shelf,Hearts",
                    Image = createImage("2020.jpg", "2021.jpg")
                });

                db.Items.Add(new Models.Carpentry.ItemModel()
                {
                    Name = "Living room deco shelfs",
                    Description = "Livig room decorative shelfs for decorative items",
                    Height = 60,
                    Width = 40,
                    Depth = 10,
                    Color = "White",
                    Price = 900,
                    amountInStock = 4,
                    tags = "Living Room,Shelf,Deco",
                    Image = createImage("2219.jpg", "2226.jpg", "IMG_2782.jpg", "IMG_2783.jpg")
                });

                db.Items.Add(new Models.Carpentry.ItemModel()
                {
                    Name = "Big storage unit",
                    Description = "Storage unit with 3 drawers and 1 door - openning upwards",
                    Height = 40,
                    Width = 60,
                    Depth = 20,
                    Color = "Purple",
                    Price = 2500,
                    amountInStock = 1,
                    tags = "Storage,Drawers",
                    Image = createImage("2234.jpg", "2235.jpg")
                });

                db.Items.Add(new Models.Carpentry.ItemModel()
                {
                    Name = "Kids boo",
                    Description = "Storage unit with 3 drawers and 1 door - openning upwards",
                    Height = 40,
                    Width = 60,
                    Depth = 20,
                    Color = "Purple",
                    Price = 2500,
                    amountInStock = 1,
                    tags = "Storage,Drawers",
                    Image = createImage("2234.jpg", "2235.jpg")
                });

                db.Items.Add(new Models.Carpentry.ItemModel()
                {
                    Name = "Shoes sotring compartment",
                    Description = "Shoes storing compartment",
                    Height = 40,
                    Width = 90,
                    Depth = 40,
                    Color = "White",
                    Price = 3800,
                    amountInStock = 0,
                    tags = "Comparment,Storage,door",
                    Image = createImage("2826.jpg", "2826.jpg", "2829.jpg")
                });

                db.Items.Add(new Models.Carpentry.ItemModel()
                {
                    Name = "Book Shelf",
                    Description = "Library with spanish caption",
                    Height = 80,
                    Width = 50,
                    Depth = 25,
                    Color = "Offwhite",
                    Price = 2500,
                    amountInStock = 8,
                    tags = "books,caption,deco",
                    Image = createImage("IMG_2767.jpg", "IMG_2775.jpg")
                });

                db.Items.Add(new Models.Carpentry.ItemModel()
                {
                    Name = "Girls cabinet",
                    Description = "Ping girls cabinet with hearted door",
                    Height = 60,
                    Width = 40,
                    Depth = 30,
                    Color = "Pink",
                    Price = 3600,
                    amountInStock = 1,
                    tags = "Kids,Cabinte,Heart,Girls",
                    Image = createImage("IMG_2791.jpg", "IMG_2793.jpg", "IMG_2794.jpg")
                });

                db.Items.Add(new Models.Carpentry.ItemModel()
                {
                    Name = "Boys cabinet",
                    Description = "Ping girls cabinet with car door",
                    Height = 60,
                    Width = 40,
                    Depth = 30,
                    Color = "Blue",
                    Price = 3600,
                    amountInStock = 1,
                    tags = "Kids,Cabinte,Car,Boys",
                    Image = createImage("IMG_2795.jpg", "IMG_2796.jpg")
                });
            }
            //db.ChangeTracker.Entries<ItemModel>()
            //    .Where(m => m.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            //    .Select(d =>d.Entity.Name)
            //    .ToList()
            //    .ForEach(k => db.Items.RemoveRange(db.Items.Where(l => l.Name == k).ToList()));

            db.SaveChanges();
        }

        private static ICollection<SavedImage> createImage(params string[] filenames)
        {
            LinkedList<SavedImage> retval = new LinkedList<SavedImage>();
            foreach (var filename in filenames)
            {
                retval.AddLast(new SavedImage()
                {
                    ContentType = "image/jpeg",
                    FileName = "filename",
                    Content = File.ReadAllBytes(@"seedImages/" + filename)
                });
            }

            return retval;
        }
    }
}
