namespace Forum.Application.Exceptions.Topics
{
    public class TopicNotFound : Exception
    {
        public string Code = "Topic not found";
        public TopicNotFound(string message) : base(message) { }

    }
}
