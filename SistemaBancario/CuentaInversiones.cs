using SistemaGestionBancariaAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario
{
    public class CuentaInversiones : CuentaBancaria, ICuentaBancariaPrincipal, ICuentaBancariaPropiedadesExtra
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Tipo { get; set; }
        public string DireccionDomicilio { get; set; }

        private decimal _interestRate;

        private decimal _balance;

        public decimal Balance { get { return this._balance; } set { this._balance = value; } }

        public CuentaInversiones(decimal amount) : base(amount)
        {

            this._interestRate = 3.8m;

        }

        public override bool Deposit(decimal amount)
        {

            var depositado = Balance + (this.Balance + amount) * _interestRate;

            if(Balance > 0)
            {

                Console.WriteLine($"Total depositado en cuenta :{amount}");

                return true;
            }

            return false;

            

        }

        public override bool Retiro(decimal amount)
        {
            Balance -= (amount * _interestRate);

            if(amount < Balance && Balance > 0)
            {

                Console.WriteLine($"El retiro de {amount} fue satisfactorio");

                return true;
            }

            return false;



        }

        public override void ImprimirBalance()
        {
            Console.WriteLine($"El total de su balance es {base.Balance}");

        }






    }
}
