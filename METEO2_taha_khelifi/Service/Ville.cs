using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METEO2_taha_khelifi.Service
{
    public class Ville
    {
        public List<string> LsVille;
        public Ville() {

            LsVille = new List<string>();

            LsVille.Add("Annecy");
            LsVille.Add("Marseille");
         
        }

        public void Addville( string city)
        {
            LsVille.Add(city);
        }
    }
}
