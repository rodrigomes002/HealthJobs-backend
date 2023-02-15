using HealthJobs.Application.Autenticacao.DTOs;
using HealthJobs.Application.Usuarios.DTOs;
using Microsoft.AspNetCore.Identity;

namespace HealthJobs.Application.Autenticacao.Services
{
    public class UsuarioService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsuarioService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public async Task<SignInResult> Login(LoginDTO dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Email,
                 dto.Senha, isPersistent: false, lockoutOnFailure: false);

            return result;

        }

        public async Task<IdentityResult> Cadastrar(UsuarioDTO dto)
        {
            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, dto.Senha);

            return result;
        }
    }
}
