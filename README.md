# Gummi Bear Kingdom
### Product Management Application for .NET Code Review (01.05.2018)

#### By Kimberly Bordon

## Description
This is an application that allows users (presumably Gummi Bear Kingdom employees) to manage the products they have available. This app will allow the user to set up a database, which will then be accessed by the web interface to add products. The app also allows the user to view, edit, and delete each product.

## Specs
| Behavior | Input Example | Output Example |
|-|-|-|
| The app loads up landing page by default. | User runs app. | Main page is displayed. |
| User can click a link on homepage to reach page listing all products. | User clicks "Products" link. | Page displays list of products. |
| User can click on a product's name to view its details. | User clicks "Gummi Bear Couch." | Page displays details of Gummi Bear Couch. |
| User can edit a product's details. | User clicks "Edit." | Page displays product details in a form, and user can click submit to save any changes made. |
| User can delete a product. | User clicks "Delete." | Page displays confirmation page, and user can click delete to finally remove product from database. |

## Wishlist
* User can save images to database.
* A blog section.
* Change edit and create form structure to a modal or something similar.
* Seed the database.

## Setup/Installation
* Make sure you have [.NET Core 1.1 SDK (Software Development Kit)](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-win-x64.1.1.4.exe) and [.NET runtime](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-win-x64.1.1.4.exe) both installed.
* You should also have [Visual Studio](https://www.visualstudio.com/downloads/), and [MAMP](https://www.mamp.info/en/downloads/) or other similar software installed.
* Make sure that MAMP is started, and running on port 8889.
* Using your terminal or powershell, clone this repository by typing ```>git clone https://github.com/kbordon/dotnet-week1-code-review-gummi```
    * Alternatively, you can use a browser to download the .zip file from the Github web interface at the URL: https://github.com/kbordon/dotnet-week1-code-review-gummi
* Open Visual Studio, and navigate to the top level of dotnet-week-1code-review-gummi and double-click on GummiBearKingdom.sln.
* Using powershell or terminal, navigate to the folder named dotnet-week-1code-review-gummi. Then enter the following commands:
  ```
  >cd dotnet-week-1code-review-gummi
  >cd GummiBearKingdom
  >dotnet restore
  >dotnet ef database update
  ```
  This will set up database onto the server.
* Back in Visual Studio, click the button at the top of the application that looks like a Play button, or press <kbd>⌘</kbd> + <kbd>return</kbd> or <kbd>ctrl</kbd> + <kbd>F5</kbd>. This will automatically run application, and open a browser directly on its homepage.
* Navigate the application as you see fit.

## Known Bugs
None at the moment!

## Technology Used
* ASP.NET
* Visual Studio

## Contact Details
Email Kimberly @ [kbordon@gmail.com](mailto:kbordon@gmail.com) for comments, questions, or concerns.

## License
**_This software is licensed under the MIT License._**

**Copyright © 2018 Kimberly Bordon**
