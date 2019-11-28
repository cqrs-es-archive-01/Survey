using Microsoft.EntityFrameworkCore;
using Survey.Transverse.Infrastracture.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Infrastracture.Util
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }

}
