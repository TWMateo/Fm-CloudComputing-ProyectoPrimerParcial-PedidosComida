using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PedidosComida.Modelos;
using PedidosComida.UAPI;

namespace PedidosComida.webMVC.Controllers
{
    public class PedidosComidaController : Controller
    {
        private Crud<Modelos.PedidoComida> pedidos = new Crud<Modelos.PedidoComida>();
        private String Url = "https://localhost:7212/api/PedidoComidas";
        // GET: PedidosComidaController
        public ActionResult Index()
        {
            var datos = pedidos.Select(Url);
            return View(datos);
        }

        // GET: PedidosComidaController/Details/5
        public ActionResult Details(int id)
        {
            var datos = pedidos.Select_ById(Url, id);
            return View(datos);
        }

        // GET: PedidosComidaController/Create
        public ActionResult Create()
        {
            var clientes = new Crud<Modelos.Cliente>().Select(Url.Replace("PedidoComidas", "Clientes"))
                .Select(p => new SelectListItem
                {
                    Value = p.IdCliente.ToString(),
                    Text = p.IdCliente+"._"+p.nombre+" "+p.apellido
                })
                .ToList();

            ViewBag.clientes = clientes;
            return View();
        }

        // POST: PedidosComidaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Modelos.PedidoComida datos,decimal datoDecimal)
        {
            try
            {
                Console.WriteLine("ACC");
                Console.WriteLine(datoDecimal);
                datos.Total =decimal.ToDouble(datoDecimal);
                pedidos.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: PedidosComidaController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = pedidos.Select_ById(Url, id);
            var clientes = new Crud<Modelos.Cliente>().Select(Url.Replace("PedidoComidas", "Clientes"))
                .Select(p => new SelectListItem
                {
                    Value = p.IdCliente.ToString(),
                    Text = p.IdCliente + "._" + p.nombre + " " + p.apellido
                })
                .ToList();

            ViewBag.clientes = clientes;
            return View(datos);
        }

        // POST: PedidosComidaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Modelos.PedidoComida datos, Decimal datoDecimal)
        {
            try
            {
                datos.Total=decimal.ToDouble(datoDecimal);
                pedidos.Update(Url, id, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: PedidosComidaController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = pedidos.Select_ById(Url,id);
            return View(datos);
        }

        // POST: PedidosComidaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Modelos.PedidoComida datos)
        {
            try
            {
                pedidos.Delete(Url, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
