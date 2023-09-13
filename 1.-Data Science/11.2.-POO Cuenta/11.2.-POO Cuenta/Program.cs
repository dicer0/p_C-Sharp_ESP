using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._2._POO_Cuenta
{
    //Clase nueva creada 
    class Account
    {
        //Readonly es para encapsular el valor de la variable y que solo se pueda modificar desde dentro de la clase
        private readonly string name;
        private readonly string account_number;
        private double balance;

        //Constructor de la clase
        public Account(string name, string account_number, double initalAmount)
        {
            this.name = name;
            this.account_number = account_number;
            balance = initalAmount;
        }
        //Método depositar
        public void Deposit(double amount)
        {
            balance = balance + amount;
        }
        //Método retirar
        public void Withdraw(double amount)
        {
            balance = balance - amount;
        }
        //Método imprimir en consola el nombre, número de cuenta y crédito de la cuenta
        public void Dump()
        {
            Console.WriteLine("{0}, {1}, balance: {2}", name, account_number, balance);
        }
    }//Clase cuenta

    //Clase default que se crea al hacer un nuevo proyecto y contiene el método main
    class ClaseDefault
    {
        static void Main(string[] args)
        {
            //Instancia de la clase Account
            Account a1 = new Account("Helmer Homero", "1234", 20000);
            Account a2 = new Account("Pita amor", "5678", 2000);

            //Utilización de los métodos de la clase con cada objeto
            a1.Deposit(1000);
            a1.Withdraw(4000);
            a2.Withdraw(10500);
            a1.Withdraw(3500);

            a1.Dump();
            a2.Dump();
            //Haciendo trampa: Si esto no lo comento el programa me dará error porque está intentando acceder a una
            //variable encapsulada
            //a2.balance = 10000;
            //a2.dump();
        }
    }
}