# ASP.NET-Restaurant-Reservation-API
### 1. Web API Project
Welcome to the Restaurant Reservation System project! This repository contains an extensive system for managing restaurant reservations, customers's data, employees's data, and orders's details. The project included the Web API functionality. Let's dive into the expanded requirements and understand the additional features.
This is an ASP.NET Core Web API project named **`RestaurantReservationAPI`**.

### 2. Implemented CRUD Operations

- Created API controllers for each entity and implement CRUD operations.

### 3. Implemented Additional Methods as API Endpoints

- Created endpoints for additional methods:
    - **GET** **`/api/employees/managers`** - List all managers.
    - **GET** **`/api/reservations/customer/{customerId}`** - Retrieve reservations by customer ID.
    - **GET** **`/api/reservations/{reservationId}/orders`** - List orders and menu items for a reservation.
    - **GET** **`/api/reservations/{reservationId}/menu-items`** - List ordered menu items for a reservation.
    - **GET** **`/api/employees/{employeeId}/average-order-amount`** - Calculate average order amount for an employee.
### 4. Implemented Authorization

- Secured the APIs using the JWT authorization mechanism.

### 5. Validation and Error Handling

- Implemented input validation and provided user-friendly error messages.

### 6. API Documentation with Swagger

- Integrated Swagger to auto-generate API documentation. The documentation is comprehensive, including parameters, expected responses, and possible error codes.

### 7. Testing

- Manually tested all endpoints using tools like Postman and the Swagger UI to ensure they're working as expected.
###
