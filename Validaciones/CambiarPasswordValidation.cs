using CashFlyingServer.Models;
using FluentValidation;

namespace CashFlyingServer.Validaciones
{
    public class CambiarPasswordValidation : AbstractValidator<CambiarPassword>
    {
        public CambiarPasswordValidation() 
        {
            RuleFor(c => c.Password).NotEmpty().WithMessage("El Campo {PropertyName} es Obligatorio");
            RuleFor(c => c.NewPassword).NotEmpty().WithMessage("El Campo {PropertyName} es Obligatorio").MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 Caracteres");
        
        }
    }
}
