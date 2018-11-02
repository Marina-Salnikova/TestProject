# TestProject

## Run tests

### From IDE for MacOS and Windows OS

* Open TestProject.sln file in Visual Studio.
* Set up app.config:
    1. Set up TestUserLogin value (use valid user login to log in).
    2. Set up TestUserPassword value (use valid user password to log in).
* Build project TestProject. 
* Run tests from Test run panel.

### From command line after build

Notice: `chromedriver` have to be in the same directory with `TestProject.dll`.
               
#### Windows OS

* Set up TestProject.dll.config in directory `./TestProject/bin`:
    1. Set up `TestUserLogin` value (use valid user login to log in).
    2. Set up `TestUserPassword` value (use valid user password to log in).
* In `cmd`:
    1. Go to directory `.\TestProject\bin`.
    2. Run command: `.\packages\NUnit.ConsoleRunner.3.9.0\tools\nunit3-console.exe TestProject.dll --workers=1`.
    
#### MacOS

* Set up TestProject.dll.config in directory `./TestProject/bin`:
    1. Set up `TestUserLogin` value (use valid user login to log in).
    2. Set up `TestUserPassword` value (use valid user password to log in).
* In Terminal:
    1. Go to directory `./TestProject/bin`.
    2. Run command: `mono ./packages/NUnit.ConsoleRunner.3.9.0/tools/nunit3-console.exe TestProject.dll --workers=1`.
    

