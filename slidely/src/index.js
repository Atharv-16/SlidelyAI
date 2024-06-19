"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var express = require("express");
var bodyParser = require("body-parser");
var fs = require('fs');
var app = express();
var port = 3000;
app.use(bodyParser.json());
// Ping endpoint
app.get('/ping', function (req, res) {
    res.json({ message: 'pong' });
});
// Submit endpoint
app.post('/submit', function (req, res) {
    var _a = req.body, name = _a.name, email = _a.email, phone = _a.phone, github_link = _a.github_link, stopwatch_time = _a.stopwatch_time;
    // Handle submission data, e.g., save to a JSON file or database
    console.log("Received submission: ".concat(name, ", ").concat(email, ", ").concat(phone, ", ").concat(github_link, ", ").concat(stopwatch_time));
    res.json({ message: 'Submission received' });
});
// Read endpoint
app.get('/read', function (req, res) {
    var index = +req.query.index; // Convert query parameter to number
    // Implement logic to read submission data based on index
    // Assuming you have a db.json file with submission data
    var submissions = require('C:\Users\Asus\Desktop\slidely\db.json');
    if (index >= 0 && index < submissions.length) {
        res.json(submissions[index]);
    }
    else {
        res.status(404).json({ message: 'Submission not found' });
    }
});
// Start server
app.listen(port, function () {
    console.log("Server running at http://localhost:".concat(port));
});
