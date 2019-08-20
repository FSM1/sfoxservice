using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sfoxservice.Services;

namespace sfoxservice.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SFoxController : ControllerBase
    {
        private ISFoxApiClient _api;
        public SFoxController(ISFoxApiClient api) => _api = api;
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("balances")]
        public async Task<ActionResult<IEnumerable<BalanceResponse>>> GetBalances() 
        {
            var balances = await _api.GetBalances();
            return balances.ToList();
        }

        [HttpGet("assetPairs")]
        public async Task<ActionResult<IEnumerable<AssetPairResponse>>> GetAssetPairs()
        {
            var assetPairs = await _api.GetAssetPairs();
            return assetPairs.Values.ToList();
        }
    }
}
