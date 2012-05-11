using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Data.EntityFramework;
using System.Web.Mvc;
using System.Web.Routing;

namespace PersonalManagerApp.Controllers
{
    public partial class PersonalManagerAppController : DbDataController<PersonalManagerApp.Models.PersonalManagerAppContext>
    {
        // Any code added here will apply to all entity types managed by this data controller
    }

    // This provides context-specific route registration
    public class PersonalManagerAppRouteRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "PersonalManagerApp"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
			RouteTable.Routes.MapHttpRoute(
                "PersonalManagerApp", // Route name
                "api/PersonalManagerApp/{action}", // URL with parameters
                new { controller = "PersonalManagerApp" } // Parameter defaults
            );
        }
    }
}
