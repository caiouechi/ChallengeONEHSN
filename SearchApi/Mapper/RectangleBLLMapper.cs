using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchApi.Mapper
{
    public class RectangleBLLMapper
    {
        public static BLL.Models.RectangleBM ConvertObject(Models.Rectangle rectangle)
        {
            var newRectangle = new BLL.Models.RectangleBM(rectangle.AdotX, rectangle.AdotY, rectangle.BdotX, rectangle.BdotY, rectangle.CdotX, rectangle.CdotY, rectangle.DdotX, rectangle.DdotY);

            return newRectangle;
        }

        public static List<BLL.Models.RectangleBM> ConvertList(List<Models.Rectangle> rectangles)
        {
            var lstRectangles = new List<BLL.Models.RectangleBM>();
            rectangles.ForEach(rectangle =>
            {
                lstRectangles.Add(new BLL.Models.RectangleBM(rectangle.AdotX, rectangle.AdotY, rectangle.BdotX, rectangle.BdotY, rectangle.CdotX, rectangle.CdotY, rectangle.DdotX, rectangle.DdotY));
            });

            return lstRectangles;
        }
    }
}