using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nationala2018
{
    public class Lectie
    {
        public int IdLectie;
        public int IdUtilizator;
        public string TitluLectie;
        public string Regiune;
        public DateTime DataCreare;
        public string NumeImagine;

        public Lectie(int idLectie, int idUtilizator, string titluLectie, string regiune, DateTime dataCreare, string numeImagine)
        {
            IdLectie = idLectie;
            IdUtilizator = idUtilizator;
            TitluLectie = titluLectie;
            Regiune = regiune;
            DataCreare = dataCreare;
            NumeImagine = numeImagine;
        }   
    }
}
