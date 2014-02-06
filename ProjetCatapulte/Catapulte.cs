using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCatapulte
{
    class Catapulte
    {
        float hauteurBute;
        float longueurBras;
        float masseBras;
        float angleForceTraction;
        float masseContrePoid;
        float masseProjectile;
        float longueurBase;


        /*
         * Constructeur par default
         * - Les valeurs par défaut sont aléatoires et comprises entre une valeur min et une valeur max qui sont différentes en fonction du type de mesure
         * 
         * - Valeur min et max pour les variables en Degrés : 1 à 180
         * - Valeur min et max pour les variables en Kilos : 1 à 30
         * - Valeur min et max pour les variables en mètres : 1 à 10
         */
        public Catapulte()
        {
            Random value = new Random();

            hauteurBute = value.Next();
            longueurBras = value.Next();
            masseBras = value.Next();
            angleForceTraction = value.Next();
            masseContrePoid = value.Next();
            masseProjectile = value.Next();
            longueurBase = value.Next();
        }

        public void afficherParametres()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Hauteur butée : " + hauteurBute + " degrés ");
            Console.WriteLine("Longueur bras : " + longueurBras + " mètres ");
            Console.WriteLine("Masse bras : " + masseBras + " kgs ");
            Console.WriteLine("Angle force traction : " + angleForceTraction + " degrés ");
            Console.WriteLine("Masse projectile : " + masseProjectile + " kgs ");
            Console.WriteLine("Longueur de la base : " + longueurBase + " mètres ");
        }

        

    }
}
