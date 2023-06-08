using AutoMapper;
using Todo.Domain.Model;
using Todo.Shared.Commands.TodoItem;

namespace Todo.API.Mappers;

/// <summary>
/// 
/// </summary>
public class CommandToDomainProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public CommandToDomainProfile()
    {
        #region Book
        CreateMap<CreateTodoItemCommand, TodoItem>();
        CreateMap<UpdateTodoItemCommand, TodoItem>();
        #endregion
    }
}