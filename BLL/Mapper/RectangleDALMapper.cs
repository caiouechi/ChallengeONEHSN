using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts;

namespace BLL.Mapper
{
    public class RectangleDALMapper
    {
        public static DAL.Contexts.Rectangle ConvertObject(Models.RectangleBM rectangleBM)
        {
            var newRectangle = new DAL.Contexts.Rectangle()
            {
                AdotX = rectangleBM.AdotX.Value,
                AdotY = rectangleBM.AdotY.Value,
                BdotX = rectangleBM.BdotX.Value,
                BdotY = rectangleBM.BdotY.Value,
                CdotX = rectangleBM.CdotX.Value,
                CdotY = rectangleBM.CdotY.Value,
                DdotX = rectangleBM.DdotX.Value,
                DdotY = rectangleBM.DdotY.Value,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            return newRectangle;
        }

        public static List<DAL.Contexts.Rectangle> ConvertList(List<Models.RectangleBM> rectanglesBM)
        {
            var lstRectangles = new List<DAL.Contexts.Rectangle>();
            rectanglesBM.ForEach(rectangleBM =>
            {
                lstRectangles.Add(new DAL.Contexts.Rectangle()
                {
                    AdotX = rectangleBM.AdotX.Value,
                    AdotY = rectangleBM.AdotY.Value,
                    BdotX = rectangleBM.BdotX.Value,
                    BdotY = rectangleBM.BdotY.Value,
                    CdotX = rectangleBM.CdotX.Value,
                    CdotY = rectangleBM.CdotY.Value,
                    DdotX = rectangleBM.DdotX.Value,
                    DdotY = rectangleBM.DdotY.Value,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                });
            });

            return lstRectangles;
        }
    }
}
