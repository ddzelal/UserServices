using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserRepository.Dto;
using UserRepository.Interfaces;
using UserRepository.Models;

namespace UserRepository.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;

        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PostCommand command)
        {

            await _postService.CreatePost(command);

            return Ok("Successfully created post!");
        }

        [HttpDelete("delete/{postId}")]
        public async Task<IActionResult> Delete(int postId)
        {
            await _postService.DelatePost(postId);

            return Ok("Successfully deleted post!");
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts(int page, int pageSize, SortOrder sortOrder)
        {
            var result = await _postService.GetPosts(page, pageSize, sortOrder);
            return Ok(result);

        }


    }
}