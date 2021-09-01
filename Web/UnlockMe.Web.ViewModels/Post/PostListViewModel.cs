namespace UnlockMe.Web.ViewModels.Post
{
    using System;
    using System.Collections.Generic;

    public class PostListViewModel
    {
        public IEnumerable<PostInListViewModel> Posts { get; set; }

        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.PostsCount / this.PostsPerPage);

        public int PostsCount { get; set; }

        public int PostsPerPage { get; set; }
    }
}
