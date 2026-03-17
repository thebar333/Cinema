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
            else if (Type == "Senior" | Type == "senior" ) { return Cost - (Cost / 5); }
            else if (Type == "Prenium" | Type == "prenium") { return Cost + (Cost / 2); }
            else { return Cost; }
        }
    }
    class Seat
    {
        private string seatType;
        private string seatName;
        private bool isFull;

        // constructor
        public Seat(string type, string name)
        {
            seatType = type;
            seatName = name;
            isFull = false;
        }
        class Room
        {
            private int seatNum;
            private Seat[,] seatingPlan;
            private Dictionary<string, string> moviesToShow;
            private int screenNumber;
            private bool isFull;

            //constructor
            public Room(int roomNumber, int rows, int columns)
            {
                screenNumber = roomNumber;
                seatNum = rows * columns;
                seatingPlan = new Seat[rows, columns];

                // adding all the seats in
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
                            seatingPlan[r, c] = new Seat(seatName, "Premium");
                        }
                        else
                        {
                            seatingPlan[r, c] = new Seat(seatName, "Standard");
                        }
                    }
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
                    Console.WriteLine("    Please enter your username and password to login. Password is still typing even if you dont see it.");
                    Console.WriteLine("    Username: ");
                    Console.Write("    Password:"); // both test users password is Password123. - 
                                                    // PREPOPULATE LOGIN WITH MANAGER AND EMPLOYEE SPECIFIC LOGIN.
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
                    Console.Write("\n");
                    int userIndex = Array.FindIndex(users, u => u == Username);
                    if (userIndex >= 0)
                    {
                        int hashedPass = this.hashPass(inputPass);
                        if (passHashed[userIndex] == hashedPass.ToString())
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
                protected int hashPass(string pass)
                {
                    int startNum = 0;
                    for (int i = 0; i < pass.Length; i++)
                    {
                        char c = pass[i];
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
