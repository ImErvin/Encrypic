const express = require('express');
const router = express.Router();
const config = require('../Config/Database');

const Message = require('../Models/Message');


router.post('/postMessage', (req, res, next) => {

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
            console.log(newMessage);
            res.status(200);
            res.json({ success: true, msg: 'Message Added' });
        }
    });

});

router.get('/getMessages', (req, res, next) => {

    Message.getMessages(function (err, messages) {
        if (err) return res.send(err)

        return res.json(messages);
    });
});

router.post('/search', (req, res, next) => {
    console.log(req.body);
    
    var query = {
        "messageTo": new RegExp(req.body.query)
    };
    Message.searchMessages(query, function (err, messages) {
        if (err) return res.send(err)
        res.status(200)
        return res.json(messages);
    });
});

router.delete('/deleteMessage',(req, res, next) => {

    Message.removeMessage(req.body.id, function (err, newMessage) {
        if (err) return res.send(err)
        res.status(200)
        return es.json({ success: true, msg: 'Message Removed' });
    });
});

module.exports = router;