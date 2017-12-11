const express = require('express');
const router = express.Router();
const passport = require('passport');
const jwt = require('jsonwebtoken');
const config = require('../Config/Database');

const User = require('../Models/User');

router.post('/postUser', (req,res,next)=>{

    console.log(req.body);
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
            console.log("woops");
            res.json({success: false, msg: 'Registration Error'});
        } else{
            res.status(200);
            console.log("added " + newUser)
            res.json({success: true, msg: 'Registration Success'});
        }
    });
})

router.get('/users', (req,res,next)=>{

    console.log("HERE");

    User.find(function(error, users) {
                if (error) return res.send(error);

                return res.json(users);
        });
        // console.log(req.body);
        // let newUser = new User({
        //     firstName: req.body.FirstName,
        //     surname: req.body.Surname,
        //     username: req.body.Username,
        //     password: req.body.Password,
        //     friends: req.body.Friends,
        //     createdAt: req.body.CreatedAt
        // });
    
        // User.addUser(newUser, (err, user) => {
        //     if(err){
        //         res.status(500);
        //         console.log("woops");
        //         res.json({success: false, msg: 'Registration Error'});
        //     } else{
        //         res.status(200);
        //         console.log("added " + newUser)
        //         res.json({success: true, msg: 'Registration Success'});
        //     }
        // });
    })

module.exports = router;