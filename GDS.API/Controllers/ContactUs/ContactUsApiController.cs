using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.ContactUs
{
    [RoutePrefix("api")]
    public class ContactUsApiController : ApiController
    {
        #region Initializtions
        private readonly IContactUsService _iContactUsService;

        public ContactUsApiController()
        {
            this._iContactUsService = EngineContext.Resolve<IContactUsService>();
        }
        #endregion

        #region Methods

        [HttpGet]
        [Route("GetContactUs")]
        public ApiResponse<ContactUsModel> GetContactUs(int? ContactId, int? UserId)
        {
            return this._iContactUsService.GetContactUs(ContactId,  UserId);
        }
        #endregion
    }
}
