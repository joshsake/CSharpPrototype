using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

// Joshua Esquivel
// This is where we can directly test any of the reusable methods, test methods,
// and anything else that is relevant.

namespace AutomationPrototype.Tests
{
    class StubTest
    {
        [Test]
        public void StubTestMethod()
        {
            Console.WriteLine("This is a stub test method");
        }
    }

    class secondStubTest{
        [Test]
        public void SecondStubTestMethod()
        {
            for (int i = 0; i< 10; i++) {
                Console.WriteLine("This is the second stub test method " + i);
            }
        }
    }
}
