# CapstoneProject
This is a copy of the code from my senior capstone project.
I worked in a group of computer science seniors to develop this application for a computer hardware company.
My primary role in this project was the creation and management of the SQL database hosted on microsoft azure that served as the backend for this application.
Due to this I had a hand in the development of most of the applications applets as they all interact in some way with the database.
Additionally, I was solely responible for the integration of the login system, manage storage applet, and the modify users applet.
Because it depends on services that our client uses, some of its features will no longer function.

## Login Technology
This application relies on a backend database hosted in Microsoft Azure. The authentication for accessing that database is handled through the use of azure active directory.
Upon login the user will be redirected to a webpage that will require the user to login with their Microsoft Azure credentials. If they are a valid user, then a SQL connection will be established.

## Menu
The main page of the application. Along the top of the menu is an array of buttons that allow the user to transition to each of the applications applets.
By default the menu shows a list of every item inventory. The application has three different user roles, customer service, engineering, and admin and will limit the view of the applets to fit that role.
![Menu_Example](https://user-images.githubusercontent.com/104809669/167961444-cb56b9ac-c287-4024-9e8b-913cc50ea7f7.png)

## Customer Service
This applet allows the user to add notes about a specifc product for future reference.

## Search for part
Allows the user to search for tracks products. The applet allows the user to search by Customer name, product serial number, and product lot number. A shared lot number distinguishes products that were added to the database together.
Additionally, this page allows the user to specify which columns should be displayed.
The user can select products and export their serial numbers to a csv file. The client uses these csv file to print barcode stickers for products.
From this page a part can be selected to display/update details about that specific part.
![Search_Example](https://user-images.githubusercontent.com/104809669/167961497-a71f1318-f0dd-4d59-8e91-4fa41ebaa3d8.png)

## Add New Part
Applet to add new products to the database. Automatically generates product serial number and lot number. Allows the user to bulk add a user defined number of products.
![New_Part_Example](https://user-images.githubusercontent.com/104809669/167961527-12c2aeb7-242e-4c30-83b1-8ad0fb02f517.png)

## Event Log
Applet to add preset product events for a product or group of products. These events are preset based on produt type.
![Event_Log_Example](https://user-images.githubusercontent.com/104809669/167961540-79eab373-e801-4e1c-87b6-2a165c14a8ed.png)

## Modify Event List
Applet to modify event list of a given product type.
![Modify_Event_List](https://user-images.githubusercontent.com/104809669/167961562-e9ad5085-131d-405f-8435-111248277d46.png)

## Manage Storage
Client had four levels of storage, Storerooms, Racks, shelves, and bins. THis applet allows the user to Add, remove, or move any of these storage items.
![Manage_Storage_Example](https://user-images.githubusercontent.com/104809669/167961578-d6fd0282-d6e4-48ae-a9fa-d3a9f2275ad7.png)

## Modify Users
Applet used by database admin to add and set the role of a database user.
![Modify_User_Example](https://user-images.githubusercontent.com/104809669/167961595-17ec4ce5-5923-40a7-b972-65c0e81f39d2.png)

## SQL Database
Schema used for sql database.
![Relational_Schema_Example](https://user-images.githubusercontent.com/104809669/167961765-c5835863-bc50-4736-a4af-5fedf0d256a0.png)
