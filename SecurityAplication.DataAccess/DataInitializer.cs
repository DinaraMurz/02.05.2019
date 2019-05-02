using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SecurityAplication.Services;

namespace SecurityAplication.DataAccess
{
    public class DataInitializer : CreateDatabaseIfNotExists<SecurityContext>
    {
       

        protected override void Seed(SecurityContext context)
        {
            context.Users.Add(new Models.User
            {
                Login = "admin",
                Password = SecurityHasher.HashPassword("123")
            });
        }
    }
}
