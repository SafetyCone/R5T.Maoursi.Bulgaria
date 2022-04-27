using System;

using R5T.Bulgaria;
using R5T.Kalamaria;
using R5T.Lombardy;using R5T.T0064;


namespace R5T.Maoursi.Bulgaria
{[ServiceImplementationMarker]
    public class DropboxOrganizationsDirectoryPathProvider : IOrganizationsDirectoryPathProvider,IServiceImplementation
    {
        private IDropboxDirectoryPathProvider DropboxDirectoryPathProvider { get; }
        private IOrganizationsDirectoryNameConvention OrganizationsDirectoryNameConvention { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public DropboxOrganizationsDirectoryPathProvider(
            IDropboxDirectoryPathProvider dropboxDirectoryPathProvider,
            IOrganizationsDirectoryNameConvention organizationsDirectoryNameConvention,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.DropboxDirectoryPathProvider = dropboxDirectoryPathProvider;
            this.OrganizationsDirectoryNameConvention = organizationsDirectoryNameConvention;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetOrganizationsDirectoryPath()
        {
            var dropboxDirectoryPath = this.DropboxDirectoryPathProvider.GetDropboxDirectoryPath();

            var organizationsDirectoryName = this.OrganizationsDirectoryNameConvention.GetOrganizationsDirectoryName();

            var organizationsDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(dropboxDirectoryPath, organizationsDirectoryName);
            return organizationsDirectoryPath;
        }
    }
}
