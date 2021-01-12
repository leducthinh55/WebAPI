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
    public interface IProductTypeService
    {
        void AddProductType(ProductType ProductType);
        void UpdateProductType(ProductType ProductType);
        void DeleteProductType(Expression<Func<ProductType, bool>> where);
        ProductType GetProductTypeById(Guid Id);
        IEnumerable<ProductType> GetAll();
        IEnumerable<ProductType> GetAll(params Expression<Func<ProductType, object>>[] includes);
        IEnumerable<ProductType> GetListProductType(Expression<Func<ProductType, bool>> where);
        IQueryable<ProductType> _GetListProductType(Expression<Func<ProductType, bool>> where);
        IQueryable<ProductType> _GetListProductType(Expression<Func<ProductType, bool>> where, params Expression<Func<ProductType, object>>[] includes);
        Task<bool> SaveProductType();
    }
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IProductTypeRespository _iRespository;
        public ProductTypeService(IUnitOfWork iUnitOfWork, IProductTypeRespository iRespository)
        {
            _iRespository = iRespository;
            _iUnitOfWork = iUnitOfWork;
        }

        public void AddProductType(ProductType ProductType)
        {
            _iRespository.Add(ProductType);
        }

        public void DeleteProductType(Expression<Func<ProductType, bool>> where)
        {
            _iRespository.Delete(where);
        }

        public IEnumerable<ProductType> GetAll()
        {
            return _iRespository.GetAll();
        }

        public IEnumerable<ProductType> GetAll(params Expression<Func<ProductType, object>>[] includes)
        {
            return _iRespository.GetAll(includes);
        }

        public IEnumerable<ProductType> GetListProductType(Expression<Func<ProductType, bool>> where)
        {
            return _iRespository.GetList(where);
        }

        public ProductType GetProductTypeById(Guid Id)
        {
            return _iRespository.GetById(Id);
        }

        public void UpdateProductType(ProductType ProductType)
        {
            _iRespository.Update(ProductType);
        }

        public IQueryable<ProductType> _GetListProductType(Expression<Func<ProductType, bool>> where)
        {
            return _iRespository._GetList(where);
        }

        public IQueryable<ProductType> _GetListProductType(Expression<Func<ProductType, bool>> where, params Expression<Func<ProductType, object>>[] includes)
        {
            return _iRespository._GetList(where, includes);
        }

        public async Task<bool> SaveProductType()
        {
            return await _iUnitOfWork.Commit();
        }
    }
}
