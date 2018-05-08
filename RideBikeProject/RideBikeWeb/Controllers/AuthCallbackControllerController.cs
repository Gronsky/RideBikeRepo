using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using RideBikeWeb.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RideBikeWeb.Controllers
{
    public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
    {

        protected override FlowMetadata FlowData
        {
            get { return new AppFlowMetadata(); }
        }
    }
}