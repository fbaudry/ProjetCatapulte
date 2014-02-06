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

    }
}
