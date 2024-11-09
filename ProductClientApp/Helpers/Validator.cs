namespace ProductClientApp.Helpers
{
    public static class Validator
    {
        public static bool IsValidPrice(decimal price)
        {
            return price > 0;
        }

        public static bool IsValidStock(int stock)
        {
            return stock >= 0;
        }
    }
}