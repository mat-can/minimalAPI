using WebApi.Interfaces;

namespace WebApi.Services
{
    public class HiWorldService : IHiWorlService
    {
        public string GetHiWorld()
        {
            return "Hi World!!!!!!!!";
        }
    }
}