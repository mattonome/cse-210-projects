using System;

// Enhancement: Added a Library of multiple scriptures and randomized the selection.
// This extends the program beyond a single scripture.
class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Psalm",118,24);
        Reference reference1 = new Reference("Proverbs", 3,5,6 );
        Reference reference2 = new Reference("Deuteronomy", 31,6 );
        Reference reference3 = new Reference("Psalm", 34,8 );
        Reference reference4 = new Reference("Lamentations", 3,22,23 );
        Reference reference5 = new Reference("2 Corinthians", 4,16,18 );


        string response = "";
        List<Scripture> library = new List<Scripture>();



        library.Add(new Scripture(reference,"This is the day that the Lord has made; we will rejoice and be glad in it."));
        library.Add(new Scripture(reference1,"Trust in the Lord with all your heart, and do not lean on your own understanding. In all your ways acknowledge him, and he will make straight your paths."));
        library.Add(new Scripture(reference2," Be strong and courageous. Do not fear or be in dread of them, for it is the Lord your God who goes with you. He will not leave you or forsake you."));
        library.Add(new Scripture(reference3," Oh, taste and see that the Lord is good! Blessed is the man who takes refuge in him!"));
        library.Add(new Scripture(reference4," The steadfast love of the Lord never ceases; his mercies never come to an end; they are new every morning; great is your faithfulness."));
        library.Add(new Scripture(reference5," So we do not lose heart. Though our outer self is wasting away, our inner self is being renewed day by day. For this light momentary affliction is preparing for us an eternal weight of glory beyond all comparison, as we look not to the things that are seen but to the things that are unseen. For the things that are seen are transient, but the things that are unseen are eternal."));

        Random randomGenerator = new Random();
        int index = randomGenerator.Next(library.Count);

        Scripture scripture = library[index];

        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("Press the Enter key or type Quit to quit.");
        response = Console.ReadLine();


        while (response.ToLower() != "quit"){
            Console.Clear();
            scripture.HideRandomWords(3);
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press the Enter key or type Quit to quit.");
            response = Console.ReadLine();
            if (scripture.IsCompletelyHidden()){
                Console.Clear();
                Console.WriteLine("All words are Hidden! The verse is fully memorized.");
                response = "Quit";
            }
        }

    }
}