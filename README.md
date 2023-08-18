# BusTicketBookingSystem
DotNet FSE Project (Note: Frontend is marked as public right now)

# TravelEase - A Bus Ticket Booking System

TravelEase is a web application that allows users to book bus tickets conveniently online. The system offers various features such as browsing available routes, checking schedules, booking seats, and managing bookings. It's built using ASP.NET Core Web API for the backend and React for the frontend.

## Table of Contents
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Contributing](#contributing)

## Features
- User Registration and Authentication
- Browse Available Buses and Routes
- View Bus Schedules
- Book Seats for a Bus Schedule
- View and Manage Bookings
- Admin Panel for Bus and Schedule Management

## Installation
1. Clone the repository
2. Navigate to the backend folder
3. Install backend dependencies

## Usage
1. Run the backend server: `dotnet run` (http://localhost:<port number>)

## Technologies Used
- ASP.NET Core Web API for the backend
- React with Bootstrap for the frontend (Not made public, since it has some flaws)
- Entity Framework Core for database management
- NUnit and Moq for unit testing
- Microsoft SQL Server for data storage

## Getting Started
1. Clone the repository as mentioned in the [Installation](#installation) section.
2. Set up the database connection in the `appsettings.json` file.
3. Run the migrations to create the database: `dotnet ef database update`
4. Seed the initial data if needed.
5. Run the backend applications.
6. Open your Swagger UI (Unless Frontend is ready).

## Contributing
Certain features of this project is not working fine at the moment.
However, Contributions are welcome! If you find any issues or want to enhance the project, feel free to create a pull request. Make sure to follow the coding standards and provide a clear description of the changes.
