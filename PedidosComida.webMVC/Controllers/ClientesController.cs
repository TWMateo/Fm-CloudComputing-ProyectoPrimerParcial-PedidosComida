using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosComida.UAPI;

namespace PedidosComida.webMVC.Controllers
{
    public class ClientesController : Controller
    {
        private Crud<Modelos.Cliente> clientes = new Crud<Modelos.Cliente>();
        private String Url = "https://localhost:7212/api/Clientes";
        // GET: ClientesController
        public ActionResult Index()
        {
            var datos = clientes.Select(Url);
            return View(datos);
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            var datos = clientes.Select_ById(Url, id);
            return View(datos);
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Modelos.Cliente datos)
        {
            try
            {
                clientes.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = clientes.Select_ById(Url, id);
            return View(datos);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Modelos.Cliente datos)
        {
            try
            {
                clientes.Update(Url, id, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = clientes.Select_ById(Url,id);
            return View(datos);
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Modelos.Cliente datos)
        {
            try
            {
                clientes.Delete(Url, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
