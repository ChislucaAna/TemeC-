using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nationala2018
{
    public class Utilizator
    {
        public int IdUtilizator;
        public string Nume;
        public string Parola;
        public string Email;

        public Utilizator(int idUtilizator, string nume, string parola, string email)
        {
            IdUtilizator = idUtilizator;
            Nume = nume;
            Parola = parola;
            Email = email;
        }   
    }
}
