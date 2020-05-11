using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using PostgresPlayGround.Db;
using PostgresPlayGround.Db.Models;
using System;

namespace test
{
    public class InitDataBase
    {
        private PlaygroundContext db_context;

        public object ConfigurationManager { get; private set; }

        [SetUp]
        public void Setup()
        {            
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<PlaygroundContext>();
            builder.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"));
            db_context = new PlaygroundContext(builder.Options);
        }


        [Test]
        [Order(1)]
        public void DeleteAll()
        { 
            db_context.Goods.RemoveRange(db_context.Goods);
            db_context.Colors.RemoveRange(db_context.Colors);
            db_context.SaveChanges();
        }
        [Test]
        [Order(2)]
        public void AddInitData()
        {
            var green = new GoodColor()
            {
                Descr = "Green"
            };
            db_context.Colors.Add(green);

            var red = new GoodColor()
            {
                Descr = "Red"
            };
            db_context.Colors.Add(red);

            var blue = new GoodColor()
            {
                Descr = "Bloe"
            };

            db_context.Colors.Add(blue);


            for (int i = 0; i < 100; i++)
            {
                var targetColor = i < 30 ? green : i < 60 ? red : blue;
                db_context.Goods.Add(new Good()
                            {
                                Name = $"Good{i}",
                                Color = targetColor,
                                Price = Math.Round(DateTime.Now.Millisecond / (DateTime.Now.Minute + 1m), 2)
                            }
                    );
            }
            db_context.SaveChanges();
        }
    }
}