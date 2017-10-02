namespace CsharpStack
{
    public abstract class MyStack
    {
        public static MyStack Create(int size)
        {
            ThrowIfSizeIsNegative(size);

            return IsSIzeEqualToZero(size) 
                ? (MyStack) new ZeroStack() 
                : new Stack(size);
        }


        public abstract int Size { get; }
        public abstract void Push(int value);
        public abstract int Pop();
        
        private static bool IsSIzeEqualToZero(int size) => size == 0;

        private static void ThrowIfSizeIsNegative(int size)
        {
            if (IsSizeNegative(size))
            {
                throw new MyStackNegativeSizeException();
            }
        }

        private static bool IsSizeNegative(int size) => size < 0;
    }
}