const express = require('express');
const router = express.Router();
const passport = require('passport');
const jwt = require('jsonwebtoken');
const config = require('../Config/Database');

const User = require('../Models/User');

router.post('/postUser', (req,res,next)=>{
    let newUser = new User({
        firstName: req.body.firstName,
        surname: req.body.surname,
        username: req.body.username,
        password: req.body.password,
        friends: req.body.friends,
        createdAt: req.body.createdAt
    });

    User.addUser(newUser, (err, user) => {
        if(err){
            res.status(500);
            res.json({success: false, msg: 'Registration Error'});
        } else{
            res.status(200);
            res.json({success: true, msg: 'Registration Success'});
        }
    });
})

module.exports = router;