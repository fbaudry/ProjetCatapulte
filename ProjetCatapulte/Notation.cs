using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCatapulte
{
    public static class Notation
    {
        public static double note(double valeur, double contrainte, double step)
        {
            double diff = valeur - contrainte;

            if (diff < 0)
                diff = Math.Sqrt(Math.Pow(diff, 2));

            if (Constantes.NOTE_MAX - Convert.ToInt16(diff / step) < 0)
                return 0;
            else
                return Constantes.NOTE_MAX - Convert.ToInt16(diff / step);

        }
    }
}
