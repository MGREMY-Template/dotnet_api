namespace Shared.Core.Extensions;

using Shared.Core.DataTransferObject;
using System;
using System.Threading.Tasks;

public static partial class ResultExtensions
{
    public static Result<T> Ensure<T>(
        this Result<T> result,
        Func<T, bool> predicate,
        int failureStatusCode,
        params string[] errors) => result.IsFailure
            ? result
            : predicate(result.Value) ?
            result :
            Result<T>.Failure(failureStatusCode, errors);

    public static Result<T> Ensure<T>(
        this Result<T> result,
        Func<T, (bool, string[])> predicate,
        int failureStatusCode)
    {
        if (result.IsFailure)
        {
            return result;
        }

        (var isSuccess, var errors) = predicate(result.Value);

        return isSuccess ?
            result :
            Result<T>.Failure(failureStatusCode, errors);
    }

    public static Result<TOut> Map<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> mappingFunc) => result.IsSuccess ?
            Result<TOut>.Success(mappingFunc(result.Value), result.StatusCode) :
            Result<TOut>.Failure(result.StatusCode, result.Messages);
}

public static partial class ResultExtensions
{
    public static Result<T> EnsureAsync<T>(
        this Result<T> result,
        Func<T, Task<bool>> predicate,
        int failureStatusCode,
        params string[] errors) => result.IsFailure
            ? result
            : new TaskFactory().StartNew(() => predicate(result.Value)).Unwrap().GetAwaiter().GetResult() ?
            result :
            Result<T>.Failure(failureStatusCode, errors);

    public static Result<T> EnsureAsync<T>(
        this Result<T> result,
        Func<T, Task<(bool, string[])>> predicate,
        int failureStatusCode)
    {
        if (result.IsFailure)
        {
            return result;
        }

        (var isSuccess, var errors) = new TaskFactory().StartNew(() => predicate(result.Value)).Unwrap().GetAwaiter().GetResult();

        return isSuccess ?
            result :
            Result<T>.Failure(failureStatusCode, errors);
    }

    public static Result<TOut> MapAsync<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, Task<TOut>> mappingFunc) => result.IsSuccess ?
            Result<TOut>.Success(new TaskFactory().StartNew(() => mappingFunc(result.Value)).Unwrap().GetAwaiter().GetResult(), result.StatusCode) :
            Result<TOut>.Failure(result.StatusCode, result.Messages);
}
