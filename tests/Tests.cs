namespace JsonCheckerTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using NUnit.Framework;

    public class Tests
    {
        static IEnumerable<string> GetManifestResourceNames(string pattern) =>
            from name in typeof(Tests).Assembly.GetManifestResourceNames()
            where Regex.IsMatch(name, pattern)
            select name;

        [TestCaseSource(nameof(GetManifestResourceNames),
                        new object[] {@"\.fail[1-9][0-9]*\.json$"})]
        public void Fail(string name)
        {
            var e = Assert.Throws<Exception>(() => Check(name));
            Assert.That(e.Message, Does.StartWith("Invalid JSON text at character offset "));
        }

        [TestCaseSource(nameof(GetManifestResourceNames),
                        new object[] { @"\.pass[1-9][0-9]*\.json$" })]
        public void Pass(string name)
        {
            Check(name);
            Assert.Pass();
        }

        static void Check(string name, int depth = 20)
        {
            string json;

            using (var stream = typeof(Tests).Assembly.GetManifestResourceStream(name))
            using (var reader = new StreamReader(stream))
                json = reader.ReadToEnd();

            var checker = new JsonCheckerTool.JsonChecker(depth);
            foreach (var ch in json)
                checker.Check(ch);
            checker.FinalCheck();
        }
    }
}
