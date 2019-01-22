SELECT Status, IssueDate FROM Jobs
WHERE Status IN('In Progress', 'Pending')
ORDER BY IssueDate, JobId