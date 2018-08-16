namespace GDS.Common
{
    using System;

    /// <summary>
    /// Class ErrorHelper.
    /// </summary>
    public class ErrorHelper
    {
        /// <summary>
        /// Gets the custom error message.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns>Return System.String.</returns>
        public static string GetCustomErrorMessage(Exception ex)
        {
            string message = "System is not able to process your request. Please try after sometime or contact Administrator.";

            ////if (ex.Message.ToLower().Contains("error occurred while sending the request"))
            ////{
            ////    Message = "System is not able to connect ";
            ////}
            return message;
        }
    }
}
