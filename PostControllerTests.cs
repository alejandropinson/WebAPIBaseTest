using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebAPIBase.Controllers;
using WebAPIBase.Models;
using Xunit;
using Moq;
using WebAPIBase.Services.PostService;

namespace WebAPIBaseTests
{
    public class PostControllerTest
    {
        // [Fact]
        // public void Check_GetAllPost_Type()
        // {
        //     BlogPostController postController = new BlogPostController();
        //     var posts = postController.GetAllPosts();
        //     Assert.IsType<OkObjectResult>(posts);
        // }


        [Fact]
        public void Check_GetById_Type()
        {
            var mockService = new Mock<IPostService>();
            var fakePost = new Post { Id = 1, Title = "Harry El Sucio Potter", Author = "Sergio", Content = "Wateva" };
            mockService.Setup(serv => serv.GetOne(1)).Returns(fakePost);
            BlogPostController SUT = new BlogPostController(mockService.Object);

            var getResult = (OkObjectResult)SUT.GetById(1);

            Post expected = new Post { Id = 1, Title = "Harry El Sucio Potter", Author = "Sergio", Content = "Wateva" };
            getResult.Value.Should().BeEquivalentTo(expected);
        }

        // [Fact]
        // public void Check_InsertNewPost()
        // {
        //     BlogPostController postController = new BlogPostController();
        //     var newPost = postController.InsertNewPost(
        //         new Post { Title = "Third Post", Author = "Diego", Content = "Third Post by Diego" }
        //         );
        //     Assert.IsType<OkObjectResult>(newPost);
        // }

        // [Fact]
        // public void Check_UpdatePost_Type()
        // {
        //     BlogPostController postController = new BlogPostController();
        //     var updatedPost = new Post
        //     {
        //         Id = 1,
        //         Title = "Updated Post",
        //         Author = "Alejandro Recio",
        //         Content = "Updated Content"
        //     };
        //     var post = postController.Put(updatedPost);
        //     Assert.IsType<OkObjectResult>(post);
        // }
    }
}


// [HttpPut]
//         public IActionResult Update([FromRoute] long id, [FromBody] Post updatedPost)
//         {
//             foreach (Post post in this.posts)
//             {
//                 if(post.Id == updatedPost.Id){
//                     post.Title = updatedPost.Title;
//                     post.Author = updatedPost.Author;
//                     post.Content = updatedPost.Content;
//                     return Ok(post);
//                 }
//             }
//             return NoContent();
//         }