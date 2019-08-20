using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace sfoxservice.Services
{

    public class SFoxApiClient: ISFoxApiClient
    {
        private readonly HttpClient _httpClient;

        public SFoxApiClient(HttpClient client)
        {
            _httpClient = client;
        }

        public Task CancelOrder(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderStatusResponse> CreateBuyLimitOrder(float quanitity, string currencyPair, decimal price)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderStatusResponse> CreateBuyMarketOrder(float quanitity, string currencyPair)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderStatusResponse> CreateSellLimitOrder(float quanitity, string currencyPair, decimal price)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderStatusResponse> CreateSellMarketOrder(float quanitity, string currencyPair)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IDictionary<string, AssetPairResponse>> GetAssetPairs()
        {
            var uri = "markets/currency-pairs";
            var response = await _httpClient.GetStringAsync(uri);
            var assetPairs = JsonConvert.DeserializeObject<IDictionary<string, AssetPairResponse>>(response);
            return assetPairs;
        }

        public async Task<IEnumerable<BalanceResponse>> GetBalances()
        {
            var uri = "user/balance";
            var response = await _httpClient.GetStringAsync(uri);
            var balances = JsonConvert.DeserializeObject<IEnumerable<BalanceResponse>>(response);
            return balances;
        }

        public Task<PricingResponse> GetBestPriceAsync(string assetName, float amount)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PricingResponse>> GetBestPriceAsync(List<PricingRequest> requests)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderStatusResponse> GetOrderStatus(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TradeHistoryResponse>> GetTradeHistory()
        {
            throw new System.NotImplementedException();
        }

        Task ISFoxApiClient.CancelOrder(int orderId)
        {
            throw new System.NotImplementedException();
        }
    }
}