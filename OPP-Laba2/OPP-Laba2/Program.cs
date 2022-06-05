using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

using UniversityLibrary;

namespace OPP_Laba2
{
    internal class Program
    {
        public static List<User> users = new List<User>();
        static void Main(string[] args)
        {
            getUsersData();

            string input = "";
            while (input != "S") {
                printCurrentUsersDataState();
                Console.Write(
                    "Input a user index for adding data\n" +
                    "or 'S' for saving and exit\n" +                                        
                    "Your choice: "
                );
                input = Console.ReadLine();

                switch (input) {
                    case "S":
                        if (isUsersValid())
                            saveUsersData();
                        else {
                            Console.Clear();
                            Console.WriteLine("Data invalid! Add info for all users!\n");
                            input = "";
                        }
                        break;
                    default:
                        if (isInputValid(input))
                            updateUserData(int.Parse(input) - 1);
                        else
                            Console.WriteLine("\n\n[ERROR] - Wrong input. You must press 1 or 2. Try again.\n"); break;
                }
            }
            Console.WriteLine("\n\nGood bye!");
        }

        static void getUsersData() {
            var data = File.ReadAllText("students.json");
            Student[] students = Newtonsoft.Json.JsonConvert.DeserializeObject<Student[]>(data);
            List<User> newUsers = new List<User>();
            foreach (Student item in students) {
                User newUser = new User();
                newUser.student = item;
                newUsers.Add(newUser);
            }            
            users = newUsers;
        }

        static void saveUsersData() {             
            string jsonString = JsonSerializer.Serialize(users);
            Console.WriteLine(users[0].student.degree);
            File.WriteAllText("usersData.json", jsonString);
            Console.WriteLine("Data saved!!!");          
        }

        static bool isUsersValid() {            
            foreach (User item in users) 
                if (!isUserValid(item))
                    return false;            
            return true;
        }

        static bool isUserValid(User user) {
            try {
                bool result =
                    user.userEmail != null &&
                    user.userPhone != null &&
                    user.userPassword != null ;
                return result;
            } catch {
                return false;
            }
        }

        static void printCurrentUsersDataState() {
            int i = 1;
            Console.WriteLine();
            foreach (User item in users) {
                string output = i + ". " + item + " - ";
                output += isUserValid(item) ? "√" : "data not valid";
                Console.WriteLine(output);
                i++;
            }
        }

        private static bool isInputValid(string input) {
            try {
                int temp = int.Parse(input);
                return temp <= users.Count;
            }
            catch {
                return false;
            }
        }

        static void updateUserData(int userListIndex) {
            User currentUser = users[userListIndex];            
            Console.WriteLine("\nAdd data for user: " + currentUser);
            Console.Write("Email: ");
            currentUser.userEmail = Console.ReadLine();
            Console.Write("Phone: ");
            currentUser.userPhone = Console.ReadLine();
            Console.Write("Password: ");
            currentUser.userPassword = Console.ReadLine();
            users[userListIndex] = currentUser;

            Console.WriteLine("\nInfo\n" + users[userListIndex].getInfo());
        }
    }
}
