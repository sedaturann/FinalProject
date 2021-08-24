using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonManager personManager = new PersonManager(new EfPersonDal());
            var result = personManager.GetPersonDetails();
            if (result.Success==true)
            {
                foreach (var person in personManager.GetPersonDetails().Data)
                {
                    Console.WriteLine(person.PersonName + person.PersonSurname);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.ReadLine();
        }
    }
}

