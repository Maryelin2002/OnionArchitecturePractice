namespace SolvexWorkShop.Core.Settings
{
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }

        public ConnectionStrings()
        {
            DefaultConnection = "Server=.; Initial Catalog=WorkShop2;Persist Security Info=True;Integrated Security=True;MultipleActiveResultSets=True;";
        }
    }
}
