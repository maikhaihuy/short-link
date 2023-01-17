using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ShortLink.Base;
using ShortLink.Common.Helpers;
using ShortLink.EntityFramework;
using ShortLink.EntityFramework.Entities;
using ShortLink.Models;

namespace ShortLink.Apis.Urls
{
    public class UrlService : BaseService, IUrlService
    {
        private readonly IMapper _mapper;
        public UrlService(IMapper mapper, ShortLinkDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
            _mapper = mapper;
        }

        public async Task<UrlModel> Shorten(ShortenParam shortenParam)
        {
            // validate
            
            // prepare
            int timestampNow = DateTimeHelpers.GetTimestamp(DateTime.UtcNow);
            string hash = ShortenerHelpers.Base10ToBase62(timestampNow);
            Url url = new()
            {
                Hash = hash,
                OriginalUrl = shortenParam.Url
            };

            // execute
            var urlEntry = DbContext.Urls.Add(url);
            await DbContext.SaveChangesAsync();

            // transfer
            var urlModel = _mapper.Map<UrlModel>(urlEntry);
            return urlModel;
        }

        public Task<UrlModel> UnShorten(UnShortenParam unShortenParam)
        {
            throw new NotImplementedException();
        }

        public async Task<UrlModel> UpdateMetaData(UpdateMetaDataParam updateMetaDataParam)
        {
            // validate
            Url url = await DbContext.Urls.FindAsync(updateMetaDataParam.Id);
            if (url == null)
                throw new KeyNotFoundException($"{updateMetaDataParam.Id} not found!");

            // prepare
            url.Title = updateMetaDataParam.Title;
            url.Thumbnail = updateMetaDataParam.Thumbnail;
            url.Description = updateMetaDataParam.Description;
            
            // execute
            var urlEntry = DbContext.Urls.Update(url);
            await DbContext.SaveChangesAsync();
            
            // transfer
            var urlModel = _mapper.Map<UrlModel>(urlEntry);
            return urlModel;
        }
    }
}