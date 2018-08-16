using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.CoverPage
{
    public class CoverPageDataCountModel
    {
        public int BICVerificationDocumentDataCount { get; set; }
        public int PartAndMoldTemperatureMapDataCount { get; set; }
        public int CheckRingStudyDataCount { get; set; }
        public int GateSealDataCount { get; set; }
        public int TonnageCalculatorDataCount { get; set; }
        public int WaterSupplyCalculatorDataCount { get; set; }
        public int GPMCalculatorDataCount { get; set; }
        public int RecoveryTimeStudyDataCount { get; set; }
        public int CavityBalanceStudyDataCount { get; set; }
        public int MiscCalculatorDataCount { get; set; }
        public int PlasticPressureLossesColdRunnerDataCount { get; set; }
        public int PlasticPressureLossesHotDropToColdRunnerDataCount { get; set; }
        public int PlasticPressureLossesHotRunnerDataCount { get; set; }
        public int WaterFlowDataCount { get; set; }
        public int BarrelHeatDataCount { get; set; }
        public int MachineLinearityDataCount { get; set; }
        public int DOEDataCount { get; set; }
        public int LinearityDataCount { get; set; }
        public int IMPDBTNProductionCount { get; set; }
        public int MoldFlowSetupHeaderId { get; set; }
        public int ProgramId { get; set; }
        public int InputDataId { get; set; }
        public string MoldNumber { get; set; }
        public int InitDataGeneralInfoId { get; set; }
        
    }
}
