Steps to run the project:
1. Create a database named DCA on local server
2. Create a user for the sql server with name "admin" and password "admin" (please make sure that the created user have rights for DCA database)
3. Run the following command on Package Manager Console to create the tables in the database : Update-Database

For creating investments: 
	1.Select a coin (the values are retreived from coinmarketcap and cached for 5 mins)
	2.Select the days of the month on witch you want to make the investments. (you can select multiple days and delete them) (ex 5 and 15)
	3.Select a range of datetimes for investments (ex: 06.01.2022 to current date) (minimum value for range is 01.01.2022).
	4.Insert amount for investment.
	5.Hit add.

Behavior: You will invest every in every 05 and 15 of each month between 06.01.2022 and the current date.
The record will be added to the table and the KPI's will be calculated. The prices for KPI's are loaded live directly from binance (Web sockets)
All imputs are validated, Business logic validated, mostly on FE.
MudBlazor was used everywere.