using _5T23_EssalhiAdam_CarrePolybe;
using System;

namespace testPourArabeN3
{
    class Program
    {
        static void Main(string[] args)
        {
            string phrase = "";
            string[,] chiffre;
            string codeDechiffrer = "";
            string[,] matricesDeBase = new string[6, 6];
            string choix;
            string entreeUser;
            string code = "";
            string chiffres;
            int n;
            int compteurL = 0;
            int compteurC = 0;
            int compteurTest = 0;
            bool recom = true;

            MethodeTraitementMat MesOutils = new MethodeTraitementMat();

            while (recom)
            {
                compteurL = 0;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("LE CARRE DE POLYBE");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("=========================");
                Console.ResetColor();
                MesOutils.CreationMatrice(code, out matricesDeBase);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("=========================");
                Console.ResetColor();

           
                Console.WriteLine("Voulez-vous crypter ou décrypter un message ? : ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("=========================");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("    1. Crypter");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("=========================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("    2. Décrypter");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("=========================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    3. Quitter");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("=========================");
                Console.ResetColor();


                choix = Console.ReadLine();
                if (choix == "1")
                {
                    Console.WriteLine("Quelle phrase voulez-vous crypter ?");
                    phrase = Console.ReadLine();
                    phrase = phrase.ToUpper();
                    Console.WriteLine("Quel sera votre code ?");
                    code = Console.ReadLine();
                    code = MesOutils.RetireEspaces(code);
                    code = code.ToUpper();
                    MesOutils.CreationMatrice(code, out matricesDeBase);
                    MesOutils.Cryptage(phrase, out chiffre, matricesDeBase);

                   
                    Console.Write("Cryptage : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 0; i < phrase.Length; i++)
                    {
                        for (int y = 0; y < 2; y++)
                        {
                            Console.Write(chiffre[i, y]);
                        }
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                    Console.ResetColor();
                }

                if (choix == "2")
                {
                    Console.WriteLine("Quels chiffres voulez-vous décrypter ?");
                    MesOutils.LireReel(out double chiffreDecryption);
                    chiffres = chiffreDecryption.ToString();
                    chiffres = MesOutils.RetireEspaces(chiffres);
                    bool validChiffres = true;

                    foreach (char item in chiffres)
                    {
                        int chiffreValeur = Convert.ToInt32(item.ToString());
                        if (chiffreValeur > 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Attention ! Vous devez entrer des valeurs inférieures ou égales à 5 !");
                            Console.ResetColor();
                            validChiffres = false;
                        }
                    }

                    if (chiffres.Length % 2 != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Attention! Le total des chiffres doit être pair !");
                        Console.ResetColor();
                        validChiffres = false;
                    }

                    if (validChiffres)
                    {
                        chiffre = new string[chiffres.Length / 2, 2];
                        Console.WriteLine("Quel est votre code ?");
                        code = Console.ReadLine();
                        code = code.ToUpper();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("=========================");
                        Console.ResetColor();
                        MesOutils.CreationMatrice(code, out matricesDeBase);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("=========================");
                        Console.ResetColor();
                        foreach (char seulChiffre in chiffres)
                        {
                            compteurTest++;
                            chiffre[compteurL, compteurC] = seulChiffre.ToString();
                            if (compteurC == 0)
                            {
                                compteurC = 1;
                            }
                            else
                            {
                                compteurC = 0;
                                compteurL++;
                            }
                        }
                        Console.WriteLine("Vos chiffres : " );
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int i = 0; i < chiffre.GetLength(0); i++)
                        {
                            for (int y = 0; y < 2; y++)
                            {
                                Console.Write(chiffre[i, y]);
                            }
                            Console.Write(" ");
                        }
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("=========================");
                        Console.ResetColor();

                        MesOutils.DeCryptage(phrase, out codeDechiffrer, matricesDeBase, chiffre);
                        Console.WriteLine("Votre phrase décryptée : ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(codeDechiffrer);
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("=========================");
                        Console.ResetColor();
                    }
                }
                if (choix == "3")
                {
                    break;
                }

                    Console.WriteLine("Voulez vous faire un autre cryptage ? (oui = o / non = autre)");
                entreeUser = Console.ReadLine();
                if (entreeUser != "o")
                {
                    recom = false;
                }
                Console.Clear();
            }
        }
    }
}
