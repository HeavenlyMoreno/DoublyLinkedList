using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using _StudentList1;

class DoublyLinkedList
{
    private Node head;

    public void InsertStudent()
    {
        Console.WriteLine("Insert Options: \n1)Beginning\n2)End \n3)Specific Location");
        Console.Write("Choose option: ");
        if (!int.TryParse(Console.ReadLine(), out int option))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        Console.Write("Enter ID: ");
        string id = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("ID cannot be empty.");
            return;
        }
        if (SearchByID(id) != null)
        {
            Console.WriteLine("ID already exists.");
            return;
        }

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Course: ");
        string course = Console.ReadLine();

        Console.Write("Enter Year Level: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Year must be a number.");
            return;
        }

        Console.Write("Enter GPA: ");
        if (!double.TryParse(Console.ReadLine(), out double gpa))
        {
            Console.WriteLine("GPA must be a number.");
            return;
        }

        Student newStudent = new Student { ID = id, Name = name, Course = course, YearLevel = year, GPA = gpa };
        Node newNode = new Node(newStudent);

        if (head == null)
        {
            
            head = newNode;
        }
        else if (option == 1)
        {
            
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }
        else if (option == 2)
        {
            
            Node temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
            newNode.Prev = temp;
        }
        else if (option == 3)
        {
            Console.Write("Enter position (1-based): ");
            if (!int.TryParse(Console.ReadLine(), out int pos) || pos < 1)
            {
                Console.WriteLine("Invalid position.");
                return;
            }

            if (pos == 1)
            {
                
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
            else
            {
                Node temp = head;
                int count = 1;
                while (temp.Next != null && count < pos - 1)
                {
                    temp = temp.Next;
                    count++;
                }

                
                newNode.Next = temp.Next;
                newNode.Prev = temp;
                if (temp.Next != null)
                    temp.Next.Prev = newNode;
                temp.Next = newNode;
            }
        }
        else
        {
            Console.WriteLine("Invalid option.");
            return;
        }

        Console.WriteLine("Student inserted.");
    }

    public void DeleteStudent()
    {
        Console.Write("Enter ID to delete: ");
        string id = Console.ReadLine();

        Node nodeToDelete = SearchByID(id);
        if (nodeToDelete == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        if (nodeToDelete.Prev != null)
            nodeToDelete.Prev.Next = nodeToDelete.Next;
        else
            head = nodeToDelete.Next;

        if (nodeToDelete.Next != null)
            nodeToDelete.Next.Prev = nodeToDelete.Prev;

        Console.WriteLine("Student deleted.");
    }

    public void UpdateStudent()
    {
        Console.Write("Enter ID to update: ");
        string id = Console.ReadLine();

        Node nodeToUpdate = SearchByID(id);
        if (nodeToUpdate == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("Enter new Name: ");
        nodeToUpdate.Data.Name = Console.ReadLine();
        Console.Write("Enter new Course: ");
        nodeToUpdate.Data.Course = Console.ReadLine();

        Console.Write("Enter new Year Level: ");
        int.TryParse(Console.ReadLine(), out int year);
        nodeToUpdate.Data.YearLevel = year;

        Console.Write("Enter new GPA: ");
        double.TryParse(Console.ReadLine(), out double gpa);
        nodeToUpdate.Data.GPA = gpa;

        Console.WriteLine("Student updated.");
    }

    public void ShowAll()
    {
        if (head == null)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Node temp = head;
        while (temp != null)
        {
            temp.Data.Display();
            temp = temp.Next;
        }
    }

    private Node SearchByID(string id)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.ID == id)
                return temp;
            temp = temp.Next;
        }
        return null;
    }

    public void SearchStudent()
    {
        Console.Write("Enter ID to search: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("ID cannot be empty.");
            return;
        }

        Node found = SearchByID(id);
        if (found != null)
        {
            Console.WriteLine("Student found:");
            found.Data.Display();
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}