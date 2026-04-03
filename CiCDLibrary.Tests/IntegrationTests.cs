using Xunit;
using System;
using System.Collections.Generic;
using CICDLibrary;

namespace CiCDLibrary.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void WorkTimeSpan_WithValidInput_ReturnsPlusAndMinusTimeSpan()
        {
            var input = new Queue<string>(new[] { "2", "30", "0" });
            var output = new List<string>();

            Class1.WorkTimeSpanForTest(
                readLine: () => input.Dequeue(),
                writeLine: (msg) => output.Add(msg)
            );

            Assert.Contains("+ TimeSpan", output);
            Assert.Contains("- TimeSpan", output);
        }

        [Fact]
        public void WorkTimeSpan_WithInvalidInput_ShowsErrorMessage()
        {
            var input = new Queue<string>(new[] { "abc", "def", "ghi" });
            var output = new List<string>();

            Class1.WorkTimeSpanForTest(
                readLine: () => input.Dequeue(),
                writeLine: (msg) => output.Add(msg)
            );

            Assert.Contains("Вы ввели не целое число или вообще не число", output);
        }

        [Fact]
        public void WorkTimeSpan_WithNegativeValues_StillWorks()
        {
            var input = new Queue<string>(new[] { "-5", "-10", "-30" });
            var output = new List<string>();

            Class1.WorkTimeSpanForTest(
                readLine: () => input.Dequeue(),
                writeLine: (msg) => output.Add(msg)
            );

            Assert.Contains("+ TimeSpan", output);
            Assert.Contains("- TimeSpan", output);
        }

        [Fact]
        public void WorkTimeSpan_WithZeroValues_WorksCorrectly()
        {
            var input = new Queue<string>(new[] { "0", "0", "0" });
            var output = new List<string>();

            Class1.WorkTimeSpanForTest(
                readLine: () => input.Dequeue(),
                writeLine: (msg) => output.Add(msg)
            );

            Assert.Contains("+ TimeSpan", output);
            Assert.Contains("- TimeSpan", output);
        }

        

        [Fact]
        public void DateDirthday_WithValidDate_ReturnsCorrectAge()
        {
            var today = DateTime.Today;
            int year = today.Year - 25;
            int month = today.Month;
            int day = today.Day;

            var input = new Queue<string>(new[] { year.ToString(), month.ToString(), day.ToString() });
            var output = new List<string>();

            Class1.DateDirthdayForTest(
                readLine: () => input.Dequeue(),
                writeLine: (msg) => output.Add(msg)
            );

            Assert.Contains("25 лет", output[output.Count - 1]);
        }

        [Fact]
        public void DateDirthday_WithInvalidYear_ShowsErrorMessage()
        {
            var input = new Queue<string>(new[] { "abcd", "5", "15" });
            var output = new List<string>();

            Class1.DateDirthdayForTest(
                readLine: () => input.Dequeue(),
                writeLine: (msg) => output.Add(msg)
            );

            Assert.Contains("не целое число", output[output.Count - 1]);
        }

        [Fact]
        public void DateDirthday_WithYearBefore1900_ShowsErrorMessage()
        {
            var input = new Queue<string>(new[] { "1800", "5", "15" });
            var output = new List<string>();

            Class1.DateDirthdayForTest(
                readLine: () => input.Dequeue(),
                writeLine: (msg) => output.Add(msg)
            );

            Assert.Contains("некорректны", output[output.Count - 1]);
        }

        [Fact]
        public void DateDirthday_WithFutureDate_ShowsErrorMessage()
        {
            var futureYear = DateTime.Today.Year + 10;
            var input = new Queue<string>(new[] { futureYear.ToString(), "1", "1" });
            var output = new List<string>();

            Class1.DateDirthdayForTest(
                readLine: () => input.Dequeue(),
                writeLine: (msg) => output.Add(msg)
            );

            Assert.Contains("некорректны", output[output.Count - 1]);
        }

        [Fact]
        public void DateDirthday_WithInvalidMonth_ShowsErrorMessage()
        {
            var input = new Queue<string>(new[] { "2000", "13", "15" });
            var output = new List<string>();

            Class1.DateDirthdayForTest(
                readLine: () => input.Dequeue(),
                writeLine: (msg) => output.Add(msg)
            );

            Assert.Contains("некорректны", output[output.Count - 1]);
        }

        [Fact]
        public void DateDirthday_WithLeapDay_CalculatesCorrectly()
        {
            var input = new Queue<string>(new[] { "2000", "2", "29" });
            var output = new List<string>();

            Class1.DateDirthdayForTest(
                readLine: () => input.Dequeue(),
                writeLine: (msg) => output.Add(msg)
            );

            Assert.Contains("лет", output[output.Count - 1]);
        }
    }
}
