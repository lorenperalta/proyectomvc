using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyectomvc.Models;

namespace proyectomvc.Controllers
{
    public class CalculadoraController : Controller
    {
        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calcular(Calculadora objCal){
            if("suma".Equals(objCal.Operacion)){
                objCal.Res = objCal.Num1 + objCal.Num2;
            }
            if("resta".Equals(objCal.Operacion)){
                objCal.Res = objCal.Num1 - objCal.Num2;
            }
            if("division".Equals(objCal.Operacion)){
                objCal.Res = objCal.Num1 / objCal.Num2;
            }
            if("multiplicacion".Equals(objCal.Operacion)){
                objCal.Res = objCal.Num1 * objCal.Num2;
            }
            return View("index", objCal);
        }
    }
}
