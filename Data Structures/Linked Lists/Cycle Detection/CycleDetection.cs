using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CycleDetection
{
    static bool hasCycle(SinglyLinkedListNode head)
    {
        SinglyLinkedListNode slow = head;
        SinglyLinkedListNode fast = head;
        while (fast.next != null && fast.next.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
            if (fast == slow)
            {
                return true;
            }
        }
        return false;
    }

    static void Main(string[] args)
    {
        SinglyLinkedListNode node1 = new SinglyLinkedListNode(1);
        SinglyLinkedListNode node2 = new SinglyLinkedListNode(2);
        SinglyLinkedListNode node3 = new SinglyLinkedListNode(3);
        node1.next = node2;
        node2.next = node3;
        node3.next = node2;
        Console.WriteLine(hasCycle(node1));
    }
}

class SinglyLinkedListNode
{
    int data;
    public SinglyLinkedListNode next;
    public SinglyLinkedListNode(int value)
    {
        data = value;
    }
}
