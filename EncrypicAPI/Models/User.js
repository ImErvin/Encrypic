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
        type: Array,
    },
    createdAt: {
        type: Date
    }
});

const User = module.exports = mongoose.model('User', UserSchema);