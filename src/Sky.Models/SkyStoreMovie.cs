using System.Collections.Generic;

namespace Sky
{
    public class SkyStoreMovie : ValueObject
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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return title;
        }
    }
}
