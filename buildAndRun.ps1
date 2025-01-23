# Cambia directory nel progetto
Set-Location -Path "C:\Users\giovy\Desktop\visual_basic\VBProject1_LibreriaDigitale_MongoDB"

# Pulizia, compilazione e avvio del progetto
dotnet clean
dotnet build

if ($?) {
    dotnet run
} else {
    Write-Host "Build failed. Please check the errors above." -ForegroundColor Red
}
