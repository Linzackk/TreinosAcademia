using AutoMapper;
using TreinosAcademia.DTOs.Treino;
using TreinosAcademia.DTOs.TreinoExercicio;
using TreinosAcademia.DTOs.Usuario;
using TreinosAcademia.Models;

namespace TreinosAcademia.Profiles
{
    public class TreinoProfile : Profile
    {
        public TreinoProfile()
        {
            CreateMap<Treino, TreinoResponseDTO>()
                .ForMember(dest => dest.UsuarioNome,
                           opt => opt.MapFrom(src => src.Usuario.Nome))
                .ForMember(dest => dest.Exercicios,
                           opt => opt.MapFrom(src => src.TreinoExercicio));

            CreateMap<TreinoCreateDTO, Treino>();
            CreateMap<TreinoUpdateDTO, Treino>();
        }
    }
}
