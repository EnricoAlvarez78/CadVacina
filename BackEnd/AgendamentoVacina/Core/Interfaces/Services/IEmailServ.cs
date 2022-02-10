using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IEmailServ
    {
        Task SendEmailAsync(string emailPara, string assunto, string menssagem);
    }
}