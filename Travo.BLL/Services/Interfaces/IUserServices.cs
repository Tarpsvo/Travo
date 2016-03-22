using System.Threading.Tasks;
using Travo.BLL.DTO;

namespace Travo.BLL.Services
{
    public interface IUserServices
    {
        Task<bool> Register(UserDTO userDTO);
        bool Login(UserDTO userDTO);
    }
}
