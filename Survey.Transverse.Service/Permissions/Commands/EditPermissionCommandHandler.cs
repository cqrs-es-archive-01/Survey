using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Permissions;
using Survey.Transverse.Domain.Permissions.Commands;
using Survey.Transverse.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey.Transverse.Service.Permissions.Commands
{
    public sealed class EditPermissionCommandHandler : ICommandHandler<EditPermissionCommand>
    {
        private readonly TransverseContext _context;
        private readonly IPermissionRepository _permissionRepository;

        public EditPermissionCommandHandler(TransverseContext context,
                                              IPermissionRepository permissionRepository)
        {
            _context = context;
            _permissionRepository = permissionRepository;

        }
        public Result Handle(EditPermissionCommand command)
        {
            var permission = _permissionRepository.FindByInclude(a => a.Id == command.Id, a => a.PermissionFeatures).FirstOrDefault();
            permission.Update(command.Label, command.Description, command?.Features, command.DeleteExistingFeatures);
            _permissionRepository.UpdateFeatures(permission, command.DeleteExistingFeatures);
            _permissionRepository.Save();
            return Result.Ok();
        }
    }
}
