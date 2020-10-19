using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyectomvc.Models;
using proyectomvc.Data;

namespace proyectomvc.Controllers
{
    public class FormularioController : Controller
    {
        private readonly ILogger<FormularioController> _logger;
        private readonly DatabaseContext _context;

        public FormularioController(ILogger<FormularioController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Recolectar(Formulario objFormulario){

            if (ModelState.IsValid)
            {
                _context.Add(objFormulario);
                _context.SaveChanges();
                objFormulario.Respuesta = "Registro exitoso, Gracias estamos en contacto";
            }
            return View("index", objFormulario);
        }
    }
}
