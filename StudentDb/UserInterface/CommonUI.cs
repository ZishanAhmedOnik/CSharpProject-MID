using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace StudentDb.UserInterface
{
    public class CommonUI
    {
        static List<int> colMaxLengthList = new List<int>();

        public static void ShowTable(DataTable dt)
        {
            string[,] dataTableArray = new string[dt.Rows.Count, dt.Columns.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j] is int)
                    {
                        dataTableArray[i, j] = dt.Rows[i][j] + "";
                    }
                    else
                    {
                        dataTableArray[i, j] = (string)dt.Rows[i][j];
                    }
                }
            }

            printTable(dataTableArray);
        }

        static void printTable(string[,] nameArray)
        {
            initcolMaxLenghtList(nameArray);
            printDashedLine();

            for (int i = 0; i < nameArray.GetLength(0); i++)
            {

                for (int j = 0; j < nameArray.GetLength(1); j++)
                {
                    printNameAdjusted(nameArray[i, j], colMaxLengthList[j]);
                }
                Console.WriteLine('|');
                printDashedLine();
            }

            colMaxLengthList.Clear();
        }

        static void printNameAdjusted(string name, int maxStringLen)
        {
            int spaces = (maxStringLen - name.Length) / 2;

            Console.Write('|');

            for (int i = 0; i <= spaces; i++)
            {
                Console.Write(' ');
            }

            Console.Write(name);

            for (int i = 0; i <= spaces; i++)
            {
                Console.Write(' ');
            }

            if (name.Length % 2 == 1)
            {
                Console.Write(' ');
            }
        }

        static void printDashedLine()
        {
            Console.Write('+');

            foreach (int len in colMaxLengthList)
            {
                for (int i = 0; i < len + 2; i++)
                {
                    Console.Write('-');
                }
                Console.Write('+');
            }

            Console.WriteLine();
        }

        static void initcolMaxLenghtList(string[,] nameArray)
        {
            int maxLeng = 0;

            for (int i = 0; i < nameArray.GetLength(1); i++)
            {
                maxLeng = 0;

                for (int j = 0; j < nameArray.GetLength(0); j++)
                {
                    if (nameArray[j, i].Length > maxLeng)
                    {
                        maxLeng = nameArray[j, i].Length;
                    }
                }

                if (maxLeng % 2 == 1)
                {
                    maxLeng += 1;
                }

                colMaxLengthList.Add(maxLeng);
            }
        }
    }
}
