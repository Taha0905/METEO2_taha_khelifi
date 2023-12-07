using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static METEO2_taha_khelifi.MainWindow;

namespace METEO2_taha_khelifi.Service
{
    public class Ville
    {
        public List<string> LsVille;
        public Ville() {

            LsVille = new List<string>();

            LsVille.Add("Annecy");
            LsVille.Add("Marseille");
            LsVille.Add("Lyon");
            LsVille.Add("Bordeaux");
            LsVille.Add("Toulouse");
            LsVille.Add("Nice");
            LsVille.Add("Strasbourg");
            LsVille.Add("Nantes");
            LsVille.Add("Montpellier");
            LsVille.Add("Rennes");
            LsVille.Add("Grenoble");
            LsVille.Add("Toulon");
            LsVille.Add("Dijon");
            LsVille.Add("Angers");
         
        }

        //fonction pour ajouter une ville qui est dans la TB_Nouveaux
        public void AjouterVille(string nouvelleVille)
        {
            if (!LsVille.Contains(nouvelleVille)) // si la ville n'existe pas dans la liste
            {
                LsVille.Add(nouvelleVille); // ajouter la ville dans la liste
            }
        }

        // Fonction pour supprimer une ville
        public void SupprimerVille(string ville)
        {
            LsVille.Remove(ville); // supprimer la ville de la liste
        }
    }
}
