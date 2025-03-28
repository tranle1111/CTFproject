namespace CTFproject.Models
{
    public class Challenge
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DownloadLink { get; set; }
        public string Hints { get; set; }
        public int Points { get; set; }
        public string Category { get; set; }
    }
}
