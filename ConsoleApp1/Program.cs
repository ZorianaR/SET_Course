using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp1
{
    class Program
    {
        static List<ToDo> ToDoList = new List<ToDo>();
        static List<Reminder> ReminderList = new List<Reminder>();
        static void Main(string[] args)
        {
            //Here we should download information from file
            menu();
            //Here we should save information in file
        }
        public class ToDo
        {
            string Name; 
            private string Description;
            public bool isdone; /*{ get; set; }*/
            public ToDo(string task_name, string task_description)
            {
                if (task_name == null || task_name == String.Empty)
                    Name = "Without Name";
                else Name = task_name;
                if (task_description == null || task_description == String.Empty)
                    Description = "Without Description";
                else Description = task_description;
                isdone = false;
            }
            public void ChangeDescription(string task_description)
            {
                if (task_description == null || task_description == String.Empty)
                    Description = "Without Description";
                else Description = task_description;
            }
            public void ChangeName(string task_name)
            {
                if (task_name == null || task_name == String.Empty)
                    Name = "Without Name";
                else Name = task_name;
            }
            
            public void ShowToDo()
            {
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Description: " + Description);
                Console.WriteLine("Status: " + (this.isdone ? "Done" : "Not Done"));
                Console.WriteLine();
            }

        }
        public class Reminder
        {
            public string Name;
            string Description;
            DateTime date;
            public bool isdone { get; set; } 

            public Reminder(string task_name, string task_description,DateTime task_date)
            {
                if (task_name == null || task_name == String.Empty)
                    Name = "Without Name";
                else Name = task_name;
                if (task_description == null || task_description == String.Empty)
                    Description = "Without Description";
                else Description = task_description;
                date = task_date;
                isdone = false;
            }
            public void ChangeDescription(string task_description)
            {
                if (task_description == null || task_description == String.Empty)
                    Description = "Without Description";
                else Description = task_description;
            }
            public void ChangeName(string task_name)
            {
                if (task_name == null || task_name == String.Empty)
                    Name = "Without Name";
                else Name = task_name;
            }
            public void ChangeTime(DateTime task_datatime)
            {
                date = task_datatime;
            }
            public DateTime Date() { return date; }
            public void ShowReminds()
            {
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Description: " + Description);
                Console.WriteLine("Time: "+date.ToString());
                Console.WriteLine("Status: " + (this.isdone ? "Done" : "Not Done"));
            }


        }
        public static void WorkWithToDo()
        {
            bool f = true;
            Console.Clear();
            Console.WriteLine("0. Exsit");
            while (f)
            {
                for (int j = 0; j < ToDoList.Count(); j++)
                {
                    Console.Write((j + 1).ToString() + ". ");
                    ToDoList.ElementAt(j).ShowToDo();
                }

                int i = -1;
                while (i == -1)
                {
                    int.TryParse(Console.ReadLine(), out i);
                    switch (i)
                    {
                        case 0:
                            f = false;
                            i = 1;
                            break;
                        case -1:
                            break;
                        default:
                            if (0 < i && i <= ToDoList.Count())
                            {
                                Console.WriteLine("1. " + "Change");
                                Console.WriteLine("2. Remouve");
                                Console.WriteLine("0. Exit");
                                string choice = Console.ReadLine();
                                if (choice == "0") break;
                                if (choice == "2")
                                    ToDoList.RemoveAt(i - 1);
                                if(choice=="1")
                                {
                                    Console.WriteLine("1. Name");
                                    Console.WriteLine("2. Description");
                                    Console.WriteLine("3. Status");
                                    Console.WriteLine("0. Exit");
                                    string choice1 = Console.ReadLine();
                                    if(choice1=="1")
                                    {
                                        Console.Write("Put a new name  ");
                                        ToDoList.ElementAt(i - 1).ChangeName(Console.ReadLine());
                                    }
                                    if (choice1 == "2")
                                    {
                                        Console.Write("Put a new Description  ");
                                        ToDoList.ElementAt(i - 1).ChangeDescription(Console.ReadLine());
                                    }
                                    if (choice1 == "3")
                                    {

                                        ToDoList.ElementAt(i - 1).isdone = !ToDoList.ElementAt(i - 1).isdone;
                                    }
                                    if(choice1=="0")
                                    {

                                    }
                                    
                                }
                            }
                            i = -1;
                            break;
                    }
                }
            }

        }
        public static void AddToDo()
        {
            Console.Clear();
            Console.Write("Put a name ");
            string Name = Console.ReadLine();
            Console.Write("Put a description ");
            string Description = Console.ReadLine();
            ToDoList.Add(new ToDo(Name, Description));
        }
        public static void ToDoMenu()
        {
            bool f = true;
            
            while(f)
            {
                Console.Clear();
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Show all Tasks");
                Console.WriteLine("2. Add Task");
                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        WorkWithToDo();
                        break;
                    case "2":
                        AddToDo();
                        break;
                    case "0":
                        f = false;
                        break;
                    default:
                        break;
                }

            }
        }
        public static void AddRewinder()
        {
            Console.Clear();
            Console.Write("Put a name ");
            string Name = Console.ReadLine();
            Console.Write("Put a description ");
            string Description = Console.ReadLine();
            int y, m, d, h, min;
            Console.Write("Put a year(for example, 2020):  ");
            int.TryParse(Console.ReadLine(), out y);
            Console.Write("Put a mounth(for example, 1):  ");
            int.TryParse(Console.ReadLine(), out m);
            Console.Write("Put a day(for example, 1):  ");
            int.TryParse(Console.ReadLine(), out d);
            Console.Write("Put a hour(for example, 1):  ");
            int.TryParse(Console.ReadLine(), out h);
            Console.Write("Put a minutes(for example, 1):  ");
            int.TryParse(Console.ReadLine(), out min);
            DateTime date1 = new DateTime(y, m, d, h, min, 0);
            ReminderList.Add(new Reminder(Name, Description,date1 ));
        }
        public static void ReminderMenu()
        {
            bool f = true;
            
            while (f)
            {
                Console.Clear();
                Console.WriteLine("1. Show all Tasks");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        WorkWithReminder();
                        break;
                    case "2":
                        AddRewinder();
                        break;
                    case "3":
                        f = false;
                        break;
                    default:
                        break;
                }

            }
        }
        public static void WorkWithReminder()
        {
            Console.Clear();
            bool f = true;
            Console.WriteLine("0. Exsit");
            while (f)
            {
                for (int j = 0; j < ReminderList.Count(); j++)
                {
                    Console.Write((j + 1).ToString() + ". ");
                    ReminderList.ElementAt(j).ShowReminds();
                }

                int i = -1;
                while (i == -1)
                {
                    int.TryParse(Console.ReadLine(), out i);
                    switch (i)
                    {
                        case 0:
                            f = false;
                            i = 1;
                            break;
                        case -1:
                            break;
                        default:
                            if (0 < i && i <= ReminderList.Count())
                            {
                                Console.WriteLine("1. " + "Change");
                                Console.WriteLine("2. Remouve");
                                Console.WriteLine("0. Exit");
                                string choice = Console.ReadLine();
                                if (choice == "0") break;//!!!!!!!!!!!!!!!!!!!!!
                                if (choice == "2")
                                    ReminderList.RemoveAt(i - 1);
                                if (choice == "1")
                                {
                                    Console.WriteLine("1. Name");
                                    Console.WriteLine("2. Description");
                                    Console.WriteLine("3. Status");
                                    Console.WriteLine("4. Time");
                                    Console.WriteLine("0. Exit");
                                    string choice1 = Console.ReadLine();
                                    if (choice1 == "1")
                                    {
                                        Console.Write("Put a new name  ");
                                        ReminderList.ElementAt(i - 1).ChangeName(Console.ReadLine());
                                    }
                                    if (choice1 == "2")
                                    {
                                        Console.Write("Put a new Description  ");
                                        ReminderList.ElementAt(i - 1).ChangeDescription(Console.ReadLine());
                                    }
                                    if (choice1 == "3")
                                    {

                                        ReminderList.ElementAt(i - 1).isdone = !ReminderList.ElementAt(i - 1).isdone;
                                    }
                                    if(choice1=="4")
                                    {
                                        int y, m, d, h, min;
                                        Console.Write("Put a year(for example, 2020):  ");
                                        int.TryParse(Console.ReadLine(),out y);
                                        Console.Write("Put a mounth(for example, 1):  ");
                                        int.TryParse(Console.ReadLine(), out m);
                                        Console.Write("Put a day(for example, 1):  ");
                                        int.TryParse(Console.ReadLine(), out d);
                                        Console.Write("Put a hour(for example, 1):  ");
                                        int.TryParse(Console.ReadLine(), out h);
                                        Console.Write("Put a minutes(for example, 1):  ");
                                        int.TryParse(Console.ReadLine(), out min);
                                        DateTime date1 = new DateTime(y, m, d, h, min, 0);
                                        ReminderList.ElementAt(i - 1).ChangeTime(date1);
                                    }
                                    if (choice1 == "0")
                                    {

                                    }

                                }
                            }
                            i = -1;
                            break;
                    }
                }
            }

        }
        public static void menu()
        {
            
            DateTime current_date = DateTime.Today;
            if (ReminderList.Count()!=0 )
            {
                    bool f = true;
                    for (int i = 0; i < ReminderList.Count(); i++)
                    {
                       if( ReminderList.ElementAt(i).Date().ToString("dd:MM:yyyy")==current_date.ToString("dd:MM:yyyy"))
                       {
                            if (f)
                            {
                                Console.WriteLine("Reminders:");
                                f = false;
                            }
                            ReminderList.ElementAt(i).ShowReminds();
                       }
                    }


            }
            bool ff = true;
            while(ff)
            {
                Console.WriteLine("Opportunities:");
                Console.WriteLine("1. ToDo List");
                Console.WriteLine("2 .Reminders");
                Console.WriteLine("0. Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ToDoMenu();
                        break;
                    case "2":
                        ReminderMenu();
                        break;
                    case "0":
                        ff = false;
                        break;
                    default:
                        break;

                }
            }

            
        }

    }
}
