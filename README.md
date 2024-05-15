Banking Management System

Descripción
El Banking Management System es una aplicación de consola desarrollada en C# que permite la gestión de cuentas de ahorros. Los usuarios pueden realizar operaciones de creación de cuenta, depósitos y retiros. La aplicación utiliza una pila (Stack) para almacenar y manejar las transacciones, y utiliza eventos para actualizar la consola en tiempo real con los detalles de cada operación.

Características
Creación de cuentas de ahorros.
Realización de depósitos y retiros.
Actualización en tiempo real del balance de la cuenta.
Manejo de transacciones utilizando una pila.
Registro detallado de cada operación realizada.
Estructura del Proyecto
El proyecto se organiza en las siguientes clases principales:

CuentaBancaria
Clase base que define las propiedades y métodos generales de una cuenta bancaria.

Propiedades
int Id: Identificador único de la cuenta.
string Nombre: Nombre del titular de la cuenta.
string Apellido: Apellido del titular de la cuenta.
string Email: Correo electrónico del titular de la cuenta.
string Sexo: Sexo del titular de la cuenta.
string Tipo: Tipo de cuenta (en este caso, "Ahorros").
string DireccionDomicilio: Dirección del domicilio del titular de la cuenta.
decimal Balance: Balance actual de la cuenta.
Métodos
virtual bool Deposit(decimal amount): Método para realizar un depósito en la cuenta.
virtual bool Retiro(decimal amount): Método para realizar un retiro de la cuenta.
virtual void ImprimirBalance(): Método para imprimir el balance actual de la cuenta.
CuentaAhorros
Clase derivada de CuentaBancaria que representa una cuenta de ahorros específica.

BankingManagementSystem<T>
Clase genérica que gestiona las transacciones bancarias utilizando una pila.

Propiedades
Stack<T> stack: Pila para almacenar las transacciones.
event StackEventHandleer<BankingManagementSystem<T>, StackEventArgs> customStackEvent: Evento que se dispara cuando cambia el estado de la pila.
Métodos
void AddTransaction(T item, string operation, decimal amount = 0): Método para agregar una transacción a la pila.
int StackLength(): Método para obtener la longitud de la pila.
T GetTransaction(): Método para obtener una transacción de la pila.
protected virtual void OnStackChanged(StackEventArgs e): Método para invocar el evento customStackEvent.
Uso
Requisitos
.NET SDK 6.0 o superior.
Instalación
Clona el repositorio:

bash
Copiar código
git clone https://github.com/tuusuario/banking-management-system.git
Navega al directorio del proyecto:

bash
Copiar código
cd banking-management-system
Restaura los paquetes NuGet:

bash
Copiar código
dotnet restore
Compila el proyecto:

bash
Copiar código
dotnet build
Ejecuta la aplicación:

bash
Copiar código
dotnet run


Ejemplo de Uso
La aplicación simula la creación de cuentas, depósitos y retiros de manera secuencial, intercalados con pausas para simular un entorno más realista.

Contribuciones
Si deseas contribuir a este proyecto, por favor sigue los siguientes pasos:

Haz un fork del repositorio.
Crea una nueva rama (git checkout -b feature/nueva-funcionalidad).
Realiza los cambios y haz commit (git commit -m 'Añadir nueva funcionalidad').
Sube los cambios a tu fork (git push origin feature/nueva-funcionalidad).
Crea un pull request explicando los cambios realizados.
Licencia
Este proyecto está bajo la Licencia MIT. Consulta el archivo LICENSE para más detalles.

Contacto
Si tienes alguna pregunta o sugerencia, no dudes en contactarme a través de [tu email] o abrir un issue en el repositorio.

