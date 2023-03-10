using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.Common.Resource;
using Sodimac.SCPRO.Model;
using Sodimac.SCPRO.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Common
{
    public class CommonRepository : BaseRepository<EntityBase>
    {
        public CommonRepository(ScproContext context) : base(context)
        {

        }

        public virtual void Add<T>(T entity) where T : EntityBase, new()
        {

            if (string.IsNullOrEmpty(entity.UsuarioRegistra))
            {
                throw new RegistrationException(ErrorMessage.RegisterErrorUserRegister);
            }

            entity.FechaRegistra = DateTime.Now;

            dbSet.Add(entity);
        }

        public virtual void Add<T>(List<T> entities) where T : EntityBase, new()
        {
            entities.ForEach(Add);
        }

        public virtual void Remove<T>(List<T> entitiesToDelete) where T : EntityBase, new()
        {
            entitiesToDelete.ForEach(Remove);
        }

        public virtual void Remove<T>(T entityToDelete) where T : EntityBase, new()
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Clear<T>(DbSet<T> dbSet) where T : EntityBase, new()
        {
            dbSet.RemoveRange(dbSet);
        }

        public virtual T Update<T>(T entityToUpdate) where T : AuditBase, IGenerateIdentity<T>, new()
        {

            entityToUpdate.FechaModifica = DateTime.Now;

            if (string.IsNullOrEmpty(entityToUpdate.UsuarioModifica))
            {
                throw new UpdateException(ErrorMessage.UpdateErrorUserRegister);
            }

            var entityClone = entityToUpdate.GetKey().Invoke();
            var attachedEntry = context.Entry(entityClone);

            context.Set<T>().Attach(entityClone);
            attachedEntry.State = EntityState.Unchanged;
            attachedEntry.CurrentValues.SetValues(entityToUpdate);
            attachedEntry.Property(x => x.Activo).IsModified = true;

            return entityClone;
        }

        public virtual List<T> Update<T>(List<T> entities) where T : AuditBase, IGenerateIdentity<T>, new()
        {
            var listEntityUpdated = new List<T>();
            entities.ForEach(x => listEntityUpdated.Add(Update(x)));
            return listEntityUpdated;
        }

        public EntityEntry<T> UpdateCustom<T>(T entity) where T : AuditBase, IGenerateIdentity<T>, new()
        {
            var entityClone = Update(entity);
            return context.Entry(entityClone);
        }

        public virtual void Unmark<T>(T entity) where T : EntityBase, new()
        {
            context.Entry(entity).State = EntityState.Unchanged;
        }
        public virtual async Task<int> SaveChangesAsync()
        {
            try
            {
                var entities = from e in context.ChangeTracker.Entries()
                               where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                               select e.Entity;

                foreach (var entity in entities)
                {
                    var validationContext = new ValidationContext(entity);
                    Validator.ValidateObject(entity, validationContext);
                }

                return await context.SaveChangesAsync();
            }
            catch (IOException ex)
            {
                throw new IOException(ex.ToString());
            }
        }

        public virtual async Task<PagedResultRepository<T>> GetQueryAny<T>(IQueryable<T> query) where T : class
        {
            var result = new PagedResultRepository<T>
            {
                Results = await query.ToListAsync()
            };
            return result;
        }

        public virtual async Task<PagedResultRepository<T>> GetPaged<T>(IQueryable<T> query,
                                                            int page = 1,
                                                            int pageSize = 10) where T : class
        {
            var result = new PagedResultRepository<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
        public virtual void InsertMassive<T>(List<T> entities) where T : AuditBase, IGenerateIdentity<T>, new()
        {
            context.BulkInsert(entities);
        }
    }

}
