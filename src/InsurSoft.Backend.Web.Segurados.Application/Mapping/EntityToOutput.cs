using AutoMapper;
using InsurSoft.Backend.Web.Segurados.Application.Output.Segurados;
using InsurSoft.Backend.Web.Segurados.Domain.Entities;

namespace InsurSoft.Backend.Web.Segurados.Application.Mapping
{
    public class EntityToOutput : Profile
    {
        public EntityToOutput()
        {
            CreateMap<Segurado, SeguradoOutput>()
                .ForMember(output => output.Nome, opts => opts.MapFrom(segurado => segurado.Nome.Nome))
                .ForMember(output => output.Sobrenome, opts => opts.MapFrom(segurado => segurado.Nome.Sobrenome))
                .ForMember(output => output.DataNascimento, opts => opts.MapFrom(segurado => segurado.DataNascimento.Data));
        }
    }
}
