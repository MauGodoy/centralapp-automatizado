@echo off
echo Iniciando Appium e Emulador...

:: Comando a ser executado no PowerShell
set comandoPowerShell=appium

:: Comando a ser executado no Prompt de Comando (cmd)
set comandoCmd1=cd C:\Users\mauri\AppData\Local\Android\Sdk\emulator
set comandoCmd2=emulator -avd Nexus4

:: Executar o PowerShell como administrador
powershell.exe -Command "Start-Process powershell -Verb runAs -ArgumentList '-Command %comandoPowerShell%'"

:: Abrir o Prompt de Comando (cmd) e executar os comandos
cmd /k "%comandoCmd1% & %comandoCmd2%"