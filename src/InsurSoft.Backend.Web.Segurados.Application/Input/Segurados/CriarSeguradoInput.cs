using System;

namespace InsurSoft.Backend.Web.Segurados.Input.Segurados
{
    public class CriarSeguradoInput
    {
        public CriarSeguradoInput()
        {

        }

        public CriarSeguradoInput(string nome, string sobrenome, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }    
    }
}
