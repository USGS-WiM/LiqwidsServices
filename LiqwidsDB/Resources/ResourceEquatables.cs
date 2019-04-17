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
                this.MediaTypeID == other.MediaTypeID && this.CollectionMethodTypeID == other.CollectionMethodTypeID &&
                this.CollectionEquipmentTypeID == other.CollectionEquipmentTypeID;

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
                    this.ProjectID + this.ActivityTypeID + this.MediaTypeID + 
                    this.CollectionEquipmentTypeID + this.CollectionMethodTypeID).GetHashCode();
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
    public partial class AnalyticalMethodType : IEquatable<AnalyticalMethodType>
    {
        public bool Equals(AnalyticalMethodType other)
        {
            return String.Equals(this.Identifier, other.Identifier) &&
                string.Equals(this.Context,other.Context);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as AnalyticalMethodType);
        }
        public override int GetHashCode()
        {
            return (this.Identifier+this.Context).GetHashCode();
        }
    }
    public partial class CharacteristicType : IEquatable<CharacteristicType>
    {
        public bool Equals(CharacteristicType other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as CharacteristicType);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class CollectionEquipmentType : IEquatable<CollectionEquipmentType>
    {
        public bool Equals(CollectionEquipmentType other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as CollectionEquipmentType);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class CollectionMethodType : IEquatable<CollectionMethodType>
    {
        public bool Equals(CollectionMethodType other)
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
            return Equals(obj as CollectionMethodType);
        }
        public override int GetHashCode()
        {
            return (this.Identifier+this.Context+this.Name).GetHashCode();
        }
    }
    public partial class DetectionConditionType : IEquatable<DetectionConditionType>
    {
        public bool Equals(DetectionConditionType other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as DetectionConditionType);
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
                this.LimitTypeID == other.LimitTypeID &&
                this.UnitTypeID == other.UnitTypeID &&
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
            return (this.ResultID+this.LimitTypeID+this.UnitTypeID+this.LimitMeasure).GetHashCode();
        }
    }
    public partial class HorizontalCollectionMethodType : IEquatable<HorizontalCollectionMethodType>
    {
        public bool Equals(HorizontalCollectionMethodType other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as HorizontalCollectionMethodType);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class HorizontalDatumType : IEquatable<HorizontalDatumType>
    {
        public bool Equals(HorizontalDatumType other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as HorizontalDatumType);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class LimitType : IEquatable<LimitType>
    {
        public bool Equals(LimitType other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as LimitType);
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
                this.HorizontalCollectionMethodTypeID == other.HorizontalCollectionMethodTypeID &&
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
            return (this.Latitude + this.Longitude+ this.HorizontalCollectionMethodTypeID+
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
    public partial class MeasureQualifierType : IEquatable<MeasureQualifierType>
    {
        public bool Equals(MeasureQualifierType other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as MeasureQualifierType);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class MediaType : IEquatable<MediaType>
    {
        public bool Equals(MediaType other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as MediaType);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class MethodSpeciationType : IEquatable<MethodSpeciationType>
    {
        public bool Equals(MethodSpeciationType other)
        {
            return String.Equals(this.Name, other.Name) &&
                this.CharacteristicTypeID == other.CharacteristicTypeID;

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as MethodSpeciationType);
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
                this.CharacteristicTypeID == other.CharacteristicTypeID &&
                this.MethodSpeciationTypeID == other.MethodSpeciationTypeID;

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
            return (this.ActivityID + this.CharacteristicTypeID).GetHashCode();
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
    public partial class SampleFractionType : IEquatable<SampleFractionType>
    {
        public bool Equals(SampleFractionType other)
        {
            return String.Equals(this.Name, other.Name);

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as SampleFractionType);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class StatisticalBaseType : IEquatable<StatisticalBaseType>
    {
        public bool Equals(StatisticalBaseType other)
        {
            return String.Equals(this.Code, other.Code);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as StatisticalBaseType);
        }
        public override int GetHashCode()
        {
            return (this.Code).GetHashCode();
        }
    }
    public partial class StatusType : IEquatable<StatusType>
    {
        public bool Equals(StatusType other)
        {
            return String.Equals(this.Name, other.Name);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as StatusType);
        }
        public override int GetHashCode()
        {
            return (this.Name).GetHashCode();
        }
    }
    public partial class UnitType : IEquatable<UnitType>
    {
        public bool Equals(UnitType other)
        {
            return String.Equals(this.Name, other.Name) &&
                String.Equals(this.Abbreviation,other.Abbreviation);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as UnitType);
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
