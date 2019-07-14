namespace WinFormsMVC
{
    public class RouteAttribute : System.Attribute
    {
        public string Route { get; set; }
        
        public RouteAttribute()
        {
        }

        public RouteAttribute(string route)
        {
            Route = route;
        }
    }
}
