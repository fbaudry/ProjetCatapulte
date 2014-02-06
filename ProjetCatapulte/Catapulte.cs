using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCatapulte
{
    class Catapulte
    {
        double hauteurBute;
        double longueurBras;
        double masseBras;
        double angleForceTraction;
        double masseContrePoid;
        double masseProjectile;
        double longueurBase;


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
            
            hauteurBute = getRandomNumber(1,180); // Angle de la butée
            longueurBras = getRandomNumber(1, 10); // En mètres
            masseBras = getRandomNumber(1, 30);    // En kilos
            angleForceTraction = getRandomNumber(1, 180); // En degrés
            masseContrePoid = getRandomNumber(1, 30); // En kilos
            masseProjectile = getRandomNumber(1, 30); // En kilos
            longueurBase = getRandomNumber(1, 10); // En mètres

        }
        public double getRandomNumber(double min, double max)
        {
            Random value = new Random();
            return Math.Round(value.NextDouble() * (max - min) + min,2);

        }


        /*
         *  Fonction d'affichage des paramètres de la catapulte
         */
        public void afficherParametres()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Hauteur butée : " + hauteurBute + " degrés ");
            Console.WriteLine("Longueur bras : " + longueurBras + " mètres ");
            Console.WriteLine("Masse bras : " + masseBras + " kgs ");
            Console.WriteLine("Angle force traction : " + angleForceTraction + " degrés ");
            Console.WriteLine("Masse projectile : " + masseProjectile + " kgs ");
            Console.WriteLine("Longueur de la base : " + longueurBase + " mètres ");
            Console.WriteLine("----------------------------------------");

        }

        public double forceTraction()
        {
            return (masseContrePoid * Constantes.gTerre) * Math.Sin(angleForceTraction) - (masseProjectile * Constantes.gTerre) * Math.Cos(hauteurBute);

        }

        public double momentBras()
        {
            return (forceTraction() * longueurBras);
        }

        public double momentInertieBras()
        {
            return (masseBras * Math.Pow(longueurBras, 2))/3;
        }

        public double accelerationAngulaire()
        {
            return (momentBras() / momentInertieBras());
        }

        public double velocite()
        {
            return (accelerationAngulaire() * longueurBras);
        }

        public double portee()
        {
            return ((Math.Pow(velocite(), 2) / Constantes.gTerre) * Math.Sin(2*(90 - hauteurBute)));
        }

        public double energieImpact()
        {
            return (0.5 * masseProjectile * Math.Pow(velocite(), 2));
        }
        public bool estViable()
        {
            var var1 = (Math.Pow((Math.Sin(hauteurBute * longueurBras)), 2) + Math.Pow(Math.Cos(hauteurBute) * longueurBras - longueurBase, 2)) * Math.Sin(hauteurBute) * (masseProjectile * Constantes.gTerre);
            var var2 = longueurBase * (masseContrePoid * Constantes.gTerre);
            
            if (var1 <= var2)
                return true;
            else
                return false;
        }
    }
}
