using System.Web;
using GDS.Common;
using GDS.Entities.IMIP;
using GDS.Entities.Master;
using GDS.Entities.STMP.InputData;
using GDS.Entities.SMOM.CoverPage;
using System;
using System.Collections.Generic;

namespace GDS.Services.IMIP.BICVerificationDocument
{
    public interface IBICVerificationDocumentService
    {
        ApiResponse<MoldNumberDDLModel> GetMoldNumber(int plantId);

        ApiResponse<CTPartThicknessModel> GetCTPartThicknessList();

        ApiResponse<ProgramMasterModel> GetProgramsByPlantId(int plantId);

        ApiResponse<CoverPageMachineConfiguration> GetBICDocument_GetPartProgramTonnage(int? plantid, long? inputdataid, long? plantequipmentlistid, Int16? lengthUnitId, Int16? pressureUnitId);

        ApiResponse<BICVerificationDocumentModel> GetBICVerificationDocumentList(int? plantId, int? plantEquipmentId,
            long? bicVerificationDocumentId, long? coverPageId);

        ApiResponse<BICVerificationDocumentImagesModel> GetBICVerificationDocumentImages(long? bicVerificationDocumentId, long? coverPageId);

        BaseApiResponse DeleteBICVerificationDocumentImages(long bicVerificationDocumentId);

        ApiResponse<BICVerificationQuestionAnswerModel> GetBICVerificationQuestionAnswerList(int? bicVerificationDocumentId, long? coverPageId);

        BaseApiResponse SaveBICVerificationDocument(BICVerificationDocumentModel model);

        BaseApiResponse UploadImage(List<HttpPostedFile> files, long bicVerificationDocumentId);

        BaseApiResponse DeleteBICVerificationDocument(long bicVerificationDocumentId, int plantId, long plantEquipmentId);
    }
}
