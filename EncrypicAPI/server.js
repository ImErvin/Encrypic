// Set up imports
const express = require('express');
const path = require('path');
const bodyParser = require('body-parser');
const cors = require('cors');
const passport = require('passport');
const mongoose = require('mongoose');
const config = require('./config/database');

mongoose.connect(config.database);

mongoose.connection.on('connected', () => {
    console.log('connected to db ' + config.database);
});
mongoose.connection.on('error', (err) => {
    console.log('db error ' + err);
});

const app = express();


const users = require('./routes/User');

const port = 3000;

app.use(cors());
app.use(bodyParser.json());
app.use(passport.initialize());
app.use(passport.session());
require('./config/passport')(passport);

app.use('/users', users);

app.get('/', (req, res) => {
    res.send('Welcome to Encrypic');
});

//run the app and listen on the port we assigned
app.listen(port, () => {
    console.log('Server started on port ' + port);
});