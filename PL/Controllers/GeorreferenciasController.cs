using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class GeorreferenciasController : Controller
    {
        // GET: Georreferencias
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Georreferencias georreferencias = new ML.Georreferencias();
            georreferencias.ListGeorreferencias = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var responsTask = client.GetAsync("Georreferencias");
                responsTask.Wait();

                var result = responsTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var item in readTask.Result.Objects)
                    {
                        ML.Georreferencias itemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Georreferencias>(item.ToString());
                        georreferencias.ListGeorreferencias.Add(itemList);
                    }
                }
            }
          return View(georreferencias);
        }

        [HttpGet]
        public ActionResult Form(int? IdGeorreferencias)
        {
            ML.Georreferencias georreferencias = new ML.Georreferencias();
            georreferencias.Estado = new ML.Estado();

            georreferencias.ListGeorreferencias = new List<object>();

            ML.Result resultEstado = BL.Estado.GetAll();

            if(IdGeorreferencias != 0) //update
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                    var responsTask = client.GetAsync("Georreferencias/GetId?IdGeorreferencias=" +  IdGeorreferencias);
                    responsTask.Wait();

                    var result = responsTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        ML.Georreferencias itemlist = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Georreferencias>(readTask.Result.Object.ToString());
                        georreferencias = itemlist;

                        georreferencias.Estado.Estados = resultEstado.Objects;
                    }

                }
            }
            else
            {
                georreferencias.Estado.Estados = resultEstado.Objects;
            }

            return View(georreferencias);
        }

        [HttpPost]
        public ActionResult Form(ML.Georreferencias georreferencias)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                if(georreferencias.IdGeorreferencias == 0) //Add
                {
                    var postTask = client.PostAsJsonAsync<ML.Georreferencias>("Georreferencias", georreferencias);
                    postTask.Wait();

                    var result = postTask.Result;
                    if(result.IsSuccessStatusCode)
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
                    var putTask = client.PutAsJsonAsync<ML.Georreferencias>("Georreferencias?IdGeorreferencias=" + georreferencias.IdGeorreferencias, georreferencias);
                    putTask.Wait();

                    var result = putTask.Result;
                    if(result.IsSuccessStatusCode)
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

        [HttpDelete]
        public ActionResult Delete(int IdGeorreferencias)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var deleteTask = client.DeleteAsync("Georreferencias?IdGeorreferencias=" + IdGeorreferencias);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Se elimino correctamente";
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