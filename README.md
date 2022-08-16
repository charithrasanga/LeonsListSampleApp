#  Sample WebApi Demonstrating the .net best practices

## Instructions for Running the Application

 
1. Clone the repo and open the solution using Visual Studio or via an editor of your choice.
2. Open the  appsettings.json (WebApi Project) and modify your connection string accordingly. 
3. Open up Package Manager Console 
4. Select Infrastructure.Identity Project and run update-database -Context IdentityContext command.
5. Select Infrastructure.Persistence Project and run update-database -Context ApplicationDbContext command.
6. Set WebApi as the startup project and run the application. 
7. Once the application started it will create default users and roles.
8. In order to login as Admin, Basic User please use below credentials to obtan a jwt token using swagger UI (/api/Account/authenticate). 
  8. once JWT recived use the JWT and log in to App using Authorize button

* please note that you need to enter your JWT according to  `Bearer {your token here}`  format 

** Swagger UI provide all required functionality to test all above mentioned senarios and you  don't need to use Postman etc.. ( still possible though)

**Admin User** 
Username : superadmin@gmail.com
Password : 123Pa$$word!

**Basic User** 
Username : basicuser@gmail.com
Password : 123Pa$$word!


In order to monitor outgoing emails please log in to https://ethereal.email/ or create a new account for free and add the configurations in appsettings.json)

url : https://ethereal.email/login
Username: gudrun.zieme@ethereal.email
Password: cGq9BGeEAdvZ6pp447