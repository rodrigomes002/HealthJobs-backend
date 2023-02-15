using HealthJobs.Application.Autenticacao.DTOs;
using HealthJobs.Application.Usuarios.DTOs;
using HealthJobs.Application.Usuarios.Services;
using HealthJobs.Domain.Usuarios;
using HealthJobs.Domain.Usuarios.Interface;
using HealthJobs.Infra.UoW;
using Microsoft.Extensions.Configuration;

namespace HealthJobs.Application.Autenticacao.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this._usuarioRepository = usuarioRepository;
            this._unitOfWork = unitOfWork;
            this._configuration = configuration;
        }

        public async Task<UsuarioToken> Login(LoginDTO dto)
        {
            var usuarioExiste = await this._usuarioRepository.Verificar(dto.Email, dto.Senha);
            if (usuarioExiste == null)
                throw new ApplicationException("Usuário ou Senha inválidos");

            return new JwtService(_configuration).GeraToken(dto);

        }

        public async Task Cadastrar(UsuarioDTO dto)
        {
            var usuarioExiste = await this._usuarioRepository.ListarPorEmail(dto.Email);
            if (usuarioExiste != null)
                throw new ApplicationException("Já existe um usuário com este email cadastrado");            

            var usuario = new Usuario();
            usuario.Email = dto.Email;
            usuario.Senha = dto.Senha;
            usuario.Tipo = dto.Tipo;

            await this._usuarioRepository.Cadastrar(usuario);
            await this._unitOfWork.CommitAsync();
        }
    }
}
