using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBancariaAPI
{
    public interface ICuentaBancariaPrincipal
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Sexo { get; set; }

        public string Tipo { get; set; }

        public string DireccionDomicilio { get; set; }




    }
}
