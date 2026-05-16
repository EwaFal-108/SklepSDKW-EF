using SklepSDKW_EF.Modele;

namespace SklepSDKW_EF.Infrastructure
{
    public class CartItem
    {
        public Film Film { get; set; }

        public int Quantity { get; set; }

        public decimal? Value { get; set; }

    }
}

