using System;
using System.Collections.Generic;
using System.Text;

namespace _5T23_EssalhiAdam_CarrePolybe
{
    public struct MethodeTraitementMat
    {
        public void Cryptage(string phrase, out string[,] chiffre, string[,] matricesDeBase)
        {
            chiffre = new string[phrase.Length, 2];
            for (int a = 0; a < phrase.Length; a++)
            {
                for (int i = 1; i < 6; i++)
                {
                    for (int y = 1; y < 6; y++)
                    {
                        if (phrase[a].ToString() == "J" && matricesDeBase[i, y] == "I")
                        {
                            chiffre[a, 0] = matricesDeBase[0, i];
                            chiffre[a, 1] = matricesDeBase[y, 0];
                        }
                        else if (phrase[a].ToString() == matricesDeBase[i, y])
                        {
                            chiffre[a, 0] = matricesDeBase[0, i];
                            chiffre[a, 1] = matricesDeBase[y, 0];
                        }
                    }
                }
            }
        }
        public void DeCryptage(string phrase, out string codeDechiffrer, string[,] matricesDeBase, string[,] chiffre)
        {
            codeDechiffrer = "";
            for (int a = 0; a < chiffre.GetLength(0); a++)
            {
                for (int i = 1; i < 6; i++)
                {
                    for (int y = 1; y < 6; y++)
                    {

                        if (chiffre[a, 0] == matricesDeBase[0, i] && chiffre[a, 1] == matricesDeBase[y, 0])
                        {
                            codeDechiffrer += matricesDeBase[i, y];

                        }
                    }
                }
            }
        }
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
        public void CreationMatrice(string code, out string[,] matricesDeBase)
        {
            int ligne = 1;
            int colonne = 1;

            string[] alphabet = new string[25] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", };
            matricesDeBase = new string[6, 6];
            for (int i = 0; i < 6; i++)
            {
                matricesDeBase[0, i] = i.ToString();
            }
            for (int i = 0; i < 6; i++)
            {
                matricesDeBase[i, 0] = i.ToString();
            }

            for (int codeInt = 0; codeInt < code.Length; codeInt++)
            {

                for (int alphabetInt = 0; alphabetInt < 25; alphabetInt++)
                {
                    if (code[codeInt].ToString() == alphabet[alphabetInt])
                    {

                        matricesDeBase[ligne, colonne] = alphabet[alphabetInt].ToString();
                        alphabet[alphabetInt] = " ";
                        if (codeInt != code.Length)
                        {
                            colonne++;
                        }

                        if (colonne == 6 && codeInt != code.Length)
                        {
                            ligne++;
                            colonne = 1;
                        }

                    }
                }

            }
            for (int li = ligne; li < 6; li++)
            {
                for (int co = colonne; co < 6; co++)
                {
                    for (int alphabetInt = 0; alphabetInt < 25; alphabetInt++)
                    {

                        if (alphabet[alphabetInt].ToString() != " ")
                        {
                            matricesDeBase[li, co] = alphabet[alphabetInt].ToString();
                            alphabet[alphabetInt] = " ";
                            alphabetInt = 25;
                            if (co == 5)
                            {
                                colonne = 1;
                            }


                        }
                    }
                }
            }
            for (int i = 0; i < matricesDeBase.GetLength(0); i++)
            {
                for (int y = 0; y < matricesDeBase.GetLength(1); y++)
                {
                    Console.Write(matricesDeBase[i, y] + "|");
                }
                Console.WriteLine(" ");
            }

        }
        public bool EntreeEstBonne(string entree)
        {
            for (int i = 0; i <= entree.Length - 1; i++) // i = Variable qui s’incrémente dans une boucle for (place dans le string)
            {
                int ic = entree[i]; // Valeur du caractère à la place "i" dans le string
                if (!(ic >= 65 && ic <= 90) && !(ic >= 97 && ic <= 122) && ic != 32) return false;
            }
            return true;
        }
        public void LireReel(out double n)
        {
            string nUser;

            nUser = Console.ReadLine();
            nUser = RetireEspaces(nUser);
            while (!double.TryParse(nUser, out n))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Attention ! vous devez entrer un nombre réel !");
                Console.ResetColor();
                nUser = Console.ReadLine();
                nUser = RetireEspaces(nUser);
            }
        }
    }
}