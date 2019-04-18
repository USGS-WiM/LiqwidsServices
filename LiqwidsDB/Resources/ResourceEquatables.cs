//------------------------------------------------------------------------------
//----- Equality ---------------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2018 WIM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping
//              
//  
//   purpose:   Overrides Equatable
//
//discussion:   https://blogs.msdn.microsoft.com/ericlippert/2011/02/28/guidelines-and-rules-for-gethashcode/    
//              http://www.aaronstannard.com/overriding-equality-in-dotnet/
//
//              var hashCode = 13;
//              hashCode = (hashCode * 397) ^ MyNum;
//              var myStrHashCode = !string.IsNullOrEmpty(MyStr) ?
//                                      MyStr.GetHashCode() : 0;
//              hashCode = (hashCode * 397) ^ MyStr;
//              hashCode = (hashCode * 397) ^ Time.GetHashCode();
// 
using System;

namespace LiqwidsDB.Resources
{
    public partial class Activity : IEquatable<Activity>
    {
        public bool Equals(Activity other)
        {
            return this.LocationID == other.LocationID &&
                String.Equals(this.UniversalUniqueID, other.UniversalUniqueID) &&
                DateTime.Equals(this.StartDateTime,other.StartDateTime) &&
                this.ProjectID == other.ProjectID && this.ActivityTypeID==other.ActivityTypeID &&
                this.MediaID == other.MediaID && this.CollectionMethodID == other.CollectionMethodID &&
                this.CollectionEquipmentID == other.CollectionEquipmentID;

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Activity);
        }
        public override int GetHashCode()
        {
            return (this.LocationID + UniversalUniqueID + this.StartDateTime + 
                    this.ProjectID + this.ActivityTypeID + this.MediaID + 
                    this.CollectionEquipmentID + this.CollectionMethodID).GetHashCode();
        }
    }
    public partial class ActivityType : IEquatable<ActivityType>
    {
        public bool Equals(ActivityType other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as ActivityType);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class AnalyticalMethod : IEquatable<AnalyticalMethod>
    {
        public bool Equals(AnalyticalMethod other)
        {
            return String.Equals(this.Identifier, other.Identifier) &&
                string.Equals(this.Context,other.Context);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as AnalyticalMethod);
        }
        public override int GetHashCode()
        {
            return (this.Identifier+this.Context).GetHashCode();
        }
    }
    public partial class Characteristic : IEquatable<Characteristic>
    {
        public bool Equals(Characteristic other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Characteristic);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class CollectionEquipment : IEquatable<CollectionEquipment>
    {
        public bool Equals(CollectionEquipment other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as CollectionEquipment);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class CollectionMethod : IEquatable<CollectionMethod>
    {
        public bool Equals(CollectionMethod other)
        {
            return String.Equals(this.Identifier, other.Identifier)&&
                string.Equals(this.Context,other.Context)&&
                string.Equals(this.Name,other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as CollectionMethod);
        }
        public override int GetHashCode()
        {
            return (this.Identifier+this.Context+this.Name).GetHashCode();
        }
    }
    public partial class DetectionCondition : IEquatable<DetectionCondition>
    {
        public bool Equals(DetectionCondition other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as DetectionCondition);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class DetectionLimit : IEquatable<DetectionLimit>
    {
        public bool Equals(DetectionLimit other)
        {
            return this.ResultID == other.ResultID &&
                this.LimitID == other.LimitID &&
                this.UnitID == other.UnitID &&
                this.LimitMeasure == other.LimitMeasure;


        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as DetectionLimit);
        }
        public override int GetHashCode()
        {
            return (this.ResultID+this.LimitID+this.UnitID+this.LimitMeasure).GetHashCode();
        }
    }
    public partial class HorizontalCollectionMethod : IEquatable<HorizontalCollectionMethod>
    {
        public bool Equals(HorizontalCollectionMethod other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as HorizontalCollectionMethod);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class HorizontalDatum : IEquatable<HorizontalDatum>
    {
        public bool Equals(HorizontalDatum other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as HorizontalDatum);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class Limit : IEquatable<Limit>
    {
        public bool Equals(Limit other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Limit);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class Location : IEquatable<Location>
    {
        public bool Equals(Location other)
        {
            return this.Latitude == other.Latitude &&
                this.Longitude == other.Longitude &&
                this.HorizontalCollectionMethodID == other.HorizontalCollectionMethodID &&
                String.Equals(this.Name, other.Name) &&
                String.Equals(this.FIPSStateID, other.FIPSStateID)&&
                String.Equals(this.FIPSCountyID, other.FIPSCountyID) &&
                this.LocationTypeID == other.LocationTypeID;

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Location);
        }
        public override int GetHashCode()
        {
            return (this.Latitude + this.Longitude+ this.HorizontalCollectionMethodID+
                this.Name + this.FIPSStateID + this.FIPSCountyID+ this.LocationTypeID).GetHashCode();
        }
    }
    public partial class LocationType : IEquatable<LocationType>
    {
        public bool Equals(LocationType other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as LocationType);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class MeasureQualifier : IEquatable<MeasureQualifier>
    {
        public bool Equals(MeasureQualifier other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as MeasureQualifier);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class Media : IEquatable<Media>
    {
        public bool Equals(Media other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Media);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class MethodSpeciation : IEquatable<MethodSpeciation>
    {
        public bool Equals(MethodSpeciation other)
        {
            return String.Equals(this.Name, other.Name) &&
                this.CharacteristicTypeID == other.CharacteristicTypeID;

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as MethodSpeciation);
        }
        public override int GetHashCode()
        {
            return (this.Name + this.CharacteristicTypeID).GetHashCode();
        }
    }
    public partial class Organization : IEquatable<Organization>
    {
        public bool Equals(Organization other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Organization);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class Project : IEquatable<Project>
    {
        public bool Equals(Project other)
        {
            return String.Equals(this.Name, other.Name) &&
                this.ManagerID == other.ManagerID;

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Project);
        }
        public override int GetHashCode()
        {
            return (this.Name + ManagerID).GetHashCode();
        }
    }
    public partial class Result : IEquatable<Result>
    {
        public bool Equals(Result other)
        {
#warning Needs more work done here
            return this.ActivityID == other.ActivityID &&
                this.CharacteristicID == other.CharacteristicID &&
                this.MethodSpeciationID == other.MethodSpeciationID;

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Result);
        }
        public override int GetHashCode()
        {
            return (this.ActivityID + this.CharacteristicID).GetHashCode();
        }
    }
    public partial class Role : IEquatable<Role>
    {
        public bool Equals(Role other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Role);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class SampleFraction : IEquatable<SampleFraction>
    {
        public bool Equals(SampleFraction other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as SampleFraction);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class StatisticalBase : IEquatable<StatisticalBase>
    {
        public bool Equals(StatisticalBase other)
        {
            return String.Equals(this.Code, other.Code);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as StatisticalBase);
        }
        public override int GetHashCode()
        {
            return (this.Code).GetHashCode();
        }
    }
    public partial class Status : IEquatable<Status>
    {
        public bool Equals(Status other)
        {
            return String.Equals(this.Name, other.Name);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Status);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class Unit : IEquatable<Unit>
    {
        public bool Equals(Unit other)
        {
            return String.Equals(this.Name, other.Name) &&
                String.Equals(this.Abbreviation,other.Abbreviation);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Unit);
        }
        public override int GetHashCode()
        {
            return (this.Name + this.Abbreviation).GetHashCode();
        }
    }
    public partial class User : IEquatable<User>
    {
        public bool Equals(User other)
        {
            return String.Equals(this.FirstName, other.FirstName) &&
                String.Equals(this.LastName, other.LastName) &&
                String.Equals(this.Email, other.Email) &&
                String.Equals(this.Username, other.Username) &&
                this.RoleID == other.RoleID;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as User);
        }
        public override int GetHashCode()
        {
            return (this.FirstName + this.LastName +Email+Username+RoleID).GetHashCode();
        }
    }
    public partial class ValueType : IEquatable<ValueType>
    {
        public bool Equals(ValueType other)
        {
            return String.Equals(this.Name, other.Name);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as ValueType);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
}
