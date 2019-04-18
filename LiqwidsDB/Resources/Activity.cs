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

using LiqwidsDB.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiqwidsDB.Resources
{
    public partial class Activity
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string UniversalUniqueID { get; set; }
        [Required]
        public int LocationID { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; } //(Date, time and time zone format optional)
        public DateTime? EndDateTime { get; set; } //(Date, time and time zone format optional)

        [Required]
        public int ProjectID { get; set; }
        [Required]
        public int ActivityTypeID { get; set; }
        [Required]
        public int MediaID { get; set; }
        public int CollectionMethodID { get; set; }
        [RequiredIf("CollectionMethodID",requiredIfenum.isNotNull)]//required if sample collection method is not null
        public int CollectionEquipmentID { get; set; }
        public string EquipmentComment { get; set; }
        public double DepthHeightValue { get; set; }
        [RequiredIf("DepthHeightValue", requiredIfenum.isNotNull)]//required if depth height value is not null
        public int DepthHeightUnitID { get; set; }

        public Location Location { get; set; }
        public Project Project { get; set; }
        public ActivityType ActivityType { get; set; }
        public Media Media { get; set; }
        public CollectionMethod CollectionMethod { get; set; }
        public CollectionEquipment CollectionEquipment { get; set; }

        public ICollection<Result> Results { get; set; }
    }
}
