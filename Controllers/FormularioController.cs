using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using proyectomvc.Models;
using proyectomvc.Data;
using Microsoft.EntityFrameworkCore;

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
            var listContactos = _context.Registros.ToList();
            return View(listContactos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Formulario objFormulario){

            if (ModelState.IsValid)
            {
                _context.Add(objFormulario);
                _context.SaveChanges();
                objFormulario.Respuesta = "Registro exitoso my friend!";
            }
            return View("crear", objFormulario);
        }

        // GET: Contacto/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Registros.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("ID,Nombre,Apellido,Distrito,Banco,Edad,Genero,Autor")] Formulario objFormulario)
        {   
            if (id != objFormulario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objFormulario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(objFormulario);
        }

        public IActionResult Delete(int? id)
        {
            var contacto = _context.Registros.Find(id);
            _context.Registros.Remove(contacto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
