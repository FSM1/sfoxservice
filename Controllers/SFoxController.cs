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

        [HttpGet("order/{id}")]
        public async Task<ActionResult<OrderStatusResponse>> GetOrderStatus(int id)
        {
            var order = await _api.GetOrderStatus(id);
            return order;
        }

        [HttpDelete("order/{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _api.CancelOrder(id);
            return null;
        }

        [HttpPost("order/market")]
        public async Task<ActionResult<OrderStatusResponse>> CreateMarketOrder(OrderAction action, decimal quantity, string currencyPair)
        {
            var order = await _api.CreateMarketOrder(action, quantity, currencyPair);
            return order;
        }

        [HttpPost("order/limit")]
        public async Task<ActionResult<OrderStatusResponse>> CreateLimitOrder(OrderAction action, decimal quanitity, string currencyPair, decimal price)
        {
            var order = await _api.CreateLimitOrder(action, quanitity, currencyPair, price);
            return order;
        }

        [HttpGet("tradeHistory")]
        public async Task<ActionResult<IEnumerable<TradeHistoryResponse>>> GetTradeHistory()
        {
            var tradehistory = await _api.GetTradeHistory();
            return tradehistory.ToList();
        }

        [HttpGet("bestPrices")]
        public async Task<ActionResult<IDictionary<string, PricingResponse>>> GetBestPrices([FromQuery] IDictionary<string, decimal> pricingRequests)
        {
            var results = await Task.WhenAll(pricingRequests.Select(async req =>
            {
                var priceResponse = await _api.GetBestPrice(OrderAction.buy, req.Key, req.Value);
                return new KeyValuePair<string, PricingResponse>(req.Key, priceResponse);
            }));

            return results.ToDictionary(r => r.Key, r => r.Value);
        }
    }
}
