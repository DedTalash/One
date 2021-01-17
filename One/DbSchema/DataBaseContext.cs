using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;


namespace One.DbSchema
{
    public partial class DataBaseContext : DbContext
    {
        public virtual DbSet<Coord> Coord { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UsePostgreSql(@"Server=localhost;Database=One;Truste_Connection=True;");
        }
    }
}
