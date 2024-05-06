using System.Collections.Generic;
using System;
using System.Linq;
using ConsoleApp4;
using System.Text;
using System.Xml.Linq;

namespace SearchProject
{
    class MainClass
    {
        static bool wantCheck;
        //store the answer
        public static string[] jobArray = { };
        public static int[] ageArray = { };
        public static string[] namesArray = { };
        public static void Main()
        {
            ChoseOp();
        }
        static public void ChoseOp()
        {
            bool haveChosed = false;
            string op;
            while (!haveChosed)
            {
                Console.WriteLine("Chose the wanted oprtion\nthe commends del = delete, srh= search, add = add name,shw = show the array, fin = finshed\n");
                op = Console.ReadLine();

                if (op == "del")
                {
                    DeleteClass.DeleteName();
                    
                }

                else if (op == "shw")
                {
                    PrintTheArrays();
                }

                else if (op == "srh")
                {
                    Search.GetInputAndTpyeForTheSearch(true);
                    
                }

                else if (op == "add")
                {
                    Adding.GetName();
                    
                }

                else if (op == "fin")
                {
                    haveChosed = true;
                }

                else if (op == "fnaf")
                {
                    Fnaf.WareWaiting();
                }

                else
                {
                    Console.WriteLine("Enter a vaild commend");
                   
                }
            }
        }
        public static void CheckForYorN(string wantCheckf, string Y, string N)
        {
            string YF = Y.ToLower(), NF = N.ToLower();
            // get the anwser for the user in lower case
            if (wantCheckf.ToLower() == YF)
            {
                wantCheck = true;
            }
            else if (wantCheckf.ToLower() == NF)
            {
                wantCheck = false;
            }
            else
            {
                FuckYou(YF, NF);
            }
        }
        static void FuckYou(string Y, string N)
        {
            Console.WriteLine("error enter " + Y + " or " + N);
            CheckForYorN(Console.ReadLine(), Y, N);
        }

        public static void PrintTheArrays()
        {
            if (CheckIfArrayIsEmpty())
            {

            }
            else
            {
                int countForIndex = -1;
                foreach (string name in namesArray)
                {
                    countForIndex++;
                    Console.WriteLine(countForIndex + ": " + name + PrintAdOns(countForIndex));
                }
            }
        }
        public static bool CheckIfArrayIsEmpty()
        {
            if (namesArray.Length == 0 || namesArray == null)
            {
                Console.WriteLine("the array is empty\n");
                return true;
            }
            else
            {
                return false;
            }
        }
        static string PrintAdOns(int countForIndex)
        {
            return " his age: " + ageArray[countForIndex].ToString() + " his job: " + jobArray[countForIndex].ToString();
        }

        public static bool GetWantCheck()
        {
            return wantCheck;
        }
        public static string[] GetNamesArray()
        {
            return namesArray;
        }
    }
}
