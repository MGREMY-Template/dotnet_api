using AutoMapper;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Shared.Core.DataTransferObject;
using Shared.Core.Entities;
using Shared.Core.Extensions;
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
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;
        protected readonly IStringLocalizer _globalStringLocalizer;

        protected GenericService(
            IUnitOfWork<T, TKey> unitOfWork,
            IMapper mapper,
            ILogger<GenericService<T, TKey>> logger,
            IStringLocalizer<Core.Resources.Global> globalStringLocalizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _globalStringLocalizer = globalStringLocalizer;
        }

        public async Task<Result<IEnumerable<TOut>>> GetAllAsync<TOut>(CancellationToken cancellationToken)
        {
            return Result.Create(await _unitOfWork.GenericRepository.GetAllAsync(cancellationToken))
                .Ensure(x => x is not null,
                    _globalStringLocalizer.GetString(Core.Resources.GlobalConstants.InternalServerError).ToStringArray())
                .Map(_mapper.Map<IEnumerable<TOut>>);
        }
        public async Task<Result<IEnumerable<TOut>>> ListAsync<TOut>(IPaging paging, CancellationToken cancellationToken)
        {
            paging.OrderBy ??= "Id";

            return Result.Create(await _unitOfWork.GenericRepository.ListAsync(paging, cancellationToken))
                .Ensure(x => x is not null,
                    _globalStringLocalizer.GetString(Core.Resources.GlobalConstants.InternalServerError).ToStringArray())
                .Map(_mapper.Map<IEnumerable<TOut>>);
        }
        public async Task<Result<int>> CountAsync(CancellationToken cancellationToken)
        {
            return Result.Create(await _unitOfWork.GenericRepository.CountAsync(cancellationToken));
        }
        public async Task<Result> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _unitOfWork.GenericRepository.AddAsync(entity, cancellationToken);

            return Result.Success();
        }
        public Result Update(T entity)
        {
            _unitOfWork.GenericRepository.Update(entity);

            return Result.Success();
        }
        public Result Delete(T entity)
        {
            _unitOfWork.GenericRepository.Delete(entity);

            return Result.Success();
        }
        public async Task<Result<TOut>> GetByKeyAsync<TOut>(TKey id, CancellationToken cancellationToken)
        {
            return Result.Create(await _unitOfWork.GenericRepository.GetByKeyAsync(id, cancellationToken))
                .Ensure(x => x is not null,
                    _globalStringLocalizer.GetString(Core.Resources.GlobalConstants.InternalServerError).ToStringArray())
                .Map(_mapper.Map<TOut>);
        }
        public async Task<Result<bool>> ExistsAsync(TKey id, CancellationToken cancellationToken)
        {
            return Result.Create(await _unitOfWork.GenericRepository.ExistsAsync(id, cancellationToken));
        }
    }
}
