using CashFlyingServer.Models;
using FluentValidation;

namespace CashFlyingServer.Validaciones
{
    public class GastoValidation : AbstractValidator<Gasto>
    {
        public GastoValidation()
        {
            RuleFor(g => g.Id).NotNull().WithMessage("El {PropertyName} No Existe");
            RuleFor(g => g.Nombre).NotEmpty().WithMessage("El Campo {PropertyName} es Obligatorio");
            RuleFor(g => g.Cantidad).NotEmpty().WithMessage("El Campo {PropertyName} es Obligatorio").GreaterThan(0).WithMessage("El Valor tiene que ser superior a 0");
            RuleFor(g => g.Categoria).NotEmpty().WithMessage("El Campo {PropertyName} es Obligatorio").IsInEnum();
            RuleFor(g => g.Descripcion).NotEmpty().WithMessage("El Campo {PropertyName} es Obligatorio");
            RuleFor(g => g.Fecha).NotEmpty().WithMessage("El Campo {PropertyName} es Obligatorio");
        }
    }
}
