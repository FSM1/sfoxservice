using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sfoxservice.Services
{
    public class PricingRequest
    {
        public string assetName { get; set; }
        public float amount { get; set; }
    }
    
    public class PricingResponse
    {
        public decimal quantity { get; set; }
        public decimal vwap { get; set; }
        public decimal price { get; set; }
        public decimal fees { get; set; }
        public decimal total { get; set; }
    }

    public class BalanceResponse
    {
        public string currency { get; set; }
        public decimal balance { get; set; }
        public decimal available { get; set; }
        public decimal held { get; set; }
        public int WalletTypeId { get; set; }
    }

    public class TradeHistoryResponse
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int client_order_id { get; set; }
        public DateTime day { get; set; }
        public string action { get; set; }
        public string currency { get; set; }
        public string memo { get; set; }
        public decimal amount { get; set; }
        public decimal net_proceeds { get; set; }
        public decimal price { get; set; }
        public decimal fees { get; set; }
        public string status { get; set; }
        public string hold_expires { get; set; }
        public string tx_hash { get; set; }
        public string algo_name { get; set; }
        public string algo_id { get; set; }
        public decimal account_balance { get; set; }
        public decimal AccountTransferFee { get; set; }
    }

    public class OrderStatusResponse
    {
        public int id { get; set; }
        public decimal quantity { get; set; }
        public decimal price { get; set; }
        public string o_action { get; set; }
        public string pair { get; set; }
        public string type { get; set; }
        public decimal vwap { get; set; }
        public int filled { get; set; }
        public string status { get; set; }
    }

    public class AssetPairResponse
    {
        public string formatted_symbol { get; set; }
        public string symbol { get; set; }
    }

    public interface ISFoxApiClient
    {
        Task<PricingResponse> GetBestPriceAsync(string assetName, float amount);
        Task<IEnumerable<PricingResponse>> GetBestPriceAsync(List<PricingRequest> requests);
        Task<IEnumerable<BalanceResponse>> GetBalances();
        Task<IEnumerable<TradeHistoryResponse>> GetTradeHistory();
        Task<OrderStatusResponse> CreateBuyMarketOrder(float quanitity, string currencyPair);
        Task<OrderStatusResponse> CreateBuyLimitOrder(float quanitity, string currencyPair, decimal price);
        Task<OrderStatusResponse> CreateSellMarketOrder(float quanitity, string currencyPair);
        Task<OrderStatusResponse> CreateSellLimitOrder(float quanitity, string currencyPair, decimal price);
        Task<OrderStatusResponse> GetOrderStatus(int orderId);
        Task CancelOrder(int orderId);
        Task<IDictionary<string, AssetPairResponse>> GetAssetPairs();
    }
}