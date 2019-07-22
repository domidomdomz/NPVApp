# Net Present Value (NPV) App

This is a web application that calculates the Net Present Value for a given series of Cash Flows and range of discount rates.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.



### Prerequisites

```
Visual Studio 2017 or newer (Community Edition will do)
```


### Installing

* **Clean and Rebuild the solution**

This is to make sure the **Roslyn** assembly files are successfully created on the bin folder

* **Publish database via Publish profile XML file**

1. Inside NPVApp.Database folder, double-click NPVApp.Database.publish.xml
![Image of Step 1.1](https://user-images.githubusercontent.com/6851315/61589553-1e3e4e80-abde-11e9-8353-512fd4559b4e.png)

2. On the Publish Profile dialog, click **Edit** to specify your local machine's SQL Server credentials
![Image of Step 1.2](https://user-images.githubusercontent.com/6851315/61589565-5cd40900-abde-11e9-91b7-a4014f4fb6bc.png)
![Image of Step 1.3](https://user-images.githubusercontent.com/6851315/61589574-90169800-abde-11e9-8bc8-2806f1a48521.png)

3. On the Publish Profile dialog again, if not filled, specify the Database as _*npvapp*_

4. Click **Publish**. On the Data Tools Operation window, a successful publish looks like this:
![Image of Step 1.4](https://user-images.githubusercontent.com/6851315/61589589-c8b67180-abde-11e9-8286-39a4dfc7b053.png)


* **Modify the DB connection string on the Web.config**

Inside NPVApp.Web, open the Wen.config file and modify the username and password for your local machine's SQL Server
![Image of Step 2.1](https://user-images.githubusercontent.com/6851315/61589638-7de92980-abdf-11e9-896b-d215ce5c8493.png)


* **Run the web application**

Press Ctrl + F5 to Build and Run the web application
![Image of Step 2.1](https://user-images.githubusercontent.com/6851315/61589679-239c9880-abe0-11e9-86e1-e064f468c748.png)

* **Optional**

If you want to minify the js and css files, kindly open the **Task Runner Explorer** and run the default task
![Image of Step 3.1](https://user-images.githubusercontent.com/6851315/61605565-b4bf4e00-ac78-11e9-9afe-218f1fa12c5d.png)

Change the *Minified* key in the Web.config to **"1"**
![Image of Step 3.2](https://user-images.githubusercontent.com/6851315/61605566-b7ba3e80-ac78-11e9-88f7-64da496f2a88.png)




## Demo

Once installed, you should be able to see the Dashboard page where the history of past calculations are loaded. 

![Image of Demo 1](https://user-images.githubusercontent.com/6851315/61604015-7aeb4900-ac72-11e9-98f1-9d012ceb5268.png)

Click the **New Calculate** button to see the Calculate NPV form.

![Image of Demo 2](https://user-images.githubusercontent.com/6851315/61604392-ef72b780-ac73-11e9-8446-82490a884675.png)

Fill out the fields and click **Calculate NPV and Save** button

![Image of Demo 3](https://user-images.githubusercontent.com/6851315/61604473-395b9d80-ac74-11e9-91f0-0d880b8643bd.png)

Results will be displayed and persisted in the database

![Image of Demo 4](https://user-images.githubusercontent.com/6851315/61604477-3e205180-ac74-11e9-8221-92ec23bbceb1.png)

![Image of Demo 5](https://user-images.githubusercontent.com/6851315/61604515-67d97880-ac74-11e9-912a-470807e584f6.png)
