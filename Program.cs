using CodeWarsExercise;

if (RomanNumeralDecoder.TryDecodeRomanNumber("MCMXCIV", out int num))
{
    Console.WriteLine(num);
}
else
{
    Console.WriteLine("Invalid format");
}