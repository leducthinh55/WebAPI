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
    public interface ITypeGroupService
    {
        void AddTypeGroup(TypeGroup TypeGroup);
        void UpdateTypeGroup(TypeGroup TypeGroup);
        void DeleteTypeGroup(Expression<Func<TypeGroup, bool>> where);
        TypeGroup GetTypeGroupById(Guid Id);
        IEnumerable<TypeGroup> GetAll();
        IEnumerable<TypeGroup> GetAll(params Expression<Func<TypeGroup, object>>[] includes);
        IEnumerable<TypeGroup> GetListTypeGroup(Expression<Func<TypeGroup, bool>> where);
        IQueryable<TypeGroup> _GetListTypeGroup(Expression<Func<TypeGroup, bool>> where);
        IQueryable<TypeGroup> _GetListTypeGroup(Expression<Func<TypeGroup, bool>> where, params Expression<Func<TypeGroup, object>>[] includes);
        Task<bool> SaveTypeGroup();
    }
    public class TypeGroupService : ITypeGroupService
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly ITypeGroupRespository _iRespository;
        public TypeGroupService(IUnitOfWork iUnitOfWork, ITypeGroupRespository iRespository)
        {
            _iRespository = iRespository;
            _iUnitOfWork = iUnitOfWork;
        }

        public void AddTypeGroup(TypeGroup TypeGroup)
        {
            _iRespository.Add(TypeGroup);
        }

        public void DeleteTypeGroup(Expression<Func<TypeGroup, bool>> where)
        {
            _iRespository.Delete(where);
        }

        public IEnumerable<TypeGroup> GetAll()
        {
            return _iRespository.GetAll();
        }

        public IEnumerable<TypeGroup> GetAll(params Expression<Func<TypeGroup, object>>[] includes)
        {
            return _iRespository.GetAll(includes);
        }

        public IEnumerable<TypeGroup> GetListTypeGroup(Expression<Func<TypeGroup, bool>> where)
        {
            return _iRespository.GetList(where);
        }

        public TypeGroup GetTypeGroupById(Guid Id)
        {
            return _iRespository.GetById(Id);
        }

        public void UpdateTypeGroup(TypeGroup TypeGroup)
        {
            _iRespository.Update(TypeGroup);
        }

        public IQueryable<TypeGroup> _GetListTypeGroup(Expression<Func<TypeGroup, bool>> where)
        {
            return _iRespository._GetList(where);
        }

        public IQueryable<TypeGroup> _GetListTypeGroup(Expression<Func<TypeGroup, bool>> where, params Expression<Func<TypeGroup, object>>[] includes)
        {
            return _iRespository._GetList(where, includes);
        }

        public async Task<bool> SaveTypeGroup()
        {
            return await _iUnitOfWork.Commit();
        }
    }
}
