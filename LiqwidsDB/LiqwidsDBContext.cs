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
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


//specifying the data provider and connection string
namespace LiqwidsDB
{
    public class LiqwidsDBContext:DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<AnalyticalMethod> AnalyticalMethods { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<CollectionEquipment> CollectionEquipment { get; set; }
        public DbSet<CollectionMethod> CollectionMethods { get; set; }
        public DbSet<DetectionCondition> DetectionConditions { get; set; }
        public DbSet<DetectionLimit> DetectionLimits { get; set; }
        public DbSet<HorizontalCollectionMethod> HorizontalCollectionMethods { get; set; }
        public DbSet<HorizontalDatum> HorizontalDatums { get; set; }
        public DbSet<Limit> Limits { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<MeasureQualifier> MeasureQualifiers { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<MethodSpeciation> MethodSpeciations { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SampleFraction> SampleFractions { get; set; }
        public DbSet<StatisticalBase> StatisticalBases { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Resources.ValueType> Values { get; set; }

        public LiqwidsDBContext() : base(){}
        public LiqwidsDBContext(DbContextOptions<LiqwidsDBContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //schema
            modelBuilder.HasDefaultSchema("liqwids");
            //unique key based on combination of both keys (many to many tables)
            modelBuilder.Entity<DetectionLimit>().HasKey(k => new { k.ResultID, k.LimitID });

            // Specify other unique constraints
            //EF Core currently does not support changing the value of alternate keys. We do have #4073 tracking removing this restriction though.
            //BTW it only needs to be an alternate key if you want it to be used as the target key of a relationship.If you just want a unique index, 
            //then use the HasIndex() method, rather than AlternateKey().Unique index values can be changed.
            modelBuilder.Entity<User>().HasIndex(k => k.Username);
            modelBuilder.Entity<Role>().HasIndex(k => k.Name);
            modelBuilder.Entity<LocationType>().HasIndex(k => k.Name);
            modelBuilder.Entity<HorizontalCollectionMethod>().HasIndex(k => k.Name);
            modelBuilder.Entity<HorizontalDatum>().HasIndex(k => k.Name);
            modelBuilder.Entity<Location>().HasIndex(k => k.Name);
            modelBuilder.Entity<MethodSpeciation>().HasIndex(k => k.Name);
            modelBuilder.Entity<Resources.ValueType>().HasIndex(k => k.Name);
            modelBuilder.Entity<Characteristic>().HasIndex(k => k.Name);
            modelBuilder.Entity<SampleFraction>().HasIndex(k => k.Name);
            modelBuilder.Entity<Status>().HasIndex(k => k.Name);
            modelBuilder.Entity<StatisticalBase>().HasIndex(k => k.Code);
            modelBuilder.Entity<AnalyticalMethod>().HasIndex(k => k.Identifier);
            modelBuilder.Entity<ActivityType>().HasIndex(k => k.Code);
            modelBuilder.Entity<CollectionMethod>().HasIndex(k => k.Name);
            modelBuilder.Entity<Media>().HasIndex(k => k.Name);
            modelBuilder.Entity<CollectionEquipment>().HasIndex(k => k.Name);
            modelBuilder.Entity<DetectionCondition>().HasIndex(k => k.Name);
            modelBuilder.Entity<MeasureQualifier>().HasIndex(k => k.Code);
            modelBuilder.Entity<Limit>().HasIndex(k => k.Name);
            modelBuilder.Entity<Unit>().HasIndex(k => k.Name);
            modelBuilder.Entity<Project>().HasIndex(k => k.Name);

            // add shadowstate
            //https://stackoverflow.com/questions/9556474/how-do-i-automatically-update-a-timestamp-in-postgresql
            //https://x-team.com/blog/automatic-timestamps-with-postgresql/
            foreach (var entitytype in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entitytype.Name).Property<DateTime>("LastModified");
            }//next entitytype


            //cascade delete is default, rewrite behavior
            modelBuilder.Entity(typeof(Location).ToString(), b =>
            {
                b.HasOne(typeof(HorizontalCollectionMethod).ToString(), "HorizontalCollectionMethod")
                    .WithMany()
                    .HasForeignKey("HorizontalCollectionMethodID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(HorizontalDatum).ToString(), "HorizontalDatum")
                    .WithMany()
                    .HasForeignKey("HorizontalDatumID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(LocationType).ToString(), "LocationType")
                    .WithMany()
                    .HasForeignKey("LocationTypeID")
                    .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity(typeof(Activity).ToString(), b =>
            {
                b.HasOne(typeof(Location).ToString(), "Location")
                    .WithMany()
                    .HasForeignKey("LocationID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(ActivityType).ToString(), "ActivityType")
                    .WithMany()
                    .HasForeignKey("ActivityTypeID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(CollectionMethod).ToString(), "CollectionMethod")
                    .WithMany()
                    .HasForeignKey("CollectionMethodID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(Media).ToString(), "Media")
                    .WithMany()
                    .HasForeignKey("MediaID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(CollectionEquipment).ToString(), "CollectionEquipment")
                    .WithMany()
                    .HasForeignKey("CollectionEquipmentID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(Project).ToString(), "Project")
                    .WithMany()
                    .HasForeignKey("ProjectID")
                    .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity(typeof(Result).ToString(), b =>
            {
                b.HasOne(typeof(Characteristic).ToString(), "Characteristic")
                    .WithMany()
                    .HasForeignKey("CharacteristicID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(SampleFraction).ToString(), "SampleFraction")
                    .WithMany()
                    .HasForeignKey("SampleFractionID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(MethodSpeciation).ToString(), "MethodSpeciation")
                    .WithMany()
                    .HasForeignKey("MethodSpeciationID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(Resources.ValueType).ToString(), "ValueType")
                    .WithMany()
                    .HasForeignKey("ValueTypeID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(Status).ToString(), "Status")
                    .WithMany()
                    .HasForeignKey("StatusID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(StatisticalBase).ToString(), "StatisticalBase")
                    .WithMany()
                    .HasForeignKey("StatisticalBaseID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(AnalyticalMethod).ToString(), "AnalyticalMethod")
                    .WithMany()
                    .HasForeignKey("AnalyticalMethodID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(Unit).ToString(), "Unit")
                    .WithMany()
                    .HasForeignKey("UnitID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(MeasureQualifier).ToString(), "MeasureQualifier")
                    .WithMany()
                    .HasForeignKey("MeasureQualifierID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(DetectionCondition).ToString(), "DetectionCondition")
                    .WithMany()
                    .HasForeignKey("DetectionConditionID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(Activity).ToString(), "Activity")
                    .WithMany()
                    .HasForeignKey("ActivityID")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity(typeof(DetectionLimit).ToString(), b =>
            {
                b.HasOne(typeof(Limit).ToString(), "Limit")
                    .WithMany()
                    .HasForeignKey("LimitID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(Unit).ToString(), "Unit")
                    .WithMany()
                    .HasForeignKey("UnitID")
                    .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<Result>()
                .HasOne(a => a.DetectionLimit)
                .WithOne(b => b.Result)
                .HasForeignKey<DetectionLimit>(b => b.ResultID);
                
            //12/21/2015 2:28:18 PM
            var format = "d/M/yyyy h:mm:ss tt";
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };

            //seed the db
            var path = Path.Combine(Environment.CurrentDirectory, "Data");
            modelBuilder.Entity<ActivityType>().HasData(JsonConvert.DeserializeObject<ActivityType[]>(File.ReadAllText(Path.Combine(path, "ActivityType.json")),dateTimeConverter));
            modelBuilder.Entity<AnalyticalMethod>().HasData(JsonConvert.DeserializeObject<AnalyticalMethod[]>(File.ReadAllText(Path.Combine(path, "AnalyticalMethod.json")), dateTimeConverter));
            modelBuilder.Entity<Characteristic>().HasData(JsonConvert.DeserializeObject<Characteristic[]>(File.ReadAllText(Path.Combine(path, "Characteristic.json")), dateTimeConverter));
            modelBuilder.Entity<CollectionEquipment>().HasData(JsonConvert.DeserializeObject<CollectionEquipment[]>(File.ReadAllText(Path.Combine(path, "CollectionEquipment.json")), dateTimeConverter));
            modelBuilder.Entity<DetectionCondition>().HasData(JsonConvert.DeserializeObject<DetectionCondition[]>(File.ReadAllText(Path.Combine(path, "DetectionCondition.json")), dateTimeConverter));
            modelBuilder.Entity<HorizontalCollectionMethod>().HasData(JsonConvert.DeserializeObject<HorizontalCollectionMethod[]>(File.ReadAllText(Path.Combine(path, "HorizontalCollectionMethod.json")), dateTimeConverter));
            modelBuilder.Entity<HorizontalDatum>().HasData(JsonConvert.DeserializeObject<HorizontalDatum[]>(File.ReadAllText(Path.Combine(path, "HorizontalDatum.json")), dateTimeConverter));
            modelBuilder.Entity<Limit>().HasData(JsonConvert.DeserializeObject<Limit[]>(File.ReadAllText(Path.Combine(path, "Limit.json")), dateTimeConverter));
            modelBuilder.Entity<LocationType>().HasData(JsonConvert.DeserializeObject<LocationType[]>(File.ReadAllText(Path.Combine(path, "LocationType.json")), dateTimeConverter));
            modelBuilder.Entity<MeasureQualifier>().HasData(JsonConvert.DeserializeObject<MeasureQualifier[]>(File.ReadAllText(Path.Combine(path, "MeasureQualifier.json")), dateTimeConverter));
            modelBuilder.Entity<Media>().HasData(JsonConvert.DeserializeObject<Media[]>(File.ReadAllText(Path.Combine(path, "Media.json")), dateTimeConverter));
            modelBuilder.Entity<MethodSpeciation>().HasData(JsonConvert.DeserializeObject<MethodSpeciation[]>(File.ReadAllText(Path.Combine(path, "MethodSpeciation.json")), dateTimeConverter));
            modelBuilder.Entity<Role>().HasData(JsonConvert.DeserializeObject<Role[]>(File.ReadAllText(Path.Combine(path, "Role.json")), dateTimeConverter));
            modelBuilder.Entity<SampleFraction>().HasData(JsonConvert.DeserializeObject<SampleFraction[]>(File.ReadAllText(Path.Combine(path, "SampleFraction.json")), dateTimeConverter));
            modelBuilder.Entity<StatisticalBase>().HasData(JsonConvert.DeserializeObject<StatisticalBase[]>(File.ReadAllText(Path.Combine(path, "StatisticalBase.json")), dateTimeConverter));
            modelBuilder.Entity<Status>().HasData(JsonConvert.DeserializeObject<Status[]>(File.ReadAllText(Path.Combine(path, "Status.json")), dateTimeConverter));
            modelBuilder.Entity<Unit>().HasData(JsonConvert.DeserializeObject<Unit[]>(File.ReadAllText(Path.Combine(path, "Unit.json")), dateTimeConverter));
            modelBuilder.Entity<Resources.ValueType>().HasData(JsonConvert.DeserializeObject<Resources.ValueType[]>(File.ReadAllText(Path.Combine(path, "ValueType.json")), dateTimeConverter));

            base.OnModelCreating(modelBuilder);             
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning Add connectionstring for migrations
            var connectionstring = "User ID=;Password=;Host=;Port=5432;Database=LiquidsDB;Pooling=true;";
            //optionsBuilder.UseNpgsql(connectionstring);
        }
    }
}
