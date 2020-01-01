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
    public sealed class CreateFeatureCommandHandler : ICommandHandler<CreateFeatureCommand>
    {
        private readonly TransverseContext _context;
        private readonly IFeatureRepository _featureRepository;

        public CreateFeatureCommandHandler(TransverseContext context,
                                      IFeatureRepository featureRepository)
        {
            _context = context;
            _featureRepository = featureRepository;
        }
        public Result Handle(CreateFeatureCommand command)
        {
            var feature = new Feature(command.Label, command.Description, command.Action, command.Controller,
                                      command.ControllerActionName, command.CreatedBy);
            _featureRepository.Insert(feature);
            if(!_featureRepository.Save())
            {
                return Result.Failure("Feature could not be saved");
            }
            return Result.Ok();
        }
    }
}
