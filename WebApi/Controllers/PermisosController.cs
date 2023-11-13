using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Permisos")]
    public class PermisosController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Permisos.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{IdUsuario?}")]
        [HttpGet]
        public IHttpActionResult GetById(int IdUsuario)
        {
            ML.Result result = BL.Permisos.GetById(IdUsuario);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.Permisos permisos)
        {
            ML.Result result = BL.Permisos.Add(permisos);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{IdUsuario?}")]
        [HttpPut]
        public IHttpActionResult Update(int IdUsuario, [FromBody] ML.Permisos permisos)
        {
            permisos.Usuario.IdUsuario = IdUsuario;
            ML.Result result = BL.Permisos.Update(permisos);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{IdUsuario?}/{IdEstado?}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdUsuario, int IdEstado)
        {
            ML.Result result = BL.Permisos.Delete(IdUsuario, IdEstado);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
