using Appwrite;
using CardapioLugano.API.Services.Interfaces;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Models;
using CardapioLugano.Shared.Requests;
using CardapioLugano.Shared.Responses;

namespace CardapioLugano.API.Services;

public class CartServices : ICartServices
{
    private readonly IDal<Cart> _cartDal;
    private readonly IDal<CartItem> _cartItem;

    public CartServices(IDal<Cart> cartDal, IDal<CartItem> cartItem)
    {
        _cartDal = cartDal;
        _cartItem = cartItem;
    }

    public async Task<Response<CartResponse>> AddCartItem(CartItemRequest cartItemRequest)
    {
        CartItem cartItem = 
            new(cartItemRequest.ProductId, 1, cartItemRequest.UnitPrice, cartItemRequest.Name, cartItemRequest.UrlImage);

        var cartDocument = await _cartDal.ListDocuments();

        if (cartDocument is null or { Total: 0 })
            throw new AppwriteException(message:"Não há nenhum carrinho existente", code:500);

        var cart = (Cart)cartDocument.Documents!.FirstOrDefault(x => x.Id == cartItemRequest.CartId)! ?? cartDocument.Documents.First();

        var (Exists, Id) = cart.CartItemsExists(cartItem);


        if(!Exists && string.IsNullOrEmpty(Id))
        {
            cart.AddCartItem(cartItem);
            
        }
        else
        {
            cartItem.Id = Id;
            cart.AddCartItem(cartItem);
        }

        var result = (Cart)await _cartDal.UpdateDocument(cart.Id!, cart);

        return new Response<CartResponse>(result);
    }

    public async Task<Response<CartResponse>> CreateAsync(CartRequest request)
    {
        var cart = new Cart(request.CustomerId!, null);

        try
        {
            var result = (Cart)await _cartDal.CreateDocument(cart);

            return new Response<CartResponse>(result);
        }
        catch (AppwriteException ex)
        {

            return new Response<CartResponse>(null, ex.Code!.Value, ex.Message);
        }
    }

    public async Task<Response<CartResponse>> GetByIdAsync(string id)
    {
        var documento = await _cartDal.GetDocument(id);

        if (documento is null)
            return new Response<CartResponse>(null, code: 404, "Carrinho não encontrado.");
        
        CartResponse cart = (Cart)documento;

        return new Response<CartResponse>(cart);
    }

    public async Task RemoveCartItem(string id)
    {
        CartItem cartItem = await _cartItem.GetDocument(id);

        Cart cart = await _cartDal.GetDocument(cartItem.CartId!);

        var (Exists, _) = cart.CartItemsExists(cartItem);

        if (!Exists) return;

        cart.RemoveCartItem(cartItem);

        await _cartDal.UpdateDocument(cart.Id!, cart);
    }
}
