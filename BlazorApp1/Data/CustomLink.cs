namespace BlazorApp1.Data
{
    public class CustomLink
    {
        public CustomLink(string title, string link)
        {
            Title = title;
            Link = link;
        }

        public string Title { get; set; }
        public string Link { get; set; }

        public static List<CustomLink> getCustomLinks()
        {
            var links = new List<CustomLink>();
            links.Add(new CustomLink("Index", "/"));
            links.Add(new CustomLink("Counter", "/counter"));
            links.Add(new CustomLink("Weather Forecast", "/fetchdata"));
            links.Add(new CustomLink("Custom Page", "/custom"));
            return links;
        }
    }
}
