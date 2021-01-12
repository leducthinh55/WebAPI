using Core.Entities;
using Infrastructure.Infrastructure;
using Infrastructure.Respositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace Service
{
    public interface IModifiedProductService
    {
        void AddModifiedProduct(ModifiedProduct ModifiedProduct);
        void UpdateModifiedProduct(ModifiedProduct ModifiedProduct);
        void DeleteModifiedProduct(Expression<Func<ModifiedProduct, bool>> where);
        ModifiedProduct GetModifiedProductById(Guid Id);
        IEnumerable<ModifiedProduct> GetAll();
        IEnumerable<ModifiedProduct> GetAll(params Expression<Func<ModifiedProduct, object>>[] includes);
        IEnumerable<ModifiedProduct> GetListModifiedProduct(Expression<Func<ModifiedProduct, bool>> where);
        IQueryable<ModifiedProduct> _GetListModifiedProduct(Expression<Func<ModifiedProduct, bool>> where);
        IQueryable<ModifiedProduct> _GetListModifiedProduct(Expression<Func<ModifiedProduct, bool>> where, params Expression<Func<ModifiedProduct, object>>[] includes);
        Task<bool> SaveModifiedProduct();
    }
    public class ModifiedProductService : IModifiedProductService
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IModifiedProductRespository _iRespository;
        public ModifiedProductService(IUnitOfWork iUnitOfWork, IModifiedProductRespository iRespository)
        {
            _iRespository = iRespository;
            _iUnitOfWork = iUnitOfWork;
        }

        public void AddModifiedProduct(ModifiedProduct ModifiedProduct)
        {
            _iRespository.Add(ModifiedProduct);
        }

        public void DeleteModifiedProduct(Expression<Func<ModifiedProduct, bool>> where)
        {
            _iRespository.Delete(where);
        }

        public IEnumerable<ModifiedProduct> GetAll()
        {
            return _iRespository.GetAll();
        }

        public IEnumerable<ModifiedProduct> GetAll(params Expression<Func<ModifiedProduct, object>>[] includes)
        {
            return _iRespository.GetAll(includes);
        }

        public IEnumerable<ModifiedProduct> GetListModifiedProduct(Expression<Func<ModifiedProduct, bool>> where)
        {
            return _iRespository.GetList(where);
        }

        public ModifiedProduct GetModifiedProductById(Guid Id)
        {
            return _iRespository.GetById(Id);
        }

        public void UpdateModifiedProduct(ModifiedProduct ModifiedProduct)
        {
            _iRespository.Update(ModifiedProduct);
        }

        public IQueryable<ModifiedProduct> _GetListModifiedProduct(Expression<Func<ModifiedProduct, bool>> where)
        {
            return _iRespository._GetList(where);
        }

        public IQueryable<ModifiedProduct> _GetListModifiedProduct(Expression<Func<ModifiedProduct, bool>> where, params Expression<Func<ModifiedProduct, object>>[] includes)
        {
            return _iRespository._GetList(where, includes);
        }

        public async Task<bool> SaveModifiedProduct()
        {
            return await _iUnitOfWork.Commit();
        }
    }
}
