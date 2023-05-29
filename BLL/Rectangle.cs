using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts;
using BLL.Models;
using Newtonsoft.Json;

namespace BLL
{
    public class Rectangle
    {
        public bool InitialSeed(int maxX, int maxY, int maxHeight, int maxWidth, int numberRectangles)
        {
            try
            {
                using (var challengeContext = new ChallengeDBEntities())
                {
                    Random rnd = new Random();

                    for (int i = 0; i < numberRectangles; i++)
                    {
                        var randomX = rnd.Next(maxX);
                        var randomY = rnd.Next(maxY);
                        var randomHeight = rnd.Next(maxHeight);
                        var randomWidth = rnd.Next(maxWidth);

                        var newRectangle = new DAL.Contexts.Rectangle() { AdotX = randomX, AdotY = randomY, BdotX = randomX + randomWidth, BdotY = randomY, CdotX = randomX, CdotY = randomY - randomHeight, DdotX = randomX + randomWidth, DdotY = randomY - randomHeight, DateCreated = DateTime.Now, DateModified = DateTime.Now };
                        challengeContext.Rectangles.Add(newRectangle);
                        challengeContext.SaveChanges();
                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                Log.LogClass.InsertLog(e.Message.ToString());
                return false;
            }
        }

        public string GetRectangles(List<Models.CoordinateBM> lstCoordinates)
        {
            try
            {
                using (var challengeContext = new ChallengeDBEntities())
                {

                    var returnDotsMapped = new Dictionary<string, List<DAL.Contexts.Rectangle>>();

                    foreach (var item in lstCoordinates)
                    {
                        var lstRectanglesIncludeDots = new List<DAL.Contexts.Rectangle>();

                        //To check if a coordinate is inside a rectangle, we just need to split the rectangle in 2 triangles
                        //1-Check if the point is inside one of each rectangle
                        foreach (var rectangle in challengeContext.Rectangles)
                        {
                            var insideTriangleCAB = PointInTriangle(lstCoordinates[0], new CoordinateBM(rectangle.CdotX, rectangle.CdotY), new CoordinateBM(rectangle.AdotX, rectangle.AdotY), new CoordinateBM(rectangle.BdotX, rectangle.BdotY));
                            var insideTriangleCDB = PointInTriangle(lstCoordinates[0], new CoordinateBM(rectangle.CdotX, rectangle.CdotY), new CoordinateBM(rectangle.DdotX, rectangle.DdotX), new CoordinateBM(rectangle.BdotX, rectangle.BdotY));

                            if (insideTriangleCAB || insideTriangleCDB) lstRectanglesIncludeDots.Add(rectangle);
                        }

                        if (lstRectanglesIncludeDots.Count > 0)
                        {
                            //var lstSerialized = JsonConvert.SerializeObject(lstRectanglesIncludeDots);
                            returnDotsMapped.Add(item.X + "," + item.Y, lstRectanglesIncludeDots);
                        }
                    }

                    var dicSerialized = JsonConvert.SerializeObject(returnDotsMapped);
                    return dicSerialized;
                }
            }
            catch (Exception e)
            {
                Log.LogClass.InsertLog(e.Message.ToString());
                return "";
            }
        }

        bool PointInTriangle(CoordinateBM pt, CoordinateBM v1, CoordinateBM v2, CoordinateBM v3)
        {
            bool b1, b2, b3;

            b1 = Sign(pt, v1, v2) < 0.0f;
            b2 = Sign(pt, v2, v3) < 0.0f;
            b3 = Sign(pt, v3, v1) < 0.0f;

            return ((b1 == b2) && (b2 == b3));
        }

        float Sign(CoordinateBM p1, CoordinateBM p2, CoordinateBM p3)
        {
            return ((float)p1.X - (float)p3.X) * ((float)p2.Y - (float)p3.Y) - ((float)p2.X - (float)p3.X) * ((float)p1.Y - (float)p3.Y);
        }

        public bool InsertRectangle(Models.RectangleBM rectangleBM)
        {
            try
            {
                using (var challengeContext = new ChallengeDBEntities())
                {
                    var newRectangle = Mapper.RectangleDALMapper.ConvertObject(rectangleBM);

                    challengeContext.Rectangles.Add(newRectangle);
                    challengeContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                Log.LogClass.InsertLog(e.Message.ToString());
                return false;
            }
        }

        public bool InsertRectangles(List<Models.RectangleBM> rectanglesBM)
        {
            try
            {
                using (var challengeContext = new ChallengeDBEntities())
                {
                    var newRectangles = Mapper.RectangleDALMapper.ConvertList(rectanglesBM);

                    challengeContext.Rectangles.AddRange(newRectangles);
                    challengeContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                Log.LogClass.InsertLog(e.Message.ToString());
                return false;
            }
        }

    }
}
