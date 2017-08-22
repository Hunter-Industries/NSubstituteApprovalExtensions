using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstituteApprovalsExtetensions;

namespace NSubstituteApprovalExtetensionsTests
{

    [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class NSubstituteApprovalsExtensionsTests
    {

        [TestMethod]
        public void TestDefinedReturnValue()
        {
            var mockedDependency = Substitute.For<IDependencyInterface>();
            mockedDependency.Call1().Returns(10);

            TheLegacyCodeToTest(mockedDependency);

            mockedDependency.VerifyNSubstituteMockBehavior();
        }


        [TestMethod]
        public void TestNoPredefinedReturnValues()
        {
            var mockedDependency = Substitute.For<IDependencyInterface>();

            TheLegacyCodeToTest(mockedDependency);

            mockedDependency.VerifyNSubstituteMockBehavior();
        }

        [TestMethod]
        public void TestExampleOfWhatIUsedToDo()
        {
            var mockedDependency = Substitute.For<IDependencyInterface>();
            mockedDependency.Call1().Returns(10);

            TheLegacyCodeToTest(mockedDependency);

            Received.InOrder(() => {
                mockedDependency.Call1();
                mockedDependency.Call2("test");
                mockedDependency.Call1();
                mockedDependency.Call3("some more arguments", 4);
            });

            mockedDependency.DidNotReceive().NeverCalled();
        }

        private static void TheLegacyCodeToTest(IDependencyInterface legacyDependency)
        {
            var result = legacyDependency.Call1();
            legacyDependency.Call2("test");
            legacyDependency.Call1();
            legacyDependency.Call2("test" + result);

            if (result > 4)
                legacyDependency.Call3("some more arguments", 4);
            else
                legacyDependency.Call4(new ClassWithMultiLineToString());
        }
    }
}