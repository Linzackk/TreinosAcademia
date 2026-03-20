using AutoMapper;
using TreinosAcademia.DTOs.TreinoExercicio;
using TreinosAcademia.Models;

namespace TreinosAcademia.Profiles
{
    public class TreinoExercicioProfile : Profile
    {
        public TreinoExercicioProfile()
        {
            CreateMap<TreinoExercicio, TreinoExercicioResponseDTO>()
            .ForMember(dest => dest.ExercicioNome,
                       opt => opt.MapFrom(src => src.Exercicio.Nome));
            CreateMap<TreinoExercicioCreateDTO, TreinoExercicio>();
            CreateMap<TreinoExercicioUpdateDTO, TreinoExercicio>();
        }
    }
}
