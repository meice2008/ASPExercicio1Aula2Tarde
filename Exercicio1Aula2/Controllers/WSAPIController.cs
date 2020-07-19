using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercicio1Aula2.DAL;
using Exercicio1Aula2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio1Aula2.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class WSAPIController : ControllerBase
    {
        private readonly WSDAO _wsDAO;
        public WSAPIController(WSDAO wsDAO)
        {
            _wsDAO = wsDAO;
        }
        [HttpGet]
        [Route("ListarEnderecos")]
        public List<WSModel> Listar()
        {
            return _wsDAO.Listar();
        }

        //GET: /api/Endereco/ListarEndereco + ?cep= numeroDoCep
        [HttpGet]
        [Route("ListarEndereco")]
        public WSModel Buscar(string cep)
        {
            WSModel model = new WSModel();
            List < WSModel > lista = _wsDAO.Listar();
            for (int i=0;i<lista.Count;i++)
            {
                if (lista[i].Cep == cep)
                {
                    model = lista[i];
                    return model;
                }
            }
            return model;
        }

        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult Cadastrar(WSModel model)
        {
            _wsDAO.Cadastrar(model);
            return Created("", model);
        }


        //DELETE: api/Endereco/DeletarEndereco + ?id= numeroDoId
        [HttpDelete]
        [Route("DeletarEndereco")]
        public IActionResult Deletar(int id)
        {
            _wsDAO.Deletar(_wsDAO.BuscarPorId(id));
            return Ok(_wsDAO.Listar());
        }

        [HttpPut]
        [Route("AlterarEndereco")]
        public IActionResult Alterar(WSModel model)
        {
            _wsDAO.Alterar(model);
            return Ok(_wsDAO.Listar());
        }
    }
}