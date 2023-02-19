Console.Title = "Composite";

var root = new Composite.Directory("root", 0);
var textFIle = new Composite.File("textFile", 100);
var topLevelDirectory1 = new Composite.Directory("topLevelDirectory1", 4);
var topLevelDirectory2 = new Composite.Directory("topLevelDirectory2", 4);

root.add(textFIle);
root.add(topLevelDirectory1);
root.add(topLevelDirectory2);

var subDirectory1 = new Composite.File("subLevelFile1", 2);
var subDirectory2 = new Composite.File("subLevelFile2", 200);

topLevelDirectory2.add(subDirectory1);
topLevelDirectory2.add(subDirectory2);

Console.WriteLine($"Size of topLevelDirectory1 is : {topLevelDirectory1.GetSize()}");
Console.WriteLine($"Size of topLevelDirectory2 is : {topLevelDirectory2.GetSize()}");
Console.WriteLine($"Size of root is : {root.GetSize()}");
