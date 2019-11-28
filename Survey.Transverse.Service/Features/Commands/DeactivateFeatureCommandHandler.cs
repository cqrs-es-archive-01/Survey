using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Features.Commands;
using Survey.Transverse.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Service.Features.Commands
{
    public sealed class DeactivateFeatureCommandHandler : ICommandHandler<DeactivateFeatureCommand>
    {
        private readonly TransverseContext _context;
        private readonly IFeatureRepository _featureRepository;

        public DeactivateFeatureCommandHandler(TransverseContext context,
                                      IFeatureRepository featureRepository)
        {
            _context = context;
            _featureRepository = featureRepository;
        }
        public Result Handle(DeactivateFeatureCommand command)
        {
            var feature = _featureRepository.FindByKey(command.Id);
            if (feature == null)
                return Result.Failure($"No feature found for Id= {command.Id}");
            feature.Deactivate(command.DisabledBy);
            _featureRepository.Save();
            return Result.Ok();
        }
    }
}
