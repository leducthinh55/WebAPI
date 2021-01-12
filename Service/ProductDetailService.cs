using Core.Entities;
using Infrastructure.Infrastructure;
using Infrastructure.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductDetailService
    {
        void AddProductDetail(ProductDetail ProductDetail);
        void UpdateProductDetail(ProductDetail ProductDetail);
        void DeleteProductDetail(Expression<Func<ProductDetail, bool>> where);
        ProductDetail GetProductDetailById(Guid Id);
        IEnumerable<ProductDetail> GetAll();
        IEnumerable<ProductDetail> GetAll(params Expression<Func<ProductDetail, object>>[] includes);
        IEnumerable<ProductDetail> GetListProductDetail(Expression<Func<ProductDetail, bool>> where);
        IQueryable<ProductDetail> _GetListProductDetail(Expression<Func<ProductDetail, bool>> where);
        IQueryable<ProductDetail> _GetListProductDetail(Expression<Func<ProductDetail, bool>> where, params Expression<Func<ProductDetail, object>>[] includes);
        Task<bool> SaveProductDetail();
    }
    public class ProductDetailService : IProductDetailService
    {
        private IUnitOfWork _IUnitOfWork;
        private IProductDetailRespository _IProductDetailRespository;
        public ProductDetailService(IUnitOfWork IUnitOfWork, IProductDetailRespository IProductDetailRespository)
        {
            _IUnitOfWork = IUnitOfWork;
            _IProductDetailRespository = IProductDetailRespository;
        }

        public void AddProductDetail(ProductDetail ProductDetail)
        {
            _IProductDetailRespository.Add(ProductDetail);
        }

        public void DeleteProductDetail(Expression<Func<ProductDetail, bool>> where)
        {
            _IProductDetailRespository.Delete(where);
        }

        public IEnumerable<ProductDetail> GetAll()
        {
            return _IProductDetailRespository.GetAll();
        }

        public IEnumerable<ProductDetail> GetListProductDetail(Expression<Func<ProductDetail, bool>> where)
        {
            return _IProductDetailRespository.GetList(where);
        }

        public ProductDetail GetProductDetailById(Guid Id)
        {
            return _IProductDetailRespository.GetById(Id);
        }

        public void UpdateProductDetail(ProductDetail ProductDetail)
        {
            _IProductDetailRespository.Update(ProductDetail);
        }

        public IQueryable<ProductDetail> _GetListProductDetail(Expression<Func<ProductDetail, bool>> where)
        {
            return _IProductDetailRespository._GetList(where);
        }

        public async Task<bool> SaveProductDetail()
        {
            return await _IUnitOfWork.Commit();
        }

        public IEnumerable<ProductDetail> GetAll(params Expression<Func<ProductDetail, object>>[] includes)
        {
            return _IProductDetailRespository.GetAll(includes);
        }

        public IQueryable<ProductDetail> _GetListProductDetail(Expression<Func<ProductDetail, bool>> where, params Expression<Func<ProductDetail, object>>[] includes)
        {
            return _IProductDetailRespository._GetList(where, includes);
        }
    }
}
