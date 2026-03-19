using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Sys
{
    internal class Program
    {
        static void Main()
        {
            Login login = new Login();
            login.Logon();
            Console.WriteLine(login.GetAccessLevel());
            int AL = login.GetAccessLevel();
            utilities util = new utilities();
            util.showMenu(AL);
        }
    }
    class utilities
    {
        public int[] BinSearch(int[] arr, int tarnum)
        {
            int arrLen = arr.Length;
            int left = 0;
            int right = 0;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == tarnum)
                { return arr; }
                else if (arr[mid] < tarnum)
                { left = mid + 1; }
                else
                { right = mid - 1; }
            }
            return arr;
        }
        public int[] BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }
        public int Discounts(string Type, int Cost)
        {
            if (Type == "Student" | Type == "student") { return Cost - (Cost / 10); }
            else if (Type == "Senior" | Type == "senior") { return Cost - (Cost / 5); }
            else if (Type == "Prenium" | Type == "prenium") { return Cost + (Cost / 2); }
            else { return Cost; }
        }
        public void showMenu(int accessLevel)
        {

            if (accessLevel == 1)
            {
                managerMenu(accessLevel);
            }
            else
            {
                employeeMenu(accessLevel);
            }
        }
        protected void employeeMenu(int accessLevel)
        {
            bool running = true;
            while (running)
            {
                int option = menuEmployee("Cinema");
                switch (option)
                {
                    //stupid ahh messages are placeholders
                    case 0:
                        Console.WriteLine("view yo seats");
                        Console.ReadLine();
                        break;
                    case 1:
                        Console.WriteLine("book yo seats");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("view yo screenings");
                        Console.ReadLine();
                        break;
                    case 3:
                        running = false;
                        Console.WriteLine("\n\n          System shutting down...");
                        break;
                }
            }
        }
        protected static int menuEmployee(string hotelName)
        {
            string[] options = {
                "View Seats",
                "Book Seats",
                "View Screenings",
                "Exit"
            };
            int currentSelection = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n\n          {hotelName} Management Sys");
                Console.WriteLine("          Choose An Option\n");
                for (int i = 0; i < options.Length; i++)
                {
                    Console.Write("          ");

                    if (i == currentSelection)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($">> {options[i]} <<");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {options[i]}   ");
                    }
                    Console.WriteLine();
                }
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    currentSelection--;
                    if (currentSelection < 0) currentSelection = options.Length - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    currentSelection++;
                    if (currentSelection >= options.Length) currentSelection = 0;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return currentSelection;
                }
            }
        }

        protected void managerMenu(int accessLevel)
        {
            bool running = true;
            while (running)
            {

                int option = menuManager("Cinema");
                switch (option)
                {
                    //HI is placeholder for actual code and classes.
                    case 0:
                        Console.WriteLine("view yo seats");
                        Console.ReadLine();
                        break;
                    case 1:
                        Console.WriteLine("book yo seats");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("view yo screenings");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("view thy report of financies");
                        Console.ReadLine();
                        if (accessLevel == 0)
                        { break; }
                        else
                        {//call here break; }
                            break;
                        }
                    case 4:
                        Console.WriteLine("create a new screnning");
                        Console.ReadLine();
                        if (accessLevel == 0)
                        { break; }
                        else
                        {//call here break; }
                        }
                        break;
                    case 5:
                        running = false;
                        Console.WriteLine("\n\n          System shutting down...");
                        break;
                }
            }
        }
        protected static int menuManager(string hotelName)
        {
            string[] options = {
                    "View Seats",
                    "Book Seats",
                    "View Screenings",
                    "Financial ReporT",
                    "New Screening",
                    "Exit"
                };


            int currentSelection = 0;


            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n\n          {hotelName} Management Sys");
                Console.WriteLine("          Choose An Option\n");


                for (int i = 0; i < options.Length; i++)
                {
                    Console.Write("          ");

                    if (i == currentSelection)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($">> {options[i]} <<");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {options[i]}   ");
                    }
                    Console.WriteLine();
                }


                var key = Console.ReadKey(true);


                if (key.Key == ConsoleKey.UpArrow)
                {
                    currentSelection--;
                    if (currentSelection < 0) currentSelection = options.Length - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    currentSelection++;
                    if (currentSelection >= options.Length) currentSelection = 0;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return currentSelection;
                }
            }
        }
    }
    class Seat
    {
        private string seatType;
        private string seatName;
        private bool isFull;

        // constructor
        public Seat(string type, string name, bool full)
        {
            seatType = type;
            seatName = name;
            isFull = full;
        }
        public string getseatName()
        {
            return seatName;
        }
        public bool getisFull()
        {
            return isFull;
        }
    }
    class Room
    {
        private int seatNum;
        private Seat[,] seatingPlan;
        private Dictionary<string, string> moviesToShow;
        private int screenNumber;
        private bool isFull;
        private string textfilename;
        private int screen_rows;
        private int screen_columns;

        //constructor
        public Room(int roomNumber, int rows, int columns)
        {
            screenNumber = roomNumber;
            seatNum = rows * columns;
            screen_rows = rows;
            screen_columns = columns;
            seatingPlan = new Seat[rows, columns];
            Console.Write($"Please write the textfile name for this screen room #{roomNumber}:");
            textfilename = $"screen{roomNumber}" + ".txt";
            // adding all the seats in
            if (File.Exists(textfilename) == true)
            {
                StreamReader SR = new StreamReader(textfilename);
                string placeholder = SR.ReadLine();
                string[] placeholderlist = placeholder.Split('|');
                screen_rows = Convert.ToInt32(placeholderlist[0]);
                screen_columns = Convert.ToInt32(placeholderlist[1]);
                for (int i = 0; i < screen_columns; i++)
                {
                    placeholder = SR.ReadLine();
                    placeholderlist = placeholder.Split('|');
                    for (int j = 0; j < screen_rows; j++)
                    {
                        if (screen_columns == 1)
                        {
                            string[] placeholderlist2 = placeholderlist[j].Split(',');
                            seatingPlan[j, i] = new Seat(placeholderlist2[0], "Premium", Convert.ToBoolean(placeholderlist2[1]));
                        }
                        else
                        {
                            string[] placeholderlist2 = placeholderlist[j].Split(',');
                            seatingPlan[j, i] = new Seat(placeholderlist2[0], "Standard", Convert.ToBoolean(placeholderlist2[1]));
                        }
                    }
                }
                SR.Close();
            }
            else
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        // giving all the seats names like A1 B2
                        Char rowLetter = (char)('A' + r);
                        Char columnNumber = (char)(c + 1);
                        string seatName = $"{rowLetter}{columnNumber}";

                        // if seat is in the back row (row 1) its Premium, rest are standard
                        if (columnNumber == 1)
                        {
                            seatingPlan[r, c] = new Seat(seatName, "Premium", false);
                        }
                        else
                        {
                            seatingPlan[r, c] = new Seat(seatName, "Standard", false);
                        }


                    }
                }
            }
        }
        public void save()
        {
            StreamWriter SW = new StreamWriter(textfilename);
            SW.WriteLine($"{screen_rows}|{screen_columns}");
            for (int i = 0; i < screen_columns; i++)
            {
                for (int j = 0; i < screen_rows; j++)
                {
                    if (j == screen_rows - 1)
                    {
                        SW.Write($"{seatingPlan[j, i].getseatName()}, {seatingPlan[j, i].getisFull()}");
                    }
                    else
                    {
                        SW.Write($"{seatingPlan[j, i].getseatName()}, {seatingPlan[j, i].getisFull()}|");
                    }
                }
                SW.WriteLine();
            }
            SW.Close();
        }
    }
    public class Login
    {
        protected int accessLevel = 0;
        protected void SetAccessLevel(int newLevel)
        {
            accessLevel = newLevel;
        }
        public int GetAccessLevel()
        {
            return accessLevel;
        }
        protected int attemptNum = 0;
        protected string vernierEncryption(string s) //takes last 5 char as key
        {
            if (s.Length <= 5) return Convert.ToBase64String(Encoding.ASCII.GetBytes(s));
            string m = s.Substring(0, s.Length - 5);
            string k = s.Substring(s.Length - 5);
            byte[] b = Encoding.ASCII.GetBytes(m);
            byte[] r = new byte[b.Length];
            for (int i = 0; i < b.Length; i++)
            { r[i] = (byte)((b[i] + k[i % 5]) % 256); }
            return Convert.ToBase64String(r.Concat(Encoding.ASCII.GetBytes(k)).ToArray());
        }
        protected string[] getUsers()
        {
            string[] users = new string[100];
            StreamReader sr = new StreamReader("users.txt");
            var lineCount = File.ReadLines(@"users.txt").Count();
            for (int i = 0; i < lineCount + 1 / 2; i = i + 2)
            {
                users[i] = sr.ReadLine();
                sr.ReadLine();
            }
            sr.Close();

            return users;
        }
        protected string[] getPassHash()
        {
            string[] passHashed = new string[100];
            StreamReader sr = new StreamReader("users.txt");
            var lineCount = File.ReadLines(@"users.txt").Count();
            for (int i = 0; i < lineCount + 1 / 2; i = i + 2)
            {
                sr.ReadLine();
                passHashed[i] = sr.ReadLine();
            }
            sr.Close();
            return passHashed;
        }
        public void Logon()
        {

            Console.Clear();
            string[] users = getUsers();
            string[] passHashed = getPassHash();
            Console.WriteLine("\n    Welcome to the Cinema Managment Sys");
            Console.WriteLine("    Please enter your username and password to login.");
            Console.WriteLine("    Username: ");
            Console.Write("    Password:"); // both test users password is Password123. - 
            Console.SetCursorPosition(14, 3);
            string Username = Console.ReadLine();
            Console.SetCursorPosition(14, 4);
            string inputPass = "";
            int startX = 14; 
            int y = 4;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    if (inputPass.Length > 0)
                    {
                        Console.SetCursorPosition(startX + inputPass.Length - 1, y);
                        Console.Write("*");
                    }
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (inputPass.Length > 0)
                    {
                        Console.SetCursorPosition(startX + inputPass.Length - 1, y);
                        Console.Write(" ");
                        inputPass = inputPass.Substring(0, inputPass.Length - 1);
                        Console.SetCursorPosition(startX + inputPass.Length, y);
                    }
                }
                else
                {
                    if (inputPass.Length > 0)
                    {
                        Console.SetCursorPosition(startX + inputPass.Length - 1, y);
                        Console.Write("*");
                    }
                    inputPass += key.KeyChar;
                    Console.SetCursorPosition(startX + inputPass.Length - 1, y);
                    Console.Write(key.KeyChar);
                }
            }
            Console.Write("\n");
            int userIndex = Array.FindIndex(users, u => u == Username);
            if (userIndex >= 0)
            {
                string partHashPass = this.vernierEncryption(inputPass);
                int hashPass = this.hashPass(partHashPass);
                if (passHashed[userIndex] == hashPass.ToString())
                {
                    Console.WriteLine("Login successful.");
                    if (Username == "Manager")
                    {
                        SetAccessLevel(1);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("UserName or password incorrect.");
                    Console.WriteLine("Press any key to continue");
                    Console.ForegroundColor = ConsoleColor.White;
                    attemptNum++;
                    Console.ReadKey();
                    Console.Clear();
                    this.Logon();
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("UserName or password incorrect");
                Console.WriteLine("Press any key to continue");
                Console.ForegroundColor = ConsoleColor.White;
                attemptNum++;
                Console.ReadKey();
                Console.Clear();
                this.Logon();
            }
        }
        public void SignUp()
        {
            string[] users = getUsers();
            StreamWriter sw = new StreamWriter("users.txt", true);
            Console.Clear();
            Console.WriteLine("\n    ");
            Console.WriteLine("    Please enter your username and password to sign up, password is typing even if you dont see it.");
            Console.WriteLine("    Username: ");
            Console.WriteLine("    Password:");
            Console.Write("    Confirm Password:");
            Console.SetCursorPosition(14, 3);
            string Username = Console.ReadLine();
            Console.SetCursorPosition(14, 4);
            string inputPass = null;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                inputPass += key.KeyChar;
            }
            Console.SetCursorPosition(22, 5);
            string confirmPass = null;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                confirmPass += key.KeyChar;
            }
            if (inputPass == confirmPass)
            {
                Console.Write("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Passwords do not match");
                Console.WriteLine("Press any key to continue");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                this.SignUp();
            }
            int userIndex = Array.FindIndex(users, u => u == Username);
            if (userIndex >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("UserName Already exists. Pick a new one.");
                Console.WriteLine("Press any key to continue");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                this.SignUp();
            }
            string inputHash = Convert.ToString(hashPass(inputPass));
            sw.WriteLine();
            sw.WriteLine(Username);
            sw.WriteLine(inputHash);
            sw.Close();

        }
        protected int hashPass(string s)
        {
            int startNum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                int inpNum = c - '0';
                if (i % 2 == 0)
                {
                    inpNum = inpNum * i;
                }
                startNum += inpNum * i;
            }
            startNum = startNum * 999331;
            startNum = startNum % 429496729;
            return startNum;
        }
    }
}




// USERS TXT FILE FORMAT
//1| 2
//2| user1
//3| passHASH1
//4| user2
//5| passHASH2
//
//
//
//
//
//
//
