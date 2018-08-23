
namespace GDS.Services
{
    using Autofac;
    using Caching;
    using Data.Repository;
    using Master.Region;
    using Master.Plant;
    using Master.Role;
    using Master.State;
    using Master.Country;
    using Master.User;
    using Process;
    using SubProcess;

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
     
            builder.RegisterType<CountryService>().As<ICountryService>().InstancePerDependency();
        
            builder.RegisterType<RegionService>().As<IRegionService>().InstancePerDependency();
         
            builder.RegisterType<PlantService>().As<IPlantService>().InstancePerDependency();
          
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerDependency();
           
            builder.RegisterType<StateService>().As<IStateService>().InstancePerDependency();
     
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();

            builder.RegisterType<ProcessService>().As<IProcessService>().InstancePerDependency();

            builder.RegisterType<SubProcessService>().As<ISubProcessService>().InstancePerDependency();


        }
    }
}
