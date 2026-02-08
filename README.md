# SteamPriceBot

A simple bot to fetch and report Steam game itemes. Designed to be extended for Discord, Telegram, or other chat platforms. 

## Features
- Fetch current Steam store prices for games (supports app ID or store URL).
- Optionally compare historical prices or detect discounts (extendable).
- Output results suitable for chat platforms (Discord/Telegram) or CLI.
- Configurable via environment variables or a config file.
- Lightweight and easy to extend with additional marketplaces or notifications.
- Built on Clean Architecture and easy extendable

## Table of Contents
- [Requirements](#requirements)
- [Installation](#installation)
- [Configuration](#configuration)

## Requirements
- A recent release of your runtime environment .NET 9 depending on the implementation.
- Network access to the Steam store web API or Steam store pages.
- Optional: API keys or tokens for the chat platform you want to connect (e.g., Discord bot token).
 - Docker Desktop (to run PostgreSQL locally).


Note: This repository may contain a specific implementation language. Adjust the commands below to match (npm/yarn for Node, pip/venv for Python).

## Installation (generic)
1. Clone the repository:
   git clone https://github.com/avisqqq/SteamPriceBot.git
   cd SteamPriceBot
   dotnet run

## PostgreSQL With Docker (local)
1. Install Docker Desktop and confirm it runs:
   `docker --version`
2. Start PostgreSQL:
   `docker compose up -d db`
3. Optional: override defaults by creating a `.env` file (use `.env.example` as a template).
4. Run the API (from the repo root):
   `dotnet run --project src/SteamPriceBot.Api/SteamPriceBot.Api.csproj`

The API reads the connection string from `src/SteamPriceBot.Api/appsettings.json`. To override it without editing files, set an environment variable:
`ConnectionStrings__DefaultConnection="Host=localhost;Port=5432;Database=steampricebot;Username=steampricebot;Password=steampricebot"`

## EF Core Migrations (PostgreSQL)
This repo applies migrations automatically at startup. If you want to run them manually:
`dotnet ef database update --project src/SteamPriceBot.Infrastructure/SteamPriceBot.Infrastructure.csproj --startup-project src/SteamPriceBot.Api/SteamPriceBot.Api.csproj`
