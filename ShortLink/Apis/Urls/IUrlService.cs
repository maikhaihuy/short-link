using System.Threading.Tasks;
using ShortLink.Models;

namespace ShortLink.Apis.Urls
{
    public interface IUrlService
    {
        public Task<UrlModel> Shorten(ShortenParam shortenParam);
        public Task<UrlModel> UnShorten(UnShortenParam unShortenParam);
        public Task<UrlModel> UpdateMetaData(UpdateMetaDataParam updateMetaDataParam);
    }
}