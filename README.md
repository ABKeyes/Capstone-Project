# CapstoneProject

This is a copy of the code from my senior capstone project. Because it depends on services that our client uses, some of its features will no longer function.

## Login Technology
This application relies on a backend database hosted in Microsoft Azure. The authentication for accessing that database is handled through the use of azure active directory.
Upon login the user will be redirected to a webpage that will require the user to login with their Microsoft Azure credentials. If they are a valid user, then a SQL connection will be established.

## Menu
The main page of the application. Along the top of the menu is an array of buttons that allow the user to transition to each of the applications applets.
By default the menu shows a list of every item inventory.
![plot](./Example_Pictures/Menu_example.png)
