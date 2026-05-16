using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using SklepSDKW_EF.DAL;
using SklepSDKW_EF.Models;

namespace SklepSDKW_EF.Infrastructure
{
    public static class CartManager
    {
        // ZMIANA: FilmsContext zastąpiony Twoim SklepContext
        public static void AddToCart(ISession session, SklepContext db, int filmId)
        {
            var cart = GetItems(session);

            var thisFilm = cart.Find(f => f.Film.Id == filmId);

            if (thisFilm != null)
            {
                thisFilm.Quantity++;
            }
            else
            {
                // Wskazówka: Jeśli po wklejeniu podkreśli Ci słowo ".Films", 
                // zmień je na ".Filmy" (zależnie od tego, jak nazwałaś tabelę w SklepContext)
                var newCartItem = db.Filmy.Find(filmId);

                if (newCartItem != null)
                {
                    var cartItem = new CartItem
                    {
                        Film = newCartItem,
                        Quantity = 1,
                        Value = newCartItem.Price
                    };

                    cart.Add(cartItem);
                }
            }

            SessionHelper.SetObjectAsJson(session, Consts.CartSessionKey, cart);
        }

        public static List<CartItem> GetItems(ISession session)
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(session, Consts.CartSessionKey);

            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }

        public static decimal? GetCartTotalValue(ISession session)
        {
            var cart = GetItems(session);

            return cart.Sum(c => c.Quantity * c.Value);
        }

        public static int RemoveFromCart(ISession session, int id)
        {
            var cart = GetItems(session);

            var thisFilm = cart.Find(f => f.Film.Id == id);

            if (thisFilm == null) return 0;

            int count = 0;

            if (thisFilm.Quantity > 1)
            {
                thisFilm.Quantity--;
                count = thisFilm.Quantity;
            }
            else
            {
                cart.Remove(thisFilm);
            }

            SessionHelper.SetObjectAsJson(session, Consts.CartSessionKey, cart);

            return count;
        }

        public static int GetCartQuantity(ISession session)
        {
            var cart = GetItems(session);

            return cart.Sum(i => i.Quantity);
        }
    }
}