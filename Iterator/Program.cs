using Iterator;

Console.Title = "Iterator Pattern";

var people = new PeopleCollection();

people.Add(new Person("John", "USA"));
people.Add(new Person("Bob", "MA"));
people.Add(new Person("Mary", "KSA"));
people.Add(new Person("Anna", "UK"));

var iterator = people.CreateIterator();

Console.WriteLine("Iterating over collection:");
for (var person = iterator.First(); !iterator.IsDone; person = iterator.Next())
{
	Console.WriteLine(person.Name);
}