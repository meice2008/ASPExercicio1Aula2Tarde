using Exercicio1Aula2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio1Aula2.DAL
{
    public class WSDAO
    {
        private readonly Context _context;
        public WSDAO(Context context)
        {
            _context = context;
        }
        public void Cadastrar(WSModel model)
        {
            _context.Enderecos.Add(model);
            _context.SaveChanges();
        }
        public List<WSModel> Listar()
        {
            return _context.Enderecos.ToList();
        }

        public WSModel Buscar(string cep)
        {
            return _context.Enderecos.Find(cep);
        }

        public void Deletar(WSModel model)
        {
            _context.Enderecos.Remove(model);
            _context.SaveChanges();
        }
        public WSModel BuscarPorId(int id)
        {
            return _context.Enderecos.Find(id);
        }

        public void Alterar(WSModel model)
        {
            _context.Enderecos.Update(model);
            _context.SaveChanges();
        }
    }
}
