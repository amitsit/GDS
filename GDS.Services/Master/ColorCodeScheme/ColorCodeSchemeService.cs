using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;
using GDS.Entities.SMOM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Master.ColorCodeScheme
{
    public class ColorCodeSchemeService : IColorCodeSchemeService
    {
        #region Constants

        /// <summary>
        /// Declare The logger object for perform operation on Logger
        /// </summary>
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        #endregion

        #region Fields

        /// <summary>
        /// Declare The provider repository object for perform operation on Provider repository
        /// </summary>
        private readonly IGenericRepository<ColorCodeSchemeModel> _repository;

        #endregion

        #region ctor


        public ColorCodeSchemeService(IGenericRepository<ColorCodeSchemeModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<ColorCodeSchemeModel> GetColorCodeSchemeList(Int16 lengthUnitId, Int16 pressureUnitId,TroubleShooterPostModel Model)
        {
            var response = new ApiResponse<ColorCodeSchemeModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("PageName",(object)Model.PageName?? DBNull.Value),
                    new SqlParameter("PressureUnitId",(object)pressureUnitId?? DBNull.Value),
                    new SqlParameter("LengthUnitId",(object)lengthUnitId?? DBNull.Value)
                };

                var result = _repository.ExecuteSQL<ColorCodeSchemeModel>("usp_ColorCodeScheme_get", paramList).ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }
        #endregion
    }
}
