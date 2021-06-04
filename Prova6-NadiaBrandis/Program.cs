using System;
using System.Collections.Generic;

namespace Prova6_NadiaBrandis
{
    class Program
    {
        static void Main(string[] args)
        {

            //Risposte alle Domande teoriche:
           //1. Quali sono i paradigmi della programmazione ad oggetti?

           // a) Ereditarietà
          
           // e) Polimorfismo
           
           // g) Incapsulamento
           // h) Astrazione

           //2.Indicare la / le risposte corrette
           
           //b) Un metodo di tipo abstract non è dotato di implementazione
           //c) La classe che eredita un metodo di tipo abstract può non implementare il
          //funzionamento
          
          //3. Data una classe padre contenente il metodo “public virtual void Stampa()”, quale/i metodi
          //può contenere la classe figlia?
          
          //c) public override void Stampa()
          
         
            Console.WriteLine("--------------COMMISSARIATO DI POLIZIA--------------");
            Console.WriteLine("");
            string scelta;
            do
            {
                Console.WriteLine("1. Guarda tutti gli agenti di Polizia");
                Console.WriteLine("2. Guarda tutti gli agenti assegnati ad un area geografica");
                Console.WriteLine("3. Guarda tutti gli agenti con più di un tot di anni di servizio");
                Console.WriteLine("4. Inserisci un nuovo agente");
                Console.WriteLine("0, Esci dal applicazione");
                Console.Write("Fai la tua scelta: ");
                scelta = Console.ReadLine();
                switch(scelta)
                {
                    case "1":
                        DbManagerConnectedMode.GetAgenti();
                        break;
                    case "2":
                        Console.WriteLine("Molo 4\nQuartire marino\nPorto san giorgio\nCentro modale");
                        Console.Write("Indica l'area geografica: ");
                        string area = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine($"----Agenti per area: {area}----");
                        DbManagerConnectedMode.GetAgentiPerArea(area);
                        break;
                    case "3":
                        Console.Write("Inserisci gli anni di servizio: ");
                        int anni = int.Parse(Console.ReadLine());
                        DbManagerConnectedMode.GetAgentiPerAnno(anni);

                        break;
                    case "4":
                        Console.WriteLine("-----INSERISCI UN NUOVO AGENTE-----");
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Cognome: ");
                        string cognome = Console.ReadLine();
                        Console.Write("Codice Fiscale: ");
                        string codicefiscale = Console.ReadLine();
                        Console.Write("Area Geografica: ");
                        string a = Console.ReadLine();
                        Console.Write("Anno di inzio attività: ");
                        int annoInizio = int.Parse(Console.ReadLine());
                        List<Agente> Agenti = DbManagerConnectedMode.GetAgenti();
                        
                            foreach (var item in Agenti)
                        {

                            if (item.CodiceFiscale == codicefiscale)
                                {
                                    Console.WriteLine("Agente già presente in commissariato");
                                    break;

                            }
                                else
                                {
                                    DbManagerConnectedMode.AggiungiAgente(nome, cognome, codicefiscale, a, annoInizio);
                                    break;
                                }

                            }
                        
                        break;
                }

            } while (scelta != "0");
        }
    }
}
