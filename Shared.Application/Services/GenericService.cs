using Shared.Core.Entities;
using Shared.Core.Interface.Repository;
using Shared.Core.Interface.Service;
using Shared.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Application.Services
{
    public abstract class GenericService<T, TKey> : IGenericService<T, TKey>
        where T : class, IBaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        protected readonly IUnitOfWork<T, TKey> _unitOfWork;

        public GenericService(IUnitOfWork<T, TKey> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _unitOfWork.GenericRepository.GetAllAsync(cancellationToken);
        }
        public async Task<IEnumerable<T>> ListAsync(IPaging paging, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GenericRepository.ListAsync(paging, cancellationToken);
        }
        public async Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return await _unitOfWork.GenericRepository.CountAsync(cancellationToken);
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _unitOfWork.GenericRepository.AddAsync(entity, cancellationToken);
        }
        public void Update(T entity)
        {
            _unitOfWork.GenericRepository.Update(entity);
        }
        public void Delete(T entity)
        {
            _unitOfWork.GenericRepository.Delete(entity);
        }
        public async Task<T> GetByKeyAsync(TKey id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GenericRepository.GetByKeyAsync(id, cancellationToken);
        }
        public async Task<bool> ExistsAsync(TKey id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GenericRepository.ExistsAsync(id, cancellationToken);
        }
    }
}
