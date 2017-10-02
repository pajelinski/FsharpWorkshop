using System.Collections.Generic;
using NUnit.Framework;

namespace CsharpStack.Test
{
    [TestFixture]
    public class MyStackTests
    {
        [Test]
        public void GivenCapacity_1_ShouldCreateStackWithLength_1()
        {
            const int expectedLength = 1;
            var myStack = MyStack.Create(expectedLength);

            Assert.That(myStack.Size, Is.EqualTo(expectedLength));
        }

        [Test]
        public void WhenPushed_1_2_PopShouldReturn_2_1()
        {
            var myStack = MyStack.Create(2);

            myStack.Push(1);
            myStack.Push(2);

            Assert.That(myStack.Pop(), Is.EqualTo(2));
            Assert.That(myStack.Pop(), Is.EqualTo(1));
        }

        [Test]
        public void WhenPushed_1_PopShouldReturn_1()
        {
            var myStack = MyStack.Create(1);

            myStack.Push(1);
            var result = myStack.Pop();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GivenSize_1_Stack_WhenPushedTwiceShouldThrowMyStackOverflowException()
        {
            var myStack = MyStack.Create(1);

            myStack.Push(1);

            Assert.That(() => myStack.Push(1), Throws.TypeOf<MyStackOverflowException>());
        }

        [Test]
        public void GivenEmptyStack_PopShouldThrowMyStackUnderflowException()
        {
            Assert.That(() => MyStack.Create(1).Pop(), Throws.TypeOf<MyStackUnderflowException>());
        }

        [Test]
        public void GivenZeroStack_PushShouldThrowMyStackOverflowException()
        {
            Assert.That(() => MyStack.Create(0).Push(1), Throws.TypeOf<MyStackOverflowException>());
        }
        
        [Test]
        public void GivenZeroStack_PopShouldThrowMyStackUnderflowException()
        {
            Assert.That(() => MyStack.Create(0).Push(1), Throws.TypeOf<MyStackOverflowException>());
        }
        
        [Test]
        public void GivenNegativeSize_ConstructorShouldThrowMyStackUnderflowException()
        {
            Assert.That(() => MyStack.Create(-1), Throws.TypeOf<MyStackNegativeSizeException>());
        }
    }
}