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
    public interface IColorService
    {
        void AddColor(Color Color);
        void UpdateColor(Color Color);
        void DeleteColor(Expression<Func<Color, bool>> where);
        Color GetColorById(Guid Id);
        IEnumerable<Color> GetAll();
        IEnumerable<Color> GetAll(params Expression<Func<Color, object>>[] includes);
        IEnumerable<Color> GetListColor(Expression<Func<Color, bool>> where);
        IQueryable<Color> _GetListColor(Expression<Func<Color, bool>> where);
        IQueryable<Color> _GetListColor(Expression<Func<Color, bool>> where, params Expression<Func<Color, object>>[] includes);
        Task<bool> SaveColor();
    }
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IColorRespository _iRespository;
        public ColorService(IUnitOfWork iUnitOfWork, IColorRespository iRespository)
        {
            _iRespository = iRespository;
            _iUnitOfWork = iUnitOfWork;
        }

        public void AddColor(Color Color)
        {
            _iRespository.Add(Color);
        }

        public void DeleteColor(Expression<Func<Color, bool>> where)
        {
            _iRespository.Delete(where);
        }

        public IEnumerable<Color> GetAll()
        {
            return _iRespository.GetAll();
        }

        public IEnumerable<Color> GetAll(params Expression<Func<Color, object>>[] includes)
        {
            return _iRespository.GetAll(includes);
        }

        public IEnumerable<Color> GetListColor(Expression<Func<Color, bool>> where)
        {
            return _iRespository.GetList(where);
        }

        public Color GetColorById(Guid Id)
        {
            return _iRespository.GetById(Id);
        }

        public void UpdateColor(Color Color)
        {
            _iRespository.Update(Color);
        }

        public IQueryable<Color> _GetListColor(Expression<Func<Color, bool>> where)
        {
            return _iRespository._GetList(where);
        }

        public IQueryable<Color> _GetListColor(Expression<Func<Color, bool>> where, params Expression<Func<Color, object>>[] includes)
        {
            return _iRespository._GetList(where, includes);
        }

        public async Task<bool> SaveColor()
        {
            return await _iUnitOfWork.Commit();
        }
    }
}
