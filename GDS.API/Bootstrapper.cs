//-----------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="Premiere Digital Services">
//     Copyright Premiere Digital Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using GDS.Services;

namespace GDS.API
{
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;
    
    /// <summary>
    /// Class Bootstrap contains all Bootstrap related methods and variable.
    /// </summary>
    public static class Bootstrapper
    {
        ////   public static string assemblyIncludingPattern;

        /// <summary>
        /// Resolves the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static void Resolve(ContainerBuilder builder)
        {
            if (HttpContext.Current != null)
            {
                builder.Register(c =>
                 new HttpContextWrapper(HttpContext.Current) as HttpContextBase)
                   .As<HttpContextBase>()
                   .InstancePerDependency();
            }

            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerDependency();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerDependency();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerDependency();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerDependency();

             ////builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => !t.IsAbstract && typeof(ApiController).IsAssignableFrom(t))
             ////    .InstancePerMatchingLifetimeScope();

            builder.RegisterControllers(typeof(GDS.API.WebApiApplication).Assembly);
            builder.RegisterApiControllers(typeof(GDS.API.WebApiApplication).Assembly);
            ServiceDependencyRegister.Resolve(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //// Create the depenedency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);
                        
            //// Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}