using BenchmarkDotNet.Attributes;
using System;

namespace Experiments
{
    public class ComparingStringsAndEnums
    {
        public enum TestEnum { Foo }
        
        [Params("Foo", "foo")]
        public string MyString { get; set; }
        
        [Params(TestEnum.Foo)]
        public TestEnum MyEnum { get; set; }

        [Benchmark]
        public void ToStringComparison() => MyEnum.ToString().Equals(MyString, StringComparison.OrdinalIgnoreCase);

        [Benchmark]
        public void CompareComparison() => string.Compare(MyEnum.ToString(), MyString, StringComparison.OrdinalIgnoreCase);
        
        [Benchmark]
        public void LowercaseComparison() => MyEnum.ToString().ToLower().Equals(MyString.ToLower());

        [Benchmark]
        public void CastComparison() => MyEnum.Equals(Enum.Parse(typeof(TestEnum), MyString, true));
    }
}
