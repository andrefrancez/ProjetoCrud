using ProjetoIBID;
using ProjetoIBID.Controller;
using ProjetoIBID.Data;
using ProjetoIBID.Repository;

var context = new DataContext();
var repository = new Repository(context);
var controller = new ProductController(repository);
var app = new MenuApp(controller);

app.Run();