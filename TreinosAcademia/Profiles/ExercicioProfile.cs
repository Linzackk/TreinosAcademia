using AutoMapper;
using TreinosAcademia.DTOs.Exercicio;
using TreinosAcademia.DTOs.Usuario;
using TreinosAcademia.Models;

namespace TreinosAcademia.Profiles
{
    public class ExercicioProfile : Profile
    {
        public ExercicioProfile()
        {
            CreateMap<Exercicio, ExercicioResponseDTO>();
            CreateMap<ExercicioCreateDTO, Exercicio>();
            CreateMap<ExercicioUpdateDTO, Exercicio>();
        }
    }
}
