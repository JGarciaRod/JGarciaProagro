using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_Web_Api.Controllers
{
    [RoutePrefix("api/Georreferencias")]
    public class GeorreferenciasController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Georreferencias.GetAll();
            
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{IdGeorreferencias?}")]
        [HttpGet]
        public IHttpActionResult GetById(int IdGeorreferencias)
        {
            ML.Result result = BL.Georreferencias.GetById(IdGeorreferencias);

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
        public IHttpActionResult Add(ML.Georreferencias georreferencias)
        {
            ML.Result result = BL.Georreferencias.Add(georreferencias);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content (HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{IdGeorreferencias?}")]
        [HttpPut]
        public IHttpActionResult Update(int IdGeorreferencias,[FromBody] ML.Georreferencias georreferencias)
        {
            georreferencias.IdGeorreferencias = IdGeorreferencias;
            ML.Result result = BL.Georreferencias.Update(georreferencias);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{IdGeorreferencias?}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdGeorreferencias)
        {
            ML.Result result = BL.Georreferencias.Delete(IdGeorreferencias);

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
