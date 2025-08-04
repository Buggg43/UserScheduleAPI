function add-mig($name) {
  Write-Host "Tworzenie migracji: $name"
  dotnet ef migrations add $name --project ./UserScheduleAPI.Infrastructure --startup-project ./UserScheduleAPI.API
}

function update-db {
  Write-Host "Aktualizacja bazy danych"
  dotnet ef database update --project ./UserScheduleAPI.Infrastructure --startup-project ./UserScheduleAPI.API
}
function remove-last-mig {
  Write-Host "Usuwanie ostatniej migracji"
  dotnet ef migrations remove --project ./UserScheduleAPI.Infrastructure --startup-project ./UserScheduleAPI.API
}