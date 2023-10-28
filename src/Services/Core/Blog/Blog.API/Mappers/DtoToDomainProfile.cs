using AutoMapper;
using Blog.Domain.Model;
using Blog.Shared.DTO.Article;
using Blog.Shared.DTO.Category;
using Blog.Shared.DTO.Comment;
using Blog.Shared.DTO.User;

namespace Blog.API.Mappers;

/// <summary>
/// 
/// </summary>
public class DtoToDomainProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public DtoToDomainProfile()
    {
        #region TodoItem
        CreateMap<UserRegisterInDto, User>();
        CreateMap<ArticleCreateInDto, Article>();
        CreateMap<Article, ArticleQueryOutDto>();
        CreateMap<Article, ArticleGetOutDto>();
        CreateMap<Comment, CommentGetOutDto>();
        CreateMap<CategoryCreateInDto, Category>();
        #endregion
    }
}