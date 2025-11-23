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


Note: This repository may contain a specific implementation language. Adjust the commands below to match (npm/yarn for Node, pip/venv for Python).

## Installation (generic)
1. Clone the repository:
   git clone https://github.com/avisqqq/SteamPriceBot.git
   cd SteamPriceBot
   dotnet run

