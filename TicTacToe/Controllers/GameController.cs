using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Helpers.AbstractFactory;
using TicTacToe.Helpers.Builder;

namespace TicTacToe.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Small()
        {
            return returnView(MethodBase.GetCurrentMethod().Name.ToLower());
        }
        public IActionResult Medium()
        {
            return returnView(MethodBase.GetCurrentMethod().Name.ToLower());
        }
        private IActionResult returnView(string method)
        {
            var director = new Director(BuilderFactory.GetBuilder(method));
            director.construct();
            return View(director.GetBoard);
        }
    }
}