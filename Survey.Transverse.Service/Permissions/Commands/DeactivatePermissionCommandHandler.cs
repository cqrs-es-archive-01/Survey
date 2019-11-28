using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Permissions.Commands;
using Survey.Transverse.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Service.Permissions.Commands
{
    public sealed class DeactivatePermissionCommandHandler : ICommandHandler<DeactivatePermissionCommand>
    {
        private readonly TransverseContext _context;
        private readonly IPermissionRepository _permissionRepository;

        public DeactivatePermissionCommandHandler(TransverseContext context,
                                                  IPermissionRepository permissionRepository)
        {
            _context = context;
            _permissionRepository = permissionRepository;
        }
        public Result Handle(DeactivatePermissionCommand command)
        {
            var permission = _permissionRepository.FindByKey(command.Id);
            permission.Deactivate(command.DisabledBy);
            _permissionRepository.Save();
            return Result.Ok();
        }
    }
}
