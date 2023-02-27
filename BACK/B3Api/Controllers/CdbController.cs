using B3Api.ModeloDeRequisicao;
using B3Modelo.ObjetosDeValor;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using B3Negocio.Ativo.CDB;
using B3Api.ModeloDeResposta;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace B3Api.Controllers
{
    public class CdbController : ApiController
    {
        private readonly CalculadoraCdb _calculadoraCdb;

        public CdbController()
        {
            _calculadoraCdb = new CalculadoraCdb();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/cdb/com-historico")]
        [HttpPost]
        public HttpResponseMessage CalcularComHistorico([FromBody] CalcularCdbRequest calcularCdbRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidOperationException(ModelState.Values.First().Errors.Last().ErrorMessage);

                var cdbs = this._calculadoraCdb.CalcularCdbComHistorico(new Dinheiro(calcularCdbRequest.Valor), calcularCdbRequest.QuantidadeDeMeses).ParaCdbRespostaResponse();
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(cdbs, settings: new Newtonsoft.Json.JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });

                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                return response;

            }
            catch (Exception e)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(e.Message);

                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                return response;
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/cdb")]
        [HttpPost]
        public HttpResponseMessage Calcular([FromBody] CalcularCdbRequest calcularCdbRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidOperationException(ModelState.Values.First().Errors.Last().ErrorMessage);
                
                var cdb = this._calculadoraCdb.CalcularCdb(new Dinheiro(calcularCdbRequest.Valor), calcularCdbRequest.QuantidadeDeMeses).ParaCdbRespostaResponse();
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(cdb, settings: new Newtonsoft.Json.JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });

                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                return response;

            }
            catch (Exception e)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(e.Message);

                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                return response;
            }
        }
    }
}
