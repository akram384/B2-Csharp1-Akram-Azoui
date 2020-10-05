using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Villes> listeVilles = new List<Villes>();
            while (true)
            {
                string choixUtilisateur = MenuVilles();

                if(choixUtilisateur == "1")
                {
                    Villes ville = CreatVilles();
                    listeVilles.Add(ville);
                }
                else if (choixUtilisateur == "2")
                {
                    Affiche(listeVilles);
                }
                else if (choixUtilisateur == "3")
                {
                    
                }
            }

            

            
            
        }
        private static string MenuVilles()
        {
            Console.WriteLine("Bienvenue dans l'appli de gestion des villes");
            Console.WriteLine("Que vouslez vous faire ?");
            Console.WriteLine("1. Créer une nouvelles ville");
            Console.WriteLine("2. Afficher l'ensemble des villes");
            Console.WriteLine("3. Afficher le nombre total d'habitants");
            string choixUtilisateur = Console.ReadLine();
            return choixUtilisateur;
        }

        public static Villes CreatVilles()
        {
            Villes ville = new Villes();

           
            ville.Nom = DemandeCaractère("Saisir le nom de la ville ?");

            
            ville.CodePostal = DemandeEntier("Saisir le code postale ? ");

            ville.nbHabitants = DemandeEntier("Saisir le nombres d'habitants ? ");

            string message;
            message = CreerMessage(ville);

            Console.WriteLine(message);
            return ville;

        }

        public static int DemandeEntier(string message)
        {
            Console.WriteLine(message);
            string entier;
            entier = Console.ReadLine();
            int intValue;
            while (true)
            {
                int.TryParse(entier,out intValue);
                if (intValue > 0)
                    break;
                Console.WriteLine("le code postal et le nombre d'habitans doivent être superieur à 0 !!!");
                entier = Console.ReadLine();
                
            }
            while (!int.TryParse(entier, out intValue))
            {
               
                    Console.WriteLine("la saisie est invalide : La saisie du code postal et du nombre d'habitants doivent être un numerique!!");
                entier = Console.ReadLine();
                
            }

          

            return intValue;
        }

        public static string DemandeCaractère(string message)
        {
            Console.WriteLine(message);
            string nom;
            int intValue;
            nom = Console.ReadLine();
            while(nom.Length ==0)
            {
                
                    Console.WriteLine("Saisie incorrecte : Le nom de la ville ne doit pas être vide !!");
                    
                    nom = Console.ReadLine();
                    
                
              
            }
            while (int.TryParse(nom, out intValue))
            {

                Console.WriteLine("la saisie est invalide : La saisie de la ville ne doit pas être un numerique!!");
                nom = Console.ReadLine();

            }
            if (String.IsNullOrEmpty(nom))
                throw new ArgumentException("ARGH!");
            return nom.First().ToString().ToUpper() + nom.Substring(1);

            
        }


        public static string CreerMessage (Villes ville)
        {
            string result;
            result = "Nom : \n" + ville.Nom + "\n" +" Code postal \n" + ville.CodePostal + "\n Nombre d'habitants \n" + ville.nbHabitants;
            return result;
         }


        public static void Affiche(List<Villes> villes)
        {
            foreach ( Villes ville in villes)
            {
                string message;
                message = CreerMessage(ville);
                Console.WriteLine(message);
                Console.WriteLine("------------------------------------------------------------");
            }
        }

     
        
    }

  
}
