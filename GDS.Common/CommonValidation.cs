﻿namespace GDS.Common
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This class will use to validate given value 
    /// </summary>
    public class CommonValidation
    {
        /// <summary>
        /// Manually the model validation.
        /// </summary>
        /// <typeparam name="T">The type of the T</typeparam>
        /// <typeparam name="TM">The type of the m.</typeparam>
        /// <param name="tvalue">The t value.</param>
        /// <param name="tmvalue">The m value.</param>
        /// <returns>List ValidationResult</returns>
        public static List<ValidationResult> ManuallyModelValidation<T, TM>(T tvalue, TM tmvalue)
        {            
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(T), typeof(TM)), typeof(T));
            var validationResults = new List<ValidationResult>();
            return validationResults;
        }
    }
}
