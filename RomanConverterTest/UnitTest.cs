using RomanConverter;

namespace RomanConverterTest
{
    public class UnitTest
    {
        [Fact] 
        public void TestValidConversions()
        {
            Assert.Equal(1, Program.RomanToInt("I"));
            Assert.Equal(4, Program.RomanToInt("IV"));
            Assert.Equal(9, Program.RomanToInt("IX"));
            Assert.Equal(58, Program.RomanToInt("LVIII"));
            Assert.Equal(1994, Program.RomanToInt("MCMXCIV"));
            Assert.Equal(3549, Program.RomanToInt("MMMDXLIX"));
        }

        [Fact] 
        public void TestInvalidConversions()
        {
            Assert.Throws<ArgumentException>(() => Program.RomanValueIsWrong("IIII"));
            Assert.Throws<ArgumentException>(() => Program.RomanValueIsWrong("XXXX"));
            Assert.Throws<ArgumentException>(() => Program.RomanValueIsWrong("MMMM"));
        }

        [Fact] 
        public void TestEdgeCases()
        {
            Assert.Throws<ArgumentException>(() => Program.RomanValueIsWrong("A"));
            Assert.Throws<ArgumentException>(() => Program.RomanValueIsWrong(""));
        }
    }
}