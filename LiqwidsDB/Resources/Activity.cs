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
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        [Required]
        public int ProjectID { get; set; }
        [Required]
        public int ActivityTypeID { get; set; }
        [Required]
        public int MediaTypeID { get; set; }
        [Required]
        public int CollectionMethodTypeID { get; set; }
        [Required]
        public int CollectionEquipmentTypeID { get; set; }
        public string EquipmentComment { get; set; }
        public double DepthHeightValue { get; set; }
        [RequiredIf("DepthHeightValue", null)]
        public int DepthHeightUnitID { get; set; }

        public Location Location { get; set; }
        public Project Project { get; set; }
        public ActivityType ActivityType { get; set; }
        public MediaType MediaType { get; set; }
        public CollectionMethodType CollectionMethodType { get; set; }
        public CollectionEquipmentType CollectionEquipmentType { get; set; }

        public ICollection<Result> Results { get; set; }


    }
}
