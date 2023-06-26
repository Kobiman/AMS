using AutoMapper;

namespace AMS.Server
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AgentDto, Agent>();
            CreateMap<Agent, AgentDto>();
        }
    }
}
