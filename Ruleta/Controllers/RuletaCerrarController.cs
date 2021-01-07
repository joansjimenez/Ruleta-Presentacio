using Ruleta.Models.Bases;
using Ruleta.Models.RuletaCerrar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ruleta.Controllers
{
    public class RuletaCerrarController : ApiController
    {
        public HttpResponseMessage RuletaCerrarActualizar(PutRuletaCerrarParameters data)
        {
            if (data.RuletaID != null )
            {
                for (int i = 0; i < data.ApuestasTotales.Length; i++)
                {
                    if (data.ApuestasTotales[i].CampoApuestaID >= 1 || data.ApuestasTotales[i].CampoApuestaID <= 36)
                    {
                        data.ApuestasTotales[i].RetornoApuesta = data.ApuestasTotales[i].DineroApostado * 5;
                    }
                    else if (data.ApuestasTotales[i].CampoApuestaID >=37 || data.ApuestasTotales[i].CampoApuestaID >= 38)
                    {
                        data.ApuestasTotales[i].RetornoApuesta = data.ApuestasTotales[i].DineroApostado * 1.8;
                    }
                    else
                    {
                        data.ApuestasTotales[i].RetornoApuesta = 0;
                    }
                    CollectionResult<CRUD_RuletaCerrar_Result> service = CallService<CRUD_RuletaCerrar_Result>("RuletaCerrar/RuletaCerrarActualizar", data, delegate ()
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
    }
}
