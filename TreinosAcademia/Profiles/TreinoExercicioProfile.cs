using AutoMapper;
using TreinosAcademia.DTOs.TreinoExercicio;
using TreinosAcademia.Models;

namespace TreinosAcademia.Profiles
{
    public class TreinoExercicioProfile : Profile
    {
        public TreinoExercicioProfile()
        {
            CreateMap<TreinoExercicio, TreinoExercicioResponseDTO>();
            CreateMap<TreinoExercicioCreateDTO, TreinoExercicio>();
            CreateMap<TreinoExercicioUpdateDTO, TreinoExercicio>();
        }
    }
}
