using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.Types
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
