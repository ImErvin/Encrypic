## Encrypic
![alt text](https://github.com/ImErvin/Encrypic/blob/master/Encrypic2017/Assets/eplogo.png?raw=true "Encrypic Logo")

A Universal Windows Platform(UWP) application built using the MVVM design to easily build the application to any UWP device (phone, desktop, hololens etc.). This is a project for my Mobile Applications Development 3 module in college. The basic idea is to make use of the powerful MVVM design pattern and use my knowledge of RESTful APIs and Databases to create a full stack UWP application.

The idea behind Encrypic is to create an application that allows users to send encrypted images to eachother and provide a private key to decrypt those images. The sender can choose to self-destruct the image after decryption or to re-encrypt the image and provide the private key again.

### Features
    1. User Accounts
    2. Message Sending
    3. Add friends
    3. Fluent UI
    
### How to run
To run this application you must ensure you are using Visual Studio **2017** and have the **Creators Fall Update**. This is important to use the fluent ui components. You must also ensure you have Node and Mongodb installed locally (If my free heroku hosting runs out for this application).

##### Front End

1. Clone this repository locally
2. Launch the *"Encrypic2017.sln"*
3. Run the debugger locally

##### Back End

(Run this only if the Heroku isn't working)
1. Open two separate windows of your favorite CLI.
2. On one of the CLI windows run the command *"mongod"*
3. On the other CLI window navigate to the EncrypicAPI folder and run the command *"node install"*
4. Once that is finished installing, run the command *"node server.js"* to start the API.


### Windows Store
###### This applicaation is currently being certified on the Windows Store - I will have further details later.
<hr/>
#### Credit
Logo created using [Logomakr](https://logomakr.com/).

### Screenshots

![login](https://scontent-mxp1-1.xx.fbcdn.net/v/t35.0-12/25445253_1823933074304832_2063181168_o.png?oh=02562ef5b22555d50ccc2a19d84eae5b&oe=5A3AEF01)
![friendsList](https://scontent-mxp1-1.xx.fbcdn.net/v/t35.0-12/25434303_1823933414304798_249345005_o.png?oh=23909d93f06a3274e31b4eec5723b4c8&oe=5A3AC03F)
![sendMessage](https://scontent-mxp1-1.xx.fbcdn.net/v/t35.0-12/25434484_1823934364304703_522669835_o.png?oh=d2e245df5366bbb95bf6f5a785dcfa8c&oe=5A39E3F4)
![inbox](https://scontent-mxp1-1.xx.fbcdn.net/v/t35.0-12/25435196_1823934824304657_1377781611_o.png?oh=5d6ab8b30531c2e5f727922327bb6165&oe=5A3AD778)

