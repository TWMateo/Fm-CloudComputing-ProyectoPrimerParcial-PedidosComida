using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosComida.Modelos;

namespace PedidosComida.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLPedidoComidasController : ControllerBase
    {
        private readonly DataContext _context;

        public BLPedidoComidasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BLPedidoComidas
        [Route("/VentaTotal")]
        [HttpGet]
        public ActionResult <double> VentaTotal()
        {
          if (_context.PedidoComidas == null)
          {
              return NotFound();
          }
            return _context.PedidoComidas.Sum(p => p.Total);
        }
    }
}
