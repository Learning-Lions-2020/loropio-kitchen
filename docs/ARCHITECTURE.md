# Loropio Kitchen Architecture

This document describes the architecture and design principles of the Loropio Kitchen application.

---

## Overview

Loropio Kitchen is a full-featured web application for booking meals, managing orders, and streamlining kitchen operations. It is built with a modern, scalable, and maintainable architecture using:

- **Frontend:** React, TypeScript, Vite
- **Backend:** .NET 9, C#

---

## Architectural Principles

- **Domain-Driven Design (DDD):** Business logic is organized around core domain concepts.
- **Separation of Concerns:** Each layer has a clear responsibility.
- **Microservice-Oriented:** The backend is modular and can be extended to microservices.
- **Repository Pattern:** Data access is abstracted for testability and flexibility.
- **Mediator Pattern:** Application logic is decoupled using MediatR.
- **DTOs & AutoMapper:** Data Transfer Objects are mapped to domain models for API communication.
- **Fluent Validation:** Business rules are enforced with validators.
- **Unit Testing:** Comprehensive tests ensure reliability.

---

## Solution Structure

```
backend/
  LoropioKitchen.API/           # ASP.NET Core Web API
  LoropioKitchen.Application/   # Application layer (MediatR, business logic)
  LoropioKitchen.Application.Tests/ # Unit tests
  LoropioKitchen.Data/          # Data access (EF Core, repositories)
  LoropioKitchen.Domain/        # Domain models and entities

frontend/
  src/                          # React app source code
  public/                       # Static assets
  ...
```

---

## Backend Layers

### 1. **Domain Layer**
- Contains core entities (e.g., [`LoropioKitchen.Domain.Entities.User`](../backend/LoropioKitchen.Domain/Entities/User.cs)).
- No dependencies on other layers.

### 2. **Data Layer**
- Implements repositories (e.g., [`LoropioKitchen.Data.Repositories.UserRepository`](../backend/LoropioKitchen.Data/Repositories/UserRepository.cs)).
- Uses Entity Framework Core for database access.
- Defines [`LoropioKitchen.Data.DbContexts.LoropioKitchenDbContext`](../backend/LoropioKitchen.Data/DbContexts/LoropioKitchenDbContext.cs).

### 3. **Application Layer**
- Contains business logic, MediatR handlers, validators, and DTOs.
- Interfaces for repositories (e.g., [`LoropioKitchen.Application.Contracts.IUserRepository`](../backend/LoropioKitchen.Application/Contracts/IUserRepository.cs)).
- Maps DTOs to domain entities using AutoMapper.

### 4. **API Layer**
- ASP.NET Core controllers expose REST endpoints.
- Handles HTTP requests, authentication, and OpenAPI documentation.

---

## Frontend

- Built with React and TypeScript.
- Uses Vite for fast development and builds.
- Tailwind CSS for styling.
- Communicates with the backend via REST APIs.

---

## Environment & Feature Flags

- Use feature flags to enable/disable features per environment (test, staging, production).
- Avoid multiple release branches; deploy from the latest release branch and control features in code.

---

## Testing

- Unit tests are located in `backend/LoropioKitchen.Application.Tests/`.
- Use xUnit and Moq for backend testing.
- Frontend tests can be added with Jest or React Testing Library.

---

## Deployment

- **Backend:** Deploy ASP.NET Core API from the latest release branch.
- **Frontend:** Deploy static assets built by Vite.
- Use CI/CD pipelines defined in `.github/workflows/`.

---

## Extending the Architecture

- Add new features by creating new domain entities, repositories, and MediatR handlers.
- Use the Releaseflow branching strategy (see [CONTRIBUTING.md](../CONTRIBUTING.md)).

---

For further details, see the code in each layer and the [README](../README.md).