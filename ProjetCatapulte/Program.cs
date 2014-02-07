using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCatapulte
{
    class Program
    {
        static void Main(string[] args)
        {

            // Création d'un jeu de catapultes
            List<Catapulte> catapultes = new List<Catapulte>();

            Console.WriteLine("Création du jeu de données (" + Constantes.NB_CATAPULTE + " catapultes)");

            for (int i = 0; i < Constantes.NB_CATAPULTE; i++)
            {
                Catapulte catapulte = new Catapulte();
                Console.WriteLine("Note moyenne de la catapulte :" + catapulte.noteMoyenne());
                catapultes.Add(catapulte);
            }

       
            Console.ReadLine();
        }
    }
}
