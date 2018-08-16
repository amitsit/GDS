

using GDS.Services.SMOM.CheckRingStudyWeight;
using GDS.Services.SMOM.GateSeal;
using GDS.Services.SMOM.GPMCalculator;
using GDS.Services.SMOM.LinearityResults;
using GDS.Services.SMOM.MachineLinearity;
using GDS.Services.SMOM.RheologyCurve;
using GDS.Services.SMOM.WaterFlow;
using GDS.Services.STMP.CustomerRequirement;
using GDS.Services.SMOM.PlasticPressureLosses;
using GDS.Services.SMOM.InitialDataConversionSetup;
using GDS.Services.STMP.LaborPlantSpecific;
using GDS.Services.STMP.MainDashboard;
using GDS.Services.Dashboard;


namespace GDS.Services
{
    using Autofac;
    using Caching;
    using STMP.InputData;
    using Data.Repository;
    using STMP.PlantEquipmentList;
    using Master.Region;
    using Master.Program;
    using Master.IACCycleGoal;
    using STMP.DailyRecapRap_PressParameters;
    using STMP.STMP_Configuration;
    using Master.Plant;
    using STMP.PressBreakDown;
    using Master.BICCycleKeyElement;
    using Master.CTPartThicknessAddition;
    using Master.TroubleShooter;
    using Master.Role;
    using Master.TLNSavingReport;
    using Master.MaterialType;
    using Master.State;
    using Master.WallStock;
    using Master.Material;
    using Master.UtilityConfiguration;
    using IMIP.BICVerificationDocument;
    using SMOM.BarrelHeats;
    using SMOM.PartAndMoldTemperatureMapping;
    using SMOM.WaterSupplyCalculator;
    using STMP.ManningUtilization;
    using SMOM.CoverPage;
    using SMOM.TonnageCalculator;
    using Master.Country;
    using Master.User;
    using IMIP.ImprovementPlanAction;
    using SMOM.RecoveryTimeStudy;
    using Master.ColorCodeScheme;
    using SMOM.CavityBalance;
    using SMOM.MiscCalculator;
    using SMOM.CorpIMPD;
    using SMOM.MaterialData;
    using SMOM.CorpIMPD.FinalProcessDataPositionDetails;
    using SMOM.MoldFlowSetup;
    using SMOM.ProcessReport;
    using SMOM.ConversionSetup;
    using STMP.CapacityChart;
    using STMP.ReplacementSavings;
    using STMP.MROData;
    using STMP.LaborPlant;
    using Master.PlantLaborCost;
    using Master.PressBreakDownOrder;
    using SMOM.DOE;
    using Master.DOEVariableMaster;
    using WindowsServices;

    /// <summary>
    /// Class ServiceDependencyRegister contains all ServiceDependencyRegister related methods and variable.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class ServiceDependencyRegister
    {
        /// <summary>
        /// Resolves the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static void Resolve(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(DBAccess1<>)).As(typeof(IDBAccess<>)).InstancePerDependency();
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("GDS_cache_static").SingleInstance();
            //builder.RegisterType<SunDance.Data.Databases.SundanceEntities>().As<SunDance.Data.Databases.IDbContext>().InstancePerDependency();

            ////  TitleService
            //builder.RegisterType<UserService>().As<IUserService>()
            //    .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("Sundance_cache_static")).InstancePerDependency();

            builder.RegisterType<InputDataService>().As<IInputDataService>().InstancePerDependency();
            builder.RegisterType<CountryService>().As<ICountryService>().InstancePerDependency();
            builder.RegisterType<PlantEquipmentListService>().As<IPlantEquipmentListService>().InstancePerDependency();
            builder.RegisterType<RegionService>().As<IRegionService>().InstancePerDependency();
            builder.RegisterType<ProgramService>().As<IProgramService>().InstancePerDependency();
            builder.RegisterType<IACCycleGoalService>().As<IACCycleGoalService>().InstancePerDependency();
            builder.RegisterType<DailyRecapRap_PressParametersService>().As<IDailyRecapRap_PressParametersService>().InstancePerDependency();
            builder.RegisterType<CustomerRequirementService>().As<ICustomerRequirementService>().InstancePerDependency();
            builder.RegisterType<PlantService>().As<IPlantService>().InstancePerDependency();
            builder.RegisterType<PressBreakDownService>().As<IPressBreakDownService>().InstancePerDependency();
            builder.RegisterType<StmpConfiguration>().As<IStmpConfigurationService>().InstancePerDependency();
            builder.RegisterType<BICCycleKeyElementService>().As<IBICCycleKeyElementService>().InstancePerDependency();
            builder.RegisterType<CTPartThicknessAdditionService>().As<ICTPartThicknessAdditionService>().InstancePerDependency();
            builder.RegisterType<TroubleShooterService>().As<ITroubleShooterService>().InstancePerDependency();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerDependency();
            builder.RegisterType<TLNSavingReportService>().As<ITLNSavingReportService>().InstancePerDependency();
            builder.RegisterType<MaterialTypeService>().As<IMaterialTypeService>().InstancePerDependency();
            builder.RegisterType<StateService>().As<IStateService>().InstancePerDependency();
            builder.RegisterType<WallStockService>().As<IWallStockService>().InstancePerDependency();
            builder.RegisterType<MaterialService>().As<IMaterialService>().InstancePerDependency();
            builder.RegisterType<UtilityConfigurationService>().As<IUtilityConfigurationService>().InstancePerDependency();
            builder.RegisterType<BICVerificationDocumentService>().As<IBICVerificationDocumentService>().InstancePerDependency();
            builder.RegisterType<MachineLinearityService>().As<IMachineLinearityService>().InstancePerDependency();
            builder.RegisterType<CheckRingStudyWeightService>().As<ICheckRingStudyWeightService>().InstancePerDependency();
            builder.RegisterType<GateSealService>().As<IGateSealService>().InstancePerDependency();
            builder.RegisterType<WaterFlowService>().As<IWaterFlowService>().InstancePerDependency();
            builder.RegisterType<BarrelHeatService>().As<IBarrelHeatService>().InstancePerDependency();
            builder.RegisterType<PartAndMoldTemperatureMappingService>().As<IPartAndMoldTemperatureMappingService>().InstancePerDependency();
            builder.RegisterType<WaterSupplyCalculatorService>().As<IWaterSupplyCalculatorService>().InstancePerDependency();
            builder.RegisterType<ManningUtilizationService>().As<IManningUtilizationService>().InstancePerDependency();
            builder.RegisterType<CoverPageService>().As<ICoverPageService>().InstancePerDependency();
            builder.RegisterType<TonnageCalculatorService>().As<ITonnageCalculatorService>().InstancePerDependency();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
            builder.RegisterType<LinearityResultsService>().As<ILinearityResultsService>().InstancePerDependency();
            builder.RegisterType<RheologyCurveService>().As<IRheologyCurveService>().InstancePerDependency();
            builder.RegisterType<ImprovementPlanActionService>().As<IImprovementPlanActionService>().InstancePerDependency();
            builder.RegisterType<RecoveryTimeStudyService>().As<IRecoveryTimeStudyService>().InstancePerDependency();
            builder.RegisterType<ColorCodeSchemeService>().As<IColorCodeSchemeService>().InstancePerDependency();
            builder.RegisterType<CavityBalanceService>().As<ICavityBalanceService>().InstancePerDependency();
            builder.RegisterType<MiscCalculatorService>().As<IMiscCalculatorService>().InstancePerDependency();
            builder.RegisterType<PlasticPressureLossesService>().As<IPlasticPressureLossesService>().InstancePerDependency();
            builder.RegisterType<GPMCalculatorService>().As<IGPMCalculatorService>().InstancePerDependency();
            builder.RegisterType<CorpIMPDService>().As<ICorpIMPDService>().InstancePerDependency();
            builder.RegisterType<MaterialDataService>().As<IMaterialDataService>().InstancePerDependency();
            builder.RegisterType<FinalProcessDataPositionDetailsService>().As<IFinalProcessDataPositionDetailsService>().InstancePerDependency();
            builder.RegisterType<InitialDataConversionSetupService>().As<IInitialDataConversionSetupService>().InstancePerDependency();
            builder.RegisterType<MoldFlowSetupService>().As<IMoldFlowSetupService>().InstancePerDependency();
            builder.RegisterType<ProcessReportService>().As<IProcessReportService>().InstancePerDependency();
            builder.RegisterType<ConversionSetupService>().As<IConversionSetupService>().InstancePerDependency();
            builder.RegisterType<CapacityChartService>().As<ICapacityChartService>().InstancePerDependency();
            builder.RegisterType<ReplacementSavingService>().As<IReplacementSavingService>().InstancePerDependency();
            builder.RegisterType<MRODataService>().As<IMRODataService>().InstancePerDependency();
            builder.RegisterType<LaborPlantSpecificService>().As<ILaborPlantSpecificService>().InstancePerDependency();
            builder.RegisterType<MainDashboardService>().As<IMainDashboardService>().InstancePerDependency();
            builder.RegisterType<PlantLaborCostService>().As<IPlantLaborCostService>().InstancePerDependency();
            builder.RegisterType<PressBreakDownOrderService>().As<IPressBreakDownOrderService>().InstancePerDependency();
            builder.RegisterType<DashboardService>().As<IDashboardService>().InstancePerDependency();
            builder.RegisterType<DOEService>().As<IDOEService>().InstancePerDependency();
            builder.RegisterType<DOEVariableMasterService>().As<IDOEVariableMasterService>().InstancePerDependency();
            builder.RegisterType<WindowsService>().As<IWindowsService>().InstancePerDependency();

        }
    }
}
