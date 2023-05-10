using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm_1_marzec_2023.Model
{
    public class Zadanie
    {
        public string Temat { get; }
        public string Opis { get; }

        public Zadanie(string temat, string opis)
        {
            Temat = temat;
            Opis = opis;
        }
    }
}
