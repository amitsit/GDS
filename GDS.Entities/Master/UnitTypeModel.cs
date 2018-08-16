namespace GDS.Entities.Master
{
    public class UnitTypeModel
    {

        private int _lengthUnitId;
        public int LengthUnitId
        {
            // Set LengthUnitId to default inch if not provided
            get { return _lengthUnitId == 0 ? 1 : _lengthUnitId; }
            set { _lengthUnitId = value; }
        }

        private int _pressureUnitId;
        public int PressureUnitId
        {
            // Set PressureUnitId to default psi if not provided
            get { return _pressureUnitId == 0 ? 1 : _pressureUnitId; }
            set { _pressureUnitId = value; }
        }
    }
}
