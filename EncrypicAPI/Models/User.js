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
        required: true,
        select: false
    },
    secretkey: {
        type: String,
    },
    friends: {
        type: String,
    },
    createdAt: {
        type: String,
    },
    profilePicture:{
        type: String
    }
});

const User = module.exports = mongoose.model('User', UserSchema);

// Find one user from the database using their username
module.exports.getUserByUsername = function(username, callback){
    const query = {username: username}
    User.findOne(query, callback).select('+password');
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

module.exports.updateUser = function(user, callback){
    user.save(callback);
}

// Password compare for the user
module.exports.comparePassword = function(candidatePassword, hash, callback){
    bcrypt.compare(candidatePassword, hash, (err, isMatch) => {
        if(err) throw err;
        callback(null, isMatch);
    });
}

// Return all users
module.exports.getAllUsers = function(callback){
    User.find(function(err, users) {
        if (err) throw err;

        callback(users);
});
}


module.exports.searchUsers = function(query, callback){
    User.find(query)
    .exec(function(err, result) {
        if (err) throw err;
        callback(result);
    });
}
;