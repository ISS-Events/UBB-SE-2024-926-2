namespace CodeBuddies.Utils.StreamProcessors
{
    internal class CollectionSummerFactory<InputType>
    {
        static public CollectionSummer<InputType> GetFromMapping(Func<InputType, int> mapping)
        {
            return new CollectionSummer<InputType>(mapping);
        }
    }
}
