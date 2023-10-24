using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMoyennes
{
    class Eleve
    {
        private string _prenom;
        private string _nom;
        public List<Note> toutesNotes = new List<Note>();
        public string prenom
        {
            get => _prenom;
            set => _prenom = value;
        }
        public string nom
        {
            get => _nom;
            set => _nom = value;
        }

        public decimal moyenneGeneral()
        {
            float noteTotal = 0;
            for (int imatiere = 0; imatiere < toutesNotes.Count; imatiere++)
            {
                noteTotal += toutesNotes[imatiere].note;
            }
            return Math.Round((decimal)(noteTotal / toutesNotes.Count), 2);
        }
        public decimal moyenneMatiere(int m)
        {
            float noteTotMat = 0;
            int counter = 0;
            for (int inote = 0; inote < toutesNotes.Count; inote++)
            {
                if (toutesNotes[inote].matiere == m)
                {
                    noteTotMat += toutesNotes[inote].note;
                    counter++;
                }
            }
            return Math.Round((decimal)(noteTotMat / counter), 2);
        }
        public void ajouterNote(Note noteEleve)
        {
            if (toutesNotes.Count >= 200)
            {
                Console.WriteLine("Erreur : Un eleve recoit au plus 200 notes au cours de l'annee");
                throw new Exception("Un eleve recoit au plus 200 notes au cours de l'annee");
            }
            toutesNotes.Add(noteEleve);
        }
    }
}
