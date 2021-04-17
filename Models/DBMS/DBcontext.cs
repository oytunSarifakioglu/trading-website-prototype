using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;

namespace Task_Back_End.Models.DBMS
{
    public class DBcontext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        internal void SaveChangesAsync(DBcontext context)
        {
            throw new NotImplementedException();
        }

        public DBcontext()
        {
            Database.SetInitializer(new DBcreator());
        }
    }

    public class DBcreator : CreateDatabaseIfNotExists<DBcontext>
    {  
        protected override void Seed(DBcontext context)
        {
            for (int i = 0; i < 10; i++)
            {
                User kullanici = new User();
                kullanici.userID = FakeData.NumberData.GetNumber();
                kullanici.mailAdress = FakeData.TextData.GetSentence();
                kullanici.password = FakeData.NumberData.GetNumber();
                kullanici.role = FakeData.BooleanData.GetBoolean();

                context.User.Add(kullanici);
            }

            context.SaveChanges();

            List<User> tumKisiler = context.User.ToList();

            foreach(User kullanici in tumKisiler)
            {
                for (int i=0; i < FakeData.NumberData.GetNumber(1, 5); i++)
                {
                    Product urun = new Product();
                    urun.productID = FakeData.NumberData.GetNumber();
                    urun.productName = FakeData.TextData.GetSentence();
                    urun.stock = FakeData.NumberData.GetNumber(0,100);
                    urun.userID = kullanici.userID;

                    context.Product.Add(urun);

                }
            }
            context.SaveChanges();

            List<Product> tumUrunler = context.Product.ToList();

            foreach (Product urun in tumUrunler)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1, 5); i++)
                {
                    Transaction islem = new Transaction();
                    islem.count = FakeData.NumberData.GetNumber(0, 100);
                    islem.orderNo = FakeData.NumberData.GetNumber();
                    islem.timeStamp = FakeData.DateTimeData.GetDatetime();
                   
                    islem.productID = urun.productID;
                    islem.userID = urun.userID;

                    context.Transaction.Add(islem);
                }
            }
            context.SaveChanges();
        }
    }
}