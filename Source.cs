using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    nodes.Add(node);
                }
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node == tail)
                    {
                        tail = node.prev;
                    } else
                    {
                        node.next.prev = node.prev;
                    }
                    
                    if (node == head)
                    {
                        head = node.next;
                        return true;
                    }
                    node.prev.next = node.next;
                    return true;
                }
                node = node.next;
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node == tail)
                    {
                        tail = node.prev;
                    } else
                    {
                        node.next.prev = node.prev;
                    }
                    
                    if (node == head)
                    {
                        if (node == tail)
                        {
                            tail = null;
                        }
                        head = node.next;

                        node = node.next;
                        continue;
                    }

                    node.prev.next = node.next;
                    node = node.next;
                    continue;
                }
                node = node.next;
            }
        }

        public void Clear()
        {
            Node node = head;
            while (node != null)
            {
                Node current = node;
                node = node.next;
                current.next = null;
                current.prev = null;
            }
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            Node node = head;
            while (node != null)
            {
                count++;
                node = node.next;
            }
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null)
            {
                _nodeToInsert.next = head;
                if (head != null)
                {
                    _nodeToInsert.next.prev = _nodeToInsert;
                }

                head = _nodeToInsert;
                if (tail == null)
                {
                    tail = _nodeToInsert;
                }
                return;
            }

            Node node = head;
            while (node != null)
            {
                if (node == _nodeAfter)
                {
                    _nodeToInsert.next = node.next;
                    _nodeToInsert.prev = node;
                    if (node == tail)
                    {
                        tail = _nodeToInsert;
                    } else
                    {
                        node.next.prev = _nodeToInsert;
                    }
                    
                    node.next = _nodeToInsert;
                    return;
                }
                node = node.next;
            }
        }
    }
}
