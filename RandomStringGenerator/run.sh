#!/bin/bash

# Random String Generator - Build and Run Script

echo "================================"
echo "Random String Generator"
echo "================================"
echo ""

# Check if .NET is installed
if ! command -v dotnet &> /dev/null; then
    echo "Error: .NET SDK is not installed."
    echo "Please install .NET 10.0 or later from https://dotnet.microsoft.com/download"
    exit 1
fi

echo "✓ .NET SDK version: $(dotnet --version)"
echo ""

# Navigate to the project directory
cd "$(dirname "$0")"

# Clean previous build
echo "Cleaning previous build..."
dotnet clean > /dev/null 2>&1

# Build the project
echo "Building the project..."
if dotnet build > /dev/null 2>&1; then
    echo "✓ Build successful"
else
    echo "✗ Build failed"
    echo "Run 'dotnet build' to see detailed error messages"
    exit 1
fi

echo ""
echo "================================"
echo "Starting application..."
echo "================================"
echo ""

# Run the application
dotnet run
