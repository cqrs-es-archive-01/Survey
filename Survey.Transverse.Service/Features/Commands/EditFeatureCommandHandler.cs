using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Features.Commands;
using Survey.Transverse.Domain.Permissions;
using Survey.Transverse.Domain.Permissions.Commands;
using Survey.Transverse.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Service.Permissions.Commands
{
    public sealed class EditFeatureCommandHandler : ICommandHandler<EditFeatureCommand>
    {
        private readonly TransverseContext _context;
        private readonly IFeatureRepository _featureRepository;

        public EditFeatureCommandHandler(TransverseContext context,
                                         IFeatureRepository featureRepository)
        {
            _context = context;
            _featureRepository = featureRepository;

        }
        public Result Handle(EditFeatureCommand command)
        {
            var feature = _featureRepository.FindByKey(command.Id);
            feature.UpdateInfo(command.Label, command.Description, command.Action, command.Controller,
                               command.ControllerActionName);

            _featureRepository.Save();
            return Result.Ok();
        }
    }
}
