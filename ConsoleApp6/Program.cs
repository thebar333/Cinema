using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace Login_Sys
{
    internal class Program
    {
        static void Main()
        {
            Login login = new Login();
            login.Logon();
            Console.WriteLine(login.GetAccessLevel());
            int AL = 1;
            utilities util = new utilities();
            util.showMenu(AL);
        }
    }
    class utilities
    {

        public string BinSearchMovies(string[] arr, string tarnum)
        {
            int arrLen = arr.Length;
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int result = string.Compare(tarnum.ToLower(), arr[mid].ToLower());

                if (result == 0)
                {
                    return arr[mid];
                }
                else if (result > 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }


            return null;
        }
        public static string[] BubbleSortMovies(string[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(arr[j], arr[j + 1]) > 0)
                    {
                        string temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }
        public static decimal Discounts(string Type, decimal Cost)
        {
            if (Type == "STUDENT") { return Cost - (Cost / 10); }
            else if (Type == "SENIOR") { return Cost - (Cost / 5); }
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
            employee staff = new employee();
            cinema myCinema = new cinema();
            while (running)
            {
                int option = menuEmployee("Cinema");
                switch (option)
                {

                    case 0:
                        int roomToView = selectRoom("Cinema");
                        switch (roomToView)
                        {
                            case 0:
                                staff.viewSeats(myCinema.room1);

                                break;

                            case 1:
                                staff.viewSeats(myCinema.room2);
                                break;

                            case 2:
                                staff.viewSeats(myCinema.room3);

                                break;

                            case 3:
                                staff.viewSeats(myCinema.room4);

                                break;

                        }
                        Console.WriteLine("\nPress any key to return to menu...");
                        Console.ReadLine();
                        break;
                    case 2:
                        staff.viewScreenings(myCinema);
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n Which movie would the customer like to see? (you may want to view screenings again)");
                        string wantedMovie = Console.ReadLine();
                        string foundmovie = BinSearchMovies(myCinema.getMovies(), wantedMovie);
                        if (foundmovie != null)
                        {
                            Room[] rooms = { myCinema.room1, myCinema.room2, myCinema.room3, myCinema.room4 };
                            Room targetRoom = null;

                            foreach (Room room in rooms)
                            {
                                if (room.getMovies().Contains(foundmovie))
                                {
                                    targetRoom = room;
                                    break;
                                }
                            }

                            if (targetRoom != null)
                            {
                                Console.WriteLine($"{foundmovie} is playing in {targetRoom.getName()}. Press enter to continue to booking");
                                Console.ReadLine();
                                staff.bookSeats(targetRoom, foundmovie);

                            }
                        }
                        else
                        {
                            Console.WriteLine($"Sorry we are not showing{wantedMovie}. Please check your capital letters or choose another");
                        }
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
                "View Screenings",
                "Book Seats",
                "Exit"
            };
            int currentSelection = 0;
            while (true)
            {

                Console.Clear();
                Console.WriteLine($"\n\n          {hotelName} Management System (employee login)");
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

        protected static int selectRoom(string hotelName)
        {
            string[] options = {
                "Room1",
                "Room 2",
                "Room 3",
                "Room 4"
            };
            int currentSelection = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n\n          What Room would you like to view?");
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
            manager boss = new manager();
            cinema myCinema = new cinema();
            bool running = true;
            while (running)
            {

                int option = menuManager("Cinema");
                switch (option)
                {
                    //HI is placeholder for actual code and classes.
                    case 0:
                        int roomToView = selectRoom("Cinema");
                        switch (roomToView)
                        {
                            case 0:
                                boss.viewSeats(myCinema.room1);

                                break;

                            case 1:
                                boss.viewSeats(myCinema.room2);
                                break;

                            case 2:
                                boss.viewSeats(myCinema.room3);

                                break;

                            case 3:
                                boss.viewSeats(myCinema.room4);

                                break;

                        }
                        Console.WriteLine("\nPress any key to return to menu...");
                        Console.ReadLine();
                        break;
                    case 2:
                        boss.viewScreenings(myCinema);
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n Which movie would the customer like to see? (you may want to view screenings again)");
                        string wantedMovie = Console.ReadLine();
                        string foundmovie = BinSearchMovies(myCinema.getMovies(), wantedMovie);
                        if (foundmovie != null)
                        {
                            Room[] rooms = { myCinema.room1, myCinema.room2, myCinema.room3, myCinema.room4 };
                            Room targetRoom = null;

                            foreach (Room room in rooms)
                            {
                                if (room.getMovies().Contains(foundmovie))
                                {
                                    targetRoom = room;
                                    break;
                                }
                            }

                            if (targetRoom != null)
                            {
                                Console.WriteLine($"{foundmovie} is playing in {targetRoom.getName()}. Press enter to continue to booking");
                                Console.ReadLine();
                                boss.bookSeats(targetRoom, foundmovie);

                            }
                        }
                        else
                        {
                            Console.WriteLine($"Sorry we are not showing{wantedMovie}. Please check your capital letters or choose another");
                        }
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
                Console.WriteLine($"\n\n          {hotelName} Management System (manager login)");
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
        private decimal price;

        // constructor
        public Seat(string type, string name, bool full, decimal price)
        {
            seatType = type;
            seatName = name;
            isFull = full;
            this.price = price;
        }
        public string getseatName()
        {
            return seatName;
        }
        public bool getisFull()
        {
            return isFull;
        }

        public void fillSeat(bool status)
        {
            isFull = status;
        }

        public decimal getPrice()
        {
            return price;
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
        private List<string> moviesShowing = new List<string>();

        //constructor
        public Room(int roomNumber, int rows, int columns)
        {
            screenNumber = roomNumber;
            seatNum = rows * columns;
            screen_rows = rows;
            screen_columns = columns;
            seatingPlan = new Seat[rows, columns];
            textfilename = $"screen{roomNumber}" + ".txt";

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
                    for (int j = 0; i < screen_rows; j++)
                    {
                        if (screen_columns == 1)
                        {
                            string[] placeholderlist2 = placeholderlist[j].Split(',');
                            seatingPlan[j, i] = new Seat(placeholderlist2[0], "Premium", Convert.ToBoolean(placeholderlist2[1]), 15);
                        }
                        else
                        {
                            string[] placeholderlist2 = placeholderlist[j].Split(',');
                            seatingPlan[j, i] = new Seat(placeholderlist2[0], "Standard", Convert.ToBoolean(placeholderlist2[1]), 10);
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
                        string seatName = $"{rowLetter}{c + 1}";

                        // if seat is in the back row (row 1) its Premium, rest are standard
                        if (rowLetter == 'A')
                        {
                            seatingPlan[r, c] = new Seat("Premium", seatName, false, 15);
                        }
                        else
                        {
                            seatingPlan[r, c] = new Seat("Standard", seatName, false, 10);
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
                for (int j = 0; j < screen_rows; j++)
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

        public Seat[,] getSeatingPlan()
        {
            return seatingPlan;
        }

        public int getRows()
        {
            return screen_rows;
        }

        public int getColumns()
        {
            return screen_columns;
        }

        public int getRoomNumber()
        {
            return screenNumber;
        }

        public void addMovie(string movieName)
        {
            moviesShowing.Add(movieName);
        }

        public List<string> getMovies()
        {
            return moviesShowing;
        }

        public string getName()
        {
            return "Screen " + this.getRoomNumber();
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
    class employee
    {
        private int accesslevel;

        public employee()
        {
            accesslevel = 0;
        }

        public void viewSeats(Room chosenRoom)
        {
            Console.Clear();
            Console.WriteLine($"Seats in Screen {chosenRoom.getRoomNumber()}\n ");

            Seat[,] plan = chosenRoom.getSeatingPlan();
            int rows = chosenRoom.getRows();
            int columns = chosenRoom.getColumns();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (plan[r, c].getisFull())
                    {
                        Console.Write(" [ X] ");

                    }
                    else
                    {
                        Console.Write($" [{plan[r, c].getseatName()}] ");
                    }
                }
                Console.WriteLine();

            }
            Console.WriteLine("                      --Screen--");
            Console.WriteLine();



        }

        public void bookSeats(Room chosenRoom, string chosenMovie)
        {

            viewSeats(chosenRoom);
            Console.WriteLine($"Book seats to see {chosenMovie} in Room {chosenRoom.getRoomNumber()}");
            Console.WriteLine("Seats in Row A are Premium (£15), all others are Standard (£10) ");
            Console.WriteLine("\nEnter the seat you would like to book");
            string wantedSeat = Console.ReadLine().ToUpper();
            Seat[,] plan = chosenRoom.getSeatingPlan();
            bool found = false;

            for (int r = 0; r < chosenRoom.getRows(); r++)
            {
                for (int c = 0; c < chosenRoom.getColumns(); c++)
                {
                    if (plan[r, c].getseatName() == wantedSeat)
                    {
                        found = true;
                        if (plan[r, c].getisFull() == true)
                        {
                            Console.WriteLine("\n Sorry that seat is taken");
                            break;
                        }
                        else
                        {
                            decimal cost = plan[r, c].getPrice();
                            decimal finalCost = 0;
                            Console.WriteLine("\nIs the customer eligible for Student or Senior discount? (write discount type or no)");
                            string DisAnswer = Console.ReadLine().ToUpper();
                            if (DisAnswer == "STUDENT")
                            {
                                finalCost = utilities.Discounts("STUDENT", cost);
                                Console.WriteLine($"\nThe seat {wantedSeat} has been booked! With a student discount the price is £{finalCost}");

                            }
                            else if (DisAnswer == "SENIOR")
                            {
                                finalCost = utilities.Discounts("SENIOR", cost);
                                Console.WriteLine($"\nThe seat {wantedSeat} has been booked! With a senior discount the price is £{finalCost}");

                            }
                            else if (DisAnswer == "NO")
                            {
                                finalCost = cost;
                                Console.WriteLine($"\nThe seat {wantedSeat} has been booked! With no discount the price is £{finalCost}");

                            }
                            else
                            {
                                Console.WriteLine("\n Please enter either the discount type or 'no' ");

                            }

                            plan[r, c].fillSeat(true);

                            //chosenRoom.save();

                        }
                        break;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("Invalid seat ID");
            }

            bool nextStep = true;
            while (nextStep)
            {
                int option = twoOptionThing("Cinema");
                switch (option)
                {
                    case 0:
                        bookSeats(chosenRoom, chosenMovie);
                        break;
                    case 1:
                        nextStep = false;
                        break;

                }
            }
        }
        protected static int twoOptionThing(string hotelName)
        {
            string[] options = {
                    "Book Another Seat",
                    "Back to Main Menu"
                };
            int currentSelection = 0;
            int startLine = Console.CursorTop;
            while (true)
            {
                Console.SetCursorPosition(0, startLine);
                Console.WriteLine(" \n What would you like to do next?");


                for (int i = 0; i < options.Length; i++)
                {


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

        public void viewScreenings(cinema theCinema)
        {
            Console.Clear();
            Console.WriteLine("----------Current screenings----------");
            Room[] allRooms = { theCinema.room1, theCinema.room2, theCinema.room3, theCinema.room4 };

            foreach (Room currentRoom in allRooms)
            {
                Console.WriteLine("\n" + currentRoom.getName());
                Console.WriteLine("-----");

                List<string> movies = currentRoom.getMovies();
                foreach (string movieName in movies)
                {
                    Console.WriteLine($"- {movieName}");
                }
            }
            Console.ReadLine();

        }

    }
    class cinema
    {
        public string[] movies;

        //adding in rooms (you now need text files screen1.txt, screen2.txt etc)
        public Room room1 = new Room(1, 12, 10);
        public Room room2 = new Room(2, 10, 5);
        public Room room3 = new Room(3, 8, 4);
        public Room room4 = new Room(4, 5, 3);


        public cinema()
        {
            movies = new string[] { "Shrek", "Shrek 2", "Cars", "The Empire Strikes Back", "Wolf of Wall Street", "Frozen", "The Bee Movie" };
            utilities.BubbleSortMovies(movies);

            int roomCounter = 0;
            foreach (string movie in movies)
            {
                if (roomCounter == 0)
                {
                    room1.addMovie(movie);
                }
                else if (roomCounter == 1)
                {
                    room2.addMovie(movie);
                }
                else if (roomCounter == 2)
                {
                    room3.addMovie(movie);
                }
                else if (roomCounter == 3)
                {
                    room4.addMovie(movie);
                }
                roomCounter++;
                if (roomCounter == 4)
                {
                    roomCounter = 0;
                }
            }

        }

        public string[] getMovies()
        {
            return movies;
        }
    }
    class manager : employee
    {
        public void editMovies(cinema currentCinema)
        {
            Console.WriteLine("Current movie selection is: ");
            for (int i = 0; i < currentCinema.movies.Length; i++)
            {
                Console.WriteLine(currentCinema.movies[i] + "\n");
            }

            Console.WriteLine("Enter Movie title to be added");
            string newName = Console.ReadLine();
            currentCinema.movies.Append(newName);

        }
    }
}
