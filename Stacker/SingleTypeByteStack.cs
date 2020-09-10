using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Stacker.Extenders;
using static Stacker.ByteStack;

namespace Stacker
{
    public class SingleTypeByteStack<T>
    where T : class, IStackable, new()
    {
        private List<T> _stackables = new List<T>();
        public List<T> Stackables => _stackables;
        public void Add(T stackable) => _stackables.Add(stackable);
        
        public byte[] Stack()
        {
            List<byte> stack = new List<byte>();
            stack.AddRange(BitConverter.GetBytes(_stackables.Count));
            _stackables.ForEach(stackable => StackAction(stackable, stack));
            return stack.ToArray();
        }

        public static SingleTypeByteStack<T> Unstack(byte[] stack)
        {
            var stream = new MemoryStream(stack);
            var len = BitConverter.ToInt32(stream.ReadBytes(sizeof(int)), 0);
            var byteStack = new SingleTypeByteStack<T>();
            for (int i = 0; i < len; i++)
            {
                UnstackAction(byteStack._stackables, stream);
            }

            return byteStack;
        }

        private static void StackAction(T obj, List<byte> output)
        {
            var bytes = obj.Stack();
            output.AddRange(bytes);
        }

        private static void UnstackAction(List<T> stackables, Stream stream)
        {
            var obj = new T();
            stackables.Add(obj.Unstack(stream.ReadBytes(obj.Size)) as T);
        }
    }
}