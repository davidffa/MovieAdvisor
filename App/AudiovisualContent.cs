namespace MovieAdvisor
{
    internal class AudiovisualContent
    {
        private String _id;
        private String _title;
        private String _synopsis;
        private String _popularity;
        private String _trailerURL;
        private String _budget;
        private String _revenue;
        private String _photo;
        private String _ageRate;
        private String _releaseDate;

        public String ID { get => _id; set => _id = value; }
        public String Title { get => _title; set => _title = value; }
        public String Synopsis { get => _synopsis; set => _synopsis = value; }
        public String Popularity { get => _popularity; set => _popularity = value; }
        public String TrailerURL { get => _trailerURL; set => _trailerURL = value; }
        public String Budget { get => _budget; set => _budget = value; }
        public String Revenue { get => _revenue; set => _revenue = value; }
        public String Photo { get => _photo; set => _photo = value; }
        public String AgeRate { get => _ageRate; set => _ageRate = value; }
        public String ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
    }
}
