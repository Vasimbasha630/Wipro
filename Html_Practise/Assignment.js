// URL of the JSON endpoint
const apiUrl = "https://dummy.restapiexample.com/api/v1/employees";

// Using Fetch API to get data
fetch(apiUrl)
  .then(response => response.json()) // Convert response to JSON
  .then(data => {
    console.log("Employee Data:", data);
  })
  .catch(error => {
    console.error("Error fetching data:", error);
  });
