// Set up imports
const express = require('express');
const path = require('path');
const bodyParser = require('body-parser');
const cors = require('cors');
const passport = require('passport');
const mongoose = require('mongoose');
const config = require('./Config/Database');

mongoose.connect(config.database);

mongoose.connection.on('connected', () => {
    console.log('connected to db ' + config.database);
});
mongoose.connection.on('error', (err) => {
    console.log('db error ' + err);
});

const app = express();

const users = require('./Routes/User');

const port = 3000;

app.use(cors());
app.use(bodyParser.json());

//index route, send responce as there is nothing there
app.get('/', (req, res) => {
    res.send("Welcome to Encrypic");
});

app.use('/users', users);

app.listen(port, () => {
    console.log('Server started on port ' + port);
});