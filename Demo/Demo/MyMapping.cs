using AutoMapper;

namespace Demo
{
    public class MyMapping
    {
        public static IMapper Mapper;

        public static void Init()
        {
            var cfg = new MapperConfiguration(x => { x.CreateMap<Customer, Person>(); });
            Mapper = cfg.CreateMapper();
        }
    }
}