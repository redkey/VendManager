using FluentValidation;

namespace VendManager.Application.Features.Machines.Command.CreateMachine
{
    public class CreateMachineValidator : AbstractValidator<CreateMachineCommand>
    {
        public CreateMachineValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.SerialNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Location)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Notes)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

     
        }
    }
}
