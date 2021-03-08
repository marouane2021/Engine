namespace Engine.Domain.Models
{
    public class BackGroundImage
    {
        public string Alt { get; set; } // the text of the image
        public bool IsEnable { get; set; } // the background image is enable or not
        public bool OpenInNewTab { get; set; } // open the image in new tab or not
        public int Order { get; set; } //the order
        public string UrlImageDesktop { get; set; } //url image desktop
        public string UrlLinkDesktop { get; set; } //url link desktop
        public string UrlImageMobile { get; set; } //url image mobile
        public string UrlLinkMobile { get; set; } // url link mobile
    }
}
