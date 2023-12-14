using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserRepository.Dto;
using UserRepository.Interfaces;

namespace UserRepository.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;

        }
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PostCommand command)
        {

            await _postService.CreatePost(command);

            return Ok("Successfully created post!");
        }

    }
}