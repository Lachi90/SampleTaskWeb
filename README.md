<pre>
  _____                       _   _______        _  __          __  _     
 / ____|                     | | |__   __|      | | \ \        / / | |    
| (___   __ _ _ __ ___  _ __ | | ___| | __ _ ___| | _\ \  /\  / /__| |__  
 \___ \ / _` | '_ ` _ \| '_ \| |/ _ \ |/ _` / __| |/ /\ \/  \/ / _ \ '_ \ 
 ____) | (_| | | | | | | |_) | |  __/ | (_| \__ \   <  \  /\  /  __/ |_) |
|_____/ \__,_|_| |_| |_| .__/|_|\___|_|\__,_|___/_|\_\  \/  \/ \___|_.__/ 
                       | |                                                
                       |_| 
</pre>
by Christian Lachmann 2021-11-07

# Purpose
This software was created as a given sample task. It should be able to select a json-file from the client filesystem, upload it to server and store it either on a database or on the filesystem.
The content of the json-file should be presented on a webpage. Clicking on an item should present a detail page. Also deleting of single data entry should be possible.

# Technology Stack
To achieve the goal the following technologies/ tools were used:
- C#
- Blazor WASM
- MudBlazor
- EntityFrameworkCore
- Moq
- FluentAssertions
- SQLite
- Swagger
- Docker

# Deployment
The web app can either be started via <b>VisualStudio</b> or can be run in a <b>Docker</b> container.

To start the web app via Docker the first step is to build an image from the current code base.

`docker build -t sampletaskweb .`

When building has finished the build image is ready to be deployed as a container.

`docker run -p 8080:80 sampletaskweb`

Now the web app can be reached via browser:

`http://localhost:8080`

# Swagger
To have an interface documentation and also having the possibility to try the backend without the need of the frontend, Swagger was integrated in the backend application.

Swagger address in the browser:
`http://localhost:{port}/swagger`

Port depends on the selected deployment.

# How it works
When either started via VS or Docker on the first page all the devices are shown. 
To add more devices press the "Upload json" Button and select the corresponding json file. The data gets send to the backed to be stored and the page refreshes. 
For deleting a device just click on the trash bin icon.</br>

<img src="./img/overview.png" alt="overview"><br>

Getting the detail view of just a click on the device itself is necessary. It is possible to navigate back to overview via pressing the "Back" button on the upper right corner.<br>

<img src="./img/detailview.png" alt="detail"><br>

# How it technically works
In deviation to the given task, the json file doesn't get uploaded to the backend directly. It gets read and deserialized on the client side. Embedded in the corresponding model class, the data gets sent via http call to the backend. 
In my opinion this has infrastructure and performance benefits. 
- It's possible to only send the data really needed to the backend, therefore you can minimize traffic.
- No need to take care about deleting old uploaded json files.
- Disk space saved by not having the json files on the backend side.

Once the data has reached the controller of the backend service, it gets stored in database via repository pattern. Due to the lightweight of the database SQLite gets used. The controller also provides functionality for deleting data and also to get all the data from the database. 

For creating the database a database-first-approach via entity framework is implemented.

The build-in dependency injection possibility of ASP.NET Core is used to register the repository for accessing the database.  

# Branching structure
To keep best track of all changes a branching concept was introduced.

## Main branch
The main branch can only be committed to via pull request and is only used for "releases" or in this case when task gets send over to the order creator.

## Develop branch
Also this branch is only reachable via pull request. It combines the source and commits from all feature branches.

## Feature branches
There are several feature branches to keep each part of the development cleanly separated from each other. 

There are the following feature branches:
| Branch                        | Purpose                                                                 |
|-------------------------------|-------------------------------------------------------------------------|
| /feature/init-project         | Setup of the project structure                                          |
| /feature/AddRepository        | Added repository pattern (database access)                              |
| /feature/addDeviceController  | Added the device controller for handling http requests                  |
| /feature/addMudBlazor         | Introduced MudBlazor framework to the front end - created overview page |
| /feature/fileUpload           | Brought file upload functionality to the front end                      |
| /feature/ShowDeviceDetails    | Functionality for showing device details was added                      |
| /feature/docker               | Possibility to run app in docker container added                        |
| /feature/readme               | Branch to created this ReadMe                                           |

# Possible improvements
This web application can be seen as a kind of proof of concept. Therefore some improvements could be implemented to get better user experience and also improve code quality, which wasn't possible by the time spent.<br>
- Currently only the backend part is covered by UnitTests. These could be extended also on the frontend part.
- For better usability loading screens could introduced on the frontend part.
- Error handling and feedback to the user: at the moment the user does not get informed about something going wrong on the data processing.
- Feature for editing the data already present to achieve all the CRUD operations.
- Extending the swagger documentation