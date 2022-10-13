using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Candidate> data = new List<Candidate>();                                                   //new list for the data of candidates
            List<string> filteredCandidates = new List<string>();                                           // new list defined for students above 3.0 GPA
            List<string> passedCandidates = new List<string>();                                             // new list having the students withmore than 90% marks
            Dictionary<string, List<string>> citywise = new Dictionary<string, List<string>>();               //dictionary to arrange students city wise
            Random numbers = new Random();                  //Random object made for Task 3

            List<string> names = new List<string> { "Waqas", "Ahmed", "Ali", "Hamza", "Hammad", "Faraz", "Yousaf", "Faizan", "Waleed", "Rafay", "Ashhad", "Umair", "Ahsan", "Sara", "Humail" };             //hardcoded data
            List<double> gpas = new List<double> { 3.6, 3.2, 2.6, 2.7, 3.5, 4.0, 2.9, 3.2, 3.6, 3.1, 3.3, 2.8, 3.6, 3.1, 3.3 };                                                                              //(Task 1)
            List<string> cities = new List<string> { "LHR", "RWP", "FSD", "ISB", "LHR", "RWP", "RWP", "FSD", "FSD", "ISB", "LHR", "RWP", "FSD", "ISB", "LHR" };


            // timecomplexity of task 1 and task 3 is O(n) as the loop will iterate more times with increase in input--
            // -- meaning the increase is linear. 
            for (int i = 0; i < names.Count; i++)
            {
                Candidate candidate = new Candidate();                      // using loop to define object and then addding the information
                candidate.name = names[i];
                candidate.gpa = gpas[i];
                candidate.city = cities[i];
                Document documents = new Document();
                documents.name = "Bachelors";
                documents.path = "C:/Users/4432/Desktop/Muhammad Ahmed Naveed";
                candidate.docs.Add(documents);
                candidate.marks1 = numbers.Next(75, 100);                   // (Task 3) using random object to assign random numbers to the students   
                candidate.marks2 = numbers.Next(75, 100);
                candidate.sum = candidate.marks1 + candidate.marks2;
                data.Add(candidate);                                        // adding all data to the candidate
            }


            // display the data
            Console.WriteLine("The Data is shown below:");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            foreach (Candidate candidate in data)
            {
                Console.WriteLine("Name={0}, GPA={1}, City={2}, marks1 ={3}, marks2 = {4}, sum of marks = {5}", candidate.name, candidate.gpa, candidate.city, candidate.marks1, candidate.marks2, candidate.sum);
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------");

            Console.WriteLine("Press any key to move to the next task");
            Console.ReadKey();
            // (Task 2) getting the students which are above 3 GPA
            // time complexity is O(n) as if condition will run more times if more students are above 3.0 GPA so it is linear as well.
            foreach (Candidate candidate in data)
            {
                if (candidate.gpa >= 3.0)
                {
                    filteredCandidates.Add(candidate.name);
                }
            }

            
            Console.WriteLine("Students above 3.0 GPA are: ");
            //displaying the students above 3.0 GPA

            for (int i = 0; i < filteredCandidates.Count; i++)
            {
                Console.Write(filteredCandidates[i]+" ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");

            Console.WriteLine("Press any key to move to the next task");
            Console.ReadKey();
            //(Task 4) Finding the students above 90% by using if condition
            //time complexity is O(n) as if condition will run more times if more students are above above 90% so it is linear as well.
            foreach (Candidate candidate in data)
            {
                if ((candidate.sum) / 200 >= 0.9)
                {
                    passedCandidates.Add(candidate.name);
                }
            }

            Console.WriteLine("Students above 90% marks are: ");
            for (int i = 0; i < passedCandidates.Count; i++)
            {
                Console.Write(passedCandidates[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");

            Console.WriteLine("Press any key to move to the next task");
            Console.ReadKey();
            //(Task 5)  Arranging citywise students by making the city as key and using names of students as values.
            foreach (Candidate candidate in data)
            {
                if (citywise.ContainsKey(candidate.city))
                {
                    citywise[candidate.city].Add(candidate.name);
                }
                else
                {
                    citywise.Add(candidate.city, new List<string> { candidate.name });
                }
            }

            Console.WriteLine("Enter the city RWP,FSD,LHR or ISB");
            string enterCity = Console.ReadLine();

            List<string> specificCityStudents = citywise[enterCity];

            // Task 5 has time complexity O(1) as the people are sorted by cities in dictionary and it will always take the same time--
            //-- when getting the students from a specific city
            //Printing the name of the students from the specific city
            Console.WriteLine("The students of the city " + enterCity + " are: ");
            for (int i = 0; i < specificCityStudents.Count; i++)
            {
                Console.Write(specificCityStudents[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");

            Console.WriteLine("Press any key to move to the next task");
            Console.ReadKey();
            // (Task 6) Sorting the list on the basis of marks.
            // Its time complexity if we consider the worst case is O(n^2) as this method uses quick sort.
            data.Sort(delegate (Candidate x, Candidate y) {
                return x.sum.CompareTo(y.sum);
            });
         
            data.Reverse();

            // Printing the list of candidates in order of their marks with most marks on top.
            Console.WriteLine("The candidates in order of their marks in the two assignments are shown below:");
            foreach (Candidate candidate in data)
            {
                Console.WriteLine(candidate.name + " "+ candidate.sum);
            }
            Console.WriteLine();




            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }
    }


    //Candidate class to get the data of the candidates
    public class Candidate
    {
        public string name { get; set; }
        public double gpa { get; set; }
        public string city { get; set; }
        public int marks1 { get; set; }
        public int marks2 { get; set; }

        public double sum { get; set; }

        public List<Document> docs = new List<Document>();          //List of data type "Document" defined below
    }

    //Documents class to get the document information
    public class Document
    {
        public string name { get; set; }
        public string path { get; set; }
    }
}