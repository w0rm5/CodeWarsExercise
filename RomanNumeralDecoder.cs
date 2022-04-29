namespace CodeWarsExercise
{
    public class RomanNumeralDecoder
    {
        private static readonly Dictionary<char, int> RomanNumbers = new()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        private static readonly Dictionary<int, int> NumberOrders = new()
        {
            { 1, 1 },
            { 5, 2 },
            { 10, 2 },
            { 50, 3 },
            { 100, 4 },
            { 500, 5 },
            { 1000, 6 },
        };

        public static bool TryDecodeRomanNumber(string romanNum, out int sum)
        {
            sum = 0;
            if (string.IsNullOrEmpty(romanNum))
            {
                return false;
            }
            int sameOccurrence = 1;
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
                    else
                    {
                        if (prev == val)
                        {
                            if (sameOccurrence >= 3)
                            {
                                sum = 0;
                                return false;
                            }
                            else
                            {
                                sameOccurrence++;
                            }
                        }
                        else
                        {
                            sameOccurrence = 1;
                        }
                    }
                }
                else
                {
                    prev = 0;
                }
                sum += val;
                if (prev < val)
                {
                    if (prev != 0 && (alreadyMinus || (NumberOrders[val] - NumberOrders[prev] != 1)))
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