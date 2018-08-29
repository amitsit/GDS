using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Search
{
    [RoutePrefix("api")]
    public class SearchApiController : ApiController
    {
        #region Initializtions
        private readonly ISearchService _iSearchService;

        public SearchApiController()
        {
            this._iSearchService = EngineContext.Resolve<ISearchService>();
        }
        #endregion

        #region Methods

        [HttpGet]
        [Route("SearchText")]
        public ApiResponse<SearchModel> SearchText(int MenuId,string SearchText,int? UserId)
        {
            return this._iSearchService.SearchText(MenuId,SearchText, UserId);
        }
        #endregion
    }
}
