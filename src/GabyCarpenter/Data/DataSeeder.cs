using GabyCarpenter.Models.Carpentry;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GabyCarpenter.Models;
using Microsoft.AspNetCore.Identity;

namespace GabyCarpenter.Data
{
    public static class DataSeeder
    {
        public static readonly string ADMIN_USERNAME = "manager@gabycarpenter.com";
        public static readonly string ADMIN_PASSWORD = "Password1!";


        public static async void SeedData(this IApplicationBuilder app)
        {

            string[] itemNames = { "Pink Shelf", "Kids Book shelf", "Small shelf","Diper chnager","Kitchen Cabinet","Living room deco shelfs", "Big storage unit", "Stool","Shoes sotring compartment","Book Shelf","Girls cabinet","Boys cabinet"};
            String[] clientNames = { "Dudu Oliel", "Igor Rochlin", "Moshe abutbul", "Yosi Cohen", "Moti Gabay", "Yuri Portinsky", "Miki Ashkenazi", "Nama Aviv" };
            string[] addresses = { "Naale", "1 Emek Ayalon, Modiin", "Addar 5, Modiin", "43 Hertzel, Rishon Letzion", "4 Alenby, Tel Aviv", "1 Haoreg, Modiin", "Haim Arlozorov, Petah TIkva", "Jaffa, Jerusalem" };
            
            var db = (GabyCarpenterContext)app.ApplicationServices.GetService(typeof(GabyCarpenterContext));
            var _accountManager = (UserManager<ApplicationUser>)app.ApplicationServices.GetService(typeof(UserManager<ApplicationUser>));

            if (await _accountManager.FindByEmailAsync(ADMIN_USERNAME) == null)
            {
                await _accountManager.CreateAsync(new ApplicationUser() { UserName = ADMIN_USERNAME, Email = ADMIN_USERNAME }, ADMIN_PASSWORD);
            }


            if (!db.Supplier.Any())
            {
                db.Supplier.Add(new Supplier()
                {
                    Name = "Maman",
                    Address = "7 hayetzira st. Rehovot",
                    ContactPersonName = "Meir Maman",
                    Email = "sells@maman.co.il",
                    PhoneNmber = "076-8019904"
                });

                db.Supplier.Add(new Supplier()
                {
                    Name = "Israely Wood Center",
                    Address = "Bilu center",
                    ContactPersonName = "Moshe",
                    Email = "info@woodcenter.co.il",
                    PhoneNmber = "08-9495990"
                });

                db.Supplier.Add(new Supplier()
                {
                    Name = "Tzdaka",
                    Address = "6 Hamapuach st. Rehovot",
                    ContactPersonName = "David Tzadka",
                    Email = "",
                    PhoneNmber = "08-9693145"
                });
            }

            db.SaveChanges();

            if (!db.Items.Any())
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
                    Image = createImage("001.jpg", "002.jpg", "003.jpg"),
                    supplier = db.Supplier.FirstOrDefault(m => m.Name == "Maman")
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
                    Image = createImage("004.jpg", "005.jpg", "2626.jpg", "2628.jpg", "2629.jpg"),
                    supplier = db.Supplier.FirstOrDefault(m => m.Name == "Maman")
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
                    Image = createImage("013.jpg", "018.jpg", "019.jpg"),
                    supplier = db.Supplier.FirstOrDefault(m => m.Name == "Maman")
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
                    Image = createImage("028.jpg", "038.jpg", "040.jpg"),
                    supplier = db.Supplier.FirstOrDefault(m => m.Name == "Israely Wood Center")
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
                    Image = createImage("2020.jpg", "2021.jpg"),
                    supplier = db.Supplier.FirstOrDefault(m => m.Name == "Israely Wood Center")
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
                    Image = createImage("2219.jpg", "2226.jpg", "IMG_2782.jpg", "IMG_2783.jpg"),
                    supplier = db.Supplier.FirstOrDefault(m => m.Name == "Israely Wood Center")
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
                    Image = createImage("2234.jpg", "2235.jpg"),
                    supplier = db.Supplier.FirstOrDefault(m => m.Name == "Israely Wood Center")
                });

                db.Items.Add(new Models.Carpentry.ItemModel()
                {
                    Name = "Stool",
                    Description = "Storage unit with 3 drawers and 1 door - openning upwards",
                    Height = 30,
                    Width = 30,
                    Depth = 40,
                    Color = "Pink",
                    Price = 2500,
                    amountInStock = 1,
                    tags = "Storage,Drawers",
                    Image = createImage("IMG_2777 - Copy.jpg", "IMG_2778 - Copy.jpg", "IMG_2777 - Copy.jpg"),
                    supplier = db.Supplier.FirstOrDefault(m => m.Name == "Israely Wood Center")
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
                    Image = createImage("2826.jpg", "2826.jpg", "2829.jpg"),
                    supplier = db.Supplier.FirstOrDefault(m => m.Name == "Tzdaka")
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
                    Image = createImage("IMG_2767.jpg", "IMG_2775.jpg"),
                    supplier = db.Supplier.FirstOrDefault(m => m.Name == "Tzdaka")
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
                    Image = createImage("IMG_2791.jpg", "IMG_2793.jpg", "IMG_2794.jpg"),
                    supplier = db.Supplier.FirstOrDefault(m => m.Name == "Tzdaka")
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
                    Image = createImage("IMG_2795.jpg", "IMG_2796.jpg"),
                    supplier = db.Supplier.FirstOrDefault(m => m.Name == "Tzdaka")
                });
            }
            //db.ChangeTracker.Entries<ItemModel>()
            //    .Where(m => m.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            //    .Select(d =>d.Entity.Name)
            //    .ToList()
            //    .ForEach(k => db.Items.RemoveRange(db.Items.Where(l => l.Name == k).ToList()));

            db.SaveChanges();
            Random rnd = new Random();

            if (!db.Orders.Any())
            {
                foreach (string address in addresses)
                {
                    db.Orders.Add(new OrderModel()
                    {
                        orderdItem = db.Items.FirstOrDefault(m => m.Name.Equals(itemNames[rnd.Next(itemNames.Length)])),
                        clientName = clientNames[rnd.Next(clientNames.Length)],
                        phoneNumber = rnd.Next(999999999).ToString(),
                        SheepingAddress = address,
                        status = (OrderStatus)Enum.GetValues(typeof(OrderStatus)).GetValue(rnd.Next(3))
                    });
                }
            }

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
