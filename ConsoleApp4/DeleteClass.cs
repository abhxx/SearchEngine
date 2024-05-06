using SearchProject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    internal class DeleteClass
    {
        static int index;
        static string name;
        static bool wantToDelete;

        static List<string> namesList = new List<string>();
        static List<int> ageList = new List<int>();
        static List<string> jobList = new List<string>();


        readonly static string Y = "y", N = "n";
        readonly static string intendedIndex = "index", intendedElement = "element";
        public static void DeleteName()
        {
            string indexOrElement;
            if (MainClass.CheckIfArrayIsEmpty())
            {//the array is empty
                MainClass.ChoseOp();
            }
            else
            {//the array have elements
                wantToDelete = true;

                while (wantToDelete)
                {
                    if (MainClass.CheckIfArrayIsEmpty())
                    {//the arrray is empty
                        wantToDelete = false;
                    }
                    else
                    {//the array have elemnet/s
                        Console.WriteLine("enter the index or the name of the unwanted elment");
                        name = Console.ReadLine();

                        bool haveNumbers = name.All(char.IsDigit);

                        if (String.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Enter a vaild value");
                        }
                        else
                        {
                            if (haveNumbers)
                            {//the user entered a number

                                Console.WriteLine("as index or element?");
                                indexOrElement = Console.ReadLine();
                                MainClass.CheckForYorN(indexOrElement, intendedIndex, intendedElement);
                                if (!MainClass.GetWantCheck())
                                {
                                    DeleteForString();
                                }

                                else
                                {

                                    index = Convert.ToInt32(name);

                                    if (index <= MainClass.namesArray.Length - 1)
                                    {// check if the user index more than the array length -1  

                                        int delAge = MainClass.ageArray[index];
                                        string delName = MainClass.namesArray[index];
                                        string delJob = MainClass.jobArray[index];

                                        namesList = MainClass.namesArray.ToList();
                                        ageList = MainClass.ageArray.ToList();
                                        jobList = MainClass.jobArray.ToList();

                                        namesList.RemoveAt(index);
                                        ageList.RemoveAt(index);
                                        jobList.RemoveAt(index);

                                        MainClass.namesArray = namesList.ToArray();
                                        MainClass.ageArray = ageList.ToArray();
                                        MainClass.jobArray = jobList.ToArray();

                                        if (!MainClass.CheckIfArrayIsEmpty())
                                        {
                                            Console.WriteLine("shit is working working");
                                            CheckAndDelDup(delAge, delJob, delName);
                                        }

                                        Console.WriteLine("The new Array\nthe list size: " + MainClass.namesArray.Length);

                                        MainClass.PrintTheArrays();

                                        Console.WriteLine("want to Delete another name?\nType N if no Type Y if yes");
                                        MainClass.CheckForYorN(Console.ReadLine(), Y, N);
                                        wantToDelete = MainClass.GetWantCheck();

                                    }
                                    else
                                    {// the user entered an ivalid index more than the array length -1 or less than 0
                                        Console.WriteLine("invaild index");
                                    }
                                }
                            }

                            else
                            {
                                DeleteForString();
                            }
                        }
                    }

                }
                MainClass.ChoseOp();
            }
        }
        static void DeleteForString()
        {
            if (MainClass.GetNamesArray().Contains(name))
            {
                index = Array.IndexOf(MainClass.GetNamesArray(), name);
                namesList = MainClass.namesArray.ToList();
                ageList = MainClass.ageArray.ToList();
                jobList = MainClass.jobArray.ToList();

                int delAge = MainClass.ageArray[index];
                string delName = MainClass.namesArray[index];
                string delJob = MainClass.jobArray[index];

                namesList.RemoveAt(index);
                ageList.RemoveAt(index);
                jobList.RemoveAt(index);

                MainClass.namesArray = namesList.ToArray();
                MainClass.ageArray = ageList.ToArray();
                MainClass.jobArray = jobList.ToArray();



                if (!MainClass.CheckIfArrayIsEmpty())
                {

                    CheckAndDelDup(delAge, delJob, delName);
                }

                Console.WriteLine("The new Array\nthe list size: " + MainClass.namesArray.Length);

                MainClass.PrintTheArrays();

                Console.WriteLine("want to Delete another name?\nType N if no Type Y if yes");
                MainClass.CheckForYorN(Console.ReadLine(), Y, N);
                wantToDelete = MainClass.GetWantCheck();
            }
            else { Console.WriteLine("Not Found"); }
        }

        static void CheckAndDelDup(int delAge, string delJob, string delName)
        {
            List<string> dupName = new List<string>();
            List<string> dupJob = new List<string>();
            List<int> dupAge = new List<int>();

            if (Adding.GetDupNameTime(delName) < 2)
            {//the deleted element does not have anthor instance of itslef in the no more

                dupName = Adding.dupName.ToList();
                dupName.RemoveAt(Array.IndexOf(Adding.dupName, delName));
                Adding.dupName = dupName.ToArray();
            }

            if (MainClass.jobArray.Contains(delJob))
            {//the deleted element have anthor instance of itslef in the array

            }
            else if (Adding.GetDupJobTime(delJob) < 2)
            {//the deleted element does not have anthor instance of itslef in the no more
                dupJob = Adding.dupJob.ToList();
                dupJob.RemoveAt(Array.IndexOf(Adding.dupJob, delJob));
                Adding.dupJob = dupJob.ToArray();
            }
            if (MainClass.ageArray.Contains(delAge))
            {//the deleted element have anthor instance of itslef in the array

            }
            else if (Adding.GetDupAgeTime(delAge) < 2)
            {//the deleted element does not have anthor instance of itslef in the no more
                dupAge = Adding.dupAge.ToList();
                dupAge.RemoveAt(Array.IndexOf(Adding.dupAge, delAge));
                Adding.dupAge = dupAge.ToArray();
            }
        }
    }
}
