using System;
using System.Collections.Generic;
using System.Net;
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

        public Task CancelOrder(int orderId)
        {
            return InvokeAsync<object>(
                client => client.DeleteAsync($"orders/{orderId}"));
        }

        public Task<OrderStatusResponse> CreateMarketOrder(OrderAction action, decimal quantity, string currencyPair)
        {
            var req = new
            {
                quantity = quantity,
                currency_pair = currencyPair,
            };
            return InvokeAsync(
                client => client.PostAsJsonAsync($"orders/{action.ToString()}", req),
                response => response.Content.ReadAsAsync<OrderStatusResponse>());
        }

        public Task<OrderStatusResponse> CreateLimitOrder(OrderAction action, decimal quantity, string currencyPair, decimal price)
        {
            var req = new
            {
                quantity = quantity,
                currency_pair = currencyPair,
                price = price
            };
            return InvokeAsync(
                client => client.PostAsJsonAsync($"orders/{action.ToString()}", req),
                response => response.Content.ReadAsAsync<OrderStatusResponse>());
        }

        public Task<IDictionary<string, AssetPairResponse>> GetAssetPairs()
        {
            return InvokeAsync(
                client => client.GetAsync("markets/currency-pairs"),
                response => response.Content.ReadAsAsync<IDictionary<string, AssetPairResponse>>());
        }

        public Task<IEnumerable<BalanceResponse>> GetBalances()
        {
            return InvokeAsync(
                client => client.GetAsync("user/balance"),
                response => response.Content.ReadAsAsync<IEnumerable<BalanceResponse>>());
        }

        public Task<PricingResponse> GetBestPrice(OrderAction action, string assetPair, decimal amount)
        {
            return InvokeAsync(
                client => client.GetAsync($"offer/{action}?amount={amount}&pair={assetPair}"),
                response => response.Content.ReadAsAsync<PricingResponse>());
        }

        public Task<OrderStatusResponse> GetOrderStatus(int orderId)
        {
            return InvokeAsync(
                client => client.GetAsync($"orders/{orderId}"),
                response => response.Content.ReadAsAsync<OrderStatusResponse>());
        }

        public Task<IEnumerable<TradeHistoryResponse>> GetTradeHistory()
        {
            return InvokeAsync(
                client => client.GetAsync("account/transactions"),
                response => response.Content.ReadAsAsync<IEnumerable<TradeHistoryResponse>>());
        }

        private async Task<T> InvokeAsync<T>(Func<HttpClient, Task<HttpResponseMessage>> operation,
            Func<HttpResponseMessage, Task<T>> actionOnResponse = null)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            HttpResponseMessage response = await operation(_httpClient).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var exception = new Exception($"SFOX API returned an error. StatusCode : {response.StatusCode}");
                exception.Data.Add("StatusCode", response.StatusCode);
                throw exception;
            }
            if (actionOnResponse != null)
            {
                return await actionOnResponse(response).ConfigureAwait(false);
            }
            else
            {
                return default(T);
            }
        }
    }
}