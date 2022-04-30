namespace CodeWarsExercise
{
    public class RomanNumeralDecoder
    {
        private readonly Dictionary<char, int> RomanNumbers = new()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        private readonly Dictionary<int, int> NumberOrders = new()
        {
            { 1, 1 },
            { 5, 2 },
            { 10, 2 },
            { 50, 3 },
            { 100, 3 },
            { 500, 4 },
            { 1000, 4 },
        };

        private readonly Dictionary<int, bool> Repeatables = new()
        {
            { 1, true },
            { 5, false },
            { 10, true },
            { 50, false },
            { 100, true },
            { 500, false },
            { 1000, true },
        };
        
        private readonly Dictionary<int, bool> Subtractables = new()
        {
            { 1, true },
            { 5, false },
            { 10, true },
            { 50, false },
            { 100, true },
            { 500, false },
            { 1000, false },
        };

        public bool TryDecodeRomanNumber(string romanNum, out int sum)
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
                            if (!Repeatables[prev] || sameOccurrence >= 3)
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
                    if (prev != 0 && (alreadyMinus || !Subtractables[prev] ||  (NumberOrders[val] - NumberOrders[prev] != 1)))
                    {
                        sum = 0;
                        return false;
                    }
                    alreadyMinus = true;
                    sum -= prev * 2;
                }
                else if (prev == val && alreadyMinus)
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