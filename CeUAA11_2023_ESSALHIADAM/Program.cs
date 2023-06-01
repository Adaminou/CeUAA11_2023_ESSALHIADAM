using System;

namespace CeUAA11_2023_ESSALHIADAM
{
    class Program
    {
        static void Main(string[] args)

        {

         
            string phClef;
            string phClaire;
            char[,] matrice;
            char[,] matAffine;
            char[,] matVigenere;
            string choix;
            string recom;
            bool firstTime = true;
            MethodesDuProjet MesOutils = new MethodesDuProjet();
            do // boucle de reprise générale
            {

                Console.Clear();
                // récupération des données
                Console.WriteLine("Bienvenue dans cette application regroupant 2 méthode de cryptage ");
                Console.WriteLine("========================================================= ");
                Console.WriteLine("Choisissez parmi les options suivantes");
                Console.WriteLine("Menu : " +
                "\n    1. Cryptage de Vigenère" +
                "\n    2. Crpytage avec la méthode affine");
                do
                {
                    if (!firstTime)
                    {
                        Console.WriteLine("/!\\ Pouvez-vous recommencer, la longueur de votre phrase doit être supérieure à celle de votre mot-clé. \nDe plus, la longueur de votre mot-clé doit être inférieure ou égale à 9.");
                    }
                    MesOutils.DemanderPhraseAvecVerification("Quel est votre mot-clé ?", out phClef);
                    MesOutils.DemanderPhraseAvecVerification("Quel est votre phrase ?", out phClaire);
                    firstTime = false;
                } while (phClef.Length >= phClaire.Length || phClef.Length > 9);
                choix = Console.ReadLine();
                if (choix == "1")
                {
                    // préparation de la chaine
                    phClaire = MesOutils.RetireEspaces(phClaire);
                    // préparation de la matrice de cryptage
                    MesOutils.DimensionneMat(phClef, phClaire, out matVigenere);
                    MesOutils.EcritChaineDansMatrice(phClef, phClaire, ref matVigenere);
                    // affichage de la matrice de cryptage
                    Console.Clear();
                    Console.WriteLine("Matrice de cryptage :");
                    Console.WriteLine("=====================");
                    matrice = MesOutils.AfficheMatriceCrypt(matrice);
                    Console.WriteLine(matrice);

                    // construction et affichage du résultat

                     matVigenere = MesOutils.CryptVigenere(phClaire, phClef,);
                    Console.WriteLine("Le message crypté est :");
                    Console.WriteLine(matVigenere);

                }
                if (choix == "2")
                {
                    // préparation de la chaine
                    phClaire = MesOutils.RetireEspaces(phClaire);
                    // préparation de la matrice de cryptage
                    MesOutils.DimensionneMat(phClef, phClaire, out matAffine);
                    MesOutils.EcritChaineDansMatrice(phClef, phClaire, ref matAffine);
                    // affichage de la matrice de cryptage
                    Console.Clear();
                    Console.WriteLine("Matrice de cryptage :");
                    Console.WriteLine("=====================");
                    MesOutils.AfficheMatriceCrypt(matrice);
                    Console.WriteLine(matrice);

                    // construction et affichage du résultat

                     matAffine = MesOutils.CryptAffine(phClaire);
                    Console.WriteLine("Le message crypté est :");
                    Console.WriteLine(matAffine);
                }



                    // Demande reprise
                    Console.WriteLine("Un autre cryptage ? (oui = espace non = autre)");
                recom = Console.ReadLine();
            } while (recom == " ");

            Console.ReadLine();
        }
    }
   
}
