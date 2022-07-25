using WebApi.Interfaces;

namespace WebApi.Services
{
    public class HiWorldService : IHiWorldInterface
    {
        public string GetHiWorld()
        {
            return "Hi World!!!!!!!!";
        }
    }
}