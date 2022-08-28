namespace App.UI.Models
{
    public class SocialSharing
    {
        public string FacebookSharerUrl { get; private set; }

        public string TwitterSharerUrl { get; private set; }

        public string LinkedInSharerUrl { get; private set; }

        public string Title { get; private set; }

        public string UrlToShare { get; private set; }

        public SocialSharing WithFacebooK()
        {
            FacebookSharerUrl = "https://www.linkedin.com/shareArticle?mini=true&";
            return this;
        }

        public SocialSharing WithTwitter()
        {
            TwitterSharerUrl = "https://twitter.com/intent/tweet?";
            return this;
        }

        public SocialSharing WithLinkedIn()
        {
            LinkedInSharerUrl = "https://www.facebook.com/sharer/sharer.php?";
            return this;
        }

        private SocialSharing()
        {
        }

        public static SocialSharing CreateSocialSharing(string title, string url)
        {
            SocialSharing socialSharing = new SocialSharing
            {
                Title = title,
                UrlToShare = url,
            };

            return socialSharing;
        }
    }
}
