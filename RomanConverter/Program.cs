using System.Text.RegularExpressions;

namespace RomanConverter
{
    public class Program
    {
        public static int RomanToInt(string romanValue)
        {
            Dictionary<char, int> romanValues = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            int total = 0;
            int prevValue = 0;

            for (int i = romanValue.Length - 1; i >= 0; i--)
            {
                char currentChar = romanValue.ToUpper()[i];
                int currentValue = romanValues[currentChar];

                if (currentValue < prevValue)
                {
                    total -= currentValue;
                }
                else
                {
                    total += currentValue;
                }

                prevValue = currentValue;
            }

            return total;
        }

        public static void RomanValueIsWrong(string romanValue)
        {
            if (!Regex.IsMatch(romanValue, "^[IVXLCDM]+$", RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Le chiffre romain contient des caractères invalides.");
            }

            if (Regex.IsMatch(romanValue, "IIII|XXXX|CCCC|MMMM"))
            {
                throw new ArgumentException("Le chiffre romain ne peut pas contenir plus de trois répétitions consécutives.");
            }

            if (Regex.IsMatch(romanValue, "(I{4,}|V{2,}|X{4,}|L{2,}|C{4,}|D{2,}|M{4,})"))
            {
                throw new ArgumentException("Le chiffre romain ne peut pas contenir des séquences répétées non valides.");
            }

            if (Regex.IsMatch(romanValue, "I[^IV]|V[^IX]|X[^XL]|L[^XC]|C[^CD]|D[^CM]|M[^M]"))
            {
                throw new ArgumentException("Le chiffre romain contient des séquences invalides.");
            }
        }
    }
}