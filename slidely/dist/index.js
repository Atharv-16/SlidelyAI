"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
const body_parser_1 = __importDefault(require("body-parser"));
const fs = require('fs');
const app = (0, express_1.default)();
const port = 3000;
app.use(body_parser_1.default.json());
// Ping endpoint
app.get('/ping', (req, res) => {
    res.json({ message: 'pong' });
});
// Submit endpoint
app.post('/submit', (req, res) => {
    const { name, email, phone, github_link, stopwatch_time } = req.body;
    // Handle submission data, e.g., save to a JSON file or database
    console.log(`Received submission: ${name}, ${email}, ${phone}, ${github_link}, ${stopwatch_time}`);
    res.json({ message: 'Submission received' });
});
// Read endpoint
app.get('/read', (req, res) => {
    const index = req.query.index !== undefined ? +req.query.index : -1; // Adjust to your preference
    // Assuming you have a db.json file with submission data
    const dbPath = 'C:/Users/Asus/Desktop/slidely/db.json'; // Adjust the path as necessary
    const submissions = require(dbPath);
    if (index >= 0 && index < submissions.length) {
        res.json(submissions[index]);
    }
    else {
        res.status(404).json({ message: 'Submission not found' });
    }
});
// Start server
app.listen(port, () => {
    console.log(`Server running at http://localhost:${port}`);
});
