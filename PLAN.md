# 📅 Plan rozwoju projektu – UserScheduleAPI

## 🎯 Cel projektu
Aplikacja do zarządzania użytkownikami oraz automatycznego generowania grafików pracy i wizyt pacjentów.  
Projekt będzie rozwijany etapami, a każdy etap zakończony commitem w repozytorium GitHub.

---

## ✅ Etapy projektu

### 1️⃣ **Konfiguracja projektu i bazy**
- Utworzenie solution i warstw (Domain, Application, Infrastructure, API)
- Dodanie encji (`User`, `Shift`, `SpecialInfo`, `UserSpecialInfo`, `ShiftRestriction`)
- Utworzenie `AppDbContext` i konfiguracja EF Core
- Migracja i utworzenie bazy

➡️ Commit: `Initial project setup with DbContext and migrations`

---

### 2️⃣ **Endpointy dla User**
- Stworzenie `UserController`
- Dodanie `GET /api/users` – lista użytkowników
- Dodanie `POST /api/users` – dodawanie użytkownika
- Dodanie `PUT` i `DELETE` – edycja i usuwanie użytkownika

➡️ Commit: `Add UserController with basic CRUD endpoints`

---

### 3️⃣ **DTO i Walidacja**
- Utworzenie DTO (`CreateUserDto`, `UpdateUserDto`)
- Mapowanie encji ↔ DTO (AutoMapper lub ręcznie)
- Dodanie FluentValidation dla User

➡️ Commit: `Add DTOs and FluentValidation for Users`

---

### 4️⃣ **Relacje z SpecialInfo**
- Endpointy do przypisywania SpecialInfo do User
- `POST /api/users/{id}/special-info`
- `GET /api/users/{id}/special-info`

➡️ Commit: `Add SpecialInfo management for Users`

---

### 5️⃣ **Shift i ShiftRestrictions**
- CRUD dla `Shift`
- CRUD dla `ShiftRestriction` (blokady godzin)

➡️ Commit: `Add Shift and ShiftRestrictions with basic CRUD`

---

### 6️⃣ **Algorytm planera**
- Logika generowania grafiku
- Uwzględnianie dostępności użytkowników, SpecialInfo i blokad

➡️ Commit: `Add automatic scheduler for users`

---

### 7️⃣ **Finalizacja i portfolio**
- README z instrukcją i diagramami (już istnieje, ewentualne uzupełnienie)
- Dodanie GitHub Actions do CI/CD
- Finalne porządki i dokumentacja

➡️ Commit: `Add README, diagrams and CI pipeline`

---

## 📅 Harmonogram – propozycja

| Dzień | Zadania                                      |
|--------|----------------------------------------------|
| 1      | Etap 1 – Konfiguracja projektu i migracje   |
| 2      | Etap 2 – CRUD dla User (GET/POST/PUT/DELETE)|
| 3      | Etap 3 – DTO + Walidacja                    |
| 4      | Etap 4 – SpecialInfo i relacje              |
| 5      | Etap 5 – Shift i ShiftRestrictions          |
| 6      | Etap 6 – Algorytm planera                   |
| 7      | Etap 7 – README, diagramy, CI/CD           |
