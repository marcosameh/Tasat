using AppCore.Common;
using AppCore.Infrastructure;

namespace AppCore.Contracts
{
    public interface ISendMail
    {
        Result Send(Email emialDetails);
    }
}
