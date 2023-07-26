using FrestyEcommerce.Shared.Dtos;

namespace FrestyEcommerce.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponseDto>>> GetCartProducts(List<CartItem> cartItem);
    }
}
