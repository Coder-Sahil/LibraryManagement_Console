// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using LibraryManagement.Business;

try
{
    new LibraryManager().StartLibrary();
}
catch (Exception ex)
{
    Console.WriteLine("Error Occur in Library Management System");
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.ToString());
}