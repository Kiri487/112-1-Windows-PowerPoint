namespace PowerPoint.Model
{
    public class CoordinatePoint
    {
        // Variable
        private float _pointX;
        private float _pointY;
        const string LEFT_PARENTHESIS = "(";
        const string COMMA = ", ";
        const string RIGHT_PARENTHESIS = ")";
        const string ZERO = "0";

        public CoordinatePoint(float pointX, float pointY)
        {
            _pointX = pointX;
            _pointY = pointY;
        }

        // Set x, y point
        public void SetPoint(float pointX, float pointY)
        {
            _pointX = pointX;
            _pointY = pointY;
        }

        // Get x point
        public float GetPointX()
        {
            return _pointX;
        }

        // Get y point
        public float GetPointY()
        {
            return _pointY;
        }

        // Change CoordinatePoint to String
        public override string ToString()
        {
            return LEFT_PARENTHESIS + _pointX.ToString(ZERO) + COMMA + _pointY.ToString(ZERO) + RIGHT_PARENTHESIS;
        }

        // Move point
        public void MovePoint(float offsetX, float offsetY)
        {
            _pointX += offsetX;
            _pointY += offsetY;
        }

        // Calculate offset X
        public float CalculateOffsetX(CoordinatePoint point)
        {
            return point.GetPointX() - _pointX;
        }

        // Calculate offset Y
        public float CalculateOffsetY(CoordinatePoint point)
        {
            return point.GetPointY() - _pointY;
        }

        // Scale point
        public CoordinatePoint Scale(float rateX, float rateY)
        {
            return new CoordinatePoint(_pointX / rateX, _pointY / rateY);
        }

        // Get shape info
        public string GetShapeInfo(CoordinatePoint secondPoint, float rateX, float rateY)
        {
            return Scale(rateX, rateY).ToString() + COMMA + secondPoint.Scale(rateX, rateY).ToString();
        }
    }
}