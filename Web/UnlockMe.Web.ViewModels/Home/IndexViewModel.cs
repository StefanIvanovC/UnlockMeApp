namespace UnlockMe.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexPageRandomPostsViewModel> RandomPosts { get; set; }

        public int PostCount { get; set; }

        public int PicturesCount { get; set; }

        public int UsersCount { get; set; }
    }
}
