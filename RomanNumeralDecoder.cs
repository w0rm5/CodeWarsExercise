namespace CodeWarsExercise
{
    public class RomanNumeralDecoder
    {
        private static Dictionary<char, int> RomanNumbers = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        public static bool TryDecodeRomanNumber(string romanNum, out int sum)
        {
            sum = 0;
            bool alreadyMinus = false;
            for (int i = romanNum.Length - 1; i >= 0; i--)
            {
                if (!RomanNumbers.TryGetValue(romanNum[i], out int val))
                {
                    sum = 0;
                    return false;
                }
                int prev;
                if (i - 1 >= 0)
                {
                    if (!RomanNumbers.TryGetValue(romanNum[i - 1], out prev))
                    {
                        sum = 0;
                        return false;
                    }
                }
                else
                {
                    prev = 0;
                }
                sum += val;
                if (prev < val)
                {
                    if (alreadyMinus)
                    {
                        sum = 0;
                        return false;
                    }
                    alreadyMinus = true;
                    sum -= prev * 2;
                }
                else if(prev == val && alreadyMinus)
                {
                    sum = 0;
                    return false;
                }
                else
                {
                    alreadyMinus = false;
                }
            }
            return true;
        }
    }
}