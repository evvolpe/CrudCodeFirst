using CrudCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CrudCodeFirst.Data
{
    public class ListContext : DbContext
    {
        public ListContext() : base("ListContext")
        {

        }

        public DbSet<ListEntry> Lists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}