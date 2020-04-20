using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank
{
    public static class LinkedLists
    {
        // For reference by Hackerrank
        public class SinglyLinkedListNode
        {
            internal int data;
            internal SinglyLinkedListNode next;

            public SinglyLinkedListNode(int data)
            {
                this.data = data;
            }
        }

        public class DoublyLinkedListNode
        {
            internal int data;
            internal DoublyLinkedListNode prev;
            internal DoublyLinkedListNode next;

            public DoublyLinkedListNode(int data)
            {
                this.data = data;
            }
        }

        public static SinglyLinkedListNode InsertNodeAtHead(SinglyLinkedListNode llist, int data)
        {
            SinglyLinkedListNode newHead = new SinglyLinkedListNode(data);
            newHead.next = llist;

            return newHead;
        }

        public static SinglyLinkedListNode Reverse(SinglyLinkedListNode head)
        {
            if (head == null)
            {
                return head;
            }

            Stack<SinglyLinkedListNode> nodes = new Stack<SinglyLinkedListNode>();
            SinglyLinkedListNode currentHead = head;

            while (currentHead != null)
            {
                nodes.Push(currentHead);

                currentHead = currentHead.next;
            }

            head = nodes.Pop();
            SinglyLinkedListNode helper = head;

            while (nodes.Count > 0)
            {
                helper.next = nodes.Pop();

                helper = helper.next;
                helper.next = null;
            }

            return head;
        }

        public static void PrintLinkedList(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode currentEl = head;

            while (currentEl != null)
            {
                Console.WriteLine(currentEl.data);

                currentEl = currentEl.next;
            }
        }

        public static SinglyLinkedListNode InsertNodeAtTail(SinglyLinkedListNode head, int data)
        {
            SinglyLinkedListNode elementToAdd = new SinglyLinkedListNode(data);
            SinglyLinkedListNode currentEl = head;

            if (currentEl == null)
            {
                currentEl = new SinglyLinkedListNode(data);

                return currentEl;
            }

            while (currentEl.next != null)
            {
                currentEl = currentEl.next;
            }

            currentEl.next = elementToAdd;

            return head;
        }

        public static SinglyLinkedListNode InsertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            if (head == null && position == 0)
            {
                head = new SinglyLinkedListNode(data);

                return head;
            }

            SinglyLinkedListNode currentEl = head;
            SinglyLinkedListNode prevEl = head;
            int index = 0;

            while (index < position)
            {
                prevEl = currentEl;
                currentEl = currentEl.next;
                index++;
            }

            if (currentEl == null)
            {
                prevEl.next = new SinglyLinkedListNode(data);
            }
            else
            {
                SinglyLinkedListNode insertBefore = currentEl;
                prevEl.next = new SinglyLinkedListNode(data);
                prevEl.next.next = insertBefore;
            }

            return head;
        }

        public static SinglyLinkedListNode DeleteNode(SinglyLinkedListNode head, int position)
        {
            int index = 0;

            if (position == 0)
            {
                head = head.next;

                return head;
            }

            SinglyLinkedListNode currentEl = head;
            SinglyLinkedListNode prevEl = head;

            while (index < position)
            {
                index++;
                prevEl = currentEl;
                currentEl = currentEl.next;
            }

            prevEl.next = prevEl.next.next;

            return head;
        }

        public static void ReversePrint(SinglyLinkedListNode head)
        {
            Stack<SinglyLinkedListNode> nodes = new Stack<SinglyLinkedListNode>();
            SinglyLinkedListNode currentHead = head;

            while (currentHead != null)
            {
                nodes.Push(currentHead);

                currentHead = currentHead.next;
            }

            while (nodes.Count > 0)
            {
                Console.WriteLine(nodes.Pop().data);
            }
        }

        public static bool CompareLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            if (head1 == null && head2 == null)
            {
                return true;
            }

            if (head1 == null || head2 == null)
            {
                return false;
            }

            SinglyLinkedListNode firstEl = head1;
            SinglyLinkedListNode secondEl = head2;

            while (firstEl != null && secondEl != null)
            {
                if (firstEl.data != secondEl.data)
                {
                    return false;
                }

                firstEl = firstEl.next;
                secondEl = secondEl.next;
            }

            if (firstEl == null && secondEl == null)
            {
                return true;
            }

            if (firstEl == null || secondEl == null)
            {
                return false;
            }

            return true;
        }

        public static int GetNode(SinglyLinkedListNode head, int positionFromTail)
        {
            Stack<SinglyLinkedListNode> nodes = new Stack<SinglyLinkedListNode>();
            SinglyLinkedListNode currentHead = head;
            int counter = 0;

            while (currentHead != null)
            {
                nodes.Push(currentHead);

                currentHead = currentHead.next;
            }

            while (nodes.Count > 0)
            {
                if (counter == positionFromTail)
                {
                    return nodes.Pop().data;
                }

                nodes.Pop();
                counter++;
            }

            return -1;
        }

        public static DoublyLinkedListNode SortedInsert(DoublyLinkedListNode head, int data)
        {
            if (head == null)
            {
                head = new DoublyLinkedListNode(data);

                return head;
            }

            DoublyLinkedListNode currentEl = head;
            DoublyLinkedListNode elementToAdd = new DoublyLinkedListNode(data);

            if (currentEl.data > elementToAdd.data)
            {
                elementToAdd.next = currentEl;
                currentEl.prev = elementToAdd;

                return elementToAdd;
            }

            while (currentEl.data < elementToAdd.data)
            {
                if (currentEl.next != null)
                {
                    currentEl = currentEl.next;
                }
                else
                {
                    currentEl.next = elementToAdd;
                    elementToAdd.prev = currentEl;

                    return head;
                }
            }

            elementToAdd.next = currentEl;
            currentEl.prev.next = elementToAdd;

            return head;
        }

        public static DoublyLinkedListNode Reverse(DoublyLinkedListNode head)
        {
            if (head == null)
            {
                return head;
            }

            Stack<DoublyLinkedListNode> nodes = new Stack<DoublyLinkedListNode>();
            DoublyLinkedListNode currentEl = head;
            DoublyLinkedListNode temp = null;

            while (currentEl != null)
            {
                temp = currentEl.prev;
                DoublyLinkedListNode nextElement = currentEl.next;
                currentEl.prev = nextElement;
                currentEl.next = temp;

                currentEl = currentEl.prev;
            }

            DoublyLinkedListNode headToReturn = head;

            while (headToReturn.prev != null)
            {
                headToReturn = headToReturn.prev;
            }

            return headToReturn;
        }

        public static bool HasCycle(SinglyLinkedListNode head)
        {
            Dictionary<SinglyLinkedListNode, int> traversedNodes = new Dictionary<SinglyLinkedListNode, int>();
            SinglyLinkedListNode currentEl = head;

            if (head == null || head.next == null)
            {
                return false;
            }

            while (currentEl != null)
            {
                if (traversedNodes.ContainsKey(currentEl))
                {
                    if (traversedNodes[currentEl] == currentEl.data)
                    {
                        return true;
                    }
                }
                else
                {
                    traversedNodes.Add(currentEl, currentEl.data);
                }

                currentEl = currentEl.next;
            }

            return false;
        }

        public static SinglyLinkedListNode MergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            // edge cases
            if (head1 == null && head2 == null)
            {
                return null;
            }
            else if (head1 == null || head2 == null)
            {
                return head1 == null ? head2 : head1;
            }
            // end of edge cases

            SinglyLinkedListNode currentEl = null;

            if (head1.data < head2.data)
            {
                currentEl = head1;
                head1 = head1.next;
            }
            else
            {
                currentEl = head2;
                head2 = head2.next;
            }

            SinglyLinkedListNode helper = currentEl;

            while (head1 != null && head2 != null)
            {
                if (head1.data < head2.data)
                {
                    helper.next = head1;
                    head1 = head1.next;
                }
                else
                {
                    helper.next = head2;
                    head2 = head2.next;
                }

                helper = helper.next;
            }

            if (head1 == null || head2 == null)
            {
                helper.next = (head1 == null ? head2 : head1);
            }

            return currentEl;
        }

        public static SinglyLinkedListNode RemoveDuplicates(SinglyLinkedListNode head)
        {
            if (head == null)
            {
                return null;
            }

            SinglyLinkedListNode currentEl = head;

            while (currentEl.next != null)
            {
                if (currentEl.next.data == currentEl.data)
                {
                    currentEl.next = currentEl.next.next;
                }
                else
                {
                    currentEl = currentEl.next;
                }
            }

            return head;
        }

        public static int FindMergeNode(SinglyLinkedListNode headA, SinglyLinkedListNode headB)
        {
            throw new NotImplementedException("TODO when hackerrank fix the input and make it understandable.");
        }
    }
}
