using System;
using System.Collections.Generic;
using System.IO;
using GoogleDriveUploader.GoogleDrive;

namespace PowerPoint.Model
{
    public class GoogleDrive
    {
        private GoogleDriveService _googleDriveServiceervice;
        const string APPLICATION_NAME = "DrawAnywhere";
        const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";

        public GoogleDrive()
        {
            
        }

        // Save
        public void Save(List<Shapes> pageList)
        {
            // 假設 _pageList 已經被填滿了資料
            int shapesListLength = 0;
            using (StreamWriter file = new StreamWriter("C:\\Users\\user\\Desktop\\output.txt"))
            {
                foreach (Shapes page in pageList)
                {
                    shapesListLength = page.GetShapesListLength();
                    for (int i = 0; i < shapesListLength; i++)
                    {
                        string name = page.GetShapeName(i);
                        CoordinatePoint startPoint = page.GetShapeStartPoint(i);
                        CoordinatePoint endPoint = page.GetShapeEndPoint(i);

                        if (i == 0)
                            file.Write(name + "," + startPoint.GetPointX() + "," + startPoint.GetPointY() + "," + endPoint.GetPointX() + "," + endPoint.GetPointY());
                        else
                            file.Write("," + name + "," + startPoint.GetPointX() + "," + startPoint.GetPointY() + "," + endPoint.GetPointX() + "," + endPoint.GetPointY());

                    }
                    file.WriteLine("");
                }
            }
        }

        // Load
        public void Load(List<Shapes> pageList)
        {
            string filePath = "C:\\Users\\user\\Desktop\\output.txt";

            pageList.Clear();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] shapeData = line.Split(',');

                    Shapes shapes = new Shapes();
                    for (int i = 0; i <= shapeData.Length - 5; i += 5)
                    {
                        shapes.SetDrawingShapeName(shapeData[i]);
                        shapes.AddShape(new CoordinatePoint(float.Parse(shapeData[i + 1]), float.Parse(shapeData[i + 2])), new CoordinatePoint(float.Parse(shapeData[i + 3]), float.Parse(shapeData[i + 4])));
                    }
                    pageList.Add(shapes);
                }
            }
        }
    }
}