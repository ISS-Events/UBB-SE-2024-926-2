namespace CodeBuddies.Utils.StreamProcessors
{
    internal class CollectionSummer<InputType>
    {
        private readonly CollectionReducer<InputType, int> reducer;
        internal Func<IEnumerable<InputType>, int> ApplyTo;
        internal CollectionSummer(Func<InputType, int> mapper)
        {
            reducer = new (
                mapper: mapper,
                folder: Aggregator.Addition,
                defaultResult: 0);
            ApplyTo = (list) => reducer.MapThenFold(list);
        }
    }
}
