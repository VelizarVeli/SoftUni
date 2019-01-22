Hey there !!!
Please follow the listed steps to evaluate the whole project:

--1: If your database is named "EventuresDb" delete yours;

--2: Change the default server name in the appsettings.json

--3: A middleware is implemented for seeding roles and seeding a first admin user 
(you can create as much as you want users with role "user" from the running app)

--3.1: The admin username is "admin" with password "12345" => use it to log to the app and create events

--4: So several restrictions when creating an event:

++ All the required contraints are implemented. There are some additional ones.
++ There is a regular expression for the property "Place" - you should import city and country, example ("Sofia, Bulgaria" or "Sofia,Bulgaria")
++ I have implemented datetime-local type to Start and End properties so you can add hours and minutes!!!
	$$ If you are using Mozilla Firefox or Safari web browser sadly :( you wont see the correct form field for these properties!!
	$$ Your date input should look like "30-11-2018 22:00" or so to say in this format "dd-MM-yyyy HH:mm"

	$$If you are using any other browser(you can try Google Chrome or Edge) you will see the datetime-local type
	$$I suggest you to try them both (chrome and edge) to see that even between them the form is different!(but working correctly)
	
--5: The logging functionality is implemented:
++ To see the console logs run the project from Eventures.Web not from the IIS Express!
++ Convinient for you i have installed dependency for Serilog.Extensions.Logging.File and you can see a text file
   in the folder Logs/CreateEvent, which is located in the project folder.
   
--6: There is custom error handling filter for all the controllers, so if there is any exception you should be redirected to a custom error view that I implemented.

--7: TO RUN FACEBOOK LOGIN: CHANGE THE AppId and AppSecret VALUES IN THE STARTUP ADD AUTHENTICATION.ADDFACEBOOK or CHANGE YOUR USERId in the .csproj file

--8: Sorry for the long information. I hope you will enjoy it!
