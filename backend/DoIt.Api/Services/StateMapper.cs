using System;

namespace DoIt.Api.Services
{
    public static class StateMapper
    {
        public static Interface.State ToDto(this Domain.State state)
        {
            return (Interface.State)Enum.Parse(typeof(Interface.State), state.ToString());
        }

        public static Domain.State ToDomain(this Interface.State state)
        {
            return (Domain.State)Enum.Parse(typeof(Domain.State), state.ToString());
        }
    }
}
