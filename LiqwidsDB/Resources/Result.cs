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

using System;
using LiqwidsDB.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiqwidsDB.Resources
{
    public partial class Result
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string ActivityID { get; set; }
        [Required]
        public int CharacteristicTypeID { get; set; }
        //[Required] characteristic specific
        public int MethodSpeciationTypeID { get; set; }
        [RequiredIf("Value", null)]
        public int DetectionConditionTypeID { get; set; }
        public double Value { get; set; }
        [RequiredIf("Value", null)]
        public int UnitTypeID { get; set; }
        [Required]
        public int MeasureQualifierID { get; set; }
        [RequiredIf("CharacteristicTypeID",null)]
        public int SampleFractionTypeID { get; set; }
        [RequiredIf("Value", null)]
        public int StatusTypeID { get; set; }
        public int StatisticalBaseCodeID { get; set; }
        public int ValueTypeID { get; set; }
        public int AnalyticalMethodID { get; set; }
        public DateTime AnalysisStartDate { get; set; }
        public string Comments { get; set; }

        public CharacteristicType CharacteristicType { get; set; }
        public MethodSpeciationType GetMethodSpeciationType { get; set; }
        public SampleFractionType SampleFractionType { get; set; }
        public ValueType ValueType { get; set; }
        public StatusType StatusType { get; set; }
        public StatisticalBaseType StatisticalBaseType { get; set; }
        public AnalyticalMethodType AnalyticalMethodType { get; set; }
        public UnitType UnitType { get; set; }
        public DetectionLimit DetectionLimit { get; set; }
        public MeasureQualifierType MeasureQualifierType { get; set; }
        public DetectionConditionType DetectionConditionType { get; set; }
    }
    
}
