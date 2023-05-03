using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CapaLogica
{
    public class ValidatorHelper
    {
        public static bool TryValidateEntity<T>(T entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);
            return isValid;
        }
    }
}
