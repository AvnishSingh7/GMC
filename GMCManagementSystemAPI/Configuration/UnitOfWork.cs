using GMCManagementSystemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace GMCManagementSystemAPI.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GmcManagementSystemContext context;
        private bool disposed;
        private Dictionary<string, object> repositories;
       // private IDbContextTransaction _objTran;
        private string _errorMessage = string.Empty;
        private readonly HttpContext httpContext;
        private readonly IConfigurationRoot m_config;
        public UnitOfWork( GmcManagementSystemContext context)
        { 
           // httpContext = httpContentAccessor.HttpContext;
            this.context = context;
           // m_config = config;
        }

        public IDbContext DbContext => new GmcManagementSystemContext(m_config.GetConnectionString("DbConnection"));

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //public void Save()
        //{
        //    context.SaveChanges();
        //}

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(TEntity).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<TEntity>)repositories[type];
        }

        //public void CreateTransaction()
        //{
        //    _objTran = context.Database.BeginTransaction();
        //}
        ////If all the Transactions are completed successfuly then we need to call this Commit() 
        ////method to Save the changes permanently in the database
        //public void Commit()
        //{
        //    _objTran.Commit();
        //}
        ////If atleast one of the Transaction is Failed then we need to call this Rollback() 
        ////method to Rollback the database changes to its previous state
        //public void Rollback()
        //{
        //    _objTran.Rollback();
        //    _objTran.Dispose();
        //}
        //This Save() Method Implement DbContext Class SaveChanges method so whenever we do a transaction we need to
        //call this Save() method so that it will make the changes in the database
        //public void Save()
        //{
        //    try
        //    {
        //        context.SaveChanges();
        //    }
        //    catch (DbEntityValidationException dbEx)
        //    {
        //        foreach (var validationErrors in dbEx.EntityValidationErrors)
        //            foreach (var validationError in validationErrors.ValidationErrors)
        //                _errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
        //        throw new Exception(_errorMessage, dbEx);
        //    }
        //}

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            // Save changes with the default options
            return context.SaveChanges();
        }

    }
}
