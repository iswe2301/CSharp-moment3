using System;

namespace Guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            GuestbookStore guestbookStore = new GuestbookStore(); // Skapar en instans av GuestbookStore
            bool exit = false; // Variabel för att hålla koll på om programmet ska avslutas

            while (!exit) // Loop för att visa menyn tills användaren väljer att avsluta
            {
                Console.Clear();
                Console.WriteLine("Gästbok - meny");
                Console.WriteLine("1. Visa alla inlägg");
                Console.WriteLine("2. Lägg till ett inlägg");
                Console.WriteLine("3. Ta bort ett inlägg");
                Console.WriteLine("4. Avsluta");

                Console.Write("Välj ett alternativ (1-4): ");
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ShowPosts(guestbookStore); // Anropar metoden för att visa alla inlägg
                            break;
                        case 2:
                            ControlAddPost(guestbookStore); // Anropar metoden för att lägga till inlägg
                            break;
                        case 3:
                            ControlRemovePost(guestbookStore); // Anropar metoden för att ta bort inlägg
                            break;
                        case 4:
                            exit = true; // Avslutar programmet
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Tryck på valfri tangent för att försöka igen.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning. Tryck på valfri tangent för att försöka igen.");
                    Console.ReadKey();
                }
            }
        }

        // Metod för att visa alla inlägg
        static void ShowPosts(GuestbookStore guestbookStore)
        {
            Console.Clear(); // Rensar konsolen
            List<GuestbookPost> posts = guestbookStore.GetPosts(); // Hämtar alla inlägg

            // Kontrollerar om det finns några inlägg att visa
            if (posts.Count == 0)
            {
                Console.WriteLine("Inga inlägg att visa.");
            }
            else
            {
                // Loopar igenom alla inlägg och visar dem
                for (int i = 0; i < posts.Count; i++)
                {
                    Console.WriteLine($"Inlägg {i + 1}:");
                    Console.WriteLine($"Namn: {posts[i].Owner}");
                    Console.WriteLine($"Text: {posts[i].PostText}");
                    Console.WriteLine("------------------------");
                }
            }

            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
        }

        // Metod för att hantera att lägga till ett inlägg
        static void ControlAddPost(GuestbookStore guestbookStore)
        {
            Console.Clear(); // Rensar konsolen

            // Variabler för att lagra ägare och inläggstext samt för att hålla koll på om inmatningen är korrekt
            string owner = string.Empty;
            string postText = string.Empty;
            bool validInput = false;

            // Loop för att säkerställa att ägaren anges, körs tills en giltig ägare anges
            while (!validInput)
            {
                Console.Write("Ange ditt namn: ");
                owner = Console.ReadLine()?.Trim() ?? string.Empty;

                // Kontrollerar om ägaren är giltig (inte tom)
                if (string.IsNullOrWhiteSpace(owner))
                {
                    Console.WriteLine("Fel: Du måste ange ditt namn.");
                }
                else
                {
                    validInput = true; // Avsluta loopen om giltig ägare
                }
            }

            validInput = false; // Återställer för att kontrollera inläggstexten

            // Loop för att säkerställa att inläggstext anges
            while (!validInput)
            {
                Console.Write("Ange inläggstext: ");
                postText = Console.ReadLine()?.Trim() ?? string.Empty;

                // Kontrollerar om inläggstexten är giltig (inte tom)
                if (string.IsNullOrWhiteSpace(postText))
                {
                    Console.WriteLine("Fel: Inläggets text får inte vara tom.");
                }
                else
                {
                    validInput = true; // Avslutar loopen om giltig inläggstext
                }
            }

            // Anropar metoden för att lägga till inlägget när ägare och inläggstext är giltiga
            GuestbookPost newPost = guestbookStore.AddPost(owner, postText);

            // Skriver ut det nya inlägget
            Console.WriteLine($"Inlägg tillagt: \nNamn: {newPost.Owner} \nText: {newPost.PostText}");
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
        }

        // Metod för att hantera borttagning av ett inlägg
        static void ControlRemovePost(GuestbookStore guestbookStore)
        {
            Console.Clear();
            List<GuestbookPost> posts = guestbookStore.GetPosts(); // Hämtar alla inlägg

            Console.WriteLine("Ta bort ett inlägg:");

            // Kontrollerar om det finns några inlägg att ta bort
            if (posts.Count == 0)
            {
                Console.WriteLine("Inga inlägg att ta bort.");
                Console.WriteLine("Tryck på valfri tangent för att återgå till menyn...");
                Console.ReadKey();
                return; // Avslutar metoden eftersom det inte finns några inlägg att ta bort
            }

            // Loopar igenom alla inlägg och visar dem
            for (int i = 0; i < posts.Count; i++)
            {
                Console.WriteLine($"Inlägg {i + 1}:");
                Console.WriteLine($"Namn: {posts[i].Owner}");
                Console.WriteLine($"Text: {posts[i].PostText}");
                Console.WriteLine("------------------------");
            }

            bool validInput = false; // Variabel för att hålla koll på om användaren angett ett giltigt index för borttagning

            // Loopar tills användaren har angett ett giltigt index för borttagning eller avbryter
            while (!validInput)
            {
                Console.Write("Ange index för inlägget du vill ta bort (1, 2, 3...) eller tryck Enter för att avbryta: ");
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                // Kontrollerar om användaren trycker Enter för att avbryta
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Borttagning avbröts. Tryck på valfri tangent för att återgå till menyn...");
                    Console.ReadKey();
                    return;
                }

                // Kontrollerar om inmatningen är ett giltigt nummer
                if (int.TryParse(input, out int index) && index > 0 && index <= posts.Count)
                {
                    // Tar bort inlägget och sparar det borttagna inlägget i en variabel
                    GuestbookPost? removedPost = guestbookStore.RemovePost(index - 1);

                    // Uppdaterar listan efter borttagning och visar inläggen som finns kvar
                    posts = guestbookStore.GetPosts();
                    Console.Clear();

                    // Kontrollerar om det finns några inlägg kvar att visa
                    if (posts.Count == 0)
                    {
                        Console.WriteLine("Alla inlägg har tagits bort.");
                    }
                    else
                    {
                        // Loopar igenom alla inlägg och visar dem
                        for (int i = 0; i < posts.Count; i++)
                        {
                            Console.WriteLine($"Inlägg {i + 1}:");
                            Console.WriteLine($"Namn: {posts[i].Owner}");
                            Console.WriteLine($"Text: {posts[i].PostText}");
                            Console.WriteLine("------------------------");
                        }
                    }

                    // Kontrollerar om inlägget togs bort och skriver ut ett meddelande om det lyckades
                    if (removedPost != null)
                    {
                        Console.WriteLine($"Inlägg {index} skapat av {removedPost.Owner} har tagits bort!");
                        // Väntar på att användaren ska trycka på en tangent innan menyn visas igen
                        Console.WriteLine("Tryck på valfri tangent för att återgå till menyn...");
                        Console.ReadKey();
                    }

                    validInput = true; // Avslutar loopen
                }
                else
                {
                    Console.WriteLine($"Fel: Ange ett giltigt index mellan 1 och {posts.Count}.");
                }
            }
        }
    }
}