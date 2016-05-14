using System.Web;

namespace BLL
{
    public class TravoExceptions
    {
        public static HttpException NotFound()
        {
            return new HttpException(404, "Not found");
        }

        public static HttpException Forbidden()
        {
            return new HttpException(403, "Forbidden");
        }
    }
}
