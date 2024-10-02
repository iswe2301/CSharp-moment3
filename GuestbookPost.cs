namespace Guestbook
{
    // Klass för att representera ett inlägg i gästboken
    public class GuestbookPost
    {
        public string Owner { get; set; }  // Ägaren av inlägget
        public string PostText { get; set; }  // Själva inläggstexten

        // Konstruktor för att skapa ett inlägg
        public GuestbookPost(string owner, string postText)
        {
            Owner = owner;
            PostText = postText;
        }

    }
}
