namespace Todo.Application
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoDto, Domain.Entity.TaskEntity>();
            CreateMap<Domain.Entity.TaskEntity, TodoDto>();
        }
    }
}
