//------------------------------------------------------------------------------
//----- Attribute --------------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2019 WIM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping
//              
//  
//   purpose:   Validation attributes let you specify validation rules for resource properties.
//
//discussion:   https://stackoverflow.com/questions/11959431/custom-validation-attribute-that-compares-the-value-of-my-property-with-another
//
// 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiqwidsDB.Attributes
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        private String _propertyName { get; set; } = string.Empty;
        private Object _desiredValue { get; set; } = null;
        private requiredIfenum _desiredMethod { get; set; }


        public RequiredIfAttribute(String propertyName, requiredIfenum method, Object desiredvalue=null)
        {
            this._propertyName = propertyName;
            this._desiredValue = desiredvalue;
            this._desiredMethod = method;

            this.ErrorMessage = $"{this._propertyName} required if {_propertyName} is {desiredvalue}.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object proprtyvalue = type.GetProperty(_propertyName).GetValue(instance, null);

            switch (_desiredMethod)
            {
                case requiredIfenum.isValue:
                    if (proprtyvalue.ToString() == _desiredValue.ToString() && value.ToString() == "N/A")
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                    break;
                case requiredIfenum.isNotValue:
                    break;
                case requiredIfenum.isNull:
                    break;
                case requiredIfenum.isNotNull:
                    break;
                default:
                    break;
            }

            return ValidationResult.Success;
        }
    }

    public enum requiredIfenum
    {
        isValue,
        isNotValue,
        isNull,
        isNotNull
    }
}
