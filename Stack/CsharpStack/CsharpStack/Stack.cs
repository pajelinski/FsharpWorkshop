namespace CsharpStack
{
    internal class Stack : MyStack
    {
        private readonly int[] _array;
        private int _index;

        internal Stack(int size)
        {
            _array = new int[size];
            Size = size;
            _index = -1;
        }

        public override int Size { get; }

        public override void Push(int value)
        {
            ThrowIfStackIsOverflowed();

            _index++;
            _array[_index] = value;
        }

        public override int Pop()
        {
            ThrowIfStackIsUnderfowled();

            var value = _array[_index];
            _index--;
            return value;
        }

        private void ThrowIfStackIsOverflowed()
        {
            if (IsStackOverflowed()) throw new MyStackOverflowException();
        }

        private bool IsStackOverflowed() => _index >= Size - 1;

        private void ThrowIfStackIsUnderfowled()
        {
            if (IsStackUnderflowed()) throw new MyStackUnderflowException();
        }

        private bool IsStackUnderflowed() => _index <= -1;
    }
}