using System.Threading.Tasks;
using Travo.BLL.DTO;

namespace Travo.BLL.Services
{
    public interface IAccountServices
    {
        Task<bool> Register(UserDTO userDTO);
        bool Login(UserDTO userDTO);
    }
}
