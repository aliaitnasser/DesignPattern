using Mediator;

Console.Title = "Mediator";

TeamChatRoom ChatRoom = new ();

var said = new Lawyer("said");
var issam = new Lawyer("issam");
var farid = new Manager("farid");
var mariam = new Manager("mariam");

ChatRoom.Register(said);
ChatRoom.Register(farid);
ChatRoom.Register(mariam);
ChatRoom.Register(issam);

said.Send("issam","Hi, Please find attached the download file");
mariam.Send("Meeting at 9AM");
