using CashFlyingServer.Models;
using FluentValidation;

namespace CashFlyingServer.Validaciones
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("El Campo {PropertyName} es Obligatorio").EmailAddress().WithMessage("El {PropertyName} no es Correcto");
            RuleFor(u => u.Password).NotEmpty().WithMessage("El Campo {PropertyName} es Obligatorio").MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 Caracteres");
        }
    }
}
