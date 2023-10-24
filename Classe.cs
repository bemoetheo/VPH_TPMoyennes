using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMoyennes
{
    class Classe
    {
        public string nomClasse;
        public List<Eleve> eleves = new List<Eleve>();
        public List<string> matieres = new List<string>();

        public Classe(string classeNom)
        {
            nomClasse = classeNom;
        }
        public void ajouterEleve(string fname, string lname)
        {
            if (eleves.Count >= 30)
            {
                Console.WriteLine("Erreur : Une classe n'accueille qu'au maximum 30 eleves");
                throw new Exception("Une classe n'accueille qu'au maximum 30 eleves");
            }
            eleves.Add(new Eleve { prenom = fname, nom = lname });
        }
        public void ajouterMatiere(string matiere)
        {
            if (matieres.Count >= 10)
            {
                Console.WriteLine("Erreur : 10 matieres maximum sont enseignees dans une classe");
                throw new Exception("10 matieres maximum sont enseignees dans une classe");
            }
            matieres.Add(matiere);
        }
        public decimal moyenneMatiere(int m)
        {
            float noteTotMatClasse = 0;
            for (int ieleve = 0; ieleve < eleves.Count; ieleve++)
            {
                float noteTotMatEleve = 0;
                int counter = 0;
                for (int inote = 0; inote < eleves[ieleve].toutesNotes.Count; inote++)
                {
                    if (eleves[ieleve].toutesNotes[inote].matiere == m)
                    {
                        noteTotMatEleve += eleves[ieleve].toutesNotes[inote].note;
                        counter++;
                    }
                }
                noteTotMatClasse += noteTotMatEleve / counter;
            }
            return Math.Round((decimal)(noteTotMatClasse / eleves.Count), 2);
        }
        public decimal moyenneGeneral()
        {
            float noteGenClasse = 0;
            for (int ieleve = 0; ieleve < eleves.Count; ieleve++)
            {
                float noteTotalEleve = 0;
                for (int inote = 0; inote < eleves[ieleve].toutesNotes.Count; inote++)
                {
                    noteTotalEleve += eleves[ieleve].toutesNotes[inote].note;
                }
                noteGenClasse += noteTotalEleve / eleves[ieleve].toutesNotes.Count;
            }
            return Math.Round((decimal)(noteGenClasse / eleves.Count), 2);
        }
    }
}
