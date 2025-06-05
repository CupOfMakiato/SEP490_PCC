using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface ITagService
    {
        // view
        Task<Result<List<ViewTagDTO>>> ViewAllTags();
        Task<Result<ViewTagDTO>> ViewTagById(Guid tagId);
        // add
        Task<Result<object>> AddNewTag(AddTagDTO addTagDTO);
    }
}
