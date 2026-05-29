# CyberSecurityChatBot

## Project Overview
CyberSecurityChatBot is a C# console application developed for Part 1 of the Programming 2A assignment.  
The chatbot is designed to educate users about basic cybersecurity awareness topics in a conversational way.

## Features
- WAV voice greeting when the application starts
- ASCII art chatbot header
- Personalized greeting using the user’s name
- Basic cybersecurity chatbot responses
- Topics include:
  - Password safety
  - Phishing scams
  - Safe browsing
  - Suspicious links
- Input validation for empty or unsupported messages
- Enhanced console interface with colours, dividers, and section headings

## Technologies Used
- C#
- .NET Console Application
- Visual Studio 2022

## Project Structure

CyberSecurityChatBot
│
├── Assets
│   ├── ascii-art.txt
│   └── greeting.wav
├── Models
│   └── UserProfile.cs
├── Services
│   ├── AudioService.cs
│   ├── ChatbotService.cs
│   └── ConsoleUIService.cs
├── Program.cs
├── README.md
└── CyberSecurityChatBot.csproj


## How to Run the Program (for part 1)
1. Open the project in Visual Studio 2022.
2. Make sure the NuGet package System.Windows.Extensions is installed.
3. Ensure that:
   - Assets/ascii-art.txt
   - Assets/greeting.wav
   are included in the project.
4. Set the asset file properties:
   - Build Action = Content
   - Copy to Output Directory = Copy if newer
5. Build and run the project.
6. Enter your name when prompted.
7. Ask the chatbot questions about cybersecurity topics.

## Example Questions
- How are you?
- What is your purpose?
- What can I ask you about?
- Tell me about password safety
- What is phishing?
- Give me safe browsing tips
- How do I identify a suspicious link?

  # Cybersecurity Awareness Chatbot (Part 2 - WPF GUI)

## Project Overview & Part 2 Updates
Welcome to Part 2 of the Cybersecurity Awareness Chatbot! In this phase, the application has been entirely transformed from a standard command-line interface into a fully interactive **Graphical User Interface (GUI)** using **Windows Presentation Foundation (WPF)**.

**Key Updates in this Release:**
* **Modern GUI Design:** A sleek, high-contrast dark theme built with XAML, featuring color-coded chat bubbles and my custom ASCII shield art.
* **Multimedia Integration:** Plays a custom voice greeting automatically upon launching.
* **Decoupled Architecture:** The backend logic has been professionally separated into distinct, scalable classes (`ChatBot.cs`, `KeywordResponder.cs`, `SentimentDetector.cs`, and `MemoryStore.cs`).
* **Advanced C# Features:** Implemented generic collections (`Dictionary`, `List`) for memory tracking and keyword pools, alongside a `Func` delegate to strictly separate the UI thread from the logic processing pipeline.
* **Dynamic Conversations:** The bot now detects user sentiment (e.g., worried, curious), remembers the user's name and favorite topics, and maintains state-aware conversation flows utilizing random response pools to keep the chat engaging.

## How to Run the Application

### Prerequisites
* **Visual Studio 2022** (with the ".NET desktop development" workload installed)
* **.NET 8.0 SDK**

### Execution Steps
1. **Clone the repository** to your local machine using Git:
   ```bash
   git clone [https://github.com/YaYa-Kwena/CyberSecurityChatBot.git](https://github.com/YaYa-Kwena/CyberSecurityChatBot.git)
2. ** Run the build

## GitHub and CI
This project is managed using GitHub with meaningful commits for each development stage.  
A GitHub Actions workflow will be added for continuous integration.

## CI Screenshot
Add a screenshot of the successful GitHub Actions run (check the assets folder)
## Video Presentation Link
https://youtu.be/nWJCcKan9do

## Notes
This project was developed as a command-line cybersecurity awareness chatbot for Part 1 of the assignment.
