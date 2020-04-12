using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hackerrank.LinkedLists;

namespace Hackerrank
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedListNode head = new SinglyLinkedListNode(5);
            var x = head;
            int i = 4;

            while (i > 0)
            {
                x.next = new SinglyLinkedListNode(i);
                i--;
                x = x.next;
            }

            LinkedLists.InsertNodeAtPosition(head, 1000, 3);
        }
    }
}
