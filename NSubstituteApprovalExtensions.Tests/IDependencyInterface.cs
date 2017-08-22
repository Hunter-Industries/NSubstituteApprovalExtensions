
using NSubstituteApprovalExtetensionsTests;

namespace NSubstituteApprovalsExtetensions
{
    public interface IDependencyInterface
    {
        int Call1();
        void Call2(string stuff);
        void Call3(string input1, int input2);
        void Call4(ClassWithMultiLineToString classWithMultiLineToString);
        void NeverCalled();
    }
}