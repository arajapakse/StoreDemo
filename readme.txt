> Add-Migration
> Update-Database
>  Add-Migration Initial -Context StoreDemoDbContext

Store Demo

Entities and Their Roles
- User: Represents customers and admins of the store.- Properties like FirstName, LastName, and EmailAddress store user information.
- The Role enum defines whether the user is a "Customer" or "Admin".
- A one-to-many relationship is established with Orders, meaning a user can place multiple orders.

- Role (Enum): Provides a strongly typed representation for the user's role.- Roles like Customer and Admin make the system more secure and user-friendly.

- Product: Contains details about items available in the store.- Includes properties like Name, Description, Price, and StockQuantity.
- It has a foreign key (CategoryId) linking it to a Category, establishing a many-to-one relationship where a product belongs to one category.
- A product can be part of multiple orders through a many-to-many relationship implemented by OrderItems.

- Category: Organizes products into groups.- A one-to-many relationship is defined between Category and Product, meaning a category can contain multiple products.

- Order: Represents an order placed by a user.- Links back to the User via UserId, establishing a many-to-one relationship where one user can place multiple orders.
- Contains properties like OrderDate and Status to track order details.
- A one-to-many relationship is set with OrderItems to represent the products in the order.
- Includes a one-to-one relationship with Payment, tracking how the order was paid.

- OrderItem: Bridges the many-to-many relationship between Order and Product.- Tracks the quantity and price for each product in an order.
- Links to Order and Product via foreign keys (OrderId and ProductId).

- Payment: Stores payment information for an order.- The foreign key OrderId links it back to the Order.
- Properties like PaymentDate, PaymentAmount, and PaymentMethod store transaction details.


Relationships Summary
- User ↔ Orders: A one-to-many relationship where each user can place multiple orders.
- Category ↔ Products: A one-to-many relationship where a category can have multiple products.
- Order ↔ OrderItems ↔ Product: A many-to-many relationship where orders can contain multiple products, and products can appear in multiple orders. This is achieved through the OrderItem entity.
- Order ↔ Payment: A one-to-one relationship where each order has a single payment record.

Design Benefits
- The schema ensures consistency and adheres to relational database principles.
- Relationships between entities like User and Order, or Product and Category, allow for efficient data retrieval.
- The use of enums (Role) enhances code readability and minimizes invalid data entries.

Here’s a concise presentation outline for your project:
---
StoreDemo: Admin Product Management API
Overview
•	Project Type: Blazor WebAssembly with .NET 8
•	Purpose: A robust API for managing products in an e-commerce platform.
•	Key Features:
•	Create, update, and delete products.
•	Built with clean architecture principles.
•	Uses MediatR for CQRS (Command Query Responsibility Segregation).
---
Core Components
1.	AdminProductsController:
•	Central API controller for product management.
•	Endpoints:
•	POST /adminapi/v1/Products: Create a new product.
•	PUT /adminapi/v1/Products/{productId}: Update an existing product.
•	DELETE /adminapi/v1/Products/{productId}: Delete a product.
2.	Commands and Queries:
•	Commands:
•	CreateProductCommand: Handles product creation.
•	UpdateProductCommand: Updates product details.
•	DeleteProductCommand: Deletes a product.
•	Queries:
•	Retrieve product details or lists (not shown in the current file).
3.	Domain Models:
•	Product: Represents a product entity with properties like Name, Price, StockQuantity, and Category.
•	Category: Links products to their respective categories.
•	OrderItem: Tracks product usage in orders.
---
Technical Highlights
•	MediatR Integration:
•	Decouples business logic from controllers.
•	Simplifies request handling with commands and queries.
•	BaseResponse:
•	Standardized response structure for API operations.
•	Includes result data and error handling.
---
Future Enhancements
•	Add product search and filtering capabilities.
•	Implement authentication and role-based access control.
•	Integrate with the Blazor WebAssembly frontend for seamless admin management.
---
This project demonstrates a scalable, maintainable approach to building modern APIs for e-commerce platforms.

