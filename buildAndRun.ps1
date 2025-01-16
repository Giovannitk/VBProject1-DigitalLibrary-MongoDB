# buildAndRun.ps1

# Ottieni i file .vb presenti nella directory
$files = Get-ChildItem -Path $pwd -Filter "*.vb"

# Verifica che ci siano file da compilare
if ($files.Count -eq 0) {
    Write-Host "Nessun file VB trovato per la compilazione."
    Exit
}

# Ordina i file in modo che GUIForm.vb venga compilato per primo
$sortedFiles = $files | Sort-Object { $_.Name -eq "GUIForm.vb" -and $_.Name -ne $null }

# Costruisci gli argomenti per il compilatore VBC
$vbcArgs = @(
    "/nologo",
    "/main:Program",
    "/out:GUIForm.exe"
)

# Aggiungi i file .vb al comando, racchiudendo i percorsi tra virgolette
foreach ($file in $sortedFiles) {
    $vbcArgs += '"' + $file.FullName + '"'
}

# Unisci gli argomenti in una stringa
$vbcCommand = "vbc " + ($vbcArgs -join " ")

# Compilazione
Write-Host "Compilando con i seguenti argomenti: $vbcCommand"
Invoke-Expression $vbcCommand

# Controlla se il file eseguibile è stato creato
if (Test-Path ".\GUIForm.exe") {
    Write-Host "Eseguendo il programma GUIForm.exe"
    .\GUIForm.exe
} else {
    Write-Host "Compilazione fallita o file GUIForm.exe non trovato."
}
