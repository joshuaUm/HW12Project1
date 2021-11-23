/// Homework No. 12 Project No. 1
/// File Name : Program.cs
/// @author : Joshua Um
/// Date : November 22 2021
/// 
/// Problem Statement : Write a program that reads both the girl’s and boy’s files into memory using a dictionary.  
///     Allow the user to input a name, the program should find the name in the dictionary and print out the rank and the number of namings.  
/// 
/// Plan:
/// 1. Parse boynames.txt and girlnames.txt into respective dictionaries with their ranking and registered births for every name.
/// 2. Prompt user to type a name to lookup in the two dictionaries.
/// 3. If dictionary does contain the name, list the ranking and registered births of that name.
/// 
using System;
using System.IO;
using System.Collections.Generic;

namespace HW12Project1
{
    class Program
    {




        static void Main(string[] args)
        {
            Dictionary<string, BabyName> boyNames = new Dictionary<string, BabyName>(), girlNames = new Dictionary<string, BabyName>();

            parseNameFile("boynames.txt",boyNames);
            parseNameFile("girlnames.txt", girlNames);

            Console.Write("Enter Name to search in baby name index :");
            string inputName = Console.ReadLine();

            checkName(inputName, boyNames, "boys");
            checkName(inputName, girlNames, "girls");

        }


        static void checkName(string inputName, Dictionary<string, BabyName> dict, string gender)
        {
            BabyName nameObject;
            Console.WriteLine(inputName + " is" + (dict.TryGetValue(inputName, out nameObject) 
                ? " ranked " + nameObject.getRank() + " in popularity among " + gender + " with " + nameObject.getRegisteredBirths() +" namings." 
                : " is not ranked among the top 1000 " + gender  + "."));
        }


        static void parseNameFile(string fileName, Dictionary<string, BabyName> dict)
        {
            using (StreamReader s = new StreamReader("../../../" + fileName))
            {
                string line = null;
                int index = 1;
                while ((line = s.ReadLine()) != null)
                {
                    string[] parsedLine = line.Split();
                    string name;
                    int registeredBirths;

                    (name, registeredBirths) = (parsedLine[0], Int32.Parse(parsedLine[1]));

                    dict.Add(name, new BabyName(registeredBirths, index++));
                }
            }
        }



    }



    public class BabyName
    {
       private int registeredBirths;
       private int rank;


       public BabyName(int registeredBirths, int rank)
        {
            this.registeredBirths = registeredBirths;
            this.rank = rank;
        }

        public int getRegisteredBirths()
        {
            return registeredBirths;
        }

        public int getRank() 
        {
            return rank;
        }
    }
}
