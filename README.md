# UserScheduleAPI

UserScheduleAPI to aplikacja oparta na ASP.NET Core, służąca do zarządzania użytkownikami oraz automatycznego generowania grafików pracy/pobytu w wyznaczonych przedziałach czasowych.  
Projekt jest tworzony w oparciu o **Clean Architecture**, **CQRS**, **EF Core** i inne dobre praktyki .NET.

---

## 📂 Struktura projektu
- **Domain** – encje i logika biznesowa (czysta warstwa domenowa)
- **Application** – logika przypadków użycia (CQRS, walidacja, MediatR)
- **Infrastructure** – implementacja dostępu do bazy danych (EF Core)
- **API** – warstwa prezentacji (kontrolery, punkty końcowe HTTP)

### Diagram warstw
![Project Structure](docs/project_structure.png)

---

## 🗄️ Model danych
Diagram ERD pokazuje główne encje i relacje w projekcie:

![ERD](docs/user_schedule_app_erd.png)

---

## 🚀 Plan rozwoju (TODO)
- [x] Utworzenie solution i struktury projektu
- [x] Dodanie diagramów ERD i warstw
- [ ] Stworzenie encji (`User`, `SpecialInfo`, `Shift`)
- [ ] Konfiguracja EF Core i migracje bazy
- [ ] Podstawowe CRUD API dla encji
- [ ] Automatyczne generowanie grafików
- [ ] Refaktoryzacja na CQRS + MediatR + FluentValidation
- [ ] Dodanie autoryzacji i ról użytkowników
- [ ] Dokumentacja API (Swagger)

---

## ⚙️ Technologie
- .NET 8 / ASP.NET Core
- Entity Framework Core
- MediatR (CQRS)
- FluentValidation
- SQL Server

---

## 📜 Licencja
Projekt tworzony w celach edukacyjnych. Można korzystać i rozwijać według własnych potrzeb.
