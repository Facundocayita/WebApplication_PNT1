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
    public class PedidoesController : Controller
    {
        private readonly WebAppDatabaseContext _context;

        public PedidoesController(WebAppDatabaseContext context)
        {
            _context = context;
        }

        // GET: Pedidoes
        public async Task<IActionResult> Index()
        {
            var webAppDatabaseContext = _context.Pedidos.Include(p => p.Proyecto);
            return View(await webAppDatabaseContext.ToListAsync());
            //return View(await _context.Pedidos.ToListAsync());
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Proyecto)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedido/Create
        public IActionResult Create([]Proyecto proyecto)
        {
           
            // var proyecto = _context.Proyectos.Find(proyectoId);
            if (proyecto == null)
            {
                return NotFound("El proyecto especificado no existe.");
            }

            var pedido = new Pedido

            {
                ProyectoId = proyecto.IdProyecto,
                FechaCreacion = DateTime.Now,
                Proyecto = proyecto,

            };

            return View(pedido);
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,FechaCreacion,Cliente,DireccionEntrega,Observaciones,TipoEntrega,Proyecto,ProyectoId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                var proyecto = await _context.Proyectos.FindAsync(pedido.ProyectoId);

                if (proyecto == null)
                {
                    ModelState.AddModelError(string.Empty, "El proyecto especificado no existe.");
                    return View(pedido);
                }

                // Realiza los cálculos necesarios usando el proyecto
                pedido.SetCostoTotal(proyecto);
                pedido.SetFechaEntrega();
                pedido.SetEstado(EstadoPedido.Pendiente);

                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = pedido.IdPedido });
            }


            // Para depuración, agrega errores de ModelState a ViewData o ViewBag
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);
            ViewBag.Errors = allErrors;

            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", pedido.ProyectoId);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,FechaCreacion,Cliente,Estado,DireccionEntrega,FechaEntrega,Observaciones,ProyectoId,TipoEntrega")] Pedido pedido)
        {
            if (id != pedido.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.IdPedido))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", pedido.ProyectoId);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Proyecto)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.IdPedido == id);
        }
    }
}
