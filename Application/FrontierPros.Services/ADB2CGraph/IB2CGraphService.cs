using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FrontierPros.Services.ADB2CGraph
{
	public interface IB2CGraphService
	{
		Task<string> GetUserByObjectIdAsync(string objectId);

		Task<string> GetAllUsersAsync(string query);

		Task<string> CreateUserAsync(object data);

		Task<string> UpdateUserAsync(string objectId, object data);

		Task<string> DeleteUserAsync(string objectId);
	}
}
