import express from 'express';
import bodyParser from 'body-parser';
import fs from 'fs';

const app = express();
const port = 3000;
const dbPath = './db.json'; // Adjust the path as necessary

app.use(bodyParser.json());

// Ping endpoint
app.get('/ping', (req, res) => {
  res.json({ message: 'pong' });
});

// Submit endpoint
app.post('/submit', (req, res) => {
  const { name, email, phone, github_link, stopwatch_time } = req.body;

  // Log received submission
  console.log(`Received submission: ${name}, ${email}, ${phone}, ${github_link}, ${stopwatch_time}`);

  // Read current submissions from db.json
  let submissions = [];
  try {
    const dbData = fs.readFileSync(dbPath, 'utf8');
    submissions = JSON.parse(dbData);
  } catch (error) {
    console.error('Error reading db.json:', error);
    return res.status(500).json({ message: 'Error reading db.json' });
  }

  // Add new submission to submissions array
  submissions.push({ name, email, phone, github_link, stopwatch_time });

  // Write updated submissions back to db.json
  try {
    fs.writeFileSync(dbPath, JSON.stringify(submissions, null, 2));
    console.log('Submission saved:', { name, email, phone, github_link, stopwatch_time });
    res.json({ message: 'Submission received and saved' });
  } catch (error) {
    console.error('Error writing to db.json:', error);
    res.status(500).json({ message: 'Error writing to db.json' });
  }
});


// Read endpoint
app.get('/read', (req, res) => {
  const index = req.query.index !== undefined ? +req.query.index : -1;

  // Read submissions from db.json
  let submissions = [];
  try {
    submissions = JSON.parse(fs.readFileSync(dbPath, 'utf8'));
  } catch (error) {
    console.error('Error reading db.json:', error);
    return res.status(500).json({ message: 'Error reading submissions' });
  }

  if (index >= 0 && index < submissions.length) {
    res.json(submissions[index]);
  } else {
    res.status(404).json({ message: 'Submission not found' });
  }
});

// Total submissions endpoint
app.get('/total', (req, res) => {
  // Read submissions from db.json
  let submissions = [];
  try {
    submissions = JSON.parse(fs.readFileSync(dbPath, 'utf8'));
  } catch (error) {
    console.error('Error reading db.json:', error);
    return res.status(500).json({ message: 'Error reading submissions' });
  }

  // Calculate total number of submissions
  const totalSubmissions = submissions.length;

  // Send total submissions count as JSON response
  res.json({ total: totalSubmissions });
});

// Start server
app.listen(port, () => {
  console.log(`Server running at http://localhost:${port}`);
});