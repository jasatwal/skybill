using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sky
{
    [TestClass]
    public class SkyStoreMovieTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullTitleArg_ShouldFail()
        {
            new SkyStoreMovie(null);
        }
    }
}