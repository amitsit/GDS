﻿using System.Linq;

namespace GDS.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Xml.Serialization;


    /// <summary>
    /// Class Utility.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Serializes to XML.
        /// </summary>
        /// <typeparam name="T">T object</typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="fileName">Name of the file.</param>
        public static void SerializeToXml<T>(T obj, string fileName)
        {
            var ser = new XmlSerializer(typeof(T));
            var fileStream = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fileStream, obj);
            fileStream.Close();
        }

        /// <summary>
        /// De-serializes from XML.
        /// This method takes and exact string to the location included the filename.
        /// </summary> 
        /// <typeparam name="T">T object</typeparam>
        /// <param name="xmlSting">The XML sting.</param>
        /// <returns>return T object</returns>
        public static T DeserializeFromXML<T>(string xmlSting)
        {
            var deserializer = new XmlSerializer(typeof(T));
            var stringReader = new StringReader(xmlSting);
            var deobj = (T)deserializer.Deserialize(stringReader);
            return deobj;
        }

        /// <summary>
        /// De-serializes from XML.
        /// This method takes and exact string to the location included the filename.
        /// </summary>
        /// <typeparam name="T">T object</typeparam>
        /// <param name="xmlSting">The XML sting.</param>
        /// <returns>
        /// return T object
        /// </returns>
        public static T DeserializeFromXMLNew<T>(string xmlSting)
        {
            var ser = new XmlSerializer(typeof(T));
            var wrapper = (T)ser.Deserialize(new StringReader(xmlSting));
            return wrapper;
        }

        /// <summary>
        /// This extension method is broken out so you can use a similar pattern with 
        /// other MetaData elements in the future. This is your base method for each. 
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>return attributes</returns>
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        /// <summary>
        /// This method creates a specific call to the above method, requesting the Description MetaData attribute.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>description for value</returns>
        public static string ToName(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        /// This method creates list from data table
        /// </summary>
        /// <typeparam name="T">The type identifier.</typeparam>
        /// <param name="dt">The Data Table identifier.</param>
        /// <returns>returns list from data table</returns>
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            return (from DataRow row in dt.Rows select GetItem<T>(row)).ToList();
        }

        /// <summary>
        /// This method converts pacific time to universal time
        /// </summary>
        /// <param name="date">The pacific date identifier.</param>
        /// <returns>returns universal equivalent date</returns>
        public static DateTime ConvertTimeToUtc(DateTime date)
        {
            TimeZoneInfo pstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            return TimeZoneInfo.ConvertTimeToUtc(date, pstTimeZone);
        }

        /// <summary>
        /// Gets the pacific base off set.
        /// </summary>
        /// <returns>returns pacific base off set</returns>
        public static string GetPacificBaseOffSet()
        {
            var pacificBaseOffSet = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time").BaseUtcOffset;
            string offSet = "{0}:{1}";
            return string.Format(offSet, pacificBaseOffSet.Hours.ToString("00"), pacificBaseOffSet.Minutes.ToString("00"));
        }

        /// <summary>
        /// Removes the entity framework metadata.
        /// </summary>
        /// <param name="entityFrameworkConnection">The entity framework connection.</param>
        /// <returns>returns ADIO.NET Connection string</returns>
        public static string RemoveEntityFrameworkMetadata(string entityFrameworkConnection)
        {
            int start = entityFrameworkConnection.IndexOf("\"", StringComparison.OrdinalIgnoreCase);
            int end = entityFrameworkConnection.LastIndexOf("\"", StringComparison.OrdinalIgnoreCase);
            start++;
            int length = end - start;

            string pureSqlConnection = entityFrameworkConnection.Substring(start, length);
            return pureSqlConnection;
        }

        /// <summary>
        /// This method creates object from 
        /// </summary>
        /// <typeparam name="T">The type identifier.</typeparam>
        /// <param name="dr">he Data Row identifier.</param>
        /// <returns>returns object for the type</returns>
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if (dr[column.ColumnName] != DBNull.Value)
                        {
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        }

                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return obj;
        }


        public static List<SelectListItem> GetTimingListValues()
        {
            var getTiming = new List<SelectListItem>();
            var k = 12;
            for (var i = 0; i < 24; i++)
            {
                for (var j = 0; j <= 45; j = j + 15)
                {

                    getTiming.Add(new SelectListItem() { Text = k.ToString("D2") + ":" + j.ToString("D2") + (i < 12 ? " AM" : " PM"), Value = i + "." + j.ToString("D2") });

                }

                if (k == 12)
                {
                    k = 1;
                }
                else

                {
                    k++;
                }
            }

            //return new List<SelectListItem>()
            //{
            //    for(int i=0;i<24;i++)
            //    {
            //        new   SelectListItem(){ Text="12:00 AM",Value="0"}
            //    }
            return getTiming;
            //};
        }

        /// <summary>
        /// Converts list of objects to datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static DataTable ConvertListToDataTable<T>(List<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        /// <summary>
        /// HTTPs the client request response synchronize.
        /// </summary>
        /// <typeparam name="T">T object</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="uri">The URI.</param>
        /// <returns>return T object</returns>
        public static T HttpClientRequestReponceSync<T>(T value, string baseAddress, string uri)
        {
            CustomDelegatingHandler customDelegatingHandler = new CustomDelegatingHandler();
            var client = HttpClientFactory.Create(customDelegatingHandler);
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var httpresult = client.GetAsync(uri).Result;

            if (httpresult.IsSuccessStatusCode)
            {
                var result = httpresult.Content.ReadAsAsync<T>();
                return (T)Convert.ChangeType(result.Result, typeof(T));
            }

            return default(T);
        }
    }

    public class CustomDelegatingHandler : DelegatingHandler
    {

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            HttpResponseMessage response = null;

            var authenticationkey = Convert.ToString(HttpContext.Current.Session["AuthenticationKey"]);
            //var authenticationguestkey = Convert.ToString(HttpContext.Current.Session["AuthenticationGuestKey"]);

            // var key = authenticationguestkey + '|' + authenticationkey;
            request.Headers.Authorization = new AuthenticationHeaderValue("amx", authenticationkey);

            response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }

    /////// <summary>
    /////// Serializes the string to XML.
    /////// </summary>
    /////// <typeparam name="T"></typeparam>
    /////// <param name="obj">The object.</param>
    /////// <returns></returns>
    ////public static string SerializeStringToXml<T>(T obj)
    ////{
    ////    System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
    ////    MemoryStream fileStream = new MemoryStream();
    ////    ser.Serialize(fileStream, obj);
    ////    byte[] byteStream = new byte[fileStream.Length];
    ////    fileStream.Write(byteStream, 0, (int)fileStream.Length);
    ////    return byteStream.ToString();
    ////}


    ////[XmlRoot(ElementName = "FieldOptions")]
    ////public class FieldOptions
    ////{
    ////    /// <summary>
    ////    /// Gets or sets the identifier.
    ////    /// </summary>
    ////    /// <value>
    ////    /// The identifier.
    ////    /// </value>
    ////    [XmlElement(ElementName = "ID")]
    ////    public string ID { get; set; }

    ////    /// <summary>
    ////    /// Gets or sets the value.
    ////    /// </summary>
    ////    /// <value>
    ////    /// The value.
    ////    /// </value>
    ////    [XmlElement(ElementName = "Value")]
    ////    public string Value { get; set; }

    ////    /// <summary>
    ////    /// Gets or sets the is default.
    ////    /// </summary>
    ////    /// <value>
    ////    /// The is default.
    ////    /// </value>
    ////    [XmlElement(ElementName = "IsDefault")]
    ////    public string IsDefault { get; set; }
    ////}       
}
