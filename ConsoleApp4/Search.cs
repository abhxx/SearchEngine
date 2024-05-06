using SearchProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp4
{
    internal class Search
    {

        //the array above hold all the duplicated elements


        public static void GetInputAndTpyeForTheSearch(bool wantToAdd)
        {
            bool startWithNAJ;
            bool nullOrEmpty;


            string array;
            string temp;
            string element;
            string indexOrElement;

            if (MainClass.CheckIfArrayIsEmpty())
            {//the array is empty
                MainClass.ChoseOp();
            }
            else
            {//the array have element/s
                if (wantToAdd)
                {

                    Console.WriteLine("search using index or element for the age type a/xxx  job j/xxx name n/xxx");

                    element = Console.ReadLine().ToLower();
                    temp = element.ToLower();



                    nullOrEmpty = String.IsNullOrWhiteSpace(element) || element.Length <= 2;

                    startWithNAJ = temp.StartsWith("a") || temp.StartsWith("j") || temp.StartsWith("n");

                    while (!startWithNAJ || nullOrEmpty)
                    {//loop to get the user input
                        Console.WriteLine("enter valid value");
                        element = Console.ReadLine().ToLower();

                        temp = element.ToLower();

                        startWithNAJ = temp.StartsWith("a") || temp.StartsWith("j") || temp.StartsWith("n");
                        nullOrEmpty = String.IsNullOrWhiteSpace(element) || element.Length < 2;
                    }

                    array = "";
                    array = temp.ToLower();
                    if (array.StartsWith("a"))
                    {
                        array = "a";
                    }
                    else if (array.StartsWith("j"))
                    {
                        array = "j";
                    }
                    else if (array.StartsWith("n"))
                    {
                        array = "n";
                    }

                    element = element.Remove(0, 2);
                    bool haveNumbers = element.All(char.IsDigit);
                    if (haveNumbers)
                    {//the element is number

                        Console.WriteLine("as index or element");
                        indexOrElement = Console.ReadLine();
                        MainClass.CheckForYorN(indexOrElement, "index", "element");

                        if (MainClass.GetWantCheck())
                        {//go to the index serach funtion
                            SearchByIndexAndPrint(Convert.ToInt32(element), array);
                        }
                        else
                        {//go to the element search funtion
                            SearchByElementAndPrint(element, array, haveNumbers);
                        }
                    }
                    else
                    {//go to the element search funtion
                        SearchByElementAndPrint(element, array, haveNumbers);
                    }
                }
                else
                {
                    MainClass.ChoseOp();
                }
            }
        }

        public static void SearchByIndexAndPrint(int index, string NAJ)
        {

            if (NAJ == "a")
            {
                if (index < MainClass.ageArray.Length)
                {//the index is < than array length
                    Console.WriteLine("found the element is :" + MainClass.ageArray[index] + " the name is :" + MainClass.namesArray[index] + " the job is :" + MainClass.jobArray[index]);

                    GetWantToSearch();
                }
                else
                {//the index is >= than the array length 
                    Console.WriteLine("not found");
                    //ask the user if he wants to contuine search
                    GetWantToSearch();
                }
            }

            else if (NAJ == "n")
            {
                if (index < MainClass.namesArray.Length)
                {
                    Console.WriteLine("found the element is :" + MainClass.namesArray[index] + " the age is :" + MainClass.ageArray[index] + " the job is :" + MainClass.jobArray[index]);

                    GetWantToSearch();
                }
                else
                {
                    Console.WriteLine("not found");

                    GetWantToSearch();
                }
            }
            else if (NAJ == "j")
            {
                if (index < MainClass.jobArray.Length)
                {
                    Console.WriteLine("found the element is :" + MainClass.jobArray[index] + " the name is :" + MainClass.namesArray[index] + " the age is :" + MainClass.ageArray[index]);

                    GetWantToSearch();
                }
                else
                {
                    Console.WriteLine("not found");

                    GetWantToSearch();
                }
            }

        }


        public static void SearchByElementAndPrint(string element, string NAJ, bool haveNumbers)
        {
            int age;

            if (NAJ == "a")
            {
                if (haveNumbers)
                {
                    age = Convert.ToInt32(element);

                    if (Adding.dupAge.Contains(age))
                    {
                        Console.Write("found at indexs :");
                        for (int i = 0; i < MainClass.ageArray.Length; i++)
                        {
                            if (MainClass.ageArray[i] == age) { Console.Write(i + " "); }
                        }
                        GetWantToSearch();
                    }
                    else
                    {
                        if (MainClass.ageArray.Contains(age))
                        {//check if the array have the wanted element
                            Console.WriteLine("found at index :" + Array.IndexOf(MainClass.ageArray, age) + "the name :" + MainClass.namesArray[Array.IndexOf(MainClass.ageArray, age)] + " the job :" + MainClass.jobArray[Array.IndexOf(MainClass.ageArray, age)]);
                            //later make a way to display dup elements
                            GetWantToSearch();
                        }
                        else
                        {//the index is >= than the array length 
                            Console.WriteLine("not found");

                            GetWantToSearch();
                            //ask the user if he wants to contuine search
                        }
                    }
                }
                else
                {
                    Console.WriteLine("invaild value");
                    GetWantToSearch();
                }

            }

            else if (NAJ == "n")
            {
                if (Adding.dupName.Contains(element))
                {
                    Console.Write("found at indexs :");
                    for (int i = 0; i < MainClass.namesArray.Length; i++)
                    {
                        if (MainClass.namesArray[i] == element) { Console.Write(i + " "); }
                    }
                    GetWantToSearch();
                }

                else
                {
                    if (MainClass.namesArray.Contains(element))
                    {
                        Console.WriteLine("found at index :" + Array.IndexOf(MainClass.namesArray, element) + " the age :" + MainClass.ageArray[Array.IndexOf(MainClass.namesArray, element)] + " the job :" + MainClass.jobArray[Array.IndexOf(MainClass.namesArray, element)]);

                        GetWantToSearch();
                    }
                    else
                    {
                        Console.WriteLine("not found");

                        GetWantToSearch();
                    }
                }
            }
            else if (NAJ == "j")
            {
                if (Adding.dupJob.Contains(element))
                {
                    Console.Write("found at indexs :");
                    for (int i = 0; i < MainClass.jobArray.Length; i++)
                    {
                        if (MainClass.jobArray[i] == element) { Console.Write(i + " "); }
                    }
                    GetWantToSearch();
                }
                else
                {
                    if (MainClass.jobArray.Contains(element))
                    {
                        Console.WriteLine("found at index :" + Array.IndexOf(MainClass.jobArray, element) + " the name :" + MainClass.namesArray[Array.IndexOf(MainClass.jobArray, element)] + " the age :" + MainClass.namesArray[Array.IndexOf(MainClass.jobArray, element)]);

                        GetWantToSearch();
                    }
                    else
                    {
                        Console.WriteLine("not found");

                        GetWantToSearch();
                    }
                }
            }
        }

        static void GetWantToSearch()
        {
            Console.WriteLine("\ndo you want to contiune searching\nif yes type y if no type n");
            MainClass.CheckForYorN(Console.ReadLine(), "y", "n");

            GetInputAndTpyeForTheSearch(MainClass.GetWantCheck());
        }

    }
}
