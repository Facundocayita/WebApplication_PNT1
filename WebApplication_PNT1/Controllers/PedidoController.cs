using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_PNT1.Context;
using WebApplication_PNT1.Models;


namespace WebApplication_PNT1.Controllers
{
    public class PedidoController : Controller
    {
        private readonly WebAppDatabaseContext _context;

        public PedidoController(WebAppDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.FechaCreacion = DateTime.Now;
                pedido.Estado = "Pendiente";
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirigir a una vista adecuada
            }
            return View(pedido);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Proyectos)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // Acciones para Confirmar, Anular y Modificar Pedido
        public async Task<IActionResult> Confirm(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            pedido.Estado = "Confirmado";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Redirigir a una vista adecuada
        }

        public async Task<IActionResult> Anular(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            pedido.Estado = "Anulado";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Redirigir a una vista adecuada
        }


    }
}
