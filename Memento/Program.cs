using Memento;

Console.Title = "Memento";

Originator Originator = new();
CareTaker Caretaker = new ();

Originator.ledTV = new LedTV("32", "10000", true);
Caretaker.AddMemento(Originator.CreateMemento());

Originator.ledTV = new LedTV("40", "20000", true);
Caretaker.AddMemento(Originator.CreateMemento());

Originator.ledTV = new LedTV("50", "30000", true);


Console.WriteLine($"\nOriginator current stats : {Originator.GetDetails()} ");

Originator.ledTV = Caretaker.GetMemento(0).LedTV;

Console.WriteLine($"\nOriginator current stats : {Originator.GetDetails()} ");


