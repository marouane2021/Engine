namespace Engine.Domain.Models
{
    public class Logo
    {
        public string UrlImageDesktop { get; set; } // url of the desktop image
        public string UrlLinkDesktop { get; set; } // url link desktop
        public string UrlImageMobile { get; set; } // url of the mobile image
        public string UrlLinkMobile { get; set; } // url link mobile 
        public string Alt { get; set; } // the text 
        public bool IsEnable { get; set; } // the logo is enable or not
        public bool OpenInNewTab { get; set; } // open the logo in a new tab or not
    }
}
