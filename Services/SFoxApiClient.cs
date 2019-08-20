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

        public Task<IDictionary<string, AssetPairResponse>> GetAssetPairs()
        {
            throw new System.NotImplementedException();
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

        Task<OrderStatusResponse> ISFoxApiClient.CreateBuyLimitOrder(float quanitity, string currencyPair, decimal price)
        {
            throw new System.NotImplementedException();
        }

        Task<OrderStatusResponse> ISFoxApiClient.CreateBuyMarketOrder(float quanitity, string currencyPair)
        {
            throw new System.NotImplementedException();
        }

        Task<OrderStatusResponse> ISFoxApiClient.CreateSellLimitOrder(float quanitity, string currencyPair, decimal price)
        {
            throw new System.NotImplementedException();
        }

        Task<OrderStatusResponse> ISFoxApiClient.CreateSellMarketOrder(float quanitity, string currencyPair)
        {
            throw new System.NotImplementedException();
        }

        Task<IDictionary<string, AssetPairResponse>> ISFoxApiClient.GetAssetPairs()
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<BalanceResponse>> ISFoxApiClient.GetBalances()
        {
            throw new System.NotImplementedException();
        }

        Task<PricingResponse> ISFoxApiClient.GetBestPriceAsync(string assetName, float amount)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<PricingResponse>> ISFoxApiClient.GetBestPriceAsync(List<PricingRequest> requests)
        {
            throw new System.NotImplementedException();
        }

        Task<OrderStatusResponse> ISFoxApiClient.GetOrderStatus(int orderId)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<TradeHistoryResponse>> ISFoxApiClient.GetTradeHistory()
        {
            throw new System.NotImplementedException();
        }
    }
}