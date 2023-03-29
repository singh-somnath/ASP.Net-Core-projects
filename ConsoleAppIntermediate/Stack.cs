using System;

namespace ConsoleAppIntermediate
{
    public class Stack
    {
        private Object[] _stack;
        private int length;

        public Stack()
        {
            this.length = 0;
            this._stack = new Object[this.length];
        }
        public void Push(Object _obj)
        {
            if (_obj == null)
                throw new InvalidOperationException();

            Object[] tempStack = this._stack;
            this._stack = new Object[++this.length];
            for (int i = 0; i < this._stack.Length - 1; i++)
            {
                this._stack[i] = tempStack[i];
            }
            this._stack[this.length - 1] = _obj;



        }

        public Object Pop()
        {
            if (this.length == 0)
                throw new InvalidOperationException();

            Object popValue = this._stack[--this.length];

            Object[] tempStack = this._stack;
            this._stack = new Object[this.length];
            for (int i = 0; i < this._stack.Length; i++)
            {
                this._stack[i] = tempStack[i];
            }
            return popValue;
        }
    }
}