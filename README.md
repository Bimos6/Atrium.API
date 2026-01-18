🏨 Atrium Hotel Management System
ASP.NET Core Web API для управления гостиничным бизнесом.

🚀 Быстрый старт
Запуск с Docker:
bash
# 1. Клонируй репозиторий
git clone https://github.com/Bimos6/atrium.git
cd atrium

# 2. Запусти всё одной командой
docker-compose up -d

# 3. Открой в браузере
open http://localhost:5000/

Запуск локально:
bash
# 1. Восстанови зависимости
dotnet restore

# 2. Примени миграции БД
cd src/Atrium.API
dotnet ef database update

# 3. Запусти API
dotnet run

🛠 Технологии
ASP.NET Core 10.0 - Web API

Entity Framework Core - ORM и миграции

SQL Server - База данных

Docker & Docker Compose - Контейнеризация

GitHub Actions - CI/CD пайплайн

FluentValidation - Валидация DTO

AutoMapper - Маппинг объектов


Доступные сервисы:
API: http://localhost:5000
База данных: localhost:1433


📊 API Endpoints
Метод	Endpoint	Описание
GET	/api/hotels	Получить все отели
GET	/api/hotels/{id}	Получить отель по ID
POST	/api/hotels	Создать новый отель
PUT	/api/hotels/{id}	Обновить отель
DELETE	/api/hotels/{id}	Удалить отель

GET	/api/guests	Получить всех гостей
GET	/api/guests/{id}	Получить гостя по ID
POST	/api/guests	Создать новыго гостя
PUT	/api/guests/{id}	Обновить гостя
DELETE	/api/guests/{id}	Удалить гостя

GET	/api/reservations	Получить все бронирования
GET	/api/reservations/{id}	Получить бронь по ID
POST	/api/reservations	Создать новыю бронь
PUT	/api/reservations/{id}	Обновить бронь
DELETE	/api/reservations/{id}	Удалить бронь

GET	/api/rooms	Получить все комнаты
GET	/api/rooms/{id}	Получить комнату по ID
POST	/api/rooms	Создать новыю комнату
PUT	/api/rooms/{id}	Обновить комнату
DELETE	/api/rooms/{id}	Удалить комнату

GET	/api/roomtypes	Получить все типы комнат
GET	/api/roomtypes/{id}	Получить тип комнаты по ID
POST	/api/roomtypes	Создать новый тип комнаты
PUT	/api/roomtypes/{id}	Обновить тип комнаты
DELETE	/api/roomtypes/{id}	Удалить тип комнаты

GET	/api/services	Получить все услуги
GET	/api/services/{id}	Получить услугу по ID
POST	/api/services	Создать новую услугу
PUT	/api/services/{id}	Обновить услугу
DELETE	/api/services/{id}	Удалить услугу
