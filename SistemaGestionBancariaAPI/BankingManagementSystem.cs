using SistemaGestionBancariaAPI;
using System;
using System.Collections.Generic;

namespace SistemaBancario
{
    public class BankingManagementSystem<T> where T : ICuentaBancariaPrincipal, ICuentaBancariaPropiedadesExtra
    {
        public delegate void StackEventHandleer<T, U>(T sender, U eventArgs);

        Stack<T> stack = null;

        public event StackEventHandleer<BankingManagementSystem<T>, StackEventArgs> customStackEvent;

        public BankingManagementSystem()
        {
            stack = new Stack<T>();
        }

        public void AddTransaction(T item, string operation, decimal amount = 0)
        {
            stack.Push(item);
            string message = $"Datetime: {DateTime.Now:dd MMM yyyy hh:mm:ss tt}, Cliente: {item.Nombre} {item.Apellido}, Operación: {operation}, Cantidad: {amount}, Balance Total: {item.Balance}";
            StackEventArgs stackEventArgs = new StackEventArgs { Message = message };
            OnStackChanged(stackEventArgs);
        }

        public int StackLength() => stack.Count;

        public T GetTransaction()
        {
            T item = stack.Pop();
            string message = $"Datetime: {DateTime.Now:dd MMM yyyy hh:mm:ss tt}, Cliente: {item.Nombre} {item.Apellido}, Operación: Procesado, Balance Total: {item.Balance}";
            StackEventArgs stackEventArgs = new StackEventArgs { Message = message };
            OnStackChanged(stackEventArgs);
            return item;
        }

        protected virtual void OnStackChanged(StackEventArgs e)
        {
            customStackEvent?.Invoke(this, e);
        }

        public IEnumerator<T> GetEnumerator() => stack.GetEnumerator();
    }

    public class StackEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
