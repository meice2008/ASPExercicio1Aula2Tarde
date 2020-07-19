using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Exercicio1Aula2.DAL;
using Exercicio1Aula2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

//Meice Silva de Jesus
namespace Exercicio1Aula2.Controllers
{
    public class WSController : Controller
    {
        private readonly WSDAO _wsDAO;
        public WSController(WSDAO wsDAO)
        {
            _wsDAO = wsDAO;
        }
        public IActionResult Index()
        {
            if(TempData["Endereco"] != null)
            {
                string result = TempData["Endereco"].ToString();
                WSModel model = JsonConvert.DeserializeObject <WSModel>(result);
                _wsDAO.Cadastrar(model);
                return View(_wsDAO.Listar());
            }
            return View(_wsDAO.Listar());
        }
        [HttpPost]
        public IActionResult PesquisarCep(string txtCep)
        {
            string url = $@"https://viacep.com.br/ws/{txtCep}/json/";
            WebClient client = new WebClient();
            TempData["Endereco"] = client.DownloadString(url);
            return RedirectToAction("Index");
        }
    }
}