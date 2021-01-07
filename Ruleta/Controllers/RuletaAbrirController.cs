using Ruleta.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ruleta.Controllers
{
    public class RuletaAbrirController : ApiController
    {
        public HttpResponseMessage RuletaAbrirActualizar(PutRuletaAbrirParameters data)
        {
            CollectionResult<CRUD_RuletaAbrir_Result> service = CallService<CRUD_RuletaAbrir_Result>("RuletaAbrir/RuletaAbrirActualizar", data, delegate ()
            {
                return db.CRUD_RuletaCerrar(data.RuletaID, data.Estado);
            });

            if (service.result == ServiceResult.Success)
                return Request.CreateResponse(HttpStatusCode.OK, service);
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, service.stackError);
        }
    }
}
