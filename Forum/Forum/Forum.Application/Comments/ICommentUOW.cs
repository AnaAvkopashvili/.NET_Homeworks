using Forum.Application.Accounts;
using Forum.Application.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Comments
{
    public interface ICommentUOW : IUnitofWork
    {
        public ICommentRepository Comments { get; }
        public ITopicRepository Topics { get; }
        public ICurrentUserService CurrentUserService { get; }
    }
}
