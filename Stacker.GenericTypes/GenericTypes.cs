using System;

namespace Stacker.GenericTypes
{
    public class StackableInt : IStackable
    {
        public StackableInt() : this(0) {}
        public StackableInt(int value) => Value = value;
        public int Value { get; }
        public byte[] Stack() => BitConverter.GetBytes(Value);
        public IStackable Unstack(byte[] bytes) => new StackableInt(BitConverter.ToInt32(bytes));
        public byte Size => sizeof(int);
    }
    
    public class StackableShort : IStackable
    {
        public StackableShort() : this(0) {}
        public StackableShort(short value) => Value = value;
        public short Value { get; }
        public byte[] Stack() => BitConverter.GetBytes(Value);
        public IStackable Unstack(byte[] bytes) => new StackableShort(BitConverter.ToInt16(bytes));
        public byte Size => sizeof(short);
    }
    
    public class StackableLong : IStackable
    {
        public StackableLong() : this(0) {}
        public StackableLong(long value) => Value = value;
        public long Value { get; }
        public byte[] Stack() => BitConverter.GetBytes(Value);
        public IStackable Unstack(byte[] bytes) => new StackableLong(BitConverter.ToInt64(bytes));
        public byte Size => sizeof(long);
    }
    
    public class StackableByte : IStackable
    {
        public StackableByte() : this(0) {}
        public StackableByte(byte value) => Value = value;
        public byte Value { get; }
        public byte[] Stack() => new []{Value};
        public IStackable Unstack(byte[] bytes) => new StackableByte(bytes[0]);
        public byte Size => sizeof(byte);
    }
}