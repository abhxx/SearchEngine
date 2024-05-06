using SearchProject;
using System;
using System.Linq;

namespace ConsoleApp4
{
    internal class SearchClass
    {
        static string name;
        public static string dupNmae;
        public static int dupAge;
        public static string dupJob;


        readonly static string Y = "y", N = "n";
        readonly static string intendedIndex = "index", intendedElement = "element";

        static void SearchForIndexAndPrintTheName(string nameF)
        {
            
            string indexOrElement;
            int arrayLentgh = MainClass.GetNamesArray().Length - 1;

            int arrayIndex = 0;
            bool haveNumbers = nameF.All(char.IsDigit);

            if (haveNumbers)
            {//namef is a int
                Console.WriteLine("as index or element?");
                indexOrElement = Console.ReadLine();
                MainClass.CheckForYorN(indexOrElement, intendedIndex, intendedElement);

                if (MainClass.GetWantCheck())
                {//the user addresed namef as an index
                    arrayIndex = Convert.ToInt32(nameF);

                    if (arrayIndex <= arrayLentgh)
                    {//the number is less or = to the array length
                        Console.WriteLine("Found " + "the elemnt is: " + MainClass.GetNamesArray()[arrayIndex] + PrintADOns(arrayIndex.ToString()));

                        GetWantToSearch();
                    }
                    else
                    {//the number is more than the array length 
                        Console.WriteLine("invaild index");

                        GetWantToSearch();
                    }
                }
                else
                {//the user addresed namef as element
                    SearchForTheString();
                }
            }
            else
            {
                //search for the name in the whole array if found print true if not print not found/ 
                SearchForTheString();
            }
        }
        public static void GetInputForTheSearch(bool haveRunnedBefore)
        {
            if (MainClass.CheckIfArrayIsEmpty())
            {
                MainClass.ChoseOp();
            }
            else
            {
                if (haveRunnedBefore)
                {
                    Console.WriteLine("enter either the name or the order of the name");
                    name = Console.ReadLine();
                    if (String.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Enter a vaild value");
                    }
                    else
                    {
                        SearchForIndexAndPrintTheName(name);
                    }
                }
                else
                {
                    MainClass.ChoseOp();
                }
            }
        }
        static void SearchForTheString()
        {
            if (dupNmae == name)
            {
                Console.Write("found at indexs :");
                for (int i = 0; i < MainClass.GetNamesArray().Length; i++) 
                {
                    string namef = MainClass.GetNamesArray()[i];
                    if (namef ==name)
                    {
                        Console.Write(i+" ");
                    }
                }
                GetWantToSearch();
            }
            else
            {
                //this functios is to serach for strings
                if (MainClass.GetNamesArray().Contains(name))
                {//the array contains the desird name
                    Console.WriteLine("Found at index " + Array.IndexOf(MainClass.GetNamesArray(), name) + PrintADOns(Array.IndexOf(MainClass.GetNamesArray(), name).ToString()));

                    GetWantToSearch();
                }
                else
                {//the array does not continas that name
                    Console.WriteLine("Not Found");
                    GetWantToSearch();
                }
            }

        }
        static string PrintADOns(string ageAndJob)
        {//print the age and job when found
            return " his age: " + MainClass.ageArray[Convert.ToInt32(ageAndJob)] + " his job: " + MainClass.jobArray[Convert.ToInt32(ageAndJob)];
        }

        static void GetWantToSearch()
        {
                Console.WriteLine("\ndo you want to search for a name\nif yes type y if no type n");
                MainClass.CheckForYorN(Console.ReadLine(), Y, N);

                GetInputForTheSearch(MainClass.GetWantCheck());
        }
        
    }
}
