using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Survey.Common.Types;
using Survey.Transverse.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;

namespace Survey.Transverse.Infrastracture.Util
{
    public sealed class UnitOfWork:IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IDbContextTransaction _transaction;
        private bool _isAlive = true;

        public UnitOfWork(TransverseContext transverseContext)
        {
            _context = transverseContext;
            _transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            if (!_isAlive)
                return;

            try
            {
                _transaction.Commit();
            }
            finally
            {
                _isAlive = false;
                _transaction.Dispose();
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _context.Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

    }
}
