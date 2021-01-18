using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExample.Lib
{
    public class IntegerLinkedList
    {
        IntegerNode _head;

        public IntegerLinkedList()
        {
        }

        public IntegerLinkedList(int v)
        {
            _head = new IntegerNode(v);
        }

        public int Count {
            get
            {
                if (_head == null)
                    return 0;
                else
                    return _head.Count;
            }
        }
        public int Sum {
            get
            {
                if (_head == null)
                    return 0;
                else
                    return _head.Sum;
            }

        }

        public void Append(int v)
        {
            if (_head == null)
                _head = new IntegerNode(v);
            else
            {
                _head.Append(v);
            }

        }

        public bool Delete(int doomed)
        {
            if (_head == null)
                return false;
            if (_head.Value == doomed) {
                _head = _head.Next;
                return true;
            }
            // this will only delete the first instance of 'doomed'
            return _head.Delete(doomed);
        }
        public override string ToString()
        {
            // string interpolation - https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=net-5.0#Starting
            return $"{{{(_head == null ? string.Empty : _head.ToString())}}}";
        }

        public void RemoveDuplicates()
        {
            if (_head != null)
                _head.RemoveDuplicates();
        }

        public void Merge(IntegerLinkedList other)
        {
            if (_head == null)
            {
                _head = other._head;
                return;
            }
            if (other._head == null)
            {
                return;
            }

            _head.Zip(other._head);
        }
    }
    class IntegerNode
    {
        int _value;
        IntegerNode _next;

        public int Value { get { return _value; } }
        public IntegerNode Next { get { return _next; } private set { _next = value; } }

        public int Count
        {
            get
            {
                if (_next == null)
                    return 1;
                else
                    return 1 + _next.Count;
            }
        }

        public int Sum
        {
            get
            {
                if (_next == null)
                    return _value;
                else
                    return _value + _next.Sum;
            }
        }

        public IntegerNode(int v)
        {
            _value = v;
            _next = null;
        }

        public void Append(int v)
        {
            if (_next == null)
                _next = new IntegerNode(v);
            else
                _next.Append(v);
        }

        public override string ToString()
        {
            return _value.ToString() + (_next == null ? string.Empty : $", {_next.ToString()}");
        }

        internal bool IsPresent(int target)
        {
            if (_value == target)
                return true;
            if (_next == null)
                return false;
            return _next.IsPresent(target);
        }

        internal bool Delete(int doomed)
        {
            // the assumption is that this value is not doomed, we would have checked 
            // to see from the node that linked here 
            if (_next != null && _next.Value == doomed)
            {
                _next = _next._next;
                return true;
            }
            if (_next == null)
                return false;
            return _next.Delete(doomed);
        }

        internal void RemoveDuplicates()
        {
            // while the next node is not null AND the current value is present in the rest of the list
            // delete the next occurence of this value from the (next) node 
            while (_next != null && _next.IsPresent(_value))
                Delete(_value);
            if (_next != null)
                _next.RemoveDuplicates();
        }

        internal void Zip(IntegerNode head)
        {
            if(_next == null)
            {
                _next = head;
                return;
            }
            if (head == null)
                return;
            IntegerNode n = _next;
            IntegerNode newHead = head.Next;

            _next = head;
            head.Next = n;

            n.Zip(newHead);
        }
    }
}
