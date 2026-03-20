using AutoMapper;
using TreinosAcademia.DTOs.Usuario;
using TreinosAcademia.Models;

namespace TreinosAcademia.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioResponseDTO>();
            CreateMap<UsuarioCreateDTO, Usuario>();
            CreateMap<UsuarioUpdateDTO, Usuario>();
        }
    }
}
