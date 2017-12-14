const mongoose = require('mongoose');
const config = require('../Config/Database');
const User = require('./User');
const Attachment = require('./File');

const MessageSchema = mongoose.Schema({
    messageFrom: {
        type: String,
        required: true
    },
    messageTo: {
        type: String,
        required: true
    },
    sentAt: {
        type: String,
        required: true
    },
    secretkey: {
        type: String,
        required: true
    },
    fileAttachment: {
        type: String
    }
});

const Message = module.exports = mongoose.model('Message', MessageSchema);