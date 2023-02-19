using Flyweight;

Console.Title = "Flyweight";

string text = "abba";

var characterFactory = new FlyweithFactory();

//get all flyweight
var characters = characterFactory.GetCharacter(text[0]);
characters?.Draw("Arial", 12);

characters = characterFactory.GetCharacter(text[1]); 
characters?.Draw("Booksman oldstyle", 18);

characters = characterFactory.GetCharacter(text[2]);
characters?.Draw("Times new Roman", 12);

characters = characterFactory.GetCharacter(text[3]);
characters?.Draw("Conic Sans", 10);

