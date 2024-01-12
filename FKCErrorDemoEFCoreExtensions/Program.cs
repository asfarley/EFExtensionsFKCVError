// See https://aka.ms/new-console-template for more information
using FKCErrorDemoEFCoreExtensions;
using Microsoft.EntityFrameworkCore;


Console.WriteLine("Hello, World!");

//Create objects
var parent1 = new ParentClass();
parent1.Name = "Foo";


var child1 = new ChildClass();
child1.Name = "Bar";

parent1.Children.Add(child1);

using (var dbContext = new MyContext("C:\\Users\\alexa\\OneDrive\\Desktop\\demo.sqlite"))
{
    dbContext.Database.Migrate();
    dbContext.Add(parent1);
    dbContext.SaveChanges();
}

using (var dbContext = new MyContext("C:\\Users\\alexa\\OneDrive\\Desktop\\demo.sqlite"))
{
    dbContext.Database.ExecuteSqlRaw("DELETE FROM ChildClasses");
    dbContext.Database.ExecuteSqlRaw("DELETE FROM ParentClasses");
}

using (var dbContext = new MyContext("C:\\Users\\alexa\\OneDrive\\Desktop\\demo.sqlite"))
{
    dbContext.ParentClasses.Add(parent1);
    //dbContext.SaveChanges(); // Saves, no error
    dbContext.BulkSaveChanges(); //Foreign key constraint violation
}

