CREATE DATABASE atrium;
GO

USE atrium;
GO

CREATE TABLE hotels(
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) NOT NULL,
    address NVARCHAR(255) NOT NULL,
    phone NVARCHAR(20), 
    email NVARCHAR(255),
    rating DECIMAL(3, 1), 
    description NVARCHAR(500) 
);

CREATE TABLE room_types(
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) NOT NULL,
    description NVARCHAR(500),
    base_price DECIMAL(10, 2) NOT NULL, 
    size DECIMAL(10, 1) NOT NULL
);

CREATE TABLE rooms(
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    hotel_id INTEGER NOT NULL FOREIGN KEY REFERENCES hotels(id),
    room_type_id INTEGER NOT NULL FOREIGN KEY REFERENCES room_types(id),
    room_number NVARCHAR(10) NOT NULL, 
    floor INTEGER NOT NULL,
    status NVARCHAR(20) NOT NULL, 
    price DECIMAL(10, 2) NOT NULL, 
    max_guests INTEGER NOT NULL
);

CREATE TABLE guests(
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    first_name NVARCHAR(255) NOT NULL,
    last_name NVARCHAR(255) NOT NULL,
    email NVARCHAR(255),
    phone NVARCHAR(20) NOT NULL, 
    passport_number NVARCHAR(50) NOT NULL, 
    date_of_birth DATE NOT NULL,
    address NVARCHAR(500) NOT NULL 
);

CREATE TABLE reservations(
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    guest_id INTEGER FOREIGN KEY REFERENCES guests(id),
    room_id INTEGER FOREIGN KEY REFERENCES rooms(id),
    check_in_date DATE NOT NULL,
    check_out_date DATE NOT NULL,
    adults_count INTEGER NOT NULL,
    children_count INTEGER NOT NULL,
    total_amount DECIMAL(10, 2) NOT NULL, 
    status NVARCHAR(20) NOT NULL 
);

CREATE TABLE stays(
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    reservation_id INTEGER FOREIGN KEY REFERENCES reservations(id),
    actual_check_in DATETIME, 
    actual_check_out DATETIME, 
    total_charges DECIMAL(10, 2) NOT NULL,
    payment_status NVARCHAR(20) NOT NULL 
);

CREATE TABLE service_categories(
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) NOT NULL,
    description NVARCHAR(500) NOT NULL,
    is_available BIT NOT NULL 
);

CREATE TABLE services(
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    category_id INTEGER FOREIGN KEY REFERENCES service_categories(id),
    name NVARCHAR(255) NOT NULL,
    description NVARCHAR(500) NOT NULL,
    price DECIMAL(10, 2) NOT NULL, 
    is_available BIT NOT NULL 
);

CREATE TABLE service_orders(
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    stay_id INTEGER FOREIGN KEY REFERENCES stays(id), 
    service_id INTEGER FOREIGN KEY REFERENCES services(id),
    quantity INTEGER NOT NULL,
    order_date DATETIME NOT NULL,
    total_price DECIMAL(10, 2) NOT NULL, 
    status NVARCHAR(20) NOT NULL 
);

CREATE TABLE payments(
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    stay_id INTEGER FOREIGN KEY REFERENCES stays(id),
    amount DECIMAL(10, 2) NOT NULL,
    payment_method NVARCHAR(255) NOT NULL,
    payment_date DATETIME NOT NULL,
    status NVARCHAR(20) NOT NULL 
);

CREATE TABLE staff(
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    hotel_id INTEGER FOREIGN KEY REFERENCES hotels(id),
    first_name NVARCHAR(255) NOT NULL,
    last_name NVARCHAR(255) NOT NULL,
    position NVARCHAR(255) NOT NULL,
    email NVARCHAR(255),
    phone NVARCHAR(20) NOT NULL, 
    hire_date DATE NOT NULL,
    salary DECIMAL(10, 2) NOT NULL, 
    is_active BIT NOT NULL 
);

CREATE TABLE room_cleaning(
    id INTEGER PRIMARY KEY IDENTITY(1,1),
    room_id INTEGER FOREIGN KEY REFERENCES rooms(id),
    staff_id INTEGER FOREIGN KEY REFERENCES staff(id),
    cleaning_date DATETIME NOT NULL, 
    status NVARCHAR(20) NOT NULL 
);

CREATE TABLE price_recommendations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id),
    ForDate DATE NOT NULL,
    RecommendedPrice DECIMAL(10,2) NOT NULL,
    CurrentPrice DECIMAL(10,2) NOT NULL,
    Reason NVARCHAR(500),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
