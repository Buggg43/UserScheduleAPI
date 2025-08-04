function add-mig($name) {
  dotnet ef migrations add $name --project ./UserScheduleAPI.Infrastructure --startup-project ./UserScheduleAPI.API
}
function update-db {
  dotnet ef database update --project ./UserScheduleAPI.Infrastructure --startup-project ./UserScheduleAPI.API
}
function remove-last-mig {
  dotnet ef migrations remove --project ./UserScheduleAPI.Infrastructure --startup-project ./UserScheduleAPI.API
}
