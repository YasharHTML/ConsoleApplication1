using System;

namespace ConsoleApplication1.Testing
{
    public class CSharpTestingModule
    {
        private int _testIndex = 0;
        private int _passedTests = 0;
        private int _failedTests = 0;

        private int _passedTestsLocal;
        private int _failedTestsLocal;

        private string _testTitle;

        private void passed()
        {
            _passedTests++;
            _passedTestsLocal++;
        }

        private void failed()
        {
            _failedTests++;
            _failedTestsLocal++;
        }

        public void StartTest(string testName)
        {
            _testIndex = 0;
            _passedTestsLocal = 0;
            _failedTestsLocal = 0;
            _testTitle = testName;
            Console.WriteLine("------- Starting " + _testTitle + " Tests -------");
        }

        public void EndTest()
        {
            Console.WriteLine($"{_passedTestsLocal}/{_passedTestsLocal + _failedTestsLocal} successful.");   
            Console.WriteLine("------- Ending " + _testTitle + " Tests -------");
        }

        public string AssertEqual(object a, object b)
        {
            if (a.Equals(b))
            {
                passed();
                return $"Test id: {_testIndex++}\n{nameof(a)}: {a} is equal to {nameof(b)}: {b} PASSED\n";
            }
            failed();
            return $"Test id: {_testIndex++}\n{nameof(a)}: {a} is not equal to {nameof(b)}: {b} FAILED\n";
        }

        public string AssertGreater(IComparable a, IComparable b)
        {
            if (a.CompareTo(b) > 0)
            {
                passed();
                return $"Test id: {_testIndex++}\n{nameof(a)}: {a} is greater to {nameof(b)}: {b} PASSED\n";
            }
            failed();
            return $"Test id: {_testIndex++}\n{nameof(a)}: {a} is not greater to {nameof(b)}: {b} FAILED\n";
        }
        
        public string AssertLesser(IComparable a, IComparable b)
        {
            if (a.CompareTo(b) < 0)
            {
                passed();
                return $"Test id: {_testIndex++}\n{nameof(a)}: {a} is lesser to {nameof(b)}: {b} PASSED\n";
            }
            failed();
            return $"Test id: {_testIndex++}\n{nameof(a)}: {a} is not lesser to {nameof(b)}: {b} FAILED\n";
        }

        public void DebugPrint(object obj)
        {
            Console.WriteLine($"DebugPrint -> Test ID: {_testIndex}:\n" + obj);
        }

        public string ShowResult()
        {
            return $"{_passedTests}/{_failedTests + _passedTests} successful.";
        }
    }
}