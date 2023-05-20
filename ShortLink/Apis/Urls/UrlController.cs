using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortLink.Models;

namespace ShortLink.Apis.Urls
{
    [ApiController]
    [Route("api/v{version:ApiVersion}/url")]
    [ApiVersion("1.0")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet("/{hash}")]
        public async Task<ActionResult> AccessShortLink(string hash)
        {
            UrlModel urlModel = await _urlService.UnShorten(new UnShortenParam { Hash = hash });

            // tracking here

            return Redirect(urlModel.OriginalUrl);
        }

        [HttpGet("{hash}")]
        public async Task<ActionResult> UnShorten(string hash)
        {
            UrlModel urlModel = await _urlService.UnShorten(new UnShortenParam { Hash = hash });
            return Ok(urlModel);
        }

        [HttpPost("shorten")]
        public async Task<ActionResult> Shorten([FromBody] ShortenParam shortenParam)
        {
            UrlModel urlModel = await _urlService.Shorten(shortenParam);;
            return Ok(urlModel);
        }
        
        [HttpPost("update-metadata")]
        public async Task<ActionResult> UpdateMetaData([FromBody] UpdateMetaDataParam updateMetaDataParam)
        {
            UrlModel urlModel = await _urlService.UpdateMetaData(updateMetaDataParam);
            return Ok(urlModel);
        }
    }
}