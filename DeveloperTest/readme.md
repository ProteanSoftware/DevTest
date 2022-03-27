# implement repository pattern to decouple data access layer

1. Create a screen that allows a user to manage a list of Customers, the Customer should have a Name and a Type.
   [] Name is required and must have a minimum length of 5 characters
   [+] Type is required and should be a select box of either "Large" or "Small".
   [+] There should be a form to add a new customer (like on the jobs page).
   [+] There should be a list to see all the customers (like on the jobs page).
   [] There should be a link on the list to open the customer record (like on the jobs page).

2. The jobs page needs to be extended to allow assigning a job to a customer.
   [] When creating a job the user should be able to pick a customer from the dropdown.
   [] Selecting a customer should be required for creating a job.
   [] The user should be able to see assigned customer in the jobs list.
   [] For any existing jobs that were not assigned to a customer it should display "Unknown" in the list.
   [] When the user opens the job details from the list this screen should include information about the Customer - Name and Type.