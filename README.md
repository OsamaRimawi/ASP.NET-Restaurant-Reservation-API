# ASP.NET-Restaurant-Reservation-API
### 1. Web API Project

- a new ASP.NET Core Web API project named **`RestaurantReservationAPI`**.

### 3. Implemented CRUD Operations

- Created API controllers for each entity and implement CRUD operations.

### 4. Implemented Reservation Endpoints

- Included CRUD and other specific endpoints for reservations.

### 5. Implemented Additional Methods as API Endpoints

- Created endpoints for additional methods:
    - **GET** **`/api/employees/managers`** - List all managers.
    - **GET** **`/api/reservations/customer/{customerId}`** - Retrieve reservations by customer ID.
    - **GET** **`/api/reservations/{reservationId}/orders`** - List orders for a reservation.
    - **GET** **`/api/reservations/{reservationId}/menu-items`** - List ordered menu items for a reservation.
    - **GET** **`/api/employees/{employeeId}/average-order-amount`** - Calculate average order amount for an employee.

### 7. Implemented Authorization

- Secured the APIs using JWT authorization mechanism.

### 8. Validation and Error Handling

- Implemented input validation and provide user-friendly error messages.

### 9. API Documentation with Swagger

- Integrated Swagger to auto-generate API documentation. The documentation is comprehensive, including parameters, expected responses, and possible error codes.

### 10. Testing

- Manually tested all endpoints using tools like Postman and the Swagger UI to ensure they're working as expected.
###
