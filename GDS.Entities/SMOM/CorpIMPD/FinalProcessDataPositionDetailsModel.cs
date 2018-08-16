using System;

namespace GDS.Entities.SMOM.CorpIMPD
{
    public class FinalProcessDataPositionDetailsModel
    {
        public long FinalProcessDataPositionDetailsId { get; set; }
        public long InitDataGeneralInfoId { get; set; }
        public byte SVG { get; set; }
        public double? TimePackTime { get; set; }
        public double? PositionPackTime { get; set; }
        public int LoggedInUserId { get; set; }


        private double? _positionOpen;
        public double? PositionOpen
        {
            get { return _positionOpen; }
            set
            {
                if (value != null)
                {
                    _positionOpen = Math.Round((double)value, 4);
                }
                else
                {
                    _positionOpen = null;
                }

            }
        }

        private double? _positionClose;
        public double? PositionClose
        {
            get { return _positionClose; }
            set
            {
                if (value != null)
                {
                    _positionClose = Math.Round((double)value, 4);
                }
                else
                {
                    _positionClose = null;
                }

            }
        }

        private double? _timeOpen;
        public double? TimeOpen
        {
            get { return _timeOpen; }
            set
            {
                if (value != null)
                {
                    _timeOpen = Math.Round((double)value, 4);
                }
                else
                {
                    _timeOpen = null;
                }

            }
        }

        private double? _timeClose;
        public double? TimeClose
        {
            get { return _timeClose; }
            set
            {
                if (value != null)
                {
                    _timeClose = Math.Round((double)value, 4);
                }
                else
                {
                    _timeClose = null;
                }

            }
        }
    }
}
