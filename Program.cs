using System;
using System.Collections.Generic;
using System.Linq;

namespace TPMoyennes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'une classe
            Classe sixiemeA = new Classe("6eme A");
            // Ajout des élèves à la classe
            sixiemeA.ajouterEleve("Jean", "RAGE");
            sixiemeA.ajouterEleve("Paul", "HAAR");
            sixiemeA.ajouterEleve("Sibylle", "BOQUET");
            sixiemeA.ajouterEleve("Annie", "CROCHE");
            sixiemeA.ajouterEleve("Alain", "PROVISTE");
            sixiemeA.ajouterEleve("Justin", "TYDERNIER");
            sixiemeA.ajouterEleve("Sacha", "TOUILLE");
            sixiemeA.ajouterEleve("Cesar", "TICHO");
            sixiemeA.ajouterEleve("Guy", "DON");
            // Ajout de matières étudiées par la classe
            sixiemeA.ajouterMatiere("Francais");
            sixiemeA.ajouterMatiere("Anglais");
            sixiemeA.ajouterMatiere("Physique/Chimie");
            sixiemeA.ajouterMatiere("Histoire");
            Random random = new Random();
            // Ajout de 5 notes à chaque élève et dans chaque matière
            for (int ieleve = 0; ieleve < sixiemeA.eleves.Count; ieleve++)
            {
                for (int matiere = 0; matiere < sixiemeA.matieres.Count; matiere++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sixiemeA.eleves[ieleve].ajouterNote(new Note(matiere, (float)((6.5 +
                       random.NextDouble() * 34)) / 2.0f));
                        // Note minimale = 3
                    }
                }
            }

            Eleve eleve = sixiemeA.eleves[6];
            // Afficher la moyenne d'un élève dans une matière
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            eleve.moyenneMatiere(1) + "\n");
            // Afficher la moyenne générale du même élève
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne Generale : " + eleve.moyenneGeneral() + "\n");
            // Afficher la moyenne de la classe dans une matière
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            sixiemeA.moyenneMatiere(1) + "\n");
            // Afficher la moyenne générale de la classe
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne Generale : " + sixiemeA.moyenneGeneral() + "\n");
            Console.Read();
        }
    }
    public class Classe
    {
        public string nomClasse;
        public List<Eleve> eleves = new List<Eleve>();
        public List<string> matieres = new List<string>();
        public float moyenneGeneral;

        public Classe(string classeNom)
        {
            nomClasse = classeNom;
        }
        public void ajouterEleve(string fname, string lname)
        {
            if (eleves.Count >= 30)
            {
                throw new Exception("Une classe n'accueille qu'au maximum 30 eleves");
            }
            eleves.Add(new Eleve { prenom = fname, nom = lname });        
        }
        public void ajouterMatiere(string matiere)
        {
            if (matieres.Count >= 10)
            {
                throw new Exception("10 matieres maximum sont enseignees dans une classe")
            }
            matieres.Add(matiere);
        }
        public float moyenneMatiere(int m)
        {
            float noteTotMat = 0;
            for (int ieleve = 0; ieleve < eleves.Count; ieleve++)
            {
                noteTotMat += eleves[ieleve].moyenneMatiere[1];
            }
            float noteMoyMat = noteTotMat / eleves.Count;
        }
    }
    class Eleve
    {
        private string _prenom;
        private string _nom;
        public List<float> moyenneMatiere = new List<float>();
        public List<Note> notes = new List<Note>();
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

    }
}




