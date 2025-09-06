
namespace _StudentList1
{


    class Program
    {
        static void Main()
        {
            DoublyLinkedList studentList = new DoublyLinkedList();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- MAIN MENU ---");
                Console.WriteLine("1. Insert Student");
                Console.WriteLine("2. Delete Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Show All");
                Console.WriteLine("5. Search ID");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        studentList.InsertStudent();
                        break;
                    case "2":
                        studentList.DeleteStudent();
                        break;
                    case "3":
                        studentList.UpdateStudent();
                        break;
                    case "4":
                        studentList.ShowAll();
                        break;
                    case "5":
                        studentList.SearchStudent();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}