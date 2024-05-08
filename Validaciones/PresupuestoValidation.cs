using CashFlyingServer.Models;
using FluentValidation;

namespace CashFlyingServer.Validaciones
{
    public class PresupuestoValidation : AbstractValidator<Presupuesto>
    {
        public PresupuestoValidation()
        {
            RuleFor(p => p.Id).NotNull();
            RuleFor(p => p.Saldo).NotEmpty().WithMessage("El Campo {PropertyName} es Obligatorio").GreaterThan(0).WithMessage("El Valor tiene que ser superior a 0");
        }
    }
}
