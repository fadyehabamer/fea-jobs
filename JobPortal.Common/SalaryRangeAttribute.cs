using System.ComponentModel.DataAnnotations;

namespace JobPortal.Common
{

    // perform custom validation logic for parameters of a method or a property of a class
    public class SalaryRangeAttribute : ValidationAttribute
    {
        private readonly string _minSalaryPropertyName;

        public SalaryRangeAttribute(string minSalaryPropertyName)
        {
            _minSalaryPropertyName = minSalaryPropertyName;
        }


        // object value: The value to validate.
        // ValidationContext validationContext : give info about obj to validate
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //
            var maxSalaryProperty = validationContext.ObjectType.GetProperty(validationContext.MemberName);
            var minSalaryProperty = validationContext.ObjectType.GetProperty(_minSalaryPropertyName);

            if (maxSalaryProperty != null && minSalaryProperty != null)
            {
                // GetValue: get the value of the property
                var maxSalaryValue = maxSalaryProperty.GetValue(validationContext.ObjectInstance, null);
                var minSalaryValue = minSalaryProperty.GetValue(validationContext.ObjectInstance, null);

                if (maxSalaryValue != null && minSalaryValue != null && (decimal)maxSalaryValue <= (decimal)minSalaryValue)
                {
                    return new ValidationResult("Max salary must be greater than Min salary.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
