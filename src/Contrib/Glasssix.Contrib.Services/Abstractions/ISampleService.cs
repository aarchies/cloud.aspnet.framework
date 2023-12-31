﻿using Glasssix.Contrib.Domain.Shared;
using Glasssix.Contrib.Domain.Shared.Dtos;
using Glasssix.Contrib.Services.Abstractions.Operations;

namespace Glasssix.Contrib.Services.Abstractions
{
    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface ISampleService<TDto, in TQueryParameter> : ISampleService<TDto, TDto, TQueryParameter>
        where TDto : IDto, new()
        where TQueryParameter : IQueryParameters
    {
    }

    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TRequest">参数类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface ISampleService<TDto, in TRequest, in TQueryParameter> : ISampleService<TDto, TRequest, TRequest, TRequest, TQueryParameter>
        where TDto : IDto, new()
        where TRequest : IRequest, IKey, new()
        where TQueryParameter : IQueryParameters
    {
    }

    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TRequest">参数类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface ISampleService<TDto, in TRequest, in TCreateRequest, in TUpdateRequest, in TQueryParameter> : IQueryService<TDto, TQueryParameter>,
        ICreate<TCreateRequest>, IUpdate<TUpdateRequest>, IDelete,
        ICreateAsync<TCreateRequest>, IUpdateAsync<TUpdateRequest>, IDeleteAsync, ISaveAsync<TRequest>, IBatchSaveAsync<TDto>
        where TDto : IDto, new()
        where TRequest : IRequest, IKey, new()
        where TCreateRequest : IRequest, new()
        where TUpdateRequest : IRequest, new()
        where TQueryParameter : IQueryParameters
    {
    }
}