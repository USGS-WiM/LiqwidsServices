//------------------------------------------------------------------------------
//----- Resource ---------------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2019 WIM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping
//              
//  
//   purpose:   Simple Plain Old Class Object (POCO) 
//
//discussion:   POCO's arn't derived from special base classed nor do they return any special types for their properties.
//              
//
//     

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LiqwidsDB.Attributes;

namespace LiqwidsDB.Resources
{
    public partial class Location
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public int HorizontalCollectionMethodTypeID { get; set; }
        [RequiredIf("HorizontalCollectionMethodTypeID",1)] //1:interpolation map
        public double MapScale { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FIPSStateID { get; set; }
        [Required]
        public string FIPSCountyID { get; set; }
        [Required]
        public int LocationTypeID { get; set; }
        public bool? OnTribalLand { get; set; }
        [RequiredIf("OnTribalLand",true)]
        public string TribalLandName { get; set; }
        public string Comments { get; set; }

        public HorizontalCollectionMethodType GetHorizontalCollectionMethod { get; set; }
        public HorizontalDatumType HorizontalDatum { get; set; }
        public LocationType LocationType { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}
