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
[Insert Menu Example Here]

## Customer Service
This applet allows the user to add notes about a specifc product for future reference.

## Search for part
Allows the user to search for tracks products. The applet allows the user to search by Customer name, product serial number, and product lot number. A shared lot number distinguishes products that were added to the database together.
Additionally, this page allows the user to specify which columns should be displayed.
The user can select products and export their serial numbers to a csv file. The client uses these csv file to print barcode stickers for products.
From this page a part can be selected to display/update details about that specific part.
[Insert Search example here]

## Add New Part
Applet to add new products to the database. Automatically generates product serial number and lot number. Allows the user to bulk add a user defined number of products.
[Insert New Part Example here]

## Event Log
Applet to add preset product events for a product or group of products. These events are preset based on produt type.
[Insert Event Log Example]

## Modify Event List
Applet to modify event list of a given product type.
[Modify Event List Example]

## Manage Storage
Client had four levels of storage, Storerooms, Racks, shelves, and bins. THis applet allows the user to Add, remove, or move any of these storage items.
[Manage Storage Example]

## Modify Users
Applet used by database admin to add and set the role of a database user.
[Modify Users Example]

## SQL Database
[SQL Database Example]
