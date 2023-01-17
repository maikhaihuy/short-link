using System.ComponentModel.DataAnnotations;

namespace ShortLink.Apis.Urls
{
    public class ShortenParam
    {
        public string Url { get; set; }
    }
    
    public class UnShortenParam
    {
        public string Hash { get; set; }
    }

    public class UpdateMetaDataParam
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
    }
}