using SistemaGestionBancariaAPI;
using System;

namespace SistemaBancario
{
    public class CuentaAhorros : CuentaBancaria, ICuentaBancariaPrincipal, ICuentaBancariaPropiedadesExtra
    {
        public CuentaAhorros(decimal balance) : base(balance)
        {
        }

        public override bool Deposit(decimal amount)
        {
            if (amount <= 0) return false;

            Balance += amount;
            Console.WriteLine($"Importe depositado en cuenta: {amount}");
            return true;
        }

        public override bool Retiro(decimal amount)
        {
            if (amount <= 0 || amount > Balance) return false;

            Balance -= amount;
            Console.WriteLine($"Importe retirado: {amount}");
            return true;
        }

        public override void ImprimirBalance()
        {
            Console.WriteLine($"Balance total en cuenta de Ahorros: {Balance}");
        }
    }
}
