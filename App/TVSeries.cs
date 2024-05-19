namespace MovieAdvisor
{
    internal class TVSeries : AudiovisualContent
    {
        private String _id;
        private String _state;
        private String _finishDate;

        public String ID { get => _id; set => _id = value; }
        public String State { get => _state; set => _state = value; }
        public String FinishDate { get => _finishDate; set => _finishDate = value; }
    }
}
