@echo off
REM Random String Generator - Build and Run Script for Windows

echo ================================
echo Random String Generator
echo ================================
echo.

REM Check if .NET is installed
where dotnet >nul 2>nul
if %ERRORLEVEL% NEQ 0 (
    echo Error: .NET SDK is not installed.
    echo Please install .NET 10.0 or later from https://dotnet.microsoft.com/download
    pause
    exit /b 1
)

echo [OK] .NET SDK version:
dotnet --version
echo.

REM Navigate to the project directory
cd /d "%~dp0"

REM Clean previous build
echo Cleaning previous build...
dotnet clean >nul 2>&1

REM Build the project
echo Building the project...
dotnet build >nul 2>&1
if %ERRORLEVEL% NEQ 0 (
    echo [FAIL] Build failed
    echo Run 'dotnet build' to see detailed error messages
    pause
    exit /b 1
)
echo [OK] Build successful

echo.
echo ================================
echo Starting application...
echo ================================
echo.

REM Run the application
dotnet run
