# Book DB

## Story

Flynn, local librarian, wants to digitalize his good ol' book register. Searching for records in a massive set of massive books is time consuming. 
Your task is to create a simple application that will store books and authors in a Microsoft SQL Server, and will allow Flynn to add, update, and list all entries.


## What are you going to learn?

- connect to a database using low level technology (SqlClient package).
- handle edge cases and exceptions.


## Tasks

1. Create a new database in Microsoft SQL Server and import both schema and data from the `books.sql` file.
    - Database with name `books` exists
    - Tables `book` and `author` are created and filled with sample data

2. Create a class called `BookDbManager` (in a catalog called 'Manager') with a method `Connect()` that will link to your `books` database and return a connection string from your app.config file. Use the `Microsoft.Data.Sqlclient` package to establish connection and `Configuration Manager` from System.Configuration to obtain the connection string.
    - Class `BookDbManager` exists, and its `ConnectionString` property returns a connection string.

3. Create `AuthorDao` and `BookDao` classes in the `Model` directory. Each class will accept the connection string as a constructor parameter. Instances of both of these DAOs will be managed by `BookDbManager`.
    - Classes `AuthorDao` and `BookDao` are implemented.
    - Classes `AuthorDao` and `BookDao` use `SqlCommand`s and `SqlDataReader`s.
    - Exceptions are chained and thrown as RuntimeWrappedExceptions, to avoid "exception swallowing".

4. Make this app functional with a simple console UI. Implement `UserInterface`'s methods, and call them from `BookDbManager` using a main menu -> submenu workflow. Make sure that the user is able to list and edit all the records, as well as add new ones.
    - Main menu with options `a - Authors`, `b - Books` and `q - Quit` navigates to the selected submenu and is functional
    - Resources menu with options `l - List`, `a - Add`, `e - Edit` and `q - Quit` is functional on the selected entities

## General requirements

None

## Hints

- When you create a new connection, you can check whether the connection works propery
((your SqlConnection object).Open() and (your SqlConnection object).Close()).
- Pay attention to what the day/month/year format for the SQL Date type is.


## Background materials

- <i class="far fa-exclamation"></i> [Working with Configuration Manager](https://www.toolsqa.com/selenium-webdriver/c-sharp/manage-read-configurations-using-configurationmanager-csharp/)
- <i class="far fa-exclamation"></i> [SQL in Visual Studio and CRUD operations](https://alexcodetuts.com/2019/04/26/how-to-connect-sql-server-database-using-c-and-perform-crud-operation-part-1/)
- <i class="far fa-exclamation"></i> [DateTime formatting guide](https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1)
- <i class="far fa-exclamation"></i> [Obtaining data through SQL DataReader](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/retrieving-data-using-a-datareader)
- <i class="far fa-exclamation"></i> [Override ToString method](https://www.c-sharpcorner.com/blogs/override-tostring-method-in-c-sharp)

