using System;
using System.Collections.Generic;

namespace ShortLink.EntityFramework.Entities
{
    public partial class Url
    {
        public string Id { get; set; }
        public string Hash { get; set; }
        public string OriginalUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
