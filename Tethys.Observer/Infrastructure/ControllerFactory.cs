using System.Data.Common;
using System.Web.Mvc;
using System.Web.Routing;
using Tethys.Observer.Controllers;
using Tethys.Observer.Domain.DataAccess;

namespace Tethys.Observer.Infrastructure
{
    public class ControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controller = (BaseController)base.CreateController(requestContext, controllerName);

            var connectionStringBuilder = new DbConnectionStringBuilder();
            connectionStringBuilder.Add("Data Source", TethysResources.DatabaseServerName);
            connectionStringBuilder.Add("Initial Catalog", TethysResources.DatabaseName);
            connectionStringBuilder.Add("User Id", TethysResources.DatabaseLogin);
            connectionStringBuilder.Add("Password", TethysResources.DatabasePassword);

            controller.Context = new TethysContext(connectionStringBuilder.ConnectionString);

            return controller;
        }

        public override void ReleaseController(IController controller)
        {
            var baseController = controller as BaseController;
            if (baseController.Context != null)
            {
                baseController.Dispose();
            }

            base.ReleaseController(controller);
        }
    }
}