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

        public double HauteurBute
        {
            get { return hauteurBute; }
            set { hauteurBute = value; }
        }
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
            this.hauteurBute = getRandomNumber(1,180); // Angle de la butée
            this.longueurBras = getRandomNumber(1, 10); // En mètres
            this.masseBras = getRandomNumber(1, 30);    // En kilos
            this.angleForceTraction = getRandomNumber(1, 180); // En degrés
            this.masseContrePoid = getRandomNumber(1, 30); // En kilos
            this.masseProjectile = getRandomNumber(1, 30); // En kilos
            this.longueurBase = getRandomNumber(1, 10); // En mètres

        }
        public double getRandomNumber(double min, double max)
        {
            return Math.Round(Constantes.random.NextDouble() * (max - min) + min,2);
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
            return Math.Round((masseContrePoid * Constantes.GTERRE) * Math.Sin(angleForceTraction) - (masseProjectile * Constantes.GTERRE) * Math.Cos(hauteurBute), 2);

        }

        public double momentBras()
        {
            return Math.Round((forceTraction() * longueurBras), 2);
        }

        public double momentInertieBras()
        {
            return Math.Round((masseBras * Math.Pow(longueurBras, 2))/3, 2);
        }

        public double accelerationAngulaire()
        {
            return Math.Round((momentBras() / momentInertieBras()), 2);
        }

        public double velocite()
        {
            return Math.Round((accelerationAngulaire() * longueurBras), 5);
        }

        public double portee()
        {
            var portee = Math.Round(((Math.Pow(velocite(), 2) / Constantes.GTERRE) * Math.Sin(2 * (90 - hauteurBute))), 2);

            if (portee > 0)
                return portee;
            else
                return 0;
        }

        public double energieImpact()
        {
            return Math.Round((0.5 * masseProjectile * Math.Pow(velocite(), 2)), 2);
        }
        public bool estViable()
        {
            var var1 = (Math.Pow((Math.Sin(hauteurBute * longueurBras)), 2) + Math.Pow(Math.Cos(hauteurBute) * longueurBras - longueurBase, 2)) * Math.Sin(hauteurBute) * (masseProjectile * Constantes.GTERRE);
            var var2 = longueurBase * (masseContrePoid * Constantes.GTERRE);
            
            if (var1 <= var2)
                return true;
            else
                return false;
        }

        public void afficherPortee()
        {
            Console.WriteLine("La portee de la catapulte est de : " + portee() + "m");
        }


        public double noteMoyenne()
        {
            double noteHauteurBute = Notation.note(hauteurBute, Contraintes.hauteurBute, Contraintes.stepAngle);
            double noteLongueurBras = Notation.note(longueurBras, Contraintes.longueurBras, Contraintes.stepMetre);
            double noteMasseBras = Notation.note(masseBras, Contraintes.masseBras, Contraintes.stepMasse);
            double noteAngleForceTraction = Notation.note(angleForceTraction, Contraintes.angleForceTraction, Contraintes.stepAngle);
            double noteMasseContrePoid = Notation.note(masseContrePoid, Contraintes.masseContrePoid, Contraintes.stepMasse);
            double noteMasseProjectile = Notation.note(masseProjectile, Contraintes.masseProjectile, Contraintes.stepMasse);
            double noteLongueurBase = Notation.note(longueurBase, Contraintes.longueurBase, Contraintes.stepMetre);

            return Math.Round((noteHauteurBute + noteLongueurBras + noteMasseBras + noteAngleForceTraction + noteMasseContrePoid + noteMasseProjectile + noteLongueurBase)/7, 2);
        }


        
    }
}
