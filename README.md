# C# Tech Challenge

## Welcome!

We're excited for you to tackle this C# coding challenge! It's designed to give us a glimpse into your technical skills and how you approach problem-solving.

## Your Task (Estimated Time: ~6 hours)

You'll be building a service that processes a log file (`webrtc_studio.log`), provides a simple Web API, and includes unit tests.

### Here's a quick rundown:

1. **Log Parsing**: Extract key data from the provided log file (timestamps, event types, user IDs, etc.).
2. **Data Aggregation**: Calculate user activity (joins/leaves) and error counts.
3. **Web API**: Create a Core Minimal API endpoint (`/api/loganalysis`) to serve the aggregated data in JSON format (example JSON structure provided below).
4. **Unit Testing**: Write tests to ensure your solution is robust.

### Example JSON Response:

```json
{
    "totalUserJoins": 4,
    "totalUserLeaves": 4,
    "userActivity": [
        {
            "userId": "456",
            "event": "JOIN",
            "timestamp": "2023-10-27 10:01:00"
        }
        // ... more user activity events
    ],
    "errors": {
        "ERROR": 4,
        "CRITICAL": 2,
        "WARNING": 3
    }
}
```

## Submission & Timeline

You'll receive the log file and details 3-4 days before your interview.
* Fork the repository to your own GitHub account.
* Unless noted elsewhere: Please submit your solution via a pull request against the `develop` branch of the original repository 24 hours before your interview.
* Include clear instructions on how to run your application and tests.
* Use descriptive commit messages.
* Let us know about any assumptions or time-related trade-offs.

## Evaluation

### We'll be looking at:

* **Correctness:** How accurately your code parses the log and aggregates the data.
* **Code Quality:** Readability and maintainability.
* **Testing:** How well you've covered key functionality with unit tests.
* **Web API:** Functionality and JSON structure.

**Note:** A working solution is required to proceed to the second part of the interview.

To ensure a smooth transition to the second part of the interview, please pay close attention to the `/api/loganalysis` endpoint. Your working solution here is essential for the next steps. Please double-check that it's functioning as expected!

## Running Your Service

Please provide instructions on how to run your application locally (e.g., commands, dependencies).

## Log File & Format

The log file (`webrtc_studio.log`) and a sample log file (`SAMPLE_LOG.md`) with the format details are located in the `/logs` directory.

## We're Excited!

We're excited to see your solution! Good luck!
