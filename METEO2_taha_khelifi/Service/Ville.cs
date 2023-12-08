using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static METEO2_taha_khelifi.MainWindow;
using System.IO;
namespace METEO2_taha_khelifi.Service
{
    public class Ville
    {

       // C:\Users\SLAB70\Downloads\C#\meteo2\METEO2_taha_khelifi\Service\FichierVille.txt
        string Path = @"Service/FichierVille.txt";
        public List<string> LsVille;
        public Ville() {

            LsVille = new List<string>();

            // Calling the ReadAllLines() function 
            string[] TabVille = File.ReadAllLines(Path);

            foreach (string ville in TabVille)
            {
                LsVille.Add(ville);
            }

        }

        public List<string> GetVille()
        {
            return LsVille;
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
