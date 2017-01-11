using Microsoft.EntityFrameworkCore;
using ReviewWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewWebSite.Data
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options)
        {
        }

        public DbSet<ReviewModel> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReviewModel>().ToTable("Reviews");
        }
    }
}
