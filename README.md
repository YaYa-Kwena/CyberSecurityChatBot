# Cybersecurity Awareness Assistant (Full Portfolio of Evidence)

## Project Overview
The Cybersecurity Awareness Assistant is an interactive Graphical User Interface (GUI) application built using Windows Presentation Foundation (WPF) and .NET 8.0. Designed as a comprehensive Portfolio of Evidence (POE) project, its core mission is to simulate real-life threat scenarios and educate South African citizens on identifying, mitigating, and managing modern cyber threats—such as phishing scams, weak password practices, and social engineering.

The system seamlessly unifies a high-contrast conversational interface with local relational database persistence, an educational training mini-game, and session auditing log features.

---

## Key Features across Milestones

### Part 1 & Part 2 Foundations (Console to GUI Migration)
* **Multimedia Initialization:** Plays a custom recorded `.wav` voice greeting asset automatically upon application launch.
* **Neo-Brutalism High-Contrast UI:** Features a stylized dark theme built with XAML, structured message bubble layout panels for natural readability, and an embedded console-style ASCII branding header.
* **Decoupled OOP Architecture:** Business logic is cleanly separated into dedicated classes (`ChatBot.cs`, `KeywordResponder.cs`, `SentimentDetector.cs`, and `MemoryStore.cs`) to ensure scalability.
* **Advanced C# Flow Handling:** Uses generic collections (`Dictionary`, `List`) to track conversational states alongside a `Func<>` delegate to manage data interaction pipelines.
* **Dynamic Engagement & Sentiment Detection:** Recognizes core cybersecurity keywords (e.g., password, scam, privacy, phishing) and emotional state cues (worried, curious, frustrated) to adapt responses with varied, randomized advice pools.

### Part 3 / Final POE Enhancements
* **Task Assistant Checklist (MySQL Storage):** Integrates a secure database management system to permanently save, load, and track critical cybersecurity tasks directly via a local MySQL server.
* **Cybersecurity Training Mini-Game:** An interactive 10+ question multiple-choice and true/false quiz evaluation engine that tracks player score matrices and returns immediate conversational reasoning feedback directly in the chat window.
* **Simulated NLP Phrase Parsing Engine:** Employs a localized phrase parsing service that handles text casing normalization and soft matching token validations, letting the chatbot interpret diverse user phrasings intelligently while minimizing input errors.
* **Automated Activity Logger:** Silently logs critical program execution records (e.g., successful database writes, mini-game initiations, intent triggers) during a session and prints a clean, truncated list view on user command.

---

## System Architecture & Project Files

```text
CyberSecurityChatBot
├── Assets/
│    ├── ascii-art.txt          # Part 1 Console UI layout visual banner asset
│    └── greeting.wav           # Part 1 High-quality voice welcoming audio file
├── Models/
│    └── MessageBubble.cs       # Holds styling, text, and alignment data properties
├── Services/
│    ├── DatabaseManager.cs     # Manages all MySQL CRUD connection logic
│    ├── QuizEngine.cs          # Orchestrates multi-format question mechanics
│    ├── NlpParser.cs           # Runs soft keyword string manipulation parsing
│    └── ActivityLogger.cs      # Logs and limits platform activity history
├── MainWindow.xaml             # Split-panel layout (Chat & Dashboard)
├── MainWindow.xaml.cs          # Central interaction event hub routers
└── README.md

Prerequisites & Database Setup. 
MySQL Local Server SetupThis application requires a local relational database instance to store data points persistently:  
Ensure MySQL Server (v8.0 or newer) is running locally on your machine over port 3306.
Launch MySQL Workbench, connect to your server, and run this initialization script to build out the assignment's database schema:
SQL 
CREATE DATABASE IF NOT EXISTS CybersecurityBotDB;
USE CybersecurityBotDB;

CREATE TABLE IF NOT EXISTS UserTasks (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description TEXT,
    reminder_days INT DEFAULT NULL,
    is_completed BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
2. Configure Your Connection Credentials
Before compiling the project inside Visual Studio, ensure the connection string properties match your database account credentials:
Open Services/DatabaseManager.cs.
Update the connectionString private field with your matching local password configuration:
C# private string connectionString = "Server=localhost;Database=CybersecurityBotDB;Uid=root;Pwd=YOUR_PASSWORD_HERE;";
How to Run the Application
Open the primary project solution file (.sln) within Visual Studio 2022.
Open the NuGet Package Manager Console (Tools > NuGet Package Manager > Package Manager Console) and verify that the database dependencies are restored by running:
Install-Package MySql.Data
Press F5 or click the green Start icon to build and execute the application.
Interact naturally with the bot in the chat bubble screen or observe real-time data adjustments on the dashboard panel.

Standard Interaction Command Prompts
To Register Checklists: Type conversational phrases like "add a password task" or "remind me to review my privacy settings".
To Launch Training Mini-Games: Type phrases like "play quiz", "test me", or "start the game".
To Audit System Event Frameworks: Type commands like "show activity log" or "what have you done for me?".  