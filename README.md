# Clinic Management Application

This application is a clinic management system designed to handle users, patients, doctors, and appointments. It is built using a three-layer architecture pattern consisting of the Business Logic Layer (BLL), Data Access Layer (DAL), and User Interface Layer (UI). It was developed in C# with a SQL Server backend. It was part of Multi-Tier Application Development course at College LaSalle.

The following will be an overview of the architecture and a guide on how to implement the Patient, Doctor, and Appointment entities following the same patterns used for the User entity.

## Architecture Overview

This application follows a three-layer architecture pattern:

- **BLL (Business Logic Layer)**: Contains entity classes and business logic
- **DAL (Data Access Layer)**: Handles database operations
- **UI (User Interface Layer)**: Contains forms for user interaction

## Current Implementation: User Entity

### BLL Layer: User.cs

The `User` class represents a user entity with three core properties:

- `Id` (int): Primary key
- `Username` (string): Validated on assignment
- `Role` (RolesEnum): Administrator, Doctor, or Receptionist

**Key Design Patterns:**

1. **Property Validation**: The `Username` setter calls `Validator.ValidateUsername()` to ensure data integrity before assignment
2. **Constructors**: Provides default constructor, parameterized constructor, and copy constructor
3. **Static CRUD Operations**: All create, read, update, delete operations are static methods that:
   - Check authorization using `UserStore.GetUser().CanPerformAction()`
   - Delegate to corresponding `UserDB` methods
4. **Helper Methods**: `RoleToString()` and `StringToRole()` for enum conversion

**Static Methods:**
- `GetAllUsers()`: Requires minimum Receptionist role
- `CreateUser(User, string)`: Requires Administrator role, validates password
- `UpdateUser(User, string)`: Requires Administrator role
- `DeleteUser(int)`: Requires Administrator role
- `GenerateRandomPassword(int)`: Utility for password generation

### DAL Layer: UserDB.cs

The `UserDB` class handles all database operations for the User table:

**Methods:**
- `GetAllUsers()`: Returns `List<User>` from database
- `AuthenticateUser(string, string)`: Verifies credentials and returns authenticated user
- `CreateUser(User, string)`: Inserts new user with hashed password
- `UpdateUser(User, string)`: Updates user, optionally changes password
- `DeleteUser(int)`: Removes user by ID

**Security Features:**
- Uses `Rfc2898DeriveBytes` (PBKDF2) for password hashing with 16-byte salt and 10,000 iterations
- `GenerateSaltedHash()`: Creates salted hash stored as Base64 string
- `VerifyPassword()`: Extracts salt from stored hash and compares

**Error Handling:**
- Catches `SqlException 2627` for unique constraint violations
- Throws custom exceptions: `UserNotFoundException`, `InvalidCredentialsException`, `UniqueConstraintViolationException`
- Always closes connection in `finally` block

### Utilities

**UserStore.cs**: Manages authentication state
- `GetUser()`: Returns current authenticated user or throws `UnauthorizedException`
- `Login(string, string)`: Authenticates and stores current user
- `Logout()`: Clears current user

**Validator.cs**: Contains validation logic
- `ValidateUsername()`: 4-20 chars, alphanumeric + underscore
- `ValidatePassword()`: Min 8 chars, requires uppercase, lowercase, digit

**RolesEnum.cs**: Defines roles (Administrator, Doctor, Receptionist)

**DataExceptions.cs**: DAL-specific exceptions
- `UserNotFoundException`
- `InvalidCredentialsException`
- `UniqueConstraintViolationException`
- `ForeignKeyConstraintViolationException`
- `DatabaseConnectionException`
- `DataRetrievalException`

**BusinessLogicExceptions.cs**: BLL-specific exceptions
- `ValidationException`
- `UserNotAuthenticated`

---

## Implementation Guide for Patient, Doctor, and Appointment

Follow the same architectural pattern used for User:

### Step 1: Create Entity Class in BLL

**File**: `BLL/Patient.cs`

Create a class with:
- Private fields for each database column
- Public properties with validation on setters (call appropriate `Validator` methods)
- Default constructor, parameterized constructor, and copy constructor
- Static CRUD methods that check authorization via `UserStore.GetUser().CanPerformAction()`
- Each static method delegates to corresponding `PatientDB` method

**Properties based on database schema:**
- `Id` (int) - Primary key
- `FirstName` (string) - Validate non-empty
- `LastName` (string) - Validate non-empty
- `DateOfBirth` (DateTime) - Validate reasonable date
- `MedicalNumber` (string) - Validate format/uniqueness
- `PhoneNumber` (string) - Validate phone format
- `Email` (string) - Validate email format

**Static Methods:**
- `GetAllPatients()`: Check minimum role requirement
- `GetPatientById(int)`: Return single patient
- `CreatePatient(Patient)`: Check authorization, validate, delegate to DAL
- `UpdatePatient(Patient)`: Check authorization, validate, delegate to DAL
- `DeletePatient(int)`: Check authorization, delegate to DAL

### Step 2: Create Database Access Class in DAL

**File**: `DAL/PatientDB.cs`

Create a class with:
- Private static `SqlConnection` and `SqlCommand` fields
- Internal static methods matching the entity's CRUD operations
- Each method follows this pattern:
  1. Open connection via `DatabaseConnection.GetConnection()`
  2. Create parameterized SQL command
  3. Execute query and process results
  4. Handle SQL exceptions (2627 for unique constraints, 547 for foreign keys)
  5. Throw appropriate custom exceptions
  6. Close connection in `finally` block

**Methods:**
- `GetAllPatients()`: SELECT all, return `List<Patient>`
- `GetPatientById(int)`: SELECT WHERE Id, return single `Patient` or throw `PatientNotFoundException`
- `CreatePatient(Patient)`: INSERT with parameters, catch constraint violations
- `UpdatePatient(Patient)`: UPDATE with parameters, check rows affected
- `DeletePatient(int)`: DELETE WHERE Id, check rows affected, handle foreign key violations

### Step 3: Add Validation Methods

**File**: `BLL/Utils/Validator.cs`

Add static validation methods:
- `ValidateName(string)`: Check non-empty, length, allowed characters
- `ValidateEmail(string)`: Check format using regex
- `ValidatePhoneNumber(string)`: Check format (10-15 digits)
- `ValidateMedicalNumber(string)`: Check format specific to your requirements
- `ValidateDateOfBirth(DateTime)`: Check not future date, reasonable age
- `ValidateAppointmentDate(DateTime)`: Check not in past, within reasonable future range
- `ValidateDescription(string)`: Check length constraints

Each validation method should:
- Return the validated value if valid
- Throw `ValidationException` with descriptive message if invalid

### Step 4: Add Custom Exceptions

**File**: `DAL/DataExceptions.cs`

Add entity-specific exceptions:
- `PatientNotFoundException`
- `DoctorNotFoundException`
- `AppointmentNotFoundException`

**File**: `BLL/Utils/BusinessLogicExceptions.cs`

Add any BLL-specific exceptions if needed (the existing `ValidationException` may suffice for most cases)

### Repeat for Doctor Entity

**File**: `BLL/Doctor.cs`

**Properties from database:**
- `Id` (int) - Foreign key to User table
- `FirstName` (string)
- `LastName` (string)
- `Specialization` (string)
- `Availability` (string)

**Note**: Doctor.Id references User.Id, so doctor creation requires a User record first

**Static Methods:**
- `GetAllDoctors()`
- `GetDoctorById(int)`
- `CreateDoctor(Doctor)`: Ensure referenced User exists with Doctor role
- `UpdateDoctor(Doctor)`
- `DeleteDoctor(int)`: Handle foreign key constraints from Appointments

**File**: `DAL/DoctorDB.cs`

Follow same pattern as `PatientDB.cs`, handle foreign key constraint to User table

### Repeat for Appointment Entity

**File**: `BLL/Appointment.cs`

**Properties from database:**
- `Id` (int)
- `PatientId` (int) - Foreign key
- `DoctorId` (int) - Foreign key
- `CreatedBy` (int) - Foreign key to User
- `Description` (string)
- `AppointmentDate` (DateTime)
- `Status` (string)
- `ModifiedDate` (DateTime) - Auto-managed by database

**Static Methods:**
- `GetAllAppointments()`
- `GetAppointmentById(int)`
- `GetAppointmentsByPatient(int)`
- `GetAppointmentsByDoctor(int)`
- `CreateAppointment(Appointment)`: Set CreatedBy from `UserStore.GetUser().Id`
- `UpdateAppointment(Appointment)`
- `DeleteAppointment(int)`

**File**: `DAL/AppointmentDB.cs`

Follow same pattern, handle multiple foreign key constraints (Patient, Doctor, User)

### Authorization Strategy

Use the existing `CanPerformAction(RolesEnum)` pattern:
- **Receptionist**: Can view all entities, create/update patients and appointments
- **Doctor**: Can view assigned appointments and patient details, update appointment status
- **Administrator**: Full access to all operations

Each static method in entity classes should check authorization before delegating to DAL.

### Summary of Changes

**New Files:**
- `BLL/Patient.cs`
- `BLL/Doctor.cs`
- `BLL/Appointment.cs`
- `DAL/PatientDB.cs`
- `DAL/DoctorDB.cs`
- `DAL/AppointmentDB.cs`

**Modified Files:**
- `BLL/Utils/Validator.cs`: Add validation methods for names, emails, phone numbers, dates, descriptions
- `DAL/DataExceptions.cs`: Add `PatientNotFoundException`, `DoctorNotFoundException`, `AppointmentNotFoundException`

### Final Notes
I'm not sure how we'll handle Doctor availability scheduling yet; we may need to expand that later.