﻿using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Search
{
    public interface ISearchService
    {
        ApiResponse<SearchModel> SearchText(int MenuId,string SearchText,int? UserId);
    }
}
