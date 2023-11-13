using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PermisosController : Controller
    {
        // GET: Permisos
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Permisos permisos = new ML.Permisos();
            permisos.ListPermisos = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var responseTask = client.GetAsync("Permisos");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var ItemList in readTask.Result.Objects)
                    {
                        ML.Permisos resultItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Permisos>(ItemList.ToString());
                        permisos.ListPermisos.Add(resultItem);
                    }
                }
            }
            return View(permisos);
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            ML.Permisos permisos = new ML.Permisos();
            permisos.ListPermisos = new List<object>();

            permisos.Usuario = new ML.Usuario();
            ML.Result resultUsuario = BL.Usuario.DropDownList();

            permisos.Estado = new ML.Estado();
            ML.Result resultEstado = BL.Estado.GetAll();

            if (IdUsuario != 0) //update
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                    var responsTask = client.GetAsync("Permisos?IdUsuario= " + IdUsuario);
                    responsTask.Wait();

                    var result = responsTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        ML.Permisos itemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Permisos>(readTask.Result.ToString());
                        permisos = itemList;
                        permisos.Estado.Estados = resultEstado.Objects;
                        permisos.Usuario.Usuarios = resultUsuario.Objects;

                    }
                }
            }
            else //add
            {
                permisos.Estado.Estados = resultEstado.Objects;
                permisos.Usuario.Usuarios = resultUsuario.Objects;
                permisos.Update = false;
            }

            return View(permisos);
        }

        [HttpPost]
        public ActionResult Form(ML.Permisos permisos)
        {
            using (var client  = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                if(permisos.Update == false) //Add
                {
                    var postTask = client.PostAsJsonAsync<ML.Permisos>("Permisos", permisos );
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se incerto correctamente";
                    }
                    else
                    {
                        ViewBag.Error = result.ToString();
                    }
                }
                else //update
                {
                    var putTask = client.PutAsJsonAsync<ML.Permisos>("Permisos?IdUsuario=" + permisos.Usuario.IdUsuario, permisos);
                    putTask.Wait();
                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se actualizo correctamente";
                    }
                    else
                    {
                        ViewBag.Error = result.ToString();
                    }
                }
            }
            return PartialView("Modal");
        }
    }
}