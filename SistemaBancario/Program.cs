using SistemaBancario;
using SistemaGestionBancariaAPI;
using System;
using System.Threading;

class Program
{
    const int Batch_Size = 5;

    static void Main(string[] args)
    {
        // Instancia del sistema de gestión bancaria para cuentas de ahorros
        BankingManagementSystem<CuentaAhorros> bankingSystem = new BankingManagementSystem<CuentaAhorros>();

        // Suscripción al evento
        bankingSystem.customStackEvent += BankingSystem_CustomStackEvent;

        // Simulación de depósitos y retiros
        var cuenta1 = new CuentaAhorros(1000m) { Id = 1, Nombre = "Juan", Apellido = "Pérez", DireccionDomicilio = "Calle Falsa 123", Tipo = "Ahorros", Sexo = "M" };
        bankingSystem.AddTransaction(cuenta1, "Cuenta creada");
        Thread.Sleep(2000);
        cuenta1.Deposit(500m);
        bankingSystem.AddTransaction(cuenta1, "Depósito", 500m);
        Thread.Sleep(2000);
        cuenta1.Deposit(300m);
        bankingSystem.AddTransaction(cuenta1, "Depósito", 300m);
        Thread.Sleep(2000);
        cuenta1.Retiro(200m);
        bankingSystem.AddTransaction(cuenta1, "Retiro", 200m);

        Thread.Sleep(2000);

        var cuenta2 = new CuentaAhorros(2000m) { Id = 2, Nombre = "Ana", Apellido = "García", DireccionDomicilio = "Avenida Siempreviva 742", Tipo = "Ahorros", Sexo = "F" };
        bankingSystem.AddTransaction(cuenta2, "Cuenta creada");
        Thread.Sleep(2000);
        cuenta2.Retiro(300m);
        bankingSystem.AddTransaction(cuenta2, "Retiro", 300m);

        Thread.Sleep(2000);

        var cuenta3 = new CuentaAhorros(1500m) { Id = 3, Nombre = "Carlos", Apellido = "Lopez", DireccionDomicilio = "Calle Luna 1", Tipo = "Ahorros", Sexo = "M" };
        bankingSystem.AddTransaction(cuenta3, "Cuenta creada");
        Thread.Sleep(2000);
        cuenta3.Deposit(700m);
        bankingSystem.AddTransaction(cuenta3, "Depósito", 700m);

        Thread.Sleep(2000);

        var cuenta4 = new CuentaAhorros(3000m) { Id = 4, Nombre = "Lucia", Apellido = "Martinez", DireccionDomicilio = "Calle Sol 2", Tipo = "Ahorros", Sexo = "F" };
        bankingSystem.AddTransaction(cuenta4, "Cuenta creada");
        Thread.Sleep(2000);
        cuenta4.Retiro(1000m);
        bankingSystem.AddTransaction(cuenta4, "Retiro", 1000m);

        Thread.Sleep(2000);

        var cuenta5 = new CuentaAhorros(5000m) { Id = 5, Nombre = "Jose", Apellido = "Ramirez", DireccionDomicilio = "Calle Estrella 3", Tipo = "Ahorros", Sexo = "M" };
        bankingSystem.AddTransaction(cuenta5, "Cuenta creada");
        Thread.Sleep(2000);
        cuenta5.Deposit(2000m);
        bankingSystem.AddTransaction(cuenta5, "Depósito", 2000m);

        // Procesar transacciones cuando se alcance el tamaño del lote
        ProcessTransactions(bankingSystem);

        Console.ReadKey();
    }

    static void BankingSystem_CustomStackEvent(BankingManagementSystem<CuentaAhorros> sender, StackEventArgs e)
    {
        Console.Clear();
        Console.WriteLine(MainHeading());
        Console.WriteLine();
        Console.WriteLine(RealTimeUpdateHeading());

        if (sender.StackLength() > 0)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine();
            Console.WriteLine(ItemsInStackHeading());
            Console.WriteLine(FieldHeadings());
            WriteValuesInStackToScreen(sender);

            if (sender.StackLength() == Batch_Size)
            {
                ProcessTransactions(sender);
            }
        }
        else
        {
            Console.WriteLine("All Transactions Have Been Processed");
        }
    }

    static void ProcessTransactions(BankingManagementSystem<CuentaAhorros> bankingSystem)
    {
        while (bankingSystem.StackLength() > 0)
        {
            Thread.Sleep(3000);
            CuentaAhorros transaction = bankingSystem.GetTransaction();
        }
    }

    static void WriteValuesInStackToScreen(BankingManagementSystem<CuentaAhorros> bankingSystem)
    {
        foreach (var transaction in bankingSystem)
        {
            Console.WriteLine($"{transaction.Id,-6}{transaction.Nombre,-15}{transaction.Apellido,-20}{transaction.Tipo,-10}{transaction.Balance,10}");
        }
    }

    static string FieldHeadings()
    {
        return UnderLine($"{"Id",-6}{"Nombre",-15}{"Apellido",-20}{"Tipo",-10}{"Balance",10}");
    }

    static string RealTimeUpdateHeading()
    {
        return UnderLine("Real-time Update");
    }

    static string ItemsInStackHeading()
    {
        return UnderLine("Transactions in Stack");
    }

    static string MainHeading()
    {
        return UnderLine("Banking Management System");
    }

    static string UnderLine(string heading)
    {
        return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
    }
}
