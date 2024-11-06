# Event Management Application

This is an ASP.NET MVC application for managing events and participants, utilizing several design patterns (Abstract Factory, Observer, Strategy) to ensure modularity, flexibility, and scalability. The application is structured around models, view models, abstractions, implementations for services with CRUD operations, and both client-side and server-side validations.

---

## Table of Contents
- [Overview](#overview)
- [Technologies](#technologies)
- [Design Patterns](#design-patterns)
- [Structure](#structure)
- [Models and ViewModels](#models-and-viewmodels)
- [Services](#services)
- [Validations](#validations)
- [Getting Started](#getting-started)

---

## Overview

The Event Management Application is a web application for organizing and managing events and participants. The application supports creating, reading, updating, and deleting (CRUD) operations for events and participants, along with notifying relevant parties of changes to the event status. The application also includes client-side and server-side validation to ensure data integrity.

---

## Technologies

- ASP.NET MVC
- C#
- Entity Framework Core (for data access)
- SQL Server (database)
- HTML, CSS, JavaScript (client-side)
  
---

## Design Patterns

This application makes use of the following design patterns to achieve clean architecture:

1. **Abstract Factory** - For creating different types of events and participants.
2. **Observer** - For notifying observers when events are updated.
3. **Strategy** - For providing different sorting mechanisms for events.

---

## Structure

The main folders in the project and their purposes are as follows:

- **Controllers**: Handle incoming HTTP requests, coordinate the logic, and return responses.
- **Models**: Define the entities and database structures.
- **Factories**: Implement the Abstract Factory pattern for creating instances of different types of events and participants.
- **Observers**: Implement the Observer pattern to notify changes to specific components (e.g., email notifications).
- **Strategies**: Implement the Strategy pattern to provide flexible sorting options.
- **ViewModels**: Used to represent the data in views, tailored to the user interface requirements.
- **Services**: Contain business logic and interact with repositories to perform CRUD operations.

---

## Models and ViewModels

### Models

1. **Event** - Represents an event with basic properties such as `Id`, `Title`, `Description`, `Date`, and `Location`.
2. **Participant** - A base class representing a participant in an event, with properties like `Id`, `Name`, and `Email`.
3. **AttendeeParticipant** and **SpeakerParticipant** - Derived from `Participant`, these classes represent different types of participants with specific properties or roles.
   
### ViewModels

ViewModels are used to bridge the gap between the data and UI, ensuring that only necessary information is exposed to the views.

1. **EventViewModel** - Contains the properties required to display an event in the views, such as title, date, and participant list.
2. **ParticipantViewModel** - Used to display information about participants, like name, email, and role in the event.

---

## Services

The application includes abstractions and implementations for services that manage the business logic and interactions with the database.

1. **EventService** - Manages CRUD operations for events. The service is responsible for retrieving, creating, updating, and deleting event records.
2. **ParticipantService** - Handles CRUD operations for participants. This service is responsible for adding, editing, and removing participants from events.

Each service has an interface (e.g., `IEventService`) defining the operations, along with an implementation (e.g., `EventService`) that executes the logic. Using interfaces makes the services more flexible and allows for dependency injection, making it easy to replace implementations when needed.

---

## Validations

The application includes both client-side and server-side validations to ensure data consistency and provide immediate feedback to users.

### Server-Side Validation

1. **Data Annotations** - Attributes like `[Required]`, `[StringLength]`, `[EmailAddress]`, etc., are applied to model properties to enforce validation rules at the server level.
2. **Custom Validation** - Certain business rules are enforced through custom validation logic in the service layer to ensure data integrity and handle specific scenarios.

### Client-Side Validation

1. **JavaScript** - Client-side validation is implemented using JavaScript, ensuring that required fields are filled, email formats are correct, and certain input values are within acceptable ranges.
2. **jQuery Validation** - Provides additional validation feedback on the client side, helping users correct any mistakes before submission.

---

## Design Patterns in Detail

### Abstract Factory

The **Abstract Factory** pattern is used to create different types of events and participants.

- `IParticipantFactory` is an interface for creating different participant types.
- `ParticipantFactory` is a concrete implementation of `IParticipantFactory` that generates instances of `AttendeeParticipant` or `SpeakerParticipant`.
- `EventFactory` serves as an abstract factory for creating different types of events.
- `ConferenceEventFactory` and `SeminarEventFactory` are concrete factories that create specific types of events, such as conferences and seminars.

### Observer

The **Observer** pattern allows observers to be notified of changes in the state of an event.

- `IObserver` defines a common interface for observers to implement an `Update()` method.
- `EmailNotificationObserver` and `LogNotificationObserver` implement `IObserver`, each providing specific ways to handle updates (e.g., sending email notifications or logging the change).
- `EventNotifier` is responsible for maintaining a list of observers and notifying them of any updates.

### Strategy

The **Strategy** pattern provides flexibility in sorting events.

- `ISortingStrategy` is an interface defining a `Sort()` method, which the concrete strategies implement.
- `SortByDateStrategy` and `SortByTitleStrategy` implement `ISortingStrategy` to sort events by date and title, respectively.

---

## Getting Started

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/EventManagementApp.git
   ```

2. **Setup the database**:
   - Update the connection string in `appsettings.json` to point to your SQL Server instance.
   - Run migrations to set up the database schema:
     ```bash
     dotnet ef database update
     ```

3. **Run the application**:
   ```bash
   dotnet run
   ```
   
4. **Access the application**:
   - Open your browser and go to `http://localhost:5000` (or the port configured).

---

## Contributing

If you want to contribute to the project, feel free to fork the repository and submit a pull request with your improvements.

---

## License

This project is licensed under the MIT License.