using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Master.Program
{
    public interface IProgramService
    {
        ApiResponse<ProgramMasterModel> GetProgramList();
        ApiResponse<ProgramMasterModel> GetProgramDetail(int ProgramID);
        ApiResponse<PlantMasterModel> GetPlantList(int UserId);
        BaseApiResponse AddOrUpdateProgram(int UserId, ProgramMasterModel ProgramObj);
        BaseApiResponse DeleteProgram(long ProgramID);
    }
}
