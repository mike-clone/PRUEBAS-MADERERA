using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CapaLogica
{
    public class ValidatorHelper
    {
        public static bool TryValidateEntity<T>(T entity, out List<string>lista) {
        var validationContext = new ValidationContext(entity);
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);
        lista = validationResults.Select(r => r.ErrorMessage).ToList();
        return isValid;
        }

        public bool ValidateNonEmpty<T>(params T[] values)
        {
            foreach (var value in values)
            {
                var validationContext = new ValidationContext(value);
                var validationResults = new List<ValidationResult>();

                if (!Validator.TryValidateObject(value, validationContext, validationResults, true))
                {
                    return false;
                }
            }

            return true;
        }

        public static string aString(List<string>lista)
        {
            string errors = string.Empty;
            foreach(var value in lista) { 
            errors += value;
            }
            return errors;
        }

    }
}
