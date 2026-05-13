# Base-Model-Auth-Dotnet
Base Model Authentication Backend Services .Net8 API Services &amp; Frontend Blazor Web UI

# Tech Stack & Architecture Overview

## Project Overview 
Aplikasi ini merupakan sistem berbasis web yang dibangun menggunakan arsitektur modern berbasis service-oriented architecture dengan pemisahan antara backend API dan frontend UI.
Backend dikembangkan menggunakan .NET 8 untuk menyediakan REST API yang scalable dan maintainable, sedangkan frontend menggunakan Blazor Web App untuk membangun antarmuka pengguna interaktif berbasis C#.

Seluruh layanan dijalankan menggunakan containerization melalui Docker guna memastikan konsistensi environment deployment dan mempermudah proses development maupun production deployment.

Database utama menggunakan Microsoft SQL Server sebagai relational database untuk penyimpanan data aplikasi.

# Technology Stack

## Backend
Framework : 
- .NET 8
- ASP.NET Core Web API

Responsibilities : 
- Menyediakan RESTful API
- sAuthentication & Authorization
- Business Logic Processing
- sData Validation
- Database Communication
- Logging & Error Handling

Common Libraries : 
- Entity Framework Core
- FluentValidation
- AutoMapper
- Serilog
- JWT Authentication
- Swagger / OpenAPI

Architecture Pattern : 
- Clean Architecture
- Layered Architecture
- Repository Pattern
- Dependency Injection

## Frontend
Framework : 
- Blazor Web App

Rendering Mode : 
- Interactive Server / Interactive WebAssembly (sesuaikan kebutuhan)

Responsibilities :
- User Interface Rendering
- API Consumption
- State Management
- Form Handling & Validation
-  Authentication Session Handling

UI Technologies : 
- Razor Components
- Bootstrap / Tailwind CSS
- Blazor Component Library (MudBlazor / Radzen jika digunakan)

## Database
Database Engine : 
Microsoft SQL Server

Responsibilities : 
- Relational Data Storage
- Transaction Management
- Stored Procedures (optional)
- Query Optimization
- Backup & Recovery

ORM : 
- Entity Framework Core

## Containerization & Deployment
Container Platform : 
- ocker

Usage :
- Backend Container
- Frontend Container
- Database Container
- Environment Consistency
- CI/CD Integration

Orchestration (Optional) : 
- Docker Compose
- Kubernetes (jika scale production besar)

## Development Control
Version Control : 
- Git

Repository Hosting : 
- GitHub / GitLab

## High Level Architecture Diagram
[ Blazor Web UI ]
        |
        v
[ .NET 8 Web API ]
        |
        v
[ SQL Server Database ]

All services run inside Docker Containers