using System;
using System.Linq;
using ApprovalTests;
using NSubstitute;

namespace NSubstituteApprovalsExtetensions
{
    public static class MockRecorderExtensions
    {
        public static void VerifyNSubstituteMockBehavior(this object nSubstituteMock)
        {
            string resultString = nSubstituteMock.GetNSubstituteRecievedCallsAsString();
            Approvals.Verify(resultString);
        }

        private static string GetNSubstituteRecievedCallsAsString(this object nSubstituteMock)
        {
            var resultString = "Recorded behavior for: " + nSubstituteMock.GetType().Name.Replace("Proxy", "") + Environment.NewLine;
            foreach (var receivedCall in nSubstituteMock.ReceivedCalls())
            {
                resultString += "Method Name: " + receivedCall.GetMethodInfo().Name + Environment.NewLine;
                resultString += "Arguments: " + receivedCall.GetArguments().Aggregate("\n", GetAggregatedArgumentsString).TrimEnd('\n') + Environment.NewLine;
                resultString += Environment.NewLine;
                resultString += Environment.NewLine;
            }

            return resultString;
        }

        private static string GetAggregatedArgumentsString(string predicate, object nextValue)
        {
            return predicate + "\tType: " + nextValue.GetType().Name + "\n\tValue:\n\t\t" + nextValue.ToString().Replace("\n", "\n\t\t") + "\n\n";
        }
    }
}