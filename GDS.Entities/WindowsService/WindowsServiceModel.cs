using System;
using System.Collections.Generic;
using GDS.Entities.STMP.CustomerRequirement;

namespace GDS.Entities.WindowsService
{
    public class WindowsServiceModel
    {
    }

    public class ShopLogixPlantListModel
    {
        public string AreaIdList { get; set; }
        public string SaasId { get; set; }
        public int? PlantId { get; set; }
        public int ShopLogixUpdateInterval { get; set; }
        public DateTime? ShopLogixLastUpdatedOn { get; set; }
    }

    public class UpdateOeeInDailyRecapInputModel
    {
        public string MachineId { get; set; }
        public string MachineName { get; set; }
        public double Oee { get; set; }
    }

    public class Metrics
    {
        public double oee { get; set; }
    }

    public class Machine
    {
        public string machineId { get; set; }
        public string machineName { get; set; }
        public Metrics metrics { get; set; }
    }

    public class Result
    {
        public string query { get; set; }
        public List<Machine> machines { get; set; }
    }

    public class RootObject
    {
        public Result result { get; set; }
    }

    public class FileInfoModel
    {
        public DateTime FileCreatedDate { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

    public class SaveQADFromServiceInputModel
    {
        public List<CustomerRequirementQADInputModel> ListCustomerRequirementModel { get; set; }
        public FileInfoModel FileInfoModel { get; set; }
    }
}
