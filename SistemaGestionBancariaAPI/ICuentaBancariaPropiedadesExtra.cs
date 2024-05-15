using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBancariaAPI
{
    public interface ICuentaBancariaPropiedadesExtra
    {

        decimal Balance { get; set; }

        bool Deposit(decimal amount);

        bool Retiro(decimal amount);

        void ImprimirBalance();


    }
}
