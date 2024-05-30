namespace MovieAdvisor
{
    internal class Episode
    {
        private String _seriesID;
        private String _seasonID;
        private String _number;
        private String _runtime;
        private String _synopsis;

        public String SeriesID { get => _seriesID; set => _seriesID = value; }
        public String SeasonID { get => _seasonID; set => _seasonID = value; }
        public String Number { get => _number; set => _number = value; }
        public String Runtime { get => _runtime; set => _runtime = value; }
        public String Synopsis { get => _synopsis; set => _synopsis = value; }

        public override string ToString()
        {
            return "Episode " + Number;
        }
    }
}
