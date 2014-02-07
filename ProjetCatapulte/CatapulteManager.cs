using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCatapulte
{
    class CatapulteManager
    {
        
        public static List<Catapulte> selectionCatapultes(List<Catapulte> allCatapultes)
        {
            List<Catapulte> catapultesSelectionnee = new List<Catapulte>();

            foreach(Catapulte selection in allCatapultes)
            {
                double diffNote = 0;
                double pourcentageAvantage = 0;
                double avantageCatapulte = 0;
                double noteMoyenne = selection.noteMoyenne();
                if( noteMoyenne > Contraintes.noteStandard)
                {
                   diffNote = noteMoyenne - Contraintes.noteStandard;
                   pourcentageAvantage = diffNote / Contraintes.stepPourcentageNote;
                   avantageCatapulte = pourcentageAvantage * Constantes.NB_CATAPULTE;
                   for (int i = 0; i <= avantageCatapulte; i++)
                   {
                       catapultesSelectionnee.Add(selection);
                   }
                }
                else
                {
                    catapultesSelectionnee.Add(selection);
                }
            }
            return catapultesSelectionnee;
        }

        //public static List<Catapulte> mutationCatapulte(List<Catapulte> allCatapultes)
        //{

        //}
    }
}
