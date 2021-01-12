using Core.Entities;
using Infrastructure.Infrastructure;
using Infrastructure.Respositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service
{
    public interface ITypeGroupUserService
    {
        void AddTypeGroupUser(TypeGroupUser TypeGroupUser);
        void UpdateTypeGroupUser(TypeGroupUser TypeGroupUser);
        void DeleteTypeGroupUser(Expression<Func<TypeGroupUser, bool>> where);
        TypeGroupUser GetTypeGroupUserById(Guid Id);
        IEnumerable<TypeGroupUser> GetAll();
        IEnumerable<TypeGroupUser> GetAll(params Expression<Func<TypeGroupUser, object>>[] includes);
        IEnumerable<TypeGroupUser> GetListTypeGroupUser(Expression<Func<TypeGroupUser, bool>> where);
        IQueryable<TypeGroupUser> _GetListTypeGroupUser(Expression<Func<TypeGroupUser, bool>> where);
        IQueryable<TypeGroupUser> _GetListTypeGroupUser(Expression<Func<TypeGroupUser, bool>> where, params Expression<Func<TypeGroupUser, object>>[] includes);
        Task<bool> SaveTypeGroupUser();
    }
    public class TypeGroupUserService : ITypeGroupUserService
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly ITypeGroupUserRespository _iRespository;
        public TypeGroupUserService(IUnitOfWork iUnitOfWork, ITypeGroupUserRespository iRespository)
        {
            _iRespository = iRespository;
            _iUnitOfWork = iUnitOfWork;
        }

        public void AddTypeGroupUser(TypeGroupUser TypeGroupUser)
        {
            _iRespository.Add(TypeGroupUser);
        }

        public void DeleteTypeGroupUser(Expression<Func<TypeGroupUser, bool>> where)
        {
            _iRespository.Delete(where);
        }

        public IEnumerable<TypeGroupUser> GetAll()
        {
            return _iRespository.GetAll();
        }

        public IEnumerable<TypeGroupUser> GetAll(params Expression<Func<TypeGroupUser, object>>[] includes)
        {
            return _iRespository.GetAll(includes);
        }

        public IEnumerable<TypeGroupUser> GetListTypeGroupUser(Expression<Func<TypeGroupUser, bool>> where)
        {
            return _iRespository.GetList(where);
        }

        public TypeGroupUser GetTypeGroupUserById(Guid Id)
        {
            return _iRespository.GetById(Id);
        }

        public void UpdateTypeGroupUser(TypeGroupUser TypeGroupUser)
        {
            _iRespository.Update(TypeGroupUser);
        }

        public IQueryable<TypeGroupUser> _GetListTypeGroupUser(Expression<Func<TypeGroupUser, bool>> where)
        {
            return _iRespository._GetList(where);
        }

        public IQueryable<TypeGroupUser> _GetListTypeGroupUser(Expression<Func<TypeGroupUser, bool>> where, params Expression<Func<TypeGroupUser, object>>[] includes)
        {
            return _iRespository._GetList(where, includes);
        }

        public async Task<bool> SaveTypeGroupUser()
        {
            return await _iUnitOfWork.Commit();
        }
    }
}
