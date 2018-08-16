//-----------------------------------------------------------------------
// <copyright file="ConfigItems.cs" company="Premiere Digital Services">
//     Copyright Premiere Digital Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GDS.Common
{
    using System;
    using System.Configuration;

    /// <summary>
    /// This class will use to get data from web-con-fig file
    /// </summary>
    public static class ConfigItems
    {
        /// <summary>
        /// Numeric Validation
        /// </summary>
       public const string NumericExpression = @"^[0-9]*$";
        
        /// <summary>
        /// allow multiple email address with comma(,) speperation
        /// </summary>
        public const string MultipleEmailRegularExpression = @"(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*,\s*|\s*$))*";
        /// <summary>
        /// The text box regular expression
        /// </summary>
        public const string TextBoxRegularExpression = @"[^<>]*";

        /// <summary>
        /// The regular expression for file name
        /// </summary>
        public const string RegularExpressionForFileName = @"[<>?/\|*:]*";

        /// <summary>
        /// The name validation expression
        /// </summary>
        public const string NameValidationExpression = @"([a-zA-Z0-9&#32;.&amp;amp;&amp;#39;-]+)";

        /// <summary>
        /// The special character validation expression
        /// </summary>
        public const string SpecialCharacterValidationExpression = @"^[^<>.!@#%/']+$";

        /// <summary>
        /// The decimal validation expression
        /// </summary>
        public const string RegularExprssionForDecimal = @"\d+(\.\d{1,2})?";

        /// <summary>
        /// The website validation expression
        /// </summary>
        public const string RegularExprssionForWebsite = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";

        /// <summary>
        /// The longitude validation expression
        /// </summary>
   
        public const string RegularExprssionForLongitude = @"^-?([1]?[0-7][0-9]|[1]?[1-8][0]|[1-9]?[0-9])\.{1}\d{1,6}";

        /// <summary>
        /// The Latitude validation expression
        /// </summary>
   
        public const string RegularExprssionForLatitude = @"^-?([0-8]?[0-9]|[0-9]0)\.{1}\d{1,6}";
        /// <summary>
        /// The Date Time Format Without Second
        /// </summary>
       
        public const string DateTimeFormatWithoutSecond = "MM/dd/yyyy hh:mm tt";

        /// <summary>
        /// The Time Format
        /// </summary>
        public const string TimeFormat = "hh:mm tt";
        
        /// <summary>
        /// Expression for Feedback Question name
        /// </summary> 
        public const string FeedbackQuestionExpression = @"^[a-zA-Z0-9\?. ]+$";// @"([A-Z])|([a-z])|([0-9])|\?|\.|\s";
        
        /// <summary>
        /// Maximum Amount Price
        /// </summary>
        public const double MaxAmount = 9999999.99;

        /// <summary>
        /// Minimum Amount Price
        /// </summary>
        public const double MinAmount = 1.0;


        /// <summary>
        /// Gets the sundance API URL.
        /// </summary>
        /// <value>
        /// The sundance API URL.
        /// </value>
        public static string IACBIAPIUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["IACBIAPIUrl"];
            }
        }

        /// <summary>
        /// Gets the date format.
        /// </summary>
        /// <value>
        /// The date format.
        /// </value>
        public static string DateFormat
        {
            get
            {
                return ConfigurationManager.AppSettings["DateFormat"];
            }
        }

        /// <summary>
        /// Gets the date format grid.
        /// </summary>
        /// <value>
        /// The date format grid.
        /// </value>
        public static string DateFormatGrid
        {
            get
            {
                return "{0: " + ConfigurationManager.AppSettings["DateFormat"] + "}";
            }
        }

        /// <summary>
        /// Gets the date time format.
        /// </summary>
        /// <value>
        /// The date time format.
        /// </value>
        public static string DateTimeFormat
        {
            get
            {
                return ConfigurationManager.AppSettings["DateTimeFormat"];
            }
        }

        /// <summary>
        /// Gets the date time format single digit.
        /// </summary>
        /// <value>The date time format single digit.</value>
        public static string DateTimeFormatSingleDigit
        {
            get
            {
                return ConfigurationManager.AppSettings["DateTimeFormat"].Replace(":ss", string.Empty).Replace("hh", "h").Replace("MM", "M").Replace("dd", "d");
            }
        }

        /// <summary>
        /// Gets the date format for date picker.
        /// </summary>
        /// <value>
        /// The date format for date picker.
        /// </value>
        public static string DateFormatForDatePicker
        {
            get
            {
                return ConfigurationManager.AppSettings["DateFormatForDatePicker"];
            }
        }

        /// <summary>
        /// Gets the date time format grid.
        /// </summary>
        /// <value>
        /// The date time format grid.
        /// </value>
        public static string DateTimeFormatGrid
        {
            get
            {
                return "{0: " + ConfigurationManager.AppSettings["DateTimeFormat"] + "}";
            }
        }

        /// <summary>
        /// Gets the current site URL.
        /// </summary>
        /// <value>
        /// The current site URL.
        /// </value>
        public static string CurrentSiteUrl
        {
            get
            {
                string strUrl = System.Web.HttpContext.Current.Request.Url.Scheme + "://" + System.Web.HttpContext.Current.Request.Url.Authority + System.Web.HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
                return strUrl;
            }
        }
        

        /// <summary>
        /// Gets the number of login attempts.
        /// </summary>
        /// <value>
        /// The number of login attempts.
        /// </value>
        public static string NumberOfLoginAttempts
        {
            get
            {
                return string.Format(ConfigurationManager.AppSettings["NumberOfLoginAttempts"]);
            }
        }

        

        /// <summary>
        /// Converts the UTC to local.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timeDifference">The time difference.</param>
        /// <returns>Return DateTime</returns>
        public static DateTime? ConvertUtcToLocal(DateTime? date, string timeDifference)
        {
            if (date != null)
            {
                int hourDifference = Convert.ToInt32(timeDifference.Split(':')[0]);
                int minDifference = Convert.ToInt32(timeDifference.Split(':')[1]);
                return date.Value.AddHours(-hourDifference).AddMinutes(-minDifference);
            }
            else
            {
                return null;
            }
        }        
    }
}
