CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Addresses" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Addresses" PRIMARY KEY AUTOINCREMENT,
    "Street" TEXT NOT NULL,
    "City" TEXT NOT NULL,
    "PostCode" INTEGER NULL
);

CREATE TABLE "Users" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY AUTOINCREMENT,
    "FirstName" TEXT NOT NULL,
    "LastName" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "AddressId" INTEGER NULL,
    CONSTRAINT "FK_Users_Addresses_AddressId" FOREIGN KEY ("AddressId") REFERENCES "Addresses" ("Id")
);

CREATE TABLE "Employments" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Employments" PRIMARY KEY AUTOINCREMENT,
    "Company" TEXT NOT NULL,
    "MonthsOfExperience" INTEGER NOT NULL,
    "Salary" INTEGER NOT NULL,
    "StartDate" TEXT NOT NULL,
    "EndDate" TEXT NULL,
    "UserId" INTEGER NULL,
    CONSTRAINT "FK_Employments_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id")
);

CREATE INDEX "IX_Employments_UserId" ON "Employments" ("UserId");

CREATE INDEX "IX_Users_AddressId" ON "Users" ("AddressId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241210081632_InitialCreate', '6.0.0');

COMMIT;

