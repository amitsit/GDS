//-----------------------------------------------------------------------
// <copyright file="EngineContext.cs" company="Premiere Digital Services">
//     Copyright Premiere Digital Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GDS.Common
{
    using Autofac;
    using Autofac.Integration.Mvc;

    /// <summary>
    /// engine context is used to get service type by single instance
    /// </summary>
    public static class EngineContext
    {
        /// <summary>
        /// Resolves service using Auto FAC
        /// </summary>
        /// <typeparam name="T">T entity</typeparam>
        /// <returns>Return T</returns>
        public static T Resolve<T>()
        {
            return AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<T>();
        }
    }
}
