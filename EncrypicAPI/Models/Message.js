const mongoose = require('mongoose');
const config = require('../Config/Database');

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

module.exports.addMessage = function(newMessage, callback){
    newMessage.save(callback);
}

module.exports.searchMessages = function(query, callback){
    Message.find(query)
    .exec(function(err, result) {
        if (err) throw err;
        callback(result);
    });
}

module.exports.removeMessage = function(newMessage, callback){
    Message.findOneAndRemove(newMessage.id)
    .exec(function(err, result) {
        if (err) throw err;
        callback(result);
    });
}
;
