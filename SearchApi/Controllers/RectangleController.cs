using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SearchApi.Auth;
using SearchApi.Filters;
using SearchApi.Models;

namespace SearchApi.Controllers
{
    public class RectangleController : ApiController
    {
        [AllowAnonymous]
        [System.Web.Http.HttpGet]
        [Route("Rectangle/GenerateJWT")]
        public string GenerateToken()
        {
            var token = JwtAuth.GenerateJwtToken("Caio", new List<string>() { "Admin" });

            return token;
        }

        [HttpPost]
        [AuthenticationFilter]
        [Route("Rectangle/DefaultFilling")]
        public IHttpActionResult DefaultFilling()
        {
            var rectangleBLL = new BLL.Rectangle();

            var initialSeed = rectangleBLL.InitialSeed(1000, 1000, 450, 400, 200);

            if (!initialSeed) return BadRequest("Error saving rectangles");

            return Ok();
        }

        [HttpPost]
        [AuthenticationFilter]
        [Route("Rectangle/Insert")]
        public IHttpActionResult Insert(Rectangle rectangle)
        {
            var rectangleBLL = new BLL.Rectangle();

            var rectangleBM = Mapper.RectangleBLLMapper.ConvertObject(rectangle);

            if(!rectangleBM.IsValid) return BadRequest("Please provide a valid rectangle");

            var insertRec = rectangleBLL.InsertRectangle(rectangleBM);

            if (!insertRec) return BadRequest("Error inserting rectangle");

            return Ok();
        }

        [HttpPost]
        [AuthenticationFilter]
        [Route("Rectangle/InsertArray")]
        public IHttpActionResult InsertArray(List<Rectangle> lstRectangles)
        {
            var rectangleBLL = new BLL.Rectangle();

            var lstRectanglesProblem = new List<int>();

            var rectanglesBM = Mapper.RectangleBLLMapper.ConvertList(lstRectangles);

            if (rectanglesBM.Any(rectangle => !rectangle.IsValid)) return BadRequest("Please provide valid retangles");

            if (!rectangleBLL.InsertRectangles(rectanglesBM)) return BadRequest("Problem inserting rectangles");

            return Ok();
        }

        [HttpPost]
        [AuthenticationFilter]
        [Route("Rectangle/GetRectangles")]
        public IHttpActionResult GetRectangles(List<Coordinate> lstCoordinates)
        {
            var rectangleBLL = new BLL.Rectangle();

            var rectanglesBM = Mapper.CoordinateBLLMapper.ConvertList(lstCoordinates);

            if(rectanglesBM.Any(coordinate => !coordinate.IsValid)) return BadRequest("Please provide valid coordinates");

            var rectangles = rectangleBLL.GetRectangles(rectanglesBM);

            if (rectangles == "error") return BadRequest("Please provide valid retangles");

            return Ok(rectangles);
        }
    }
}