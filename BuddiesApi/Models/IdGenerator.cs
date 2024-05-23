namespace CodeBuddies.Utils
{
    internal class IDGenerator
    {
        private static readonly byte BYTE_SIZE = 8;
        private static readonly Random Generator = new ();
        public static long RandomLong()
        {
            int prefix = Generator.Next();
            int suffix = Generator.Next();
            return (((long)prefix) << (BYTE_SIZE * sizeof(int))) + suffix;
        }
        public static long Default() => 0L;
    }
}
