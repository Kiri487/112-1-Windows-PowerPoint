using System.Collections.Generic;
using System.Linq;

namespace PowerPoint.Model
{
    public class Shapes
    {
        // Variable
        string _drawingShapeName = null;
        int _selectedShapeIndex;
        List<Shape> _shapesList = new List<Shape>();
        Shape _drawingShape = null;
        Shape _selectedShape = null;
        ShapeFactory _shapeFactory = new ShapeFactory();
        const float SELECT_POINT_SIZE = 10;
        const float HALF_SELECT_POINT_SIZE = SELECT_POINT_SIZE / 2;

        public Shapes()
        {
        }

        // Add new shape by type of shape
        public void AddShape(string shapeType)
        {
            _shapesList.Add(_shapeFactory.CreateShape(shapeType));
        }

        // Add new shape with start point and end point
        public void AddShape(CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            _shapesList.Add(_shapeFactory.CreateShape(_drawingShapeName, startPoint, endPoint));
        }

        // Add new shape with start point and end point at index
        public void AddShape(int index, CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            _shapesList.Insert(index, _shapeFactory.CreateShape(_drawingShapeName, startPoint, endPoint));
        }

        // Create new shape with start point and end point by type of shape
        public Shape CreateShape(string shapeType, CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            return _shapeFactory.CreateShape(shapeType, startPoint, endPoint);
        }

        // Delete shape from the shapes list
        public void DeleteShape()
        {
            if (_selectedShape != null)
                DeleteShape(_selectedShapeIndex);
        }

        // Delete shape from the shapes list
        public void DeleteShape(int index)
        {
            if (_selectedShape == _shapesList[index])
                _selectedShape = null;
            _shapesList.RemoveAt(index);
        }

        // Set shape point
        public void SetPoint(int index, CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            _shapesList[index].SetPoint(startPoint, endPoint);
        }

        // Get info of shape (coordinate point)
        public string GetInfo(int index, float rateX, float rateY)
        {
            return _shapesList[index].GetInfo(rateX, rateY);
        }

        // Get name of shape (type)
        public string GetShapeName(int index)
        {
            return _shapesList[index].GetName();
        }

        // Get data of shape (type, coordinate point)
        public string[] GetShapeData(int index, float rateX, float rateY)
        {
            string[] shapeData = { "", GetShapeName(index), GetInfo(index, rateX, rateY) };
            return shapeData;
        }

        // Get shape start point
        public CoordinatePoint GetShapeStartPoint(int index)
        {
            return _shapesList[index].GetStartPoint();
        }

        // Get shape end point
        public CoordinatePoint GetShapeEndPoint(int index)
        {
            return _shapesList[index].GetEndPoint();
        }

        // Get length of shapes list
        public int GetShapesListLength()
        {
            return _shapesList.Count();
        }

        // Set drawing shape name
        public void SetDrawingShapeName(string shapeType)
        {
            _drawingShapeName = shapeType;
        }

        // Set drawing shape point
        public void CreateDrawingShape(CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            if (_drawingShapeName != null)
                _drawingShape = CreateShape(_drawingShapeName, startPoint, endPoint);
        }

        // Delete drawing shape
        public void DeleteDrawingShape()
        {
            _drawingShape = null;
        }

        // Draw shape
        public void Draw(IGraphics graphics)
        {
            foreach (Shape shapes in _shapesList)
                shapes.Draw(graphics);
            if (_drawingShape != null)
                _drawingShape.Draw(graphics);
            if (_selectedShape != null)
                _selectedShape.Select(graphics);
        }

        // Select shape
        public bool IsSelect()
        {
            if (_selectedShape != null)
                return true;
            else
                return false;
        }

        // Select shape
        public bool IsSelect(float pointX, float pointY)
        {
            for (int i = _shapesList.Count() - 1; i >= 0; i--) 
            { 
                if (pointX >= _shapesList[i].GetUpperLeftPoint().GetPointX() && 
                    pointX <= _shapesList[i].GetLowerRightPoint().GetPointX() && 
                    pointY >= _shapesList[i].GetUpperLeftPoint().GetPointY() && 
                    pointY <= _shapesList[i].GetLowerRightPoint().GetPointY())
                {
                    SetSelectShape(i);
                    return true;
                }
            }
            _selectedShape = null;
            return false;
        }

        // Set select shape
        public void SetSelectShape(int index)
        {
            if (index >= 0 && index < GetShapesListLength())
            {
                _selectedShape = _shapesList[index];
                _selectedShapeIndex = index;
            }
        }

        // Get select shape index
        public int GetSelectShapeIndex()
        {
            return _selectedShapeIndex;
        }

        // Cancel select shape
        public void CancelSelect()
        {
            _selectedShape = null;
        }

        // Move shape
        public void Move(float offsetX, float offsetY)
        {
            if (_selectedShape != null)
                _selectedShape.Move(offsetX, offsetY);
        }

        // Is shape scale
        public bool IsScale(float pointX, float pointY, float rateX, float rateY)
        {
            if (_selectedShape != null)
            {
                if (pointX >= (_selectedShape.GetLowerRightPoint().GetPointX() - HALF_SELECT_POINT_SIZE * rateX) &&
                    pointX <= (_selectedShape.GetLowerRightPoint().GetPointX() + HALF_SELECT_POINT_SIZE * rateX) &&
                    pointY >= (_selectedShape.GetLowerRightPoint().GetPointY() - HALF_SELECT_POINT_SIZE * rateY) &&
                    pointY <= (_selectedShape.GetLowerRightPoint().GetPointY() + HALF_SELECT_POINT_SIZE * rateY))
                {
                    return true;
                }
            }
            return false;
        }

        // Scale shape
        public void Scale(float offsetX, float offsetY)
        {
            if (_selectedShape != null)
                _selectedShape.Scale(offsetX, offsetY);
        }

        // Reset shape point
        public void ResetPoint()
        {
            if (_selectedShape != null)
                _selectedShape.ResetPoint();
        }
    }
}