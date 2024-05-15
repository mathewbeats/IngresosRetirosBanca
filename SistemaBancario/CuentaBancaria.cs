using SistemaGestionBancariaAPI;
using System;

namespace SistemaBancario
{
    public class CuentaBancaria : ICuentaBancariaPrincipal, ICuentaBancariaPropiedadesExtra
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Tipo { get; set; }
        public string DireccionDomicilio { get; set; }

        private decimal _balance;

        public decimal Balance
        {
            get { return this._balance; }
            set
            {
                if (value >= 0)
                    this._balance = value;
            }
        }

        public CuentaBancaria(decimal balance)
        {
            this._balance = balance;
        }

        public virtual bool Deposit(decimal amount)
        {
            if (amount <= 0) return false;

            Balance += amount;
            Console.WriteLine($"Deposito efectivo. Total depositado: {amount}");
            return true;
        }

        public virtual bool Retiro(decimal amount)
        {
            if (amount <= 0 || amount > Balance) return false;

            Balance -= amount;
            Console.WriteLine($"Total retirado: {amount}");
            return true;
        }

        public virtual void ImprimirBalance()
        {
            Console.WriteLine($"Balance total en cuenta: {this.Balance}");
        }
    }
}
