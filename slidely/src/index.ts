import * as express from 'express';
import * as bodyParser from 'body-parser';
const fs = require('fs');

const app = express();
const port = 3000;

app.use(bodyParser.json());

// Ping endpoint
app.get('/ping', (req: express.Request, res: express.Response) => {
  res.json({ message: 'pong' });
});

// Submit endpoint
app.post('/submit', (req: express.Request, res: express.Response) => {
  const { name, email, phone, github_link, stopwatch_time } = req.body;
  // Handle submission data, e.g., save to a JSON file or database
  console.log(`Received submission: ${name}, ${email}, ${phone}, ${github_link}, ${stopwatch_time}`);
  res.json({ message: 'Submission received' });
});

// Read endpoint
app.get('/read', (req: express.Request, res: express.Response) => {
  const index = +req.query.index; // Convert query parameter to number
  // Implement logic to read submission data based on index
  // Assuming you have a db.json file with submission data
  const submissions = require('C:\Users\Asus\Desktop\slidely\db.json');
  if (index >= 0 && index < submissions.length) {
    res.json(submissions[index]);
  } else {
    res.status(404).json({ message: 'Submission not found' });
  }
});

// Start server
app.listen(port, () => {
  console.log(`Server running at http://localhost:${port}`);
});
