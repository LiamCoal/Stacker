namespace Stacker
{
    public interface IStackable
    {
        public byte[] Stack();
        public IStackable Unstack(byte[] bytes);
        public byte Size { get; }
    }
}