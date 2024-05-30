namespace MovieAdvisor
{
    internal class Watchlist
    {
        private String _title;
        private String _userID;
        private String _visibility;

        public String Title { get => _title; set => _title = value; }
        public String UserID { get => _userID; set => _userID = value; }
        public String Visibility { get => _visibility; set => _visibility = value; }

        public override string ToString()
        {
            return _title;
        }
    }
}
