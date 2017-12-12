const express = require('express');
const router = express.Router();
const passport = require('passport');
const jwt = require('jsonwebtoken');
const config = require('../Config/Database');

const User = require('../Models/User');

router.get('/getUsers', (req, res, next) => {
    
        User.getAllUsers(function (err, users) {
            if (err) return res.send(err)
    
            return res.json(users);
        });
    });

router.post('/postUser', (req, res, next) => {

    User.getUserByUsername(req.body.username, (err, user) => {
        if (err) throw err;

        if (user) {
            res.status(409);
            return res.json({ success: false, msg: 'Username already exists' });
        }

        let newUser = new User({
            firstName: req.body.firstName,
            surname: req.body.surname,
            username: req.body.username,
            password: req.body.password,
            friends: req.body.friends,
            createdAt: req.body.createdAt,
            profilePicture: req.body.profilePicture
        });

        console.log(req.body.profilePicture);
        User.addUser(newUser, (err, user) => {
            if (err) {
                res.status(500);
                res.json({ success: false, msg: 'Registration Error' });
            } else {
                res.status(200);
                res.json({ success: true, msg: 'Registration Success' });
            }
        });
    });


})

//authenticate route
router.post('/authenticate', (req, res, next) => {
    const username = req.body.username;
    const password = req.body.password;

    User.getUserByUsername(username, (err, user) => {
        if (err) throw err;

        if (!user) {
            res.status(404);
            return res.json({ success: false, msg: 'Username not found' });
        }

        User.comparePassword(password, user.password, (err, isMatch) => {
            if (err) throw err;

            //if passwords do match
            if (isMatch) {
                res.json({
                    success: true,
                    user: {
                        id: user._id,
                        firstName: user.firstName,
                        surname: user.surname,
                        username: user.username,
                        secretkey: user.secretkey,
                        friends: user.friends,
                        createdAt: user.createdAt,
                        profilePicture: user.profilePicture
                    }
                });
            } else {
                res.status(422);
                return res.json({ success: false, msg: 'Wrong password' });
            }
        });
    });
});

router.get('/search', (req, res, next) => {
    var query = {
        "username": new RegExp(req.body.query)
    };
    User.searchUsers(query, function (err, users) {
        if (err) return res.send(err)

        return res.json(users);
    });
});

module.exports = router;