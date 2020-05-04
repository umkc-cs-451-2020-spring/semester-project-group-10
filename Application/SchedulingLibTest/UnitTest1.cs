using SchedulerClient;
using NUnit.Framework;

namespace SchedulingLibTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        //Test 
        public void testNewInstructor(){

            NewInstructor obj = new NewInstructor();
            Assert.IsNotNull(instructor);
        
        }

    }

    
}