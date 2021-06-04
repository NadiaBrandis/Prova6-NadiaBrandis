using System;
using System.Collections.Generic;
using System.Text;

namespace Prova6_NadiaBrandis
{
    class Agente : Persona
    {
        public string AreaGeografica{ get; set; }
        public int AnnoInizioAttivita { get; set; }
        public Agente(string nome,string cognome,string codiceFiscale,string areaGeografica,int annoInizio)
            :base(nome,cognome,codiceFiscale)
        {
            AreaGeografica = areaGeografica;
            AnnoInizioAttivita = annoInizio;
        }
    }
}
