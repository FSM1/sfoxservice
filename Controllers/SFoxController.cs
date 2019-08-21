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

        [HttpPost("order/market/buy")]
        public async Task<ActionResult<OrderStatusResponse>> CreateBuyMarketOrder(decimal quanitity, string currencyPair)
        {
            var order = await _api.CreateBuyMarketOrder(quanitity, currencyPair);
            return order;
        }

        [HttpPost("order/market/sell")]
        public async Task<ActionResult<OrderStatusResponse>> CreateSellMarketOrder(decimal quanitity, string currencyPair)
        {
            var order = await _api.CreateSellMarketOrder(quanitity, currencyPair);
            return order;
        }

        [HttpPost("order/limit/buy")]
        public async Task<ActionResult<OrderStatusResponse>> CreateBuyLimitOrder(decimal quanitity, string currencyPair, decimal price)
        {
            var order = await _api.CreateBuyLimitOrder(quanitity, currencyPair, price);
            return order;
        }

        [HttpPost("order/limit/sell")]
        public async Task<ActionResult<OrderStatusResponse>> CreateSellLimitOrder(decimal quanitity, string currencyPair, decimal price)
        {
            var order = await _api.CreateSellLimitOrder(quanitity, currencyPair, price);
            return order;
        }

        [HttpGet("tradeHistory")]
        public async Task<ActionResult<IEnumerable<TradeHistoryResponse>>> GetTradeHistory()
        {
            var tradehistory = await _api.GetTradeHistory();
            return tradehistory.ToList();
        }
    }
}
