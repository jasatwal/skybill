namespace Sky
{
    public class SkyStoreMovie
    {
        private readonly string title;

        public string Title
        {
            get { return title; }
        }

        public SkyStoreMovie(string title)
        {
            Check.Argument.IsNotNull(title, nameof(title));

            this.title = title;
        }
    }
}
