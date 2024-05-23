using System.Data;

namespace CodeBuddies.Utils.StreamProcessors
{
    internal class StreamProcessor<InputType, OutputType>
    {
        public static IEnumerable<InputType> FilterCollection(IEnumerable<InputType> source, Func<InputType, bool> condition)
            => source.Where(condition);
        public static OutputType MapOne(IEnumerable<InputType> source, Func<InputType, OutputType> mapping)
            => mapping(source.First());
        public static IEnumerable<OutputType> MapCollection(IEnumerable<InputType> source, Func<InputType, OutputType> mapping)
            => source.Select(mapping);
        public static OutputType FilterAndMapOne(IEnumerable<InputType> source, Func<InputType, bool> condition, Func<InputType, OutputType> mapping)
            => mapping(source.Where(condition).First());
        public static IEnumerable<OutputType> FilterAndMapCollection(IEnumerable<InputType> source, Func<InputType, bool> condition, Func<InputType, OutputType> mapping)
            => source.Where(condition).Select(mapping);
    }
}
