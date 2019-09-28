using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.CustomValidation
{
    public class YearAttribute : ValidationAttribute
    {
        private readonly string _comprassionProperty;

        public YearAttribute(string comprassionProperty)
        {
            if (comprassionProperty != null)
            {
                _comprassionProperty = comprassionProperty;
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessage;
            var currentValue = (int)value;
            var property = validationContext.ObjectType.GetProperty(_comprassionProperty);
            var propertyValue = property.GetValue(validationContext.ObjectInstance);

            if (propertyValue == null)
                return ValidationResult.Success;

            var comprassionProperty = (int)propertyValue;

            if (currentValue > comprassionProperty)
                return new ValidationResult(ErrorMessage);
            

            return ValidationResult.Success;
        }
    }
}