namespace MovieAdvisor
{
    internal class Season
    {
        private String _id;
        private String _number;
        private String _photo;
        private String _trailerURL;
        private String _releaseDate;

        public String ID { get => _id; set => _id = value; }
        public String Number { get => _number; set => _number = value; }
        public String Photo { get => _photo; set => _photo = value; }
        public String TrailerURL { get => _trailerURL; set => _trailerURL = value; }
        public String ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
    }
}
