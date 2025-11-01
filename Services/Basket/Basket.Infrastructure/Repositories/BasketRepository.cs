using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository(IDistributedCache redisCache) : IBasketRepository
    {
        private readonly IDistributedCache _redisCache = redisCache;

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket))
            {
                return null;
            }
            return JsonSerializer.Deserialize<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart cart)
        {
            //check key or username is exist or not to prevent duplicate data of username
            var basket = await _redisCache.GetStringAsync(cart.UserName);
            if (string.IsNullOrEmpty(basket))
            {
                //key is not exist create new basket
                await _redisCache.SetStringAsync(cart.UserName, JsonSerializer.Serialize(cart));
                return await GetBasket(cart.UserName);
            }
            else
            {
                //key is exist update basket
                //var existingBasket = JsonSerializer.Deserialize<ShoppingCart>(basket);
                //existingBasket.Items = cart.Items;
                //basket = JsonSerializer.Serialize(existingBasket);
                return await GetBasket(cart.UserName); //return error message that basket is already exist
            }

           
        }

        public async Task<bool> DeleteBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if (!string.IsNullOrEmpty(basket))
            {
                await _redisCache.RemoveAsync(userName);
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
