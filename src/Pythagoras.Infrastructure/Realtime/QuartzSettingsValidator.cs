using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.Realtime
{
    internal sealed class QuartzSettingsValidator : AbstractValidator<QuartzSettings>
    {
        public QuartzSettingsValidator() 
        {
            RuleFor(s => s.Date).GreaterThan(DateTime.MinValue);
            RuleFor(s => s.StartTime).GreaterThanOrEqualTo(TimeSpan.Zero);
            RuleFor(s => s.EndTime).Must((s, t) => t > s.StartTime)
                .WithMessage("EndTime must be greater than StartTime");
            RuleFor(s => s.TimeFactor).GreaterThan(0.0);
        }
    }
}
