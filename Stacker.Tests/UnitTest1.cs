#nullable enable
using System;
using System.IO;
using NUnit.Framework;
using Stacker.GenericTypes;

namespace Stacker.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestStackerManagerEmpty()
        {
            var byteStack = new ByteStack();
            Assert.AreEqual(byteStack.Stack(), BitConverter.GetBytes(0));
            Assert.Pass();
        }

        [Test] public void TestStackerManagerEmptyStackable() => TestStackable<EmptyStackable>();
        [Test] public void TestStackerManagerMultiEmptyStackable() => TestStackable<EmptyStackable>(5);

        public static void TestStackable<T>(int count = 1)
        where T : IStackable, new()
        {
            var byteStack = new ByteStack();
            for (int i = 0; i < count; i++) byteStack.Add(new T());
            var stack = byteStack.Stack();
            Assert.AreEqual(ByteStack.Unstack(stack).Stackables[0].GetType(), typeof(T));
            Console.WriteLine();
            Assert.Pass();
        }
        
        private class EmptyStackable : IStackable
        {
            public byte[] Stack() => new byte[0];
            public IStackable Unstack(byte[] bytes) => new EmptyStackable();
            public byte Size => 0;
        }
    }
}