using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GDS.Services.ContactUs
{
    public interface IContactUsService
    {
        ApiResponse<ContactUsModel> GetContactUs(int? ContactId, int? UserId);
        ApiResponse<ContactUsModel> GetContactUsDetail(int? ContactId, int? UserId);
        ApiResponse<ContactUsModel> GetContactListByStatus(int? MenuId, int? UserId,bool? IsActive);
        BaseApiResponse SaveContactDetail(int? UserId, ContactUsModel ContactObj);


    }
}
