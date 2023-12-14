using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRepository.Models;

namespace UserRepository.Interfaces
{
    public interface IPostRepository
    {
        public Task Add(Post post);

    }
}