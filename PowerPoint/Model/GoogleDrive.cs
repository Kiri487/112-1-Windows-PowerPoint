using System;
using System.Collections.Generic;
using System.IO;
using GoogleDriveUploader.GoogleDrive;

namespace PowerPoint.Model
{
    public class GoogleDrive
    {
        
        const string APPLICATION_NAME = "DrawAnywhere";
        const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
        const string FILE_PATH = "./";
        const string FILE_NAME = "saved.txt";
        const string CONTENT_TYPE = "text/plain";
        const string COMMA = ",";
        const string NO_FILE = "找不到檔案：";
        const int TWO = 2;
        const int THREE = 3;
        const int FOUR = 4;
        const int FIVE = 5;
        private GoogleDriveService _googleDriveService = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);

        public GoogleDrive()
        {
        }

        // Save
        public void Save(List<Shapes> pageList)
        {
            int shapesListLength;
            using (StreamWriter file = new StreamWriter(FILE_NAME))
            {
                foreach (Shapes page in pageList)
                {
                    shapesListLength = page.GetShapesListLength();
                    for (int i = 0; i < shapesListLength; i++)
                    {
                        string name = page.GetShapeName(i);
                        CoordinatePoint startPoint = page.GetShapeStartPoint(i);
                        CoordinatePoint endPoint = page.GetShapeEndPoint(i);
                        file.Write((i == 0 ? "" : COMMA) + name + COMMA + startPoint.GetPointX() + COMMA + startPoint.GetPointY() + COMMA + endPoint.GetPointX() + COMMA + endPoint.GetPointY());
                    }
                    file.WriteLine("");
                }
            }
        }

        // Update to Google drive
        public void Upload()
        {
            if (!File.Exists(FILE_NAME))
            {
                throw new FileNotFoundException(NO_FILE + FILE_NAME);
            }
            _googleDriveService.UploadFile(FILE_NAME, CONTENT_TYPE);
            File.Delete(FILE_NAME);
        }

        // Load
        public void Load(List<Shapes> pageList, PageIndex currentPageIndex)
        {
            _googleDriveService.DownloadFileByName(FILE_NAME, FILE_PATH);
            using (StreamReader reader = new StreamReader(FILE_NAME))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] shapeData = line.Split(char.Parse(COMMA));
                    Shapes shapes = new Shapes();
                    for (int i = 0; i <= shapeData.Length - FIVE; i += FIVE)
                    {
                        shapes.SetDrawingShapeName(shapeData[i]);
                        shapes.AddShape(new CoordinatePoint(float.Parse(shapeData[i + 1]), float.Parse(shapeData[i + TWO])), new CoordinatePoint(float.Parse(shapeData[i + THREE]), float.Parse(shapeData[i + FOUR])));
                    }
                    pageList.Add(shapes);
                }
            }
            currentPageIndex.SetPageIndex(0);
        }
    }
}