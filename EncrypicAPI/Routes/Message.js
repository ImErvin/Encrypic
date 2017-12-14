const express = require('express');
const router = express.Router();
const config = require('../Config/Database');

const Message = require('../Models/Message');


router.get('/postMessage', (req, res, next) => {

    let newMessage = new Message({
        messageFrom: req.body.messageFrom,
        messageTo: req.body.messageTo,
        sentAt: req.body.sentAt,
        secretkey: req.body.secretkey,
        fileAttachment: req.body.fileAttachment,
    });

    Message.addMessage(newMessage, (err, user) => {
        if (err) {
            res.status(500);
            res.json({ success: false, msg: 'Message failed to add' });
        } else {
            res.status(200);
            res.json({ success: true, msg: 'Message Added' });
        }
    });

});

router.post('/searchMessage', (req, res, next) => {
    
        var query = {
            "username": new RegExp(req.body.query)
        };
        User.searchUsers(query, function (err, users) {
            if (err) return res.send(err)
            res.status(200)
            return res.json(users);
        });
    });