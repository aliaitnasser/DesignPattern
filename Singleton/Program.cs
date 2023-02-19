

using Singleton;

var loggerInstance1 = Logger.Instance;
var loggerInstance2 = Logger.Instance;

Console.WriteLine(loggerInstance1 == loggerInstance2);