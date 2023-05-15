using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class Hash
    {
        public int key;
        public Hash next;

        public Hash(int key)
        {
            this.key = key;
            this.next = null;
        }
    }
    public class MyHashSet
    {
        public Hash head;
        public MyHashSet()
        {
            this.head = null;
        }

        public void Add(int key)
        {
            Hash node = new Hash(key);
            if (this.head == null)
            {
                this.head = node;
            }
            else
            {

                Hash currentNode = this.head;
                Hash previousNode = null;
                bool keyPresent = false;
                while (currentNode != null)
                {
                    if (currentNode.key == key)
                    {
                        keyPresent = true;
                        break;
                    }
                    previousNode = currentNode;
                    currentNode = currentNode.next;
                }

                if (!keyPresent)
                {
                    previousNode.next = node;
                }

            }

        }
        public void Remove(int key)
        {
            if (this.head != null)
            {
                if (this.head.key == key)
                {
                    if(this.head.next == null) {
                        this.head = null;
                    }
                    else
                    {
                        this.head = this.head.next;
                    }
                  
                }
                else
                {
                    Hash currentNode = this.head;
                    Hash previousNode = null;
                    bool keyPresent = false;
                    while (currentNode != null)
                    {
                        
                        if (currentNode.key == key)
                        {
                            keyPresent = true;
                            break;
                        }
                        previousNode = currentNode;
                        currentNode = currentNode.next;
                    }
                    if (keyPresent)
                    {
                        previousNode.next = currentNode.next;
                    }
                }
            }
        }

        public bool Contains(int key)
        {
            Hash currentNode = this.head;
            bool keyPresent = false;
            while (currentNode != null)
            {
                if (currentNode.key == key)
                {
                    keyPresent = true;
                    break;
                }
                currentNode = currentNode.next;
            }
            return keyPresent;
        }
    }

    /**
     * Your MyHashSet object will be instantiated and called as such:
     * MyHashSet obj = new MyHashSet();
     * obj.Add(key);
     * obj.Remove(key);
     * bool param_3 = obj.Contains(key);
     */
}
