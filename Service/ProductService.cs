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
    public interface IProductService
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Expression<Func<Product, bool>> where);
        Product GetProductById(Guid Id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAll(params Expression<Func<Product, object>>[] includes);
        IEnumerable<Product> GetListProduct(Expression<Func<Product, bool>> where);
        IQueryable<Product> _GetListProduct(Expression<Func<Product, bool>> where);
        IQueryable<Product> _GetListProduct(Expression<Func<Product, bool>> where, params Expression<Func<Product, object>>[] includes);
        Task<bool> SaveProduct();
    }
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IProductRespository _iRespository;
        public ProductService(IUnitOfWork iUnitOfWork, IProductRespository iRespository)
        {
            _iRespository = iRespository;
            _iUnitOfWork = iUnitOfWork;
        }

        public void AddProduct(Product product)
        {
            _iRespository.Add(product);
        }

        public void DeleteProduct(Expression<Func<Product, bool>> where)
        {
            _iRespository.Delete(where);
        }

        public IEnumerable<Product> GetAll()
        {
            return _iRespository.GetAll();
        }

        public IEnumerable<Product> GetAll(params Expression<Func<Product, object>>[] includes)
        {
            return _iRespository.GetAll(includes);
        }

        public IEnumerable<Product> GetListProduct(Expression<Func<Product, bool>> where)
        {
            return _iRespository.GetList(where);
        }

        public Product GetProductById(Guid Id)
        {
            return _iRespository.GetById(Id);
        }

        public void UpdateProduct(Product product)
        {
            _iRespository.Update(product);
        }

        public IQueryable<Product> _GetListProduct(Expression<Func<Product, bool>> where)
        {
            return _iRespository._GetList(where);
        }

        public IQueryable<Product> _GetListProduct(Expression<Func<Product, bool>> where, params Expression<Func<Product, object>>[] includes)
        {
            return _iRespository._GetList(where, includes);
        }

        public async Task<bool> SaveProduct()
        {
            return await _iUnitOfWork.Commit();
        }
    }
}
