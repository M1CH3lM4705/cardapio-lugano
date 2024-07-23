
using Appwrite.Models;
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Models;
public class Cart : BaseModel
{
    public static readonly string Carts = "shoppingCart";
    public Cart()
    {

    }

    public Cart(string customerId, double? totalAmout)
    {
        CustomerId = customerId;
        TotalAmount = totalAmout;
    }

    [JsonProperty("customerId")]
    public string? CustomerId { get; set; }

    [JsonProperty("totalAmount")]
    public double? TotalAmount { get; set; } = default;

    [JsonProperty("shoppingCartItems")]
    public List<CartItem> CartItems { get; set; } = [];
    public override Dictionary<string, object?> ToMap()
    {
        return new Dictionary<string, object?>
        {
            { "customerId", CustomerId },
            { "totalAmount", TotalAmount },
            { "shoppingCartItems", CartItems },
        };
    }

    public static implicit operator Cart(Document data) =>
        new Cart().ConvertTo<Cart>(data);

    public void CalculateValuesCartItems() =>
        TotalAmount = CartItems.Sum(c => c.CalculateValue());

    public (bool Exists, string? Id) CartItemsExists(CartItem item)
    {
        var exists = CartItems.Any(c => c.ProductId == item.ProductId);

        var id = exists ? CartItems.FirstOrDefault(c => c.ProductId == item?.ProductId)!.Id : null;

        return (exists, id);
    }

    public CartItem GetProductId(string productId) =>
        CartItems.FirstOrDefault(c => c.ProductId!.Equals(productId))!;

    public void AddCartItem(CartItem item)
    {
        item.AssociateCart(Id!);

        var (Exists, _) = CartItemsExists(item);

        if (Exists)
        {
            var exist = GetProductId(item.ProductId!);

            exist.AddUnit(item.Quantity);

            item = exist;

            CartItems.Remove(exist);
        }

        CartItems.Add(item);
        CalculateValuesCartItems();
    }

    public void RemoveCartItem(CartItem item)
    {
        var (Exists, _) = CartItemsExists(item);

        if (!Exists) return;

        var exist = GetProductId(item.ProductId!);
        
        if(exist.Quantity >= 1)
        {
            exist.RemoveUnit();
            CalculateValuesCartItems();
            return;
        }
        CartItems.Remove(GetProductId(item.ProductId!));

    }

}
