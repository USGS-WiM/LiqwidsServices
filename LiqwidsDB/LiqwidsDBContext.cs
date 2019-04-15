//------------------------------------------------------------------------------
//----- DB Context ---------------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2019 WIM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping
//              
//  
//   purpose:   Responsible for interacting with Database 
//
//discussion:   The primary class that is responsible for interacting with data as objects. 
//              The context class manages the entity objects during run time, which includes 
//              populating objects with data from a database, change tracking, and persisting 
//              data to the database.
//              
//
//   

using Microsoft.EntityFrameworkCore;
using LiqwidsDB.Resources;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System;
//specifying the data provider and connection string
namespace LiqwidsDB
{
    public class LiqwidsDBContext:DbContext
    {
        public DbSet<LiqwidsResource> Liqwids { get; set; }

        public LiqwidsDBContext() : base()
        {
        }
        public LiqwidsDBContext(DbContextOptions<LiqwidsDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //schema
            modelBuilder.HasDefaultSchema("liqwids");
            //unique key based on combination of both keys (many to many tables)
            //modelBuilder.Entity<RegionManager>().HasKey(k => new { k.ManagerID, k.RegionID });

            // Specify other unique constraints
            //EF Core currently does not support changing the value of alternate keys. We do have #4073 tracking removing this restriction though.
            //BTW it only needs to be an alternate key if you want it to be used as the target key of a relationship.If you just want a unique index, 
            //then use the HasIndex() method, rather than AlternateKey().Unique index values can be changed.
            //modelBuilder.Entity<Manager>().HasIndex(k => k.Username);

            // add shadowstate
            //https://stackoverflow.com/questions/9556474/how-do-i-automatically-update-a-timestamp-in-postgresql
            //https://x-team.com/blog/automatic-timestamps-with-postgresql/
            foreach (var entitytype in modelBuilder.Model.GetEntityTypes())
            {
                //"EquationError","EquationUnitType","RegionManager","RegionRegressionRegion","VariableUnitType" 
                if (new List<string>() { typeof(LiqwidsResource).FullName}
                .Contains(entitytype.Name))
                { continue; }
                modelBuilder.Entity(entitytype.Name).Property<DateTime>("LastModified");
            }//next entitytype


            //cascade delete is default, rewrite behavior
            modelBuilder.Entity(typeof(LiqwidsResource).ToString(), b =>
            {
                b.HasOne(typeof(LiqwidsResource).ToString(), "ErrorType")
                    .WithMany()
                    .HasForeignKey("ErrorTypeID")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //seed the db
            //var path = Path.Combine(Environment.CurrentDirectory, "Data");
            //modelBuilder.Entity<LiqwidsResource>().HasData(JsonConvert.DeserializeObject<LiqwidsResource[]>(File.ReadAllText(Path.Combine(path, "Liqwids.json"))));



            base.OnModelCreating(modelBuilder);             
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning Add connectionstring for migrations
            var connectionstring = "User ID=;Password=;Host=;Port=5432;Database=;Pooling=true;";
            //optionsBuilder.UseNpgsql(connectionstring);
        }
    }
}
