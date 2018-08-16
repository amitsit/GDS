using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.MoldFlowSetup
{
    public class MoldFlowInsertFileModel
    {
        public int? UserId { get; set; }
        public string MoldFlowSetup_GeneralInfo_PlantName { get; set; }
        public string MoldFlowSetup_GeneralInfo_MoldNumber { get; set; }
        public string MoldFlowSetup_GeneralInfo_JobName { get; set; }
        public string MoldFlowSetup_GeneralInfo_PressNumber { get; set; }
        public string MoldFlowSetup_GeneralInfo_Date { get; set; }
        public string MoldFlowSetup_GeneralInfo_MaterialName { get; set; }

        public double? MoldFlowSetup_MoldTemp_Stationary { get; set; }
        public double? MoldFlowSetup_MoldTemp_Moveable { get; set; }

        public double? MoldFlowSetup_ShotPosition_ShotSize { get; set; }
        public double? MoldFlowSetup_ShotPosition_Transfer { get; set; }
        public double? MoldFlowSetup_ShotPosition_Cushion { get; set; }
        public double? MoldFlowSetup_ShotPosition_CubicVolumnTransfer { get; set; }
        public double? MoldFlowSetup_ShotPosition_TotalCubicVolumn { get; set; }
        public double? MoldFlowSetup_ShotPosition_ShrinkRateMoldIsCutTo { get; set; }
        public double? MoldFlowSetup_ShotPosition_MeltSolidRatio { get; set; }
        public double? MoldFlowSetup_ShotPosition_VolumefromAnalysisin3 { get; set; }
        public double? MoldFlowSetup_ShotPosition_MeltDensity { get; set; }
        public double? MoldFlowSetup_ShotPosition_SolidDensity { get; set; }

        public double? MoldFlow_Pressure_HydraulicTransfer { get; set; }
        public double? MoldFlow_Pressure_PlasticTransfer { get; set; }
        public double? MoldFlow_Pressure_HydraulicPack { get; set; }
        public double? MoldFlow_Pressure_PlasticPack { get; set; }
        public double? MoldFlow_Pressure_HydaulicHold { get; set; }
        public double? MoldFlow_Pressure_PlasticHold { get; set; }
        public double? MoldFlow_Pressure_HydaulicTonnage { get; set; }
        public double? MoldFlow_Pressure_PlasticTonnage { get; set; }

        public double? MoldFlow_Timer_Fill { get; set; }
        public double? MoldFlow_Timer_Pack { get; set; }
        public double? MoldFlow_Timer_Hold { get; set; }
        public double? MoldFlow_Timer_Cooling { get; set; }
        public string VIPOfAnalysis { get; set; }


        public double? MoldFlowGeneralInfoId { get; set; }
        public double? MeltTemp { get; set; }
        public double? MoldCavitySideTemp { get; set; }
        public double? MoldCoreSideTemp { get; set; }
        public double? TimeAtTheEndOfFilling { get; set; }
        public double? SwitchOverPressure { get; set; }
        public double? MaximumInjectionPressure { get; set; }
        public double? PackingPhase { get; set; }
        public double? ClampForceMaximum { get; set; }
        public double? MaxClampForceRequired { get; set; }
        public double? NominalFlowRate { get; set; }
        public double? TotalVolumeOfThePartsAndRunners { get; set; }
        public double? VolumeFilledInitially { get; set; }
        public double? VolumeToBeFilled { get; set; }
        public double? TotalProjectedArea { get; set; }
        public double? TotalPartWeightExcludingRunners { get; set; }
        public double? TotalPartWeightMaximum { get; set; }
        public double? TotalWeightPartsPlusRunnersFillWeight { get; set; }
        public double? TotalWeightExcludingRunnersFillWeight { get; set; }





        public List<ValveGatePositionsCell> Valvegatelist { get; set; }
        
        public class ValveGatePositionsCell
        {
            public long ValveGatePositionId { get; set; }
            public long MoldFlowGeneralInfoId { get; set; }
            public byte Zone { get; set; }
            public string ZoneName { get; set; }
            public string OpenVolumePercentage { get; set; }
            public string CloseVolumePercentage { get; set; }
            public string OpenPosition { get; set; }
            public string ClosePosition { get; set; }
            public string PackTime { get; set; }
            public double? VIPVolume { get; set; }
            public double? ShrinkFactor { get; set; }
            public int LoggedInUserId { get; set; }
        }

       
    }
}
