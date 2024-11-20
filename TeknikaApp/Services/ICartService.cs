using TeknikaApp.Models;

namespace TeknikaApp.Services;

public interface ICartService
{
    Task<IEnumerable<CartItemModel>> GetCartItemsAsync();
    Task<CartItemModel> GetCartItemAsync(int id);
    Task<IEnumerable<OrderLineModel>> GetOrderLinesAsync(int orderId);
    Task<decimal> CalcItemPriceAsync(CartItemModel cartItem);
    Task AddCartItemAsync(CartItemModel cartItem);
    Task DelCartItemAsync(int cartItemId);
    Task EditCartItemAsync(CartItemModel cartItem);
    Task CheckOptionalConflictsAsync(CartItemModel cartItem);
    Task ConfirmCartInOrderAsync(CartItemModel cartConfirm);
    Task FlushCartAsync();
}