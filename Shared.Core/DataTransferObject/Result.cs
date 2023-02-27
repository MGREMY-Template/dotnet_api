using System.Collections.Generic;

namespace Shared.Core.DataTransferObject
{
	public abstract class Result
	{
		public bool IsSuccess { get; }
		public bool IsFailure => !IsSuccess;
		public IEnumerable<string> Message { get; protected set; }

		protected Result(bool isSuccess)
		{
			IsSuccess = isSuccess;
		}

#nullable enable
		public static Result<TResult> Create<TResult>(TResult value, string? errorMessage = null) =>
			Result<TResult>.Success(value);
#nullable restore
	}

	public class Result<TResult> : Result
	{
		public TResult Value { get; protected set; }

		protected Result(bool isSuccess, TResult result) : base(isSuccess)
		{
			Value = result;
		}
		protected Result(bool isSuccess, IEnumerable<string> message) : base(isSuccess)
		{
			Message = message;
		}


		public static Result<TResult> Success(TResult result)
		{
			return new Result<TResult>(true, result);
		}
		public static Result<TResult> Failure(IEnumerable<string> message)
		{
			return new Result<TResult>(false, message);
		}
	}
}
