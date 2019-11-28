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
    public sealed class RemovePermissionCommandHandler : ICommandHandler<RemovePermissionCommand>
    {
        private readonly TransverseContext _context;
        private readonly IPermissionRepository _permissionRepository;

        public RemovePermissionCommandHandler(TransverseContext context,
                                              IPermissionRepository permissionRepository)
        {
            _context = context;
            _permissionRepository = permissionRepository;
        }
        public Result Handle(RemovePermissionCommand command)
        {
            var permission = _permissionRepository.FindByKey(command.Id);
            permission.Remove(command.By, command.Reason);
            _permissionRepository.Save();
            return Result.Ok();
        }
    }
}
