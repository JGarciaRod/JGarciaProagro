using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var responseTask = client.GetAsync($"Usuario");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var item in readTask.Result.Objects)
                    {
                        ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(item.ToString());
                        usuario.Usuarios.Add(resultItemList);
                    }
                }
            }
           return View(usuario);
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario) 
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<object>();

            if (IdUsuario != 0 ) //update
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                    var responseTak = client.GetAsync("Usuario/GetId?IdUsuario=" + IdUsuario);
                    responseTak.Wait();

                    var result = responseTak.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
                        usuario = resultItemList;
                    }
                }
            }
            else //add
            {

            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                if (usuario.IdUsuario == 0) //Add
                {
                    var postTask = client.PostAsJsonAsync<ML.Usuario>("Usuario", usuario);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Incertado Correctamente";
                    }
                    else
                    {
                        ViewBag.Error = result.ToString();
                    }
                }
                else //update
                {
                    var putTask = client.PutAsJsonAsync<ML.Usuario>("Usuario?IdUsuario=" + usuario.IdUsuario, usuario);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Actualizado Correctamente";
                    }
                    else
                    {
                        ViewBag.Error = result.ToString();
                    }
                }
                return PartialView("Modal");
            }
        }

        [HttpDelete]
        public ActionResult Dell(int IdUsuario)
        {
            using (var client  = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var deleteTask = client.DeleteAsync("Usuario?IdUsuario=" + IdUsuario);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Eliminado correctamente";
                }
                else
                {
                    ViewBag.Error = result.ToString();
                }
            }
            return PartialView("Modal");
        }
    }
}