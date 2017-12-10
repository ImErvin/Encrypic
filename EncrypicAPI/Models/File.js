const mongoose = require('mongoose');
const config = require('../Config/Database');

const FileSchema = mongoose.Schema({
    encryptedB64: {
        type: String,
        required: true
    }
});

const File = module.exports = mongoose.model('File', FileSchema);