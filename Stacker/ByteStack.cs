#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Stacker.Extenders;

namespace Stacker
{
    public class ByteStack
    {
        private List<IStackable> _stackables = new List<IStackable>();

        public List<IStackable> Stackables => _stackables;

        public void Add(IStackable stackable) => _stackables.Add(stackable);
        
        public byte[] Stack()
        {
            List<byte> stack = new List<byte>();
            stack.AddRange(BitConverter.GetBytes(_stackables.Count));
            _stackables.ForEach(stackable => StackAction(stackable, stack));
            return stack.ToArray();
        }

        public static ByteStack Unstack(byte[] stack)
        {
            var stream = new MemoryStream(stack);
            var len = BitConverter.ToInt32(stream.ReadBytes(sizeof(int)), 0);
            var byteStack = new ByteStack();
            for (int i = 0; i < len; i++)
            {
                UnstackAction(byteStack._stackables, stream);
            }

            return byteStack;
        }

        private static void StackAction(IStackable obj, List<byte> output)
        {
            var bytes = obj.Stack();
            output.AddRange(Encoding.UTF8.GetBytes(obj.GetType().FullName! + ';'));
            output.AddRange(bytes);
        }

        private static void UnstackAction(List<IStackable> stackables, Stream stream)
        {
            var typename = Encoding.UTF8.GetString(stream.ReadUntil((byte) ';'));
            var type = FindType(typename);
            var obj = Activator.CreateInstance(type!);
            if (obj is IStackable stackable)
            {
                stackables.Add(stackable.Unstack(stream.ReadBytes(stackable.Size)));
            } 
            else throw new InvalidDataException("Class received is not IStackable.");
        }

        internal static Type? FindType(string name) =>
            AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t => t.FullName == name);
    }
}

