# Net Present Value (NPV) App

This is a web application that calculates the Net Present Value for a given series of Cash Flows and range of discount rates.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

```
Visual Studio 2017 or newer (Community Edition will do)
```

### Installing

Publish database via Publish profile XML file

```
1. Inside NPVApp.Database folder, double-click NPVApp.Database.publish.xml
![Image of Step 1.1](https://user-images.githubusercontent.com/6851315/61589553-1e3e4e80-abde-11e9-8353-512fd4559b4e.png)

2. On the Publish Profile dialog, click "Edit" to specify your local machine's SQL Server credentials
![Image of Step 1.2](https://user-images.githubusercontent.com/6851315/61589565-5cd40900-abde-11e9-91b7-a4014f4fb6bc.png)

![Image of Step 1.3](https://user-images.githubusercontent.com/6851315/61589574-90169800-abde-11e9-8bc8-2806f1a48521.png)

3. On the Publish Profile dialog again, if not filled, specify the Database as "npvapp"

4. Click "Publish". On the Data Tools Operation window, a successful publish looks like this:
![Image of Step 1.4](https://user-images.githubusercontent.com/6851315/61589589-c8b67180-abde-11e9-8286-39a4dfc7b053.png)

```

Modify the DB connection string on the Web.config

```
Inside NPVApp.Web, open the Wen.config file and modify the username and password for your local machine's SQL Server
![Image of Step 2.1](https://user-images.githubusercontent.com/6851315/61589638-7de92980-abdf-11e9-896b-d215ce5c8493.png)

```

Build and Run the web application

```
Press Ctrl + F5 to Build and Run the web application
![Image of Step 2.1](https://user-images.githubusercontent.com/6851315/61589679-239c9880-abe0-11e9-86e1-e064f468c748.png)

```
