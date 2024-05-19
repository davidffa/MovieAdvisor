namespace MovieAdvisor
{
    internal class Movie
    {
        private String _id;
        private String _runtime;

        public String Id { get => _id; set => _id = value; }
        public String Runtime { get => _runtime; set => _runtime = value; }
    }
}
