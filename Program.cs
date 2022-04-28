using CodeWarsExercise;

if (RomanNumeralDecoder.TryDecodeRomanNumber("MCMXCIX", out int num))
{
    Console.WriteLine(num);
}
else
{
    Console.WriteLine("Invalid format");
}