using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Guestbook
{
    // Klass för att hantera lagring, hämtning och borttagning av inlägg
    public class GuestbookStore
    {
        private string filename = @"guestbook.json";  // Fil där inläggen ska sparas
        private List<GuestbookPost> guestbookPosts = new List<GuestbookPost>(); // Lista för inläggen

        // Konstruktor som laddar inlägg från fil om filen existerar
        public GuestbookStore()
        {
            try
            {
                // Kontrollerar om filen existerar och läser in innehållet
                if (File.Exists(filename) == true)
                {
                    string jsonString = File.ReadAllText(filename);
                    guestbookPosts = JsonSerializer.Deserialize<List<GuestbookPost>>(jsonString)!;
                }
                else
                {
                    guestbookPosts = new List<GuestbookPost>(); // Skapar en tom lista om filen inte existerar
                }
            }
            catch (Exception error) // Fångar upp eventuella fel och skriver ut felmeddelande
            {
                Console.WriteLine($"Fel vid laddning av inlägg: {error.Message}");
                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ReadKey();  // Väntar på att användaren trycker på en tangent
                guestbookPosts = new List<GuestbookPost>(); // Skapar en tom lista om något går fel
            }
        }

        // Metod för att lägga till ett inlägg i gästboken
        public GuestbookPost AddPost(string owner, string postText)
        {
            GuestbookPost newPost = new GuestbookPost(owner, postText);
            guestbookPosts.Add(newPost);
            SavePosts();
            return newPost;  // Returnerar objektet
        }

        // Metod för att ta bort ett inlägg från gästboken
        public GuestbookPost? RemovePost(int index)
        {
            // Kontrollerar att indexet är inom listans gränser
            if (index >= 0 && index < guestbookPosts.Count)
            {
                GuestbookPost removedPost = guestbookPosts[index];
                guestbookPosts.RemoveAt(index);
                SavePosts();  // Anropar metoden för att spara inläggen till fil
                return removedPost;  // Returnerar det borttagna inlägget
            }
            return null;  // Returnerar null om indexet är ogiltigt
        }

        // Metod för att hämta alla inlägg
        public List<GuestbookPost> GetPosts()
        {
            return guestbookPosts;
        }

        // Sparar inläggen till fil (JSON-format)
        private void SavePosts()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(guestbookPosts); // Konverterar listan till JSON-format
                File.WriteAllText(filename, jsonString);  // Sparar JSON-strängen till fil
            }
            // Fångar upp eventuella fel och skriver ut felmeddelande
            catch (Exception error)
            {
                Console.WriteLine($"Fel vid sparning av inlägg: {error.Message}");
            }
        }
    }
}