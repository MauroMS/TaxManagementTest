Welcome to Tax Management System!
===================


How to Setup
-------------

Download the solution to a local folder on your machine, open it with visual studio 2013 (might have to be update 5 as that's the one I'm working on).

> **Notes:**
> - Please, notice that this project was created using **.Net Framework 4.6.1**
> - After downloading the solution, navigate to **Resources\Scripts** folder inside the root folder and run **Database.sql** on Sql Server Management Studio in order to create the database structure needed for this project.
> - Visual studio will install all dependencies required when it first build the app.
> - No error handling in the application due to lack of time.
> - You can find a CSV sample file (50k rows) at **\Resources** on the root folder.

----------


How to Use
-------------------
It's very simple and straight forward to use.  

#### <i class="icon-upload"> Upload Files

> - To Upload your CSV files, you just need to navigate to the upload page using the **Upload** menu at the top. Once you are there, you need to click on the **choose file** button, and select the desired CSV file and click the **Upload** button. 
> - After the file is uploaded successfully, you will be able to see how many rows worked/failed and all the information about the failed ones in a paginated grid.
> - **There are no loading messages at the moment... It takes between 1-2 minutes to run for 50k rows**

#### <i class="icon-refresh"></i> Manage Transactions

> - Click on the **Transactions** menu at the top and you will be redirected to the Manage transactions page, where you will be able to see, edit, delete any transaction added to the system.
> - Once you there, you will see a paginated grid, with all data and 2 action links (Edit and Delete).
> - If you click Edit, you will be redirect to another page where you can edit all the information about that specific transaction. Please notice there are some restrictions when updating values: 
 > ** All fields are mandatory.
 > **Currency code must be exact 3 chars (and should be a valid CurrencyCode, validation not in place at the moment for the edit feature).
 > **Amount must be a numeric value.
> - If you click Delete, you will be redirected to a confirmation page where you can confirm you want to delete or go back to the Transactions list page.
