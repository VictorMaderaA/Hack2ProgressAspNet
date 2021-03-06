﻿using Hack2ProgressAspMvc.Models;
using Library.MySQL;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Hack2ProgressAspMvc.Controllers
{
    public class HogarController : Controller
    {
        // GET: Hogar
        public ActionResult Index()
        {
            var cmd = new MySqlCommand
            {
                CommandText = "SELECT * FROM hogares"
            };
            var items = SqlConnector.Instance.GetTable(cmd, out var r);
            List<Hogar> hogares = new List<Hogar>();
            foreach (DataRow item in items.Rows)
            {
                var hogar = new Hogar()
                {
                    Id = int.Parse(item[0].ToString()),
                    Nombre = item[1].ToString()
                };
                hogares.Add(hogar);
            }

            return View(hogares);
        }

        // GET: Hogar/Details/5
        [ActionName("Details")]
        public ActionResult Details(int id)
        {
            var cmd = new MySqlCommand
            {
                CommandText = "SELECT * FROM hogares WHERE id = @id"
            };
            cmd.Parameters.Add("@id", id);
            var items = SqlConnector.Instance.GetTable(cmd, out var r);
            List<Hogar> hogares = new List<Hogar>();
            foreach (DataRow i in items.Rows)
            {
                var hogar = new Hogar()
                {
                    Id = int.Parse(i[0].ToString())
                };
                hogares.Add(hogar);
            }

            var item = hogares.First(x => x.Id == id);
            return View(item);
        }

        // GET: Hogar/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Hogar/Create
        [HttpPost]
        public ActionResult Create(Hogar collection)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    var cmd = new MySqlCommand
                    {
                        CommandText = "INSERT INTO `hogares` (`id`, `nombre`) VALUES (NULL, @nombre)"
                    };
                    cmd.Parameters.Add("@nombre", collection.Nombre);

                    SqlConnector.Instance.ExecuteQuery(cmd, out var r);

                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        // GET: Hogar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Hogar/Edit/5

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hogar item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cmd = new MySqlCommand
                    {
                        CommandText = "Update hogares set id = @id, nombre = @nombre where id = @id"
                    };
                    cmd.Parameters.Add("@id", item.Id);
                    cmd.Parameters.Add("@nombre", item.Nombre);

                    SqlConnector.Instance.ExecuteQuery(cmd, out var r);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        // GET: Hogar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Hogar/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete(int id, Hogar model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cmd = new MySqlCommand
                    {
                        CommandText = "DELETE FROM hogares WHERE id = @id"
                    };
                    cmd.Parameters.Add("@id", model.Id);

                    SqlConnector.Instance.ExecuteQuery(cmd, out var r);

                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }
    }
}
