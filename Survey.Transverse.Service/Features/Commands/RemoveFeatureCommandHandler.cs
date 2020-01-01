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
    public sealed class RemoveFeatureCommandHandler : ICommandHandler<RemoveFeatureCommand>
    {
        private readonly TransverseContext _context;
        private readonly IFeatureRepository _featureRepository;

        public RemoveFeatureCommandHandler(TransverseContext context,
                                      IFeatureRepository featureRepository)
        {
            _context = context;
            _featureRepository = featureRepository;
        }
        public Result Handle(RemoveFeatureCommand command)
        {
            var feature = _featureRepository.FindByKey(command.Id);
            if (feature == null)
                return Result.Failure($"No feature found for Id= {command.Id}");
            feature.Remove(command.DeletedBy, command.Reason);
            if (!_featureRepository.Save())
            {
                return Result.Failure("Feature could not be deactivated");
            }
            return Result.Ok();
        }
    }
}
