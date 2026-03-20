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
            CreateMap<TreinoExercicio, TreinoExercicioResponseDTO>()
            .ForMember(dest => dest.ExercicioNome,
                       opt => opt.MapFrom(src => src.Exercicio.Nome));
            CreateMap<TreinoCreateDTO, Treino>();
            CreateMap<TreinoUpdateDTO, Treino>();
        }
    }
}
