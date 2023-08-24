using WebCookingBook.DbContexts;

namespace WebCookingBook.Service
{
    public class ApplicationRepository: IApplicationRepository
    {
        private readonly ApplicationContext _context;

        public ApplicationRepository(ApplicationContext context) 
        {
            this._context = context;
        }
    }
}
