using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sfoxservice.Services
{
    public class PricingRequest
    {
        public string assetPair { get; set; }
        public decimal amount { get; set; }
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
        public string order_id { get; set; }
        public string client_order_id { get; set; }
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

    public enum OrderAction {
        buy,
        sell,
    }

    public interface ISFoxApiClient
    {
        Task<PricingResponse> GetBestPrice(OrderAction action, string assetPair, decimal amount);
        Task<IEnumerable<BalanceResponse>> GetBalances();
        Task<IEnumerable<TradeHistoryResponse>> GetTradeHistory();
        Task<OrderStatusResponse> GetOrderStatus(int orderId);
        Task CancelOrder(int orderId);
        Task<IDictionary<string, AssetPairResponse>> GetAssetPairs();
        Task<OrderStatusResponse> CreateMarketOrder(OrderAction action, decimal quantity, string currencyPair);
        Task<OrderStatusResponse> CreateLimitOrder(OrderAction action, decimal quantity, string currencyPair, decimal price);
    }
}