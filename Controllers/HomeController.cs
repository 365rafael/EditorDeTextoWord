using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TextEditor.Data;
using TextEditor.Models;

namespace TextEditor.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var documentos = await _context.Documentos.ToListAsync();

            return View(documentos);
        }

        public IActionResult CriarDocumento()
        {
            return View();
        }

        public async Task<IActionResult> EditarDocumento(int id)
        {
            var documento = await _context.Documentos.FirstOrDefaultAsync(x => x.Id == id);
            return View(documento);
        }

        [HttpPost]
        public async Task<IActionResult> CriarDocumento(Documento documentoRecebido)
        {
            if(ModelState.IsValid)
            {
                _context.Add(documentoRecebido);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else 
            { 
                return View(documentoRecebido); 
            }
        }
          
        [HttpPost]
        public async Task<IActionResult> EditarDocumento(Documento documentoEditado)
        {
            if(ModelState.IsValid)
            {
                var documento = await _context.Documentos.FirstOrDefaultAsync(x => x.Id == documentoEditado.Id);

                documento.Titulo = documentoEditado.Titulo;
                documento.Conteudo = documentoEditado.Conteudo;
                documento.DataAlteracao = DateTime.Now;

                _context.Update(documento);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else 
            { 
                return View(documentoEditado); 
            }
        }

        public async Task<IActionResult> RemoverDocumento(int id)
        {
            var documento = await _context.Documentos.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(documento);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}
