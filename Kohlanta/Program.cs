using System;
using System.Collections.Generic;
using static System.Console;

namespace Kohlanta
{
    class Program
    {
        static void Main(string[] args)
        {

            Title = "Kohlanta";

            bool play = true;

            int nbparties = 1000000;
            int j1Wins = 0;
            int j2Wins = 0;

            for (int i = 0; i < nbparties; i++)
            {
                //Fill les invenataires avec les balles 
                // 0 = Blanches
                // 1 = Noir 
                List<int> InventaireJ1 = new List<int>();
                List<int> InventaireJ2 = new List<int>();

                for (int f = 0; f < 100; f++)
                {
                    if (f < 40)
                        InventaireJ1.Add(0);
           
                    else
                        InventaireJ1.Add(1);
                }
                
                for (int g = 0; g < 120; g++)
                {
                    if (g < 40)
                        InventaireJ2.Add(0);
                    else
                        InventaireJ2.Add(1);
                }

                double nbBlanchesTire1 = 0;
                double nbNoirTire1 = 0;
                double nbBlanchesTire2 =0;
                double nbNoirTire2 = 0;

                while (play)
                {
                    Random nb1 = new Random();
                    int num1 = nb1.Next(0, InventaireJ1.Count);

                    Random nb2 = new Random();
                    int num2 = nb2.Next(0, InventaireJ2.Count);

                    // Vérifications du nombres de boules 
                    if(nbBlanchesTire1 == 20 && nbBlanchesTire2 <= 20)
                    {
                        //WriteLine("Le joueur 2 win ");
                        
                        play = false;
                        break; 
                    }
                    if (nbBlanchesTire1 <= 20 && nbBlanchesTire2 == 20)
                    {
                        //WriteLine("Le joueur 1 win ");
                        
                        play = false;
                        break;
                    }
                    // Case 1 (Joueur 1 win)

                    if (InventaireJ1[num1] == 0 && InventaireJ2[num2] == 1)
                    {
                        j1Wins++;
                        //WriteLine("Joueur 1 Win ");
                        
                        break;
                    }
                    // Case 2 ( Joueur 2 win)
                    if (InventaireJ1[num1] == 1 && InventaireJ2[num2] == 0)
                    {
                        j2Wins++;
                        //WriteLine("Joueur 2 Win ");
                        //ReadKey();
                        break;
                    }

                    // Case 3 (égalité)
                    if(InventaireJ1[num1] == 0 && InventaireJ2[num2] == 0)
                    {
                        nbBlanchesTire1++;
                        nbBlanchesTire2++;
                        InventaireJ1.RemoveAt(num1);
                        InventaireJ2.RemoveAt(num2);
                        //WriteLine("Egalité blanc");
                        //ReadKey();
                        continue;
                    }
                    // Case 4 (égalité)
                    if (InventaireJ1[num1] == 1 && InventaireJ2[num2] == 1)
                    {
                        nbNoirTire1++;
                        nbNoirTire2++;
                        InventaireJ1.RemoveAt(num1);
                        InventaireJ2.RemoveAt(num2);
                        //WriteLine("Egalité noir");
                        //ReadKey();
                        continue;
                    }
                }
            }
            Clear();
            WriteLine($"Joueur 1 wins : {j1Wins}");
            WriteLine($"Joueur 2 wins : {j2Wins}");
            WriteLine($"% de chances de victoire du joueur 1 sur {nbparties} parties = {CalcAvg(j1Wins, nbparties)}%");
            WriteLine($"% de chances de victoire du joueur 2 sur {nbparties} parties =  {CalcAvg(j2Wins, nbparties)}%");
            ReadKey();

        }
        public static double CalcAvg(double nb1, double total)
        {
            double average = (nb1 * 100) / total;
            return Math.Round(average, 2);
        }


    }
}
