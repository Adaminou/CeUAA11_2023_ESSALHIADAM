using System;
using System.Collections.Generic;
using System.Text;

namespace CeUAA11_2023_ESSALHIADAM
{
    public struct MethodesDuProjet
    {
        /**
         * RetireEspaces : crée une chaine de caractères sans espace
         * IN chaine : chaine de caractères dans laquelle on retire les espaces
         * OUT copie conforme de la chaine de départ sans les espaces
         * HYPO : chaine non vide
         */
        public string RetireEspaces(string chaine)
        {
            string newChaine = "";
            string carExt;
            int lg = chaine.Length;
            for (int i = 0; i < lg; i++)
            {
                carExt = chaine.Substring(i, 1);
                if (carExt != " ")
                {
                    newChaine += carExt;
                }
            }
            return newChaine;
        }
        /**
         * DimensionneMat : Crée la matrice de cryptage sur base des deux chaines encodées par l'utilisateur
         *                  et la remplit d'espaces
         * IN : cle, le mot cle pour l'ordre de l'anagramme
         * IN : texte, le texte à crypter
         * HYPO : cle et texte non vides
         */
        public void DimensionneMat(string cle, string texte, out char[,] matrice)
        {
            int d1 = (int)(texte.Length / cle.Length) + 2;
            int d2 = cle.Length;
            if (texte.Length % cle.Length != 0)
            {
                d1 += 1;
            }
            matrice = new char[d1, d2];
            for (int i = 0; i < d1; i++)
            {
                for (int j = 0; j < d2; j++)
                {
                    matrice[i, j] = ' ';
                }
            }
        }
        /**
         * EcritChaineDansMatrice : réparti les caractères de la clé dans la prmière ligne de la matrice de cryptage
         *                          et le texte à crypter dans les dernières lignes à partir de la 3°
         * IN : cle, le mot cle pour l'ordre de l'anagramme
         * IN : texte, le texte à crypter
         * REF : matrice, la matrice de cryptage
         * HYPO : cle et texte non vides, matrice existe et comporte les dimensions adaptées au texte et à la clé
         */
        public void EcritChaineDansMatrice(string cle, string texte, ref char[,] matrice)
        {
            int k;
            for (int j = 0; j < matrice.GetLength(1); j++)
            {
                matrice[0, j] = char.Parse(cle.Substring(j, 1).ToUpper());
            }
            k = 0;
            for (int i = 2; i < matrice.GetLength(0); i++)
            {
                int j = 0;
                while (j < matrice.GetLength(1) && k < texte.Length)
                {
                    matrice[i, j] = char.Parse(texte.Substring(k, 1).ToUpper());
                    k++;
                    j++;
                }
            }
        }
        /**
         * CryptVigenere : Construit la chaine de caractère cryptée suivant la règle du cryptage de Vigenere
         * IN : phClef, phClaire
         * HYPO : matrice contient tous les éléments nécessaires au cryptage selon la règle imposée
         */
        public void CryptVigenere(string phClaire, string phClef, int codeAscii)
        {
            
            string matVigenere = new string [4, phClaire.Length];
            int j = 0;
            for (int i = 0; i < phClaire.Length - 1; i++)
            {
                matVigenere[0, 1] = phClaire[i];
                if (int j = phClef.Length)
                {
                    int j = 0;
                    matVigenere[1, i] = phClef[j];
                    matVigenere[2, 1] = ((int)phClef[j]) - 65).ToString();
                }
                if (int) phClaire[i] + int.Parse(matVigenere[2, 1]) <= 90))
                {
                    codeAscii = (int)Char.Parse(matVigenere[0, 1]) + int.Parse(matVigenere[2, 1]);
                }
                else
                {
                codeAscii = (int)Char.Parse(matVigenere[0, 1]) + int.Parse(matVigenere[2, 1]) - 26;
                }
                matVigenere[3, 1] = Convert.ToChar(codeAscii).ToString();
                j = j + 1;
            

        }
        /**
         * ConstruitCryptage : Construit la chaine de caractère cryptée suivant la règle du cryptage avec affine
         * IN : phClaire
         * HYPO : matAffine contient tous les éléments nécessaires au cryptage selon la règle imposée
         */
        public void CryptAffine(string phClaire)
        {
            
            string matAffine = new string [4, phClaire.Length];
            for (int i = 0; i < phClaire.Length - 1; i++)
            {
                matAffine[0, 1] = phClaire[i];
                int x = ((int)phClaire[i] - 65);
                matAffine[1, i] = x;
                int y = (a * x + b) % 26;
                matAffine[2, i] = y;
                matAffine[3, i] = y + 65;
            }
        }
        /**
       * AfficheMatriceCrypt : construit une chaine de caractère contenant la concaténation du contenu de la matrice de cryptage 
       *                       dans une chaine de caractères en plaçant un 'retour chariot' à chaque fin de ligne
       * IN : matrice, la matrice de cryptage 
       * HYPO : matrice non vide
       */
        public string AfficheMatriceCrypt(char[,] matrice)
        {
            string vueMatrice = "";
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    vueMatrice = vueMatrice + matrice[i, j].ToString() + " ";
                }
                vueMatrice += "\n";
            }
            return vueMatrice;
        }
        /// <summary>
        /// Demander une des entrées à l’utilisateur avec les vérifications nécessaires.
        /// </summary>
        /// <param name="question">Question à poser à l’utilisateur</param>
        /// <param name="resultat">Entrée de l’utilisateur</param>
        public void DemanderPhraseAvecVerification(string question, out string resultat)
        {
            bool uneFois = false; // Variable qui permet de savoir si l’utilisateur à déjà fait une erreur
            do
            {
                if (uneFois) Console.WriteLine("/!\\ Pouvez-vous recommencer, votre entrée n'était pas bonne (doit contenir uniquement MAJ, min et espace).");
                Console.WriteLine(question);
                resultat = Console.ReadLine();
                uneFois = true;
            } while (!EntreeEstBonne(resultat));
        }

        /// <summary>
        /// Savoir si l’entrée de l’utilisateur est bonne.
        /// </summary>
        /// <param name="entree">Entrée de l’utilisateur</param>
        /// <returns>Si l’entrée est bonne ou non</returns>
        public bool EntreeEstBonne(string entree)
        {
            for (int i = 0; i <= entree.Length - 1; i++) // i = Variable qui s’incrémente dans une boucle for (place dans le string)
            {
                int ic = entree[i]; // Valeur du caractère à la place "i" dans le string
                if (!(ic >= 65 && ic <= 90) && !(ic >= 97 && ic <= 122) && ic != 32) return false;
            }
            return true;
        }

    }
}
