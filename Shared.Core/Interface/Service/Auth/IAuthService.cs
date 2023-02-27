using Shared.Core.DataTransferObject;
using Shared.Core.DataTransferObject.Auth.AuthController;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Interface.Service.Auth
{
	public interface IAuthService
	{
		public Task<Result<SignUpOutput>> SignUpAsync(SignUpInput input, CancellationToken cancellationToken);
		public Task<Result<GetEmailConfirmationTokenOutput>> GetEmailConfirmTokenAsync(GetEmailConfirmationInput input, CancellationToken cancellationToken);
		public Task<Result<ConfirmEmailOutput>> ConfirmEmailAsync(ConfirmEmailInput input, CancellationToken cancellationToken);
		public Task<Result<SignInOutput>> SignInAsync(SignInInput input, CancellationToken cancellationToken);
	}
}
