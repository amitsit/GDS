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
    
    public partial class ProcessDetail
    {
        public int ProcessId { get; set; }
        public int SubMenuId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public string ProcessModelPath { get; set; }
        public string ProcessDescription { get; set; }
        public string ProcessOwner { get; set; }
        public string ProcessInput { get; set; }
        public string FundamentalOfProcess { get; set; }
        public string ProcessOutput { get; set; }
        public int RegionId { get; set; }
        public bool IsActive { get; set; }
        public short DisplayOrder { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
