using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Bulgaria;
using R5T.Dacia;
using R5T.Kalamaria;
using R5T.Lombardy;


namespace R5T.Maoursi.Bulgaria
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Add the <see cref="DropboxOrganizationsDirectoryPathProvider"/> implementation for <see cref="IOrganizationsDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDropboxOrganizationsDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IDropboxDirectoryPathProvider> addDropboxDirectoryPathProvider,
            ServiceAction<IOrganizationsDirectoryNameConvention> addOrganizationsDirectoryNameConvention,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<IOrganizationsDirectoryPathProvider, DropboxOrganizationsDirectoryPathProvider>()
                .RunServiceAction(addDropboxDirectoryPathProvider)
                .RunServiceAction(addOrganizationsDirectoryNameConvention)
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Add the <see cref="DropboxOrganizationsDirectoryPathProvider"/> implementation for <see cref="IOrganizationsDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IOrganizationsDirectoryPathProvider> AddDropboxOrganizationsDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IDropboxDirectoryPathProvider> addDropboxDirectoryPathProvider,
            ServiceAction<IOrganizationsDirectoryNameConvention> addOrganizationsDirectoryNameConvention,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<IOrganizationsDirectoryPathProvider>(() => services.AddDropboxOrganizationsDirectoryPathProvider(
                addDropboxDirectoryPathProvider,
                addOrganizationsDirectoryNameConvention,
                addStringlyTypedPathOperator));
            return serviceAction;
        }
    }
}
