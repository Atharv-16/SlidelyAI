# SlidelyAI
# Google Forms Clone

This project is a simplified clone of Google Forms, consisting of a frontend built with Visual Basic and a backend built with Express.js.

## Backend (Express.js)

The backend is responsible for handling submissions and providing data to the frontend application.

### Prerequisites

- Node.js (v14.x or higher)
- npm (Node Package Manager)

### Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/your-repo.git
   cd slidely

2. Build the Project
If necessary:
```bash
npm run build
```
3. Start the Server
```bash
npm start
```

The server will start running on http://localhost:3000.

## API Endpoints
/submissions - GET: Fetches all submissions.
/submissions/
- GET: Fetches a specific submission by ID.
## Environment Variables
Make sure to set the following environment variables:

PORT - Port number for the server (default: 3000).
Any other relevant configuration variables (database connection, etc.).
## Frontend (Visual Basic)
The frontend is built using Visual Basic and interacts with the backend API to display and manage form submissions.

## Installation
- Navigate to the GoogleFormsClone folder.
- Run the setup file named setup to install the application.
- Ensure all dependencies are installed as per the setup instructions.

## Running the Application
- Open the Visual Basic project in your preferred IDE (e.g., Visual Studio).
- Build and run the project to start the frontend application.
### Features
- Create New Submission: Allows users to input Name, Email, Phone Number, GitHub repo link, and manage a stopwatch.
- View Submissions: Navigate through all form entries and view details of each submission.
