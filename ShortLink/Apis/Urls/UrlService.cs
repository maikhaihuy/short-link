using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data;

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
            long timestampNow = DateTimeHelpers.GetTimestamp(DateTime.UtcNow);
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
            var urlModel = _mapper.Map<UrlModel>(urlEntry.Entity);
            return urlModel;
        }

        public async Task<UrlModel> UnShorten(UnShortenParam unShortenParam)
        {
            // validate

            // prepare
            long timestampHash = ShortenerHelpers.Base62ToBase10(unShortenParam.Hash);

            // execute
            Url url = DbContext.Urls.Where(u => u.Hash == unShortenParam.Hash).FirstOrDefault();
            if (url is null)
            {
                throw new KeyNotFoundException();
            }

            // transfer
            var urlModel = _mapper.Map<UrlModel>(url);
            return urlModel;
        }

        public async Task<UrlModel> UpdateMetaData(UpdateMetaDataParam updateMetaDataParam)
        {
            // validate
            Url url = await DbContext.Urls.FindAsync(updateMetaDataParam.Id);
            if (url == null)
                throw new KeyNotFoundException($"{updateMetaDataParam.Id} not found!");

            // prepare
            url = _mapper.Map<Url>(updateMetaDataParam);
            
            // execute
            var urlEntry = DbContext.Urls.Update(url);
            await DbContext.SaveChangesAsync();
            
            // transfer
            var urlModel = _mapper.Map<UrlModel>(urlEntry.Entity);
            return urlModel;
        }
    }
}