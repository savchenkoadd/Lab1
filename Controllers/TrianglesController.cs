using Microsoft.AspNetCore.Mvc;
using System.Text;
using Triangles.Models;

namespace Triangles.Controllers
{
    public class TrianglesController : Controller
    {
        [Route("/")]
        public IActionResult StartMenu()
        {
            Response.ContentType = "text/html";

            return Content("<h1>Welcome to testing program</h1>" +
                "<h3>Press <a href=\"/regulartriangle\">here</a> to test regular triangle</h3>" +
                "<h3>Press <a href=\"/pyramid\">here</a> to test regular triangular pyramid</h3>");
        }

        [Route("/regulartriangle/{sideLength?}")]
        public IActionResult TestRegularTriangle(RegularTriangle regularTriangle)
        {
            var validationMessage = ValidateModel(regularTriangle);

            if (validationMessage is not null)
            {
                return BadRequest(validationMessage);
            }

            return Content($"To string method:\t{regularTriangle}\n" +
                $"Square method:\t{regularTriangle.GetSquare()}\n" +
                $"Perimeter method:\t{regularTriangle.GetPerimeter()}\n" +
                $"Side length property:\t{regularTriangle.SideLength}\n" +
                $"Operator (triangle multiplied by 3):\t{regularTriangle * 3}\n" +
                $"Operator (3 multiplied by triangle):\t{3 * regularTriangle}\n", "text/plain");
        }

        [Route("/pyramid/{sideLength?}/{height?}")]
        public IActionResult TestPyramid(RegularTriangularPyramid regularPyramid)
        {
            var validationMessage = ValidateModel(regularPyramid);

            if (validationMessage is not null)
            {
                return BadRequest(validationMessage);
            }

            return Content($"ToString method (override):\t'{regularPyramid}'\n" +
                $"Square method (override):\t{regularPyramid.GetSquare()}\n" +
                $"Perimeter method (override):\t{regularPyramid.GetPerimeter()}\n" +
                $"Volume method:\t{regularPyramid.Volume} \n" +
                $"Side length property:\t{regularPyramid.SideLength}\n" +
                $"Operator (override) (triangle multiplied by 3):\t{regularPyramid * 3}\n" +
                $"Operator (override) (3 multiplied by triangle):\t{3 * regularPyramid}\n", "text/plain");
        }

        [NonAction]
        public string? ValidateModel<T>(T value)
        {
            if (!ModelState.IsValid)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        sb.AppendLine(error.ErrorMessage);
                    }
                }

                return sb.ToString();
            }

            return null;
        }

        private static bool IsCorrectPyramidData(int? height, int? sideLength)
        {
            return height is null || sideLength is null ||
                            height is not int || sideLength is not int;
        }
    }
}
