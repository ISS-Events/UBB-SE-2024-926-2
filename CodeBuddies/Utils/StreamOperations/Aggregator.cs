namespace CodeBuddies.Utils.StreamProcessors
{
    internal class Aggregator
    {
        public static int Addition(int firstTerm, int secondTerm) => firstTerm + secondTerm;
        public static string StringConcatWithSpaceBetween(string firstString, string secondString) => $"{firstString} {secondString}";
    }
}
