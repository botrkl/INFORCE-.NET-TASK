using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.DAL.Entities;

namespace URLShortener.DAL.DbDataGenerators
{
    public static class UserDataGenerator
    {
        public static readonly List<User> users = new List<User>
        {
            new()
            {
                Id=Guid.Parse("9B4673FB-20C2-4341-9A36-A3CFAA22878B"),
                Username="test1",
                HashPassword="r4A/IOyfd//CftSMJ0/HYQ==:57hdC+TEJMp1K0tT8g9idzFKhJShQa+s0kDt7EVaoMQ=",
                IsAdmin=false
            },
            new()
            {
                Id=Guid.Parse("747A1720-4CA3-43E2-93FA-BECC860589DC"),
                Username="admin",
                HashPassword="r4A/IOyfd//CftSMJ0/HYQ==:57hdC+TEJMp1K0tT8g9idzFKhJShQa+s0kDt7EVaoMQ=",
                IsAdmin=true
            },
            new()
            {
                Id=Guid.Parse("539AD3F7-7478-4B34-8A09-9509B6F4ADFD"),
                Username="test2",
                HashPassword="r4A/IOyfd//CftSMJ0/HYQ==:57hdC+TEJMp1K0tT8g9idzFKhJShQa+s0kDt7EVaoMQ=",
                IsAdmin=false
            }
        };
        public static void Generate(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(users);
        }
    }
}
