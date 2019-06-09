using Blog.Infrastructure;
using System;
using Xunit;

namespace BlogTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var postsRepository = new PostsRepository();

            postsRepository.GetPosts();
        }
    }
}
