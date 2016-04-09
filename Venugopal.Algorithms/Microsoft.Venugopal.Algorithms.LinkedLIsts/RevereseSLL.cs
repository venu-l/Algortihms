using Microsoft.Venugopal.Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Venugopal.Algorithms.LinkedLists
{
    public class RevereseSLL
    {
        public RevereseSLL()
        {

        }

        public void Execute()
        {
            Node head = GetNode(10);
            head.next = GetNode(20);
            head.next.next = GetNode(30);
            head.next.next.next = GetNode(40);
            head.next.next.next.next = GetNode(50);

            Traverse(head);
            Node newHead = ReverseLinkedList(head);
            Traverse(newHead);
        }

        private Node GetNode(int dat)
        {
            return new Node() { data = dat };
        }
        
        private Node ReverseLinkedList(Node head)
        {
            if (head == null)
                throw new ArgumentNullException("root");

            Node previous, current, next;
            previous = current = next = head;

            current = current.next;

            //Core Logic 
            while (current != null)
            {
                next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            head.next = null;
            head = previous;

            return head;
        }

        private Node ReverseSubList(Node head)
        {
            if (head == null)
                throw new ArgumentNullException("root");

            Node previous, current, next, originalListHead, subListHead;
            previous = current = next = originalListHead = subListHead = head;

            current = current.next;

            //Core Logic 
            while (current != null)
            {
                next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            head.next = null;
            head = previous;

            return head;
        }

        private void Traverse(Node head)
        {
            while (head != null)
            {
                Console.Write("{0}--",head.data);
                head = head.next;
            }

            Console.WriteLine();
        }
    }
}
