using System;

// Original code to improve :
/*  
    if (message is MessageA)
    {
        var messageA = message as MessageA;
        messageA?.MycustomMethodOnA();
    }
    else if (message is MessageB)
    {
        var messageB = message as MessageB;
        messageB?.MycustomMethodOnB();
        messageB?.SomeAdditionalMethodOnB();
    }
    else if (message is MessageC)
    {
        var messageC = message as MessageC;
        messageC?.MycustomMethodOnC();
    }
*/

/***********
It's possible to reduce code and repetitions by using an abstraction.

Using an interface "IMessage" that each "MessageX" implements, we can call a ".MyCustomMethod" on the abstraction without knowing its true type

It's also possible to call "SomeAdditionalMethodOnB" in the "myCustomMethod", removing the need to test the IMessage's true type.

This would depends on how and when this method is called somewhere else, but judging from this piece of code alone
nothing prevents us from calling SomeAdditionalMethodOnB from within MyCustomMethod directly
***********/

namespace TUIExercice2
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessage messageA = new MessageA();
            IMessage messageB = new MessageB();
            IMessage messageC = new MessageC();

            Tester.Test(messageA);
            Tester.Test(messageB);
            Tester.Test(messageC);

            Console.WriteLine("\nEnd...");
            Console.ReadLine();
        }
    }

    static class Tester
    {
        internal static void Test(IMessage message)
        {
            message.MyCustomMethod();
        }
    }

    interface IMessage
    {
        void MyCustomMethod();
    }

    class MessageC : IMessage
    {
        public void MyCustomMethod()
        {
            Console.WriteLine("customOnC");
        }
    }

    class MessageB : IMessage
    {
        public void MyCustomMethod()
        {
            Console.WriteLine("customOnB");
            SomeAdditionalMethodOnB();
        }

        private void SomeAdditionalMethodOnB()
        {
            Console.WriteLine("SomeAdditionalMethodOnB");
        }
    }

    class MessageA : IMessage
    {
        public void MyCustomMethod()
        {
            Console.WriteLine("customOnA");
        }
    }
}