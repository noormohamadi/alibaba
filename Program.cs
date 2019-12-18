using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Collections;
using System.Net.Mail;
using System;
using System.Linq;

namespace myinterface
{
    class Program
    {
        static void Main(string[] args)
        {
            // BMW mybmw = new BMW();
            // mybmw.speed = 200;
            // mybmw.engin = 213;
            // mybmw.door = 4;
            // pride mypride = new pride();
            // mypride.speed = 100;
            // mypride.engin = 10;
            // mypride.door = 4;
            // lambo mylambo = new lambo();
            // mylambo.speed = 300;
            // mylambo.engin = 200;
            // mylambo.door = 2;
            // // Console.WriteLine("lambo speed : {0}\npride speed : {1}\nbmw speed : {2}\n", mylambo.speed, mypride.speed, mybmw.speed);
            // ICar car = new pride();
            // // IEnumerable list = new List<ICar>();
            // int[] number = new int[10];
            // Random rnd = new Random();
            // for (int i = 0; i < number.Length; i++)
            // {
            //     number[i] = rnd.Next()%20;
            //     Console.Write(number[i] + " ");
            // }
            // Console.Write("\n");
            // var list = (from n in number orderby n descending where n > 10 select n).ToList();
            // for (int i = 0; i < list.Count; i++)
            // {
            //     Console.Write(list[i] + " ");
            // }
            // Console.Write("\n" + (from n in number where n == 2 select n).Count() + "\n");
            List<Person> students = new List<Person>();
            students.Add(new Person(0, "mohamad", "nmadi", 21));
            students.Add(new Person(1, "mohd", "ni", 22));
            students.Add(new Person(2, "mo", "noori", 20));
            List<Grades> grades = new List<Grades>();
            for (int i = 0; i < 3; i++)
            {
                grades.Add(new Grades(i, "java", 17));
                grades.Add(new Grades(i, "C++", 20));
                grades.Add(new Grades(i, "C#", 20));
            }
            var innerJoinQuery =
                (from st in students
                join gr in grades on st.id equals gr.id
                select new { id = st.id, name = st.name, family = st.family, age = st.age, gr.corse, gr.grade }).ToList();
            var aveList = (from g in grades where g.id == 0 select g.grade).Average();
            for (int i = 0; i < innerJoinQuery.Count; i++)
            {
                Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\n",
                innerJoinQuery[i].id,innerJoinQuery[i].name,innerJoinQuery[i].family,innerJoinQuery[i].age,innerJoinQuery[i].corse,innerJoinQuery[i].grade);
            }
            Console.WriteLine(aveList);
        }
    }
    class BMW : ICar{
        public int speed { get ; set; }
        public int engin { get; set; }
        public int door { get; set; }
    }
    class lambo : ICar{        
        public int speed { get; set; }
        public int engin { get; set; }
        public int door { get; set; }
    }
    class pride : ICar{
        public int speed { get; set; }
        public int engin { get; set; }
        public int door { get; set; }
    }
    interface ICar{
        public int speed { get; set; }
        public int engin { get; set; }
        public int door { get; set; }
    }
    class Person{
        public int id { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public int age { get; set; }
        public Person(int id, string name, string family, int age){
            this.age = age;
            this.name = name;
            this.family = family;
            this.id = id;
        }
    }
    class Grades{
        public int grade { get; set; }
        public string corse { get; set; }
        public int id { get; set; }
        public Grades(int id, string corse, int grade){
            this.grade = grade;
            this.id = id;
            this.corse = corse;
        }
    }
    static class myExtentions {
        public static void toRial(this int input){
            Console.WriteLine(String.Format("{0:n0}", input));
        }
        public static string shamsi(this DateTime thisDate){
            PersianCalendar pc = new PersianCalendar();
            return String.Format("{0}/{1}/{2}\n",   
                      pc.GetDayOfMonth(thisDate),
                      pc.GetMonth(thisDate),  
                      pc.GetYear(thisDate));
        }
        public static string farsi(this string name){
            if(name == "mohamad"){
                return "";
            }
            return "";
        }
        
    }
}
