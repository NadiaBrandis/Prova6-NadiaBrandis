﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Prova6_NadiaBrandis
{
    abstract class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public Persona()
        {

        }
        public Persona(string nome,string cognome,string codiceFiscale)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codiceFiscale;
        }
    }
}
