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
            SinglyLinkedListNode head1 = new SinglyLinkedListNode(1);
            head1.next = new SinglyLinkedListNode(1);
            head1.next.next = new SinglyLinkedListNode(3);

            SinglyLinkedListNode head2 = new SinglyLinkedListNode(1);
            var y = head2;
            int j = 2;

            while (j < 4)
            {
                //if (j != 2 && j != 5 && j != 11)
                //{
                //    j++;
                //    continue;
                //}

                y.next = new SinglyLinkedListNode(j);
                j++;
                y = y.next;
            }

            LinkedLists.FindMergeNode(head1, head2);
        }
    }
}
