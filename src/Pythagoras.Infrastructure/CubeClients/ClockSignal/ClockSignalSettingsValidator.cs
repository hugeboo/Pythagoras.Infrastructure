using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.CubeClients.ClockSignal
{
    public sealed class ClockSignalSettingsValidator : AbstractValidator<ClockSignalSettings>
    {
        public ClockSignalSettingsValidator()
        {
            RuleFor(s => (int)s.Mode).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            RuleFor(s => s.StartDate).GreaterThan(DateTime.MinValue);
            RuleFor(s => s.EndDate).Must((s, t) => t.Date >= s.StartDate.Date)
                .WithMessage("EndDate must be greater than or equals to StartDate");
            RuleFor(s => s.StartTime).GreaterThanOrEqualTo(TimeSpan.Zero);
            RuleFor(s => s.EndTime).Must((s, t) => t > s.StartTime)
                .WithMessage("EndTime must be greater than StartTime");
            RuleFor(s => s.TimeFactor).GreaterThan(0.0);
        }
    }
}
