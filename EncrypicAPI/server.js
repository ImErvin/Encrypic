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

//set up users var for routing
const users = require('./routes/users');

//port
const port = 3000;

app.listen(port, () => {
    console.log('Server started on port ' + port);
});