using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace sfoxservice.Services
{
    public class SFoxApiClient : ISFoxApiClient
    {
        private readonly HttpClient _httpClient;

        public SFoxApiClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task CancelOrder(int orderId)
        {
            var uri = $"orders/{orderId}";
            await _httpClient.DeleteAsync(uri);
        }

        public async Task<OrderStatusResponse> CreateBuyLimitOrder(decimal quantity, string currencyPair, decimal price)
        {
            var uri = $"orders/buy";
            var req = new {
                quantity = quantity,
                currency_pair = currencyPair,
                price = price
            };            
            var reqBody = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, reqBody);
            var order = JsonConvert.DeserializeObject<OrderStatusResponse>(await response.Content.ReadAsStringAsync());
            return order;
        }

        public async Task<OrderStatusResponse> CreateBuyMarketOrder(decimal quantity, string currencyPair)
        {
            var uri = $"orders/buy";
            var req = new {
                quantity = quantity,
                currency_pair = currencyPair
            };
            var reqBody = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, reqBody);
            var order = JsonConvert.DeserializeObject<OrderStatusResponse>(await response.Content.ReadAsStringAsync());
            return order;
        }

        public async Task<OrderStatusResponse> CreateSellLimitOrder(decimal quantity, string currencyPair, decimal price)
        {
            var uri = $"orders/sell";
            var req = new {
                quantity = quantity,
                currency_pair = currencyPair,
                price = price
            };            
            var reqBody = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, reqBody);
            var order = JsonConvert.DeserializeObject<OrderStatusResponse>(await response.Content.ReadAsStringAsync());
            return order;
        }

        public async Task<OrderStatusResponse> CreateSellMarketOrder(decimal quantity, string currencyPair)
        {
            var uri = $"orders/sell";
            var req = new {
                quantity = quantity,
                currency_pair = currencyPair,
            };
            var reqBody = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, reqBody);
            var order = JsonConvert.DeserializeObject<OrderStatusResponse>(await response.Content.ReadAsStringAsync());
            return order;
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

        public async Task<PricingResponse> GetBestPrice(string assetPair, decimal amount)
        {
            // TODO: What about sell price
            var uri = $"offer/buy?amount={amount}&pair={assetPair}";
            var response = await _httpClient.GetStringAsync(uri);
            var pricingResponse = JsonConvert.DeserializeObject<PricingResponse>(response);
            return pricingResponse;
        }

        public async Task<OrderStatusResponse> GetOrderStatus(int orderId)
        {
            var uri = $"orders/{orderId}";
            var response = await _httpClient.GetStringAsync(uri);
            var order = JsonConvert.DeserializeObject<OrderStatusResponse>(response);
            return order;
        }

        public async Task<IEnumerable<TradeHistoryResponse>> GetTradeHistory()
        {
            var uri = "account/transactions";
            var response = await _httpClient.GetStringAsync(uri);
            var assetPairs = JsonConvert.DeserializeObject<IEnumerable<TradeHistoryResponse>>(response);
            return assetPairs;
        }
    }
}