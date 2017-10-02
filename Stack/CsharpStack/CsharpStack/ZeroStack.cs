namespace CsharpStack
{
    internal class ZeroStack : MyStack
    {
        public override int Size => 0;
        public override void Push(int value)
        {
            throw new MyStackOverflowException();
        }

        public override int Pop()
        {
            throw new MyStackUnderflowException();
        }
    }
}