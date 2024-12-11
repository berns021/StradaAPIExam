## Project Name
StradaAPI Exam

## Description
This is requirements for the hiring process of Strada. The application is using .NET C# and SQLite for the database. 
Used  Visual Studio Mac. For this reason I'm having hard time and adjustment with the implementation of the solution.

## Prerequisites
- **.NET**: Version 6.0  
  _Reason: .NET 6 is the only supported version on my machine, which is macOS._
- **Dependencies**:
  - **Microsoft.AspNetCore.App**: v6.0.31
  - **Microsoft.NETCore.App**: v6.0.31
  - **Microsoft.EntityFrameworkCore**: v6.0.0
  - **Microsoft.EntityFrameworkCore.Sqlite**: v6.0.0
  - **Microsoft.EntityFrameworkCore.SqlServer**: v6.0.0
  - **Microsoft.EntityFrameworkCore.Tools**: v6.0.0
  - **Swashbuckle.AspNetCore**: v6.5.0

## Installation\Cloning
1. Clone the repository:
   ```bash
   git clone https://github.com/berns021/StradaAPI.git
   ```
2. Then open the .sln using visual studio
3. Swagger will prompt
   ```
   https://localhost:7262/swagger/index.html
   ```

## API Endpoints
- `POST /api/v1/users` - Create a new user.
![image](https://github.com/user-attachments/assets/59dde721-a540-4792-ba7f-e59ba501b5a0)
  ```
  {
  "id": 0,
  "firstName": "Fname",
  "lastName": "Lname",
  "email": "email@email.com",
  "address": {
    "id": 0,
    "street": "StreetName",
    "city": "CityName",
    "postCode": 0
  },
  "employments": [
    {
      "id": 0,
      "company": "CompanyName",
      "monthsOfExperience": 0,
      "salary": 0,
      "startDate": "2024-12-11T06:40:55.718Z",
      "endDate": "2025-12-11T06:40:55.718Z"
    }
  ]}


- `GET /api/v1/users/{id}` - Retrieve user details by ID.
  ![image](https://github.com/user-attachments/assets/b1cb53ca-cbb9-4b2a-8da4-d911e9dc7715)

- `PUT /api/v1/users/{id}` - Update an existing user's information.
    ![image](https://github.com/user-attachments/assets/945f8010-e6fa-4844-83c6-61a0faa554c3)
```{
  "id": 0,
  "firstName": "Fname",
  "lastName": "Lname",
  "email": "Email@email.com",
  "address": {
    "id": 0,
    "street": "StretName",
    "city": "CityName",
    "postCode": 0
  },
  "employments": [
    {
      "id": 0,
      "company": "CompnayName",
      "monthsOfExperience": 0,
      "salary": 0,
      "startDate": "2024-12-11T06:45:43.962Z",
      "endDate": "2025-12-11T06:45:43.962Z"
    }
  ]}
```


## Contact
- **Author**: Bernard Vic Caay  
- **Email**: bernardcaay@gmail.com
- **GitHub**: [berns021](https://github.com/berns021)
