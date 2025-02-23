using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicatonDBContext : DbContext
    {
        //координация EFCore в базе данных
        public ApplicatonDBContext(DbContextOptions dbContextOptions)
        :base(dbContextOptions)
        {
            
        }

//          The code above establishes a DbSet<Urers> property representing the enentity set. 
//      In the language of Entity Framework, an tity set generally aligns with a database table,
//      and an entity corresponds to an individual row within that table. (объяснили на медиум.ком)
        public DbSet<Userss> Users { get; set; } 
    }
}