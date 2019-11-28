using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Permissions;
using Survey.Transverse.Domain.Permissions.Commands;
using Survey.Transverse.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Service.Permissions.Commands
{
    public sealed class CreatePermissionCommandHandler : ICommandHandler<CreatePermissionCommand>
    {
        private readonly TransverseContext _context;
        private readonly IPermissionRepository _permissionRepository;

        public CreatePermissionCommandHandler(TransverseContext context,
                                              IPermissionRepository permissionRepository)
        {
            _context = context;
            _permissionRepository = permissionRepository;

        }
        public Result Handle(CreatePermissionCommand command)
        {
            var permission = new Permission(command.Label, command.Description, command.CreatedBy,command?.Features);
            _permissionRepository.Insert(permission);
            _permissionRepository.Save();
            return Result.Ok();
        }
    }
}
