//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GDS.Data.Databases
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProcessDocument
    {
        public int DocumentId { get; set; }
        public string DocumentCode { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentPath { get; set; }
        public System.DateTime ReleaseDate { get; set; }
        public int RegionId { get; set; }
        public bool IsActive { get; set; }
        public short DisplayOrder { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
