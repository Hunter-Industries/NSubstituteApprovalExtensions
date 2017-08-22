# NSubstituteApprovalExtensions
Legacy Vice Testing Tool that records what happens to a NSubstitute mock and verifies it using approval tests.

When writing a test for legacy code using mocks it would take a lot of time to go back and forth to the code to userstand the order in which the mock should be set up. Rather than looking up the behavior in the code we can write a 3 line test that will take the interactions on the mock and use approval tests to vice the functionality of the target implementation.

## What we used to do:
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

## What we can do now
### Code
```csharp
        [TestMethod]
        public void TestNoPredefinedReturnValues()
        {
            var mockedDependency = Substitute.For<IDependencyInterface>();
            TheLegacyCodeToTest(mockedDependency);
            mockedDependency.VerifyNSubstituteMockBehavior();
        }
```

### Resulting Approval File
```
Recorded behavior for: IDependencyInterface
Method Name: Call1
Arguments: 


Method Name: Call2
Arguments: 
	Type: String
	Value:
		test


Method Name: Call1
Arguments: 


Method Name: Call2
Arguments: 
	Type: String
	Value:
		test0


Method Name: Call4
Arguments: 
	Type: ClassWithMultiLineToString
	Value:
		ClassWith
		MultiLine
		To
		String

```
