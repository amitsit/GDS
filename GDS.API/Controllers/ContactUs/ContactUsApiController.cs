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

        [HttpGet]
        [Route("GetContactUsDetail")]
        public ApiResponse<ContactUsModel> GetContactUsDetail(int? ContactId, int? UserId)
        {
            return this._iContactUsService.GetContactUsDetail(ContactId, UserId);
        }

        [HttpGet]
        [Route("GetContactListByStatus")]
        public ApiResponse<ContactUsModel> GetContactListByStatus(int? MenuId, int? UserId,bool? IsActive)
        {
            return this._iContactUsService.GetContactListByStatus(MenuId, UserId,IsActive);
        }

        [HttpGet]
        [Route("DeleteContact")]
        public BaseApiResponse DeleteContact(int? ContactId, int? UserId)
        {
            return this._iContactUsService.DeleteContact(ContactId, UserId);
        }

        [HttpPost]
        [Route("SaveContactDetail")]
        public BaseApiResponse SaveContactDetail(int? UserId, ContactUsModel ContactObj)
        {
            return this._iContactUsService.SaveContactDetail(UserId, ContactObj);
        }

        
        #endregion
    }
}
