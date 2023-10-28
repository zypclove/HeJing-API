using Blog.Domain.Model;
using Blog.HostApp.Areas.Blog.Services;
using Blog.Infrastructure;
using Blog.Shared.DTO.Comment;
using Microsoft.EntityFrameworkCore;

namespace Blog.HostApp.Areas.Blog.Controllers;

/// <summary>
/// 
/// </summary>
[Area("Blog")]
public class CommentController : AppControllerBase
{
    private readonly CommentService _service;
    private BlogDbContext _dbContext;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public CommentController(IServiceProvider serviceProvider, BlogDbContext dbContext, CommentService service) :
        base(serviceProvider)
    {
        _dbContext = dbContext;
        _service = service;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult> Create(CommentCreateInDto input)
    {
        if (ModelState.IsValid)
        {
            var comment = new Comment
            {
                Id = NewId.NextGuid(),
                Content = input.Content!,
                AuthorName = input.AuthorName!,
                PublishDate = DateTime.Now,
                ArticleId = input.ArticleId
            };

            await _dbContext.Comments.AddAsync(comment);

            await _dbContext.SaveChangesAsync();

            // 评论提交成功后的处理逻辑
            // ...

            return Success();
        }
        return Failure();
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<CommentUpdateOutDto>> Update(CommentUpdateInDto input)
    {
        var result = await _service.Update(input);
        return Success(result);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<CommentDeleteOutDto>> Delete(CommentDeleteInDto input)
    {
        var result = await _service.Delete(input);
        return Success(result);
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<PagingOut<CommentQueryOutDto>>> Query([FromQuery] CommentQueryInDto input)
    {
        var result = await _service.Query(input);
        return Success(result);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<CommentGetOutDto>> Get([FromQuery] CommentGetInDto input)
    {
        var result = await _service.Get(input);
        return Success(result);
    }
}