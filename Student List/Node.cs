using _StudentList1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _StudentList1
{
    class Node
    {
        public Student Data;
        public Node Next;
        public Node Prev;

        public Node(Student student)
        {
            Data = student;
            Next = null;
            Prev = null;
        }
    }
}
