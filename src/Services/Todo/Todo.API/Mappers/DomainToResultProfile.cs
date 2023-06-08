using AutoMapper;
using Todo.Domain.Model;
using Todo.Shared.DTO.TodoItem;

namespace Todo.API.Mappers;

/// <summary>
/// 
/// </summary>
public class DomainToResultProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public DomainToResultProfile()
    {
        #region TodoItem
        CreateMap<TodoItem, TodoItemQueryOutDto>();
        CreateMap<TodoItem, TodoItemGetOutDto>();
        #endregion
    }
}