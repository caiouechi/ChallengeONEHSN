using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchApi.Mapper
{
    public class CoordinateBLLMapper
    {
        public static List<BLL.Models.CoordinateBM> ConvertList(List<Models.Coordinate> coordinates)
        {
            var lstCoordinates = new List<BLL.Models.CoordinateBM>();

            coordinates.ForEach(coordinate =>
            {
                lstCoordinates.Add(new BLL.Models.CoordinateBM(coordinate.X, coordinate.Y));
            });

            return lstCoordinates;
        }
    }
}