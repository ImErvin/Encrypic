const mongoose = require('mongoose');
const config = require('../Config/Database');
const User = require('./User');
const Attachment = require('./File');

const MessageSchema = mongoose.Schema({
    messageFrom: {
        type: User,
        required: true
    },
    messageTo: {
        type: User,
        required: true
    },
    sentAt: {
        type: Date,
        required: true
    },
    secretkey: {
        type: String,
        required: true
    },
    fileAttached: {
        type: Boolean,
        required: true
    },
    fileAttachment: {
        type: Attachment
    },
    encryptedMessage: {
        type: String,
        required: true
    },
    expireAt: {
        type: Date,
    }
});

const Message = module.exports = mongoose.model('Message', MessageSchema);