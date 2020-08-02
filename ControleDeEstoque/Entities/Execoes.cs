using System;

namespace ControleDeEstoque
{
    class Execao : ApplicationException
    {
        public Execao(string erro) : base(erro)
        {
        }
    }
}
