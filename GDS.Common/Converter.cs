using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace GDS.Services
{
  public class Converter
    {
        public static DataTable ToDataTable<T>(List<T> items, bool needToOrder = false, string csvExceptProperties = "")
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            //DataColumn dc = null;
            var Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => string.IsNullOrEmpty(csvExceptProperties) || !csvExceptProperties.Split(',').ToList().Any(x => x == p.Name)).ToList();
            if (needToOrder)
            {
                Props = Props.OrderBy(p => p.Name).ToList();
            }

            Props.ForEach(
                o =>
                {
                   // dc = new DataColumn();
                    //dc.ColumnName = o.Name;
                    //dc.DataType = o.PropertyType;
                    //Setting column names as Property names  
                    //dataTable.Columns.Add(dc);
                    dataTable.Columns.Add(o.Name, Nullable.GetUnderlyingType(o.PropertyType) ?? o.PropertyType);
                });

            items.AsEnumerable().ToList().ForEach(
                o =>
                {
                    var values = new object[Props.Count()];
                    for (int i = 0; i < Props.Count(); i++)
                    {
                        values[i] = Props[i].GetValue(o, null);
                    }
                    dataTable.Rows.Add(values);
                });
            return dataTable;
        }

    }
}
