using System;

namespace TPR4
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskA();
            Console.WriteLine();
            TaskB();
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void TaskA()
        {
            double numberOfExperts = 5;
            double[,] expertRating = new double[5, 3]
            {
                {5, 4, 3},
                {4, 3, 2},
                {5, 5, 4},
                {4, 3, 2},
                {5, 4, 3}
            };

            string[] personalityRating = new string[5]
            {
                "r", "p", "o", "r", "r"
            };

            double[,] koefArray = new double[5, 4];
            for (int i = 0; i < koefArray.GetLength(0); i++)
            {
                if (Equals(personalityRating[i], "o"))
                {
                    koefArray[i, 0] = 3;
                    koefArray[i, 1] = 0;
                    koefArray[i, 2] = 2;
                    koefArray[i, 3] = 25;
                }
                if (Equals(personalityRating[i], "r"))
                {
                    koefArray[i, 0] = 1;
                    koefArray[i, 1] = 4;
                    koefArray[i, 2] = 1;
                    koefArray[i, 3] = 36;
                }
                if (Equals(personalityRating[i], "p"))
                {
                    koefArray[i, 0] = 2;
                    koefArray[i, 1] = 0;
                    koefArray[i, 2] = 3;
                    koefArray[i, 3] = 25;
                }
            }
            Console.WriteLine("Завдання 1");
            Console.WriteLine();
            double a = 0;
            for (int i = 0; i < koefArray.GetLength(0); i++)
            {
                a += CountFunc(numberOfExperts, koefArray, expertRating, i);

            }
            Console.WriteLine("Колективна оцiнка=" + a);
            double sigma = 0;
            for (int i = 0; i < koefArray.GetLength(0); i++)
            {
                sigma += ((1 / numberOfExperts) * ((expertRating[i, 2] - expertRating[i, 0]) / koefArray[i, 3])) + ((1 / numberOfExperts) * Math.Pow((a - CountFunc(numberOfExperts, koefArray, expertRating, i)), 2));

            }
            Console.WriteLine("Дисперсiя=" + sigma);
            Console.WriteLine("_______________________________");
        }

        private static void TaskB()
        {
            string[,] individualRanking = new string[7, 5]
            {
                {"B", "G", "G", "C", "G"},
                {"F", "D", "C", "D", "A"},
                {"C", "C", "A", "G", "C"},
                {"D", "B", "B", "A", "B"},
                {"E", "A", "F", "F", "E"},
                {"A", "F", "D", "B", "D"},
                {"G", "E", "E", "E", "F"}
            };
            TaskB1(individualRanking);
            Console.WriteLine();
            TaskB2(individualRanking);
            Console.WriteLine();
        }

        private static void TaskB1(string[,] individualRanking)
        {
            Console.WriteLine("Завдання 2");
            Console.WriteLine();
            double a = 0, b = 0, c = 0, d = 0, e = 0, f = 0, g = 0;
            string[] letters = new string[7] { "A", "B", "C", "D", "E", "F", "G" };
            double[] summarizedRanking = new double[individualRanking.GetLength(0)];
            for (int i = 0; i < individualRanking.GetLength(0); i++)
            {
                for (int j = 0; j < individualRanking.GetLength(1); j++)
                {
                    if (Equals(individualRanking[i, j], "A"))
                    {
                        a += (i + 1);
                        summarizedRanking[0] = a;
                    }
                    if (Equals(individualRanking[i, j], "B"))
                    {
                        b += (i + 1);
                        summarizedRanking[1] = b;
                    }
                    if (Equals(individualRanking[i, j], "C"))
                    {
                        c += (i + 1);
                        summarizedRanking[2] = c;
                    }
                    if (Equals(individualRanking[i, j], "D"))
                    {
                        d += (i + 1);
                        summarizedRanking[3] = d;
                    }
                    if (Equals(individualRanking[i, j], "E"))
                    {
                        e += (i + 1);
                        summarizedRanking[4] = e;
                    }
                    if (Equals(individualRanking[i, j], "F"))
                    {
                        f += (i + 1);
                        summarizedRanking[5] = f;
                    }
                    if (Equals(individualRanking[i, j], "G"))
                    {
                        g += (i + 1);
                        summarizedRanking[6] = g;
                    }
                }
            }
            Console.WriteLine("Об'єкт  Сумарний ранг");
            Console.WriteLine("______  _____________");
            for (int i = 0; i < summarizedRanking.GetLength(0); i++)
            {
                Console.Write("  " + letters[i] + "          " + summarizedRanking[i]);
                Console.WriteLine();
            }
            Array.Sort(summarizedRanking);

            double w = 0;
            double length = 7;
            double experts = 5;
            for (int i = 0; i < summarizedRanking.GetLength(0); i++)
            {
                w += Math.Pow((summarizedRanking[i] - 0.5 * experts * (length + 1)), 2) / (Math.Pow(experts, 2) * (Math.Pow(length, 3) - length));
            }
            w *= 12;
            Console.WriteLine();
            Console.WriteLine("Коефiцiєнт конкордацiї=" + w);
            Console.WriteLine("_______________________________");
        }

        private static void TaskB2(string[,] individualRanking)
        {
            Console.WriteLine("Завдання 3");
            Console.WriteLine();
            string[] letters = new string[7] { "A", "B", "C", "D", "E", "F", "G" };
            double[,] MPP1 = new double[7, 7];
            MPP1 = CountMPP(0, MPP1, letters, individualRanking);
            double[,] MPP2 = new double[7, 7];
            MPP2 = CountMPP(1, MPP2, letters, individualRanking);
            double[,] MPP3 = new double[7, 7];
            MPP3 = CountMPP(2, MPP3, letters, individualRanking);
            double[,] MPP4 = new double[7, 7];
            MPP4 = CountMPP(3, MPP4, letters, individualRanking);
            double[,] MPP5 = new double[7, 7];
            MPP5 = CountMPP(4, MPP5, letters, individualRanking);
            double[,] MeanMPP = new double[7, 8];
            double sum = 0;
            for (int i = 0; i < MeanMPP.GetLength(0); i++)
            {
                for (int j = 0; j < MeanMPP.GetLength(1) - 1; j++)
                {
                    MeanMPP[i, j] = (MPP1[i, j] + MPP2[i, j] + MPP3[i, j] + MPP4[i, j] + MPP5[i, j]) / 5.0;
                }
            }
            for (int i = 0; i < MeanMPP.GetLength(0); i++)
            {
                for (int j = 0; j < MeanMPP.GetLength(1) - 1; j++)
                {
                    MeanMPP[i, 7] += MeanMPP[i, j];
                }
            }
            Console.WriteLine();
            Console.WriteLine("Колективна МПП");
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0,5} ", Math.Round(MeanMPP[i, j], 1));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Матрицi вiдстаней:");
            double[,] dist1 = DistanceCounter(MPP1, MeanMPP);
            double[,] dist2 = DistanceCounter(MPP2, MeanMPP);
            double[,] dist3 = DistanceCounter(MPP3, MeanMPP);
            double[,] dist4 = DistanceCounter(MPP4, MeanMPP);
            double[,] dist5 = DistanceCounter(MPP5, MeanMPP);

            double[] distance = new double[5] { dist1[7, 7], dist2[7, 7], dist3[7, 7], dist4[7, 7], dist5[7, 7] };
            double min = Math.Min(distance[1], distance[2]);
            for (int i = 2; i < distance.GetLength(0); i++)
            {
                if (distance[i] < min)
                    min = distance[i];
            }
            Console.WriteLine("Мiнiмальна вiдстань - " + min);

        }

        private static double[,] CountMPP(int expert, double[,] indMPP, string[] letters, string[,] indRanking)
        {
            int indexCol = 0;
            int indexRow = 0;
            for (int i = 0; i < indMPP.GetLength(0); i++)
            {
                for (int j = 0; j < indMPP.GetLength(1); j++)
                {
                    for (int k = 0; k < letters.GetLength(0); k++)
                    {
                        if (Equals(letters[i], indRanking[k, expert]))
                        {
                            indexCol = k;
                        }
                        if (Equals(letters[j], indRanking[k, expert]))
                        {
                            indexRow = k;
                        }
                    }
                    if (indexCol < indexRow)
                        indMPP[i, j] = 1;
                    else if (indexCol > indexRow)
                        indMPP[i, j] = -1;
                    else if (indexCol == indexRow)
                        indMPP[i, j] = 0;
                }
            }
            Console.Write("     ");
            for (int i = 0; i < 7; i++)
                Console.Write(letters[i] + "   ");
            Console.WriteLine("\n     _   _   _   _   _   _   _");
            for (int i = 0; i < 7; i++)
            {
                Console.Write(letters[i] + "| ");
                for (int j = 0; j < 7; j++)
                {
                    Console.Write("{0,3} ", indMPP[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            return indMPP;
        }

        private static double[,] DistanceCounter(double[,] inArray, double[,] meanArray)
        {
            string[] letters = new string[7] { "A", "B", "C", "D", "E", "F", "G" };
            double[,] outArray = new double[8, 8];
            for (int i = 0; i < outArray.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < outArray.GetLength(1) - 1; j++)
                {
                    outArray[i, j] = Math.Abs(inArray[i, j] - meanArray[i, j]);
                }
            }
            for (int i = 0; i < outArray.GetLength(0); i++)
            {
                for (int j = 0; j < outArray.GetLength(1) - 1; j++)
                {
                    outArray[i, 7] += outArray[i, j];
                }
            }
            for (int i = 0; i < outArray.GetLength(0) - 1; i++)
            {
                outArray[7, 7] += (0.5 * outArray[i, 7]);
            }

            Console.Write("       ");
            for (int i = 0; i < 7; i++)
                Console.Write(letters[i] + "     ");
            Console.WriteLine("\n       _     _     _     _     _     _     _");
            for (int i = 0; i < outArray.GetLength(0); i++)
            {
                if (i < 7)
                    Console.Write(letters[i] + "| ");
                for (int j = 0; j < outArray.GetLength(1); j++)
                {
                    if (i < 7)
                        Console.Write("{0,5} ", outArray[i, j]);
                    if (i == 7 && j == 0)
                    {
                        Console.Write("   ");
                    }
                    if (i == 7)
                    {
                        Console.Write("{0,5} ", outArray[i, j]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            return outArray;
        }

        private static double CountFunc(double numberofExperts, double[,] array1, double[,] array2, int i)
        {
            double result = (1 / numberofExperts) * ((array1[i, 0] * array2[i, 0] + array1[i, 1] * array2[i, 1] + array1[i, 2] * array2[i, 2])
                    / (array1[i, 0] + array1[i, 1] + array1[i, 2]));
            return result;
        }
    }
}
