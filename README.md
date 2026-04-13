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


## How to Run the Program
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

## GitHub and CI
This project is managed using GitHub with meaningful commits for each development stage.  
A GitHub Actions workflow will be added for continuous integration.

## CI Screenshot
Add a screenshot of the successful GitHub Actions run (check the assets folder)
## Video Presentation Link
https://youtu.be/nWJCcKan9do

## Notes
This project was developed as a command-line cybersecurity awareness chatbot for Part 1 of the assignment.