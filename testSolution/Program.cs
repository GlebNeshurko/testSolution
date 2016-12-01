using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace testSolution
{
    static class Program
    {
        public class Student
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
        }
        public static List<Student> students = new List<Student>
        {
                new Student { Name = "Dasha", LastName = "Lox", ID = 0},
                new Student { Name = "Katya", LastName = "Proger", ID = 1},
                new Student { Name = "Natasha", LastName = "Netvoya", ID = 2},
                new Student { Name = "Olya", LastName = "Klinton", ID = 3},
                new Student { Name = "Vitya", LastName = "Pikcher", ID = 4},
                new Student { Name = "Vitya?", LastName = "Da", ID = 5}
        };
        public static List<ForEnumTable> LibraryList = new List<ForEnumTable>
        {
            new ForEnumTable { Value = 11 },
            new ForEnumTable { Value = 12 },
            new ForEnumTable { Value = 15 },
            new ForEnumTable { Value = 14 },
            new ForEnumTable { Value = 13 }
        };
        public static void Main(string[] args)
        {
            //
            StartingDataClass startD = new StartingDataClass { ListValue = 9 };

            LibraryE lb = new LibraryE();
            ClassForRelinq CFR = new ClassForRelinq();

            decimal ctp = lb.Count();
            decimal ctp0 = CFR.ReCount();
            Console.WriteLine("Total count of first table: {0}", ctp);
            Console.WriteLine("Total count of secondary table: {0}", ctp0);
            //

            QueryResults();
            Console.WriteLine("\n");
            QueryResultsLymbda();
            Console.WriteLine("\n");
            ProtectionExample();
            ///////////////////////////////////////////////////////
            Console.ReadKey();
        }
        public static void QueryResults()
        {
            var results = from student in students
                          group student by student.LastName into newGroup
                          orderby newGroup.Key
                          select newGroup;
            foreach (var nameGroup in results)
            {
                Console.WriteLine("Key Key Key: {0}", nameGroup.Key);
                foreach (var student in nameGroup)
                {
                    Console.WriteLine("\t{0},{1}", student.LastName, student.Name);
                }
            }             
        } 
        public static void QueryResultsLymbda()
        {
            var selectedStudents = (students.Where(t => t.Name.ToUpper().StartsWith("K")).OrderBy(t => t.Name));
            // расширеный метод, а далее без него
            //var selectedStudents = from s in students
            //                       where s.Name.ToUpper().StartsWith("K")
            //                       orderby s
            //                       select s;
            foreach (var item in selectedStudents)
            {
                Console.WriteLine(item.Name);
            }
            int number = (from t in students where t.Name.ToUpper().StartsWith("D") select t).Count();
            Console.WriteLine("{0}", number);
        }
        public static void IntExample0()
        {
            int[] Mass = new int[] { 97, 92, 81, 60 };
            IEnumerable<int> scoreCount =
                from score in Mass
                where score > 80 && score < 90
                select score;
            Console.WriteLine("\n");
            foreach (int item in scoreCount)
            {
                Console.WriteLine("{0}", item);
            }
        }
        public static void IntExample1()
        {
            List<int> ListInt = new List<int> { 100, 90, 80, 70, 75 };
            IEnumerable<int> numbersCount =
                from numbers in ListInt
                where numbers > 70 && numbers != 100
                select numbers;
            Console.WriteLine("\n");
            foreach (var item in numbersCount)
            {
                Console.WriteLine("{0}", item);
            }
        }
        public static void StringExample1()
        {
            List<string> ListString = new List<string> { "one", "two", "three", "four", "five" };
            IEnumerable<string> stringsCount =
                from strings in ListString
                where strings != "one"
                select strings;
            Console.WriteLine("\n");
            foreach (var item in stringsCount)
            {
                Console.WriteLine("{0}", item);
            }
        }
        public static void ProtectionExample()
        {
            List<string> List = new List<string>() { "0fuck0", "0fuck0", "1fuck1", "2fuck2", "3fuck3", "fuck" };

            foreach (var item in List.SkipWhile(t => t.StartsWith("0")))
            {
                Console.WriteLine("{0}", item);
            }

        }
        public static decimal Count(this LibraryE LE)
        {
            decimal total = 0m;
            foreach (ForEnumTable fett in LE.Table)
            {
                total += fett.Value;
            }
            return total;
        }
        public static decimal ReCount(this ClassForRelinq CFR0)
        {
            decimal total0 = 0;
            foreach (StartingDataClass item in CFR0.TableRelinq)
            {
                total0 += item.ListValue;
            }
            return total0;
        }

    }
}
