# SCHEDULER_TODO.md

## 1. Slot Builder & Restriction Filtering
- [ ] Utworzyć klasę `SlotBuilder` z metodą:
  - `BuildSlots(DateTime shiftStart, DateTime shiftEnd, int visitLengthMinutes) : IEnumerable<Slot>`
- [ ] Utworzyć klasę `RestrictionFilter` z metodą:
  - `FilterSlots(IEnumerable<Slot> slots, IEnumerable<TimeRange> restrictions) : IEnumerable<Slot>`
- [ ] Napisać test:
  - Scenariusz: shift 08:00–12:00, długość wizyty = 30 min, przerwa 09:00–09:30 ⇒ brak slotu zaczynającego się o 09:00; reszta slotów obecna

## 2. Dopasowanie pacjentów po tagach + priorytetyzacja
- [ ] Metoda `FilterPatientsByTags(IEnumerable<Patient> patients, IEnumerable<string> userTags) : IEnumerable<Patient>`
- [ ] (Opcjonalnie) `PatientPrioritizer` z prostym scoringiem (więcej rzadkich tagów → wyższy prioritet)
- [ ] Test:
  - UserTags = {A, B, C}, Pacjent1: {A, B} → dopasowany, Pacjent2: {A, D} → odrzucony

## 3. Alokacja slotów + bufor czasowy
- [ ] Klasa/metoda `VisitAssigner.AssignVisits(IEnumerable<Slot> slots, IEnumerable<Patient> candidates, int bufferMinutes) : IEnumerable<Visit>`
- [ ] Logika min-buffer: po każdej wizycie wprowadzić blok time buffer (np. 15 min)
- [ ] Test:
  - Buffer = 15 min, wizyta 08:00–08:30 ⇒ następny możliwy slot od 08:45

## 4. Mapowanie danych i agregacja wyników
- [ ] `VisitDtoMapper.Map(Visit visit, Patient patient, User user) : VisitDto`
- [ ] Zbiór `List<VisitDto>` → `UserScheduleDto` → `GeneratedScheduleDto`
- [ ] Test:
  - Shift i pacjent spełniający warunki → `GeneratedScheduleDto` zawiera poprawnie wypełniony VisitDto

## 5. FluentValidation – walidacja `GenerateScheduleRequestDto`
- [ ] Reguły walidacji:
  - `StartDate < EndDate` oraz maksymalny zakres np. ≤ 31 dni
  - `PreferredVisitLengthMinutes` ∈ {15, 20, 30, 45, 60}
  - `DayOfWeekFilters` muszą być unikalne
- [ ] Integracja FluentValidation z pipeline ASP.NET Core (`AddFluentValidation()`)
- [ ] Testy walidatora:
  - StartDate > EndDate ⇒ walidator zwraca czytelny błąd
  - Niewłaściwa długość wizyty ⇒ walidacja się nie powiedzie
  - Duplikaty dni tygodnia ⇒ walidacja się nie powiedzie

## 6. (Opcjonalnie) Priorytety i strategia alokacji
- [ ] Wprowadzić interfejs `IPriorityStrategy`, np. `RareTagsPriorityStrategy`
- [ ] Wstrzykiwanie strategii priorytetów przez `IOptions<ScheduleOptions>`

## 7. Dokumentacja & workflow
- [ ] Umieścić ten plik `SCHEDULER_TODO.md` w repo  
- [ ] Przygotować przykładowe dane (seed) dla bazy testowej (alias `efm.ps1`)  
- [ ] Każdy punkt/zadanie committować jako osobny, mały i czytelny PR

---

###  Ćwierć kroku dalej?
Jeśli chcesz, mogę Ci także przygotować:
- **Przykładową strukturę testowych danych** (np. pacjenci i shifty seedowane do bazy lub w formie in-memory list),
- Lub skrócone wersje komend — “jak odpalić testy”, “jak zainicjalizować Shift w unit-testach” itd.

Daj znać, jeśli coś dodać lub poprawić — robimy dalej krok po kroku! :rocket:
::contentReference[oaicite:0]{index=0}
