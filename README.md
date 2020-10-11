# CarSales
CarSales

CarSales API

1. 	Download Repository, and open in Visual studio. Selct Solution and Select 'Restore Nuget Packages' and Rebuild project.
2.  Change Database Connection string, which is in CarSales.API project in 'appsetting.json' file. 
3.	Open 'Package Manager Console' and Select "CarSales.Data" Project and run 'Update-Database' command.


Design Pattern used:
- CQRS
- DDD
- Mediatr

- All projects are in .Net core 3.1

- Swagger is used to render rich UI for Web API

You can see the webAPi in swagger by typing /swagger after the localhost url. e.g http://localhost:port/swagger

I did not implement UI in MVC(I can if require) instead used Angular. You can test the code to call API Methods.