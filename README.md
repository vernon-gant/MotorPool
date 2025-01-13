# Motor Pool Management System

## Project Overview

The Motor Pool Management System is a comprehensive web application designed for managing vehicles, enterprises, drivers, and trips efficiently. It provides features for tracking vehicle details, managing enterprises and their managers, assigning drivers, handling GPS tracks, and generating detailed reports.

## Features and Functionalities

### Vehicle Management
- **Vehicles**: Add, edit, view, and delete vehicles with details such as cost, manufacture year, mileage, and acquisition date.
- **Brands**: Separate model to manage brand details including type (passenger car, truck, bus), fuel tank capacity, payload capacity, and seating.

**Screenshot Placeholder:** `/mnt/data/enterprise vehicles.png`
**Screenshot Placeholder:** `/mnt/data/vehicle brands.png`

### Enterprise Management
- **Enterprises**: Add and manage enterprises, each associated with vehicles, drivers, and managers. Enterprises are assigned time zones for accurate time management.
- **Managers**: Enterprises have assigned managers, inheriting from standard users with authorization.

**Screenshot Placeholder:** `/mnt/data/home.png`

### REST API
- Comprehensive API for managing vehicles, brands, enterprises, and drivers.
- Supports CRUD operations for vehicles and enterprises.
- Paged responses for large datasets.
- Time-zone-aware API for date-time fields.

### Driver Management
- Assign drivers to enterprises and vehicles. Drivers can be active for specific vehicles, ensuring accurate tracking.
- Supports many-to-many relationships between vehicles and drivers.

**Screenshot Placeholder:** `/mnt/data/vehicle details.png`

### GPS Tracking and Trips
- **Trips**: Tracks vehicle trips with start and end timestamps in UTC, associated with enterprise time zones.
- **GPS Tracks**: Efficient storage and retrieval of GPS data for trips, with support for geoJSON.
- Generate realistic GPS tracks using city maps and routing APIs.

**Screenshot Placeholder:** `/mnt/data/map.png`
**Screenshot Placeholder:** `/mnt/data/trips.png`

### Reports
- Generate reports for vehicle mileage over specified periods (day, month, year).
- REST API for report generation with customizable parameters.
- Web interface for report visualization and downloading.

**Screenshot Placeholder:** `/mnt/data/reports.png`
**Screenshot Placeholder:** `/mnt/data/vehicle mileage report.png`

## Key Technical Highlights

- **Technologies Used**: ASP.NET Core MVC, Entity Framework Core, RESTful APIs.
- **Pagination**: Efficient handling of large datasets using paginated responses.
- **Time Zone Management**: Accurate time handling across multiple time zones.
- **Routing and Maps**: Integration with OpenRouteService and Map APIs for GPS track generation and visualization.
- **Data Models**: Separation of concerns with distinct models for vehicles, brands, enterprises, drivers, trips, and reports.

## Technical Experiments and Educational Additions

### Data Generation Tools
- **Vehicles and Drivers**: Generates thousands of vehicles and drivers, with realistic details. Useful for development and testing.
- **GPS Tracks**: Simulates realistic vehicle tracks over a specified range, with routing APIs (e.g., OpenRouteService).

### Deployment
- Automated deployment using a Docker Compose setup with the UI and database in separate containers.
- Script installs Docker and builds the project for seamless deployment.

### Telegram Bot
- Created a Telegram bot for manager interaction:
- Features login functionality and report generation for vehicles and enterprises.
- Commands include `/login` for authentication and mileage report retrieval.

### Caching
- Implemented caching for improved performance:
- Output caching middleware for web pages.
- IMemoryCache for storing frequently accessed data, such as reports.

### CI/CD
- Experimented with CI/CD pipelines in Azure:
- Built services, created Docker images, and pushed them to Azure Container Registry.
- Focused on learning the fundamentals of CI/CD pipelines.

### Microservices
- Added microservices using Kafka for educational purposes:
- One service stores telemetry data in Azure Blob Storage.
- Another monitors vehicle speeds and sends alerts if thresholds are exceeded.

### Load Testing
- Conducted load testing using the NBomber library:
- Tested API endpoints under high traffic to evaluate performance and scalability.

### Integration and E2E Testing
- **Integration Tests**: Used ASP.NET integration testing framework:
    - Spun up Docker containers for databases during tests.
    - Verified end-to-end system behavior.
- **E2E Tests**: Developed Cypress tests for various user workflows in the UI.

### Logging
- Integrated logging with ASP.NET Core and experimented with Serilog
- Configured structured logging and log analysis tools for better traceability.

### Load and Stress Testing
- Conducted load testing to simulate real-world usage scenarios:
- Explored tools like NBomber to evaluate API resilience.

### CI/CD Experimentation
- Built CI/CD pipelines focusing on Docker-based workflows:
- Explored continuous integration practices and containerization.
- Focused on understanding the deployment process without production-grade deployment.

### Microservices Implementation
- Implemented microservices for telemetry processing:
- Used Kafka as the message broker.
- Developed services for data storage and threshold-based alerts.

### Integration Tests
- Added comprehensive integration tests for REST APIs:
- Used Dockerized databases for testing in isolated environments.
- Covered core use cases and business logic.

### Educational Insights
- All implementations were undertaken for educational purposes.
- Gained practical insights into multiple technologies and frameworks.
- These experiments were designed to explore potential solutions and understand the basics, not to create production-grade systems.

