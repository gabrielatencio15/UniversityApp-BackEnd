using System;
using Microsoft.EntityFrameworkCore;
using UniversityApp_BackEnd.Models;

namespace UniversityApp_BackEnd
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
          
        }

        public DbSet<Students> Students { get; set; }
    }
}
