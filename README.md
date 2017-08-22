# NSubstituteApprovalExtensions
Legacy Vice Testing Tool that records what happens to a NSubstitute mock and verifies it using approval tests.

##What we used to do:
```csharp
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
```

##What we can do now
```csharp
        [TestMethod]
        public void TestNoPredefinedReturnValues()
        {
            var mockedDependency = Substitute.For<IDependencyInterface>();
            TheLegacyCodeToTest(mockedDependency);
            mockedDependency.VerifyNSubstituteMockBehavior();
        }
```