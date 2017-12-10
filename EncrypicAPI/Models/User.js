const mongoose = require('mongoose');
const bcrypt = require('bcryptjs');
const config = require('../Config/Database');

const UserSchema = mongoose.Schema({
    firstName: {
        type: String,
        required: true
    },
    surname: {
        type: String,
        required: true
    },
    username: {
        type: String,
        required: true
    },
    password: {
        type: String,
        required: true
    },
    secretket: {
        type: String,
    },
    friends: {
        type: String,
    },
    createdAt: {
        type: Date
    }
});

const User = module.exports = mongoose.model('User', UserSchema);

// Find one user from the database using their ID
module.exports.getUserById = function(id, callback){
    User.findById(id, callback);
}

// Find one user from the database using their username
module.exports.getUserByUsername = function(username, callback){
    const query = {username: username}
    User.findOne(query, callback);
}

// Create a user on the database
module.exports.addUser = function(newUser, callback){
    bcrypt.genSalt(10, (err, salt) => {
        bcrypt.hash(newUser.password, salt, (err, hash) => {
            if(err) throw err;
            newUser.password = hash;
            newUser.save(callback);
        });
    });
}

// Password compare for the user
module.exports.comparePassword = function(candidatePassword, hash, callback){
    bcrypt.compare(candidatePassword, hash, (err, isMatch) => {
        if(err) throw err;
        callback(null, isMatch);
    });
};