using SearchProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Adding
    {
        public static string[] dupName = { };
        public static string[] dupJob = { };
        public static int[] dupAge = { };

        static List<string> dupNamesList = new List<string>();
        static List<int> dupAgeList = new List<int>();
        static List<string> dupJobList = new List<string>();

        readonly static string Y = "y", N = "n";
        static bool wantToAdd = true;
        static bool nameAccpeted = true;


        static string name;
        static string age;
        static string job;



        static List<string> namesList = new List<string>();
        static List<int> ageList = new List<int>();
        static List<string> jobList = new List<string>();
        static bool haveNumbers;
        public static void GetName()
        {  //add the name the user typed in the array   


            while (wantToAdd == true)
            {
                nameAccpeted = true;
                AddName();
                if (nameAccpeted)
                {
                    AddAge();
                    AddJob();
                }

                Console.WriteLine("want to Enter another name?\nType N if no Type Y if yes");

                MainClass.CheckForYorN(Console.ReadLine(), Y, N);
                wantToAdd = MainClass.GetWantCheck();
            }

            Console.WriteLine("the list size:" + MainClass.namesArray.Length);
            MainClass.PrintTheArrays();
            wantToAdd = true;
            MainClass.ChoseOp();
        }

        private static void AddName()
        {
            bool nameIsNull;
            bool alreadyThere;
            Console.WriteLine("enter the name");

            name = Console.ReadLine();
            nameIsNull = String.IsNullOrWhiteSpace(name);
            alreadyThere = MainClass.namesArray.Contains(name);

            if (alreadyThere)
            {
                Console.WriteLine("this name is already in the list are you sure you want to more instnce of it");
                MainClass.CheckForYorN(Console.ReadLine(), Y, N);

                if (!MainClass.GetWantCheck())
                {//the user didnt add the dup name
                    nameAccpeted = false;
                }

                else
                {// the user added the dup name
                    if (!dupName.Contains(name))
                    {
                        dupNamesList = dupNamesList.ToList();
                        dupNamesList.Add(name);
                        dupName = dupNamesList.ToArray();
                    }
                    namesList = MainClass.namesArray.ToList();
                    namesList.Add(name);
                    MainClass.namesArray = namesList.ToArray();
                }
            }
            else
            {
                while (nameIsNull)
                {
                    Console.WriteLine("Enter a vaild value");

                    Console.WriteLine("enter the name");

                    name = Console.ReadLine();
                    nameIsNull = String.IsNullOrWhiteSpace(name);
                }

                namesList = MainClass.namesArray.ToList();
                namesList.Add(name);
                MainClass.namesArray = namesList.ToArray();
            }
        }

        private static void AddAge()
        {
            int agef;
            bool ageIsNull;

            Console.WriteLine("enter the age");
            age = Console.ReadLine();
            ageIsNull = String.IsNullOrWhiteSpace(age);
            haveNumbers = age.All(char.IsDigit);

            while (ageIsNull || !haveNumbers)
            {

                Console.WriteLine("enter a vaild value");
                age = Console.ReadLine();
                ageIsNull = String.IsNullOrWhiteSpace(age);
                haveNumbers = age.All(char.IsDigit);

            }
            agef = Convert.ToInt32(age);

            if (MainClass.ageArray.Contains(agef))
            {//the age array have that element 
                if (!dupAge.Contains(agef))
                {
                    dupAgeList = dupAgeList.ToList();
                    dupAgeList.Add(agef);
                    dupAge = dupAgeList.ToArray();
                }
            }

            ageList = MainClass.ageArray.ToList();
            ageList.Add(agef);
            MainClass.ageArray = ageList.ToArray();
        }

        private static void AddJob()
        {
            Console.WriteLine("enter the job");
            job = Console.ReadLine();
            haveNumbers = job.All(char.IsDigit);
            bool jobIsNull = String.IsNullOrWhiteSpace(job);

            while (haveNumbers || jobIsNull)
            {
                Console.WriteLine("enter a vaild value");
                job = Console.ReadLine();
                haveNumbers = job.All(char.IsDigit);
                jobIsNull = String.IsNullOrWhiteSpace(job);
            }

            if (MainClass.jobArray.Contains(job))
            {// the job array already have that element
                if (!dupJob.Contains(job))
                {
                    dupJobList = dupJobList.ToList();
                    dupJobList.Add(job);
                    dupJob = dupJobList.ToArray();
                }
            }

            jobList = MainClass.jobArray.ToList();
            jobList.Add(job);
            MainClass.jobArray = jobList.ToArray();

        }
        public static int GetDupAgeTime(int agef)
        {// the 3 functions bleow dont work untill there is no element left
            int dupTimes = 0;

            foreach (int i in MainClass.ageArray)
            {
                if (i == agef) { dupTimes++; }
            }

            return dupTimes;
        }

        public static int GetDupNameTime(string namef)
        {
            int dupTimes = 0;

            foreach (string i in MainClass.namesArray)
            {
                if (i == namef)
                {
                    dupTimes++;
                }
            }
            return dupTimes;
        }
        public static int GetDupJobTime(string jobf)
        {
            int dupTimes = 0;
            foreach (string i in MainClass.jobArray)
            {
                if (i == jobf)
                {
                    dupTimes++;
                }
            }
            return dupTimes;
        }
    }
}
