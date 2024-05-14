using CashFlyingServer.Models;
using CashFlyingServer.Services.UsuarioServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CashFlyingServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private const string SecretKey = "contraseñasupersecretahoyeslunesymeestoyvolviendolocanonlaauth";
        private const string Issuer = "http://localhost:5221";
        private const string Audience = "http://localhost:5221";

        private static TimeSpan TokenLifetime = TimeSpan.FromHours(24);

        private readonly IUsuarioServices usuarioServices;
        public IdentityController(IUsuarioServices usuarioServices)
        {
            this.usuarioServices = usuarioServices;
        }
        public class RegisterUserModel
        {
            public required Usuario NuevoUsuario { get; set; }
        }

        [HttpPost("Register")]
        public async Task<ActionResult<Usuario>> RegistrarUsuario([FromBody] RegisterUserModel model)
        {
            if (model == null || model.NuevoUsuario == null)
            {
                return BadRequest("Los Datos del Registro no son Válidos");
            }
            try
            {
                var result = await usuarioServices.RegistrarUsuario(model.NuevoUsuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //TODO log.Error($"Error durante el inicio de sesión: {ex.Message}");
                return StatusCode(500, $"Error interno al registrar al usuario: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> GenerateToken(LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Credenciales de inicio de sesión no validas");
            }
            try
            {
                //Verificar las credenciasles del usuario
                var userExist = await usuarioServices.CheckUserAndPass(request.Email, request.Password);
                if (userExist)
                {
                    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
                    SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var SecretToken = new JwtSecurityToken(
                      Issuer,
                      Audience,
                      null,
                      expires: DateTime.Now.Add(TokenLifetime),
                      signingCredentials: credentials);

                    var token = new JwtSecurityTokenHandler().WriteToken(SecretToken);                    
                    return Ok(token);
                }
                else
                {
                    
                     return Unauthorized("El Usuario no Existe");
                }              

              
            }
            catch (Exception ex)
            {
                //log.Error($Error durante el inicio de sesion: {ex.Message}");
                return StatusCode(500, $"Error interno del servidor {ex.Message}");
            }

        }
        [HttpPost("CambiarPassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CambiarPassword>> CambiarPassword(CambiarPassword model)
        {
          
            try
           {
               var cambioCorrecto = await usuarioServices.CambiarPassword(model.Id, model.Password, model.NewPassword);
                if(cambioCorrecto == null)
                {
                    return BadRequest("La contraseña actual no es correcta");
                   
                }
                else
                {
                    return Ok(new { message = "Contraseña Cambiada Correctamente" });
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error del Servidor: {ex.Message}");
            }
        }

    }
}
