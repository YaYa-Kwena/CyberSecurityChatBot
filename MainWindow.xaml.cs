using System;
using System.Collections.ObjectModel;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CyberSecurityChatBot
{
    public partial class MainWindow : Window
    {
        private readonly ChatBot _botEngine = new ChatBot();
        private DatabaseManager db = new DatabaseManager();
        private ActivityLogger logger = new ActivityLogger();
        private QuizEngine activeQuiz;
        private QuizQuestion currentQuestion;
        public ObservableCollection<MessageBubble> Messages { get; set; } = new ObservableCollection<MessageBubble>();

        public MainWindow()
        {
            InitializeComponent();
            ChatContainer.ItemsSource = Messages;
            ExecuteBootSequence();
            RefreshTaskGrid(); // Load existing tasks on startup
        }

        private void ExecuteBootSequence()
        {
            TxtAsciiHeader.Text = _botEngine.GetAsciiArt();

            try
            {
                string audioPath = _botEngine.GetVoiceGreetingPath();
                if (System.IO.File.Exists(audioPath))
                {
                    using (SoundPlayer player = new SoundPlayer(audioPath))
                    {
                        player.Play();
                    }
                }
            }
            catch (Exception) { /* Failsafe for audio driver locks */ }

            AppendMessage("Bot", "Hello! Welcome to Kwena Mokoena's Cybersecurity Awareness Bot. I'm here to help you stay safe online. Before we start, what is your name?");
            logger.LogAction("Chatbot booted up successfully.");
        }

        private void ProcessInteraction()
        {
            string rawInput = TxtInput.Text.Trim();
            if (string.IsNullOrEmpty(rawInput)) return;

            AppendMessage("User", rawInput);
            TxtInput.Clear();

            // 1. Determine user intent using our NLP Phrase Engine
            UserIntent intent = NlpParser.DetermineIntent(rawInput);
            logger.LogAction($"User input parsed. Detected Intent: {intent}");

            // 2. Route the communication depending on what the user wants to do
            switch (intent)
            {
                case UserIntent.AddTask:
                    // Simulated input processing: parse keywords for task assignment
                    string taskTitle = "Enable Multi-Factor Auth";
                    string taskDesc = "Configure 2FA settings to secure your system endpoints.";
                    int reminderDays = 7;

                    if (rawInput.ToLower().Contains("password"))
                    {
                        taskTitle = "Update Account Password";
                        taskDesc = "Change your account credentials to a strong, unique value.";
                        reminderDays = 1;
                    }
                    else if (rawInput.ToLower().Contains("privacy"))
                    {
                        taskTitle = "Review Privacy Configurations";
                        taskDesc = "Audit authorization permissions across active profile spaces.";
                        reminderDays = 3;
                    }

                    // Save to MySQL DB
                    db.AddTask(taskTitle, taskDesc, reminderDays);
                    logger.LogAction($"Saved task to MySQL DB: '{taskTitle}'");

                    RefreshTaskGrid();
                    AppendMessage("Bot", $"Task added: '{taskTitle}'. Description: '{taskDesc}'. I have set a reminder for {reminderDays} days from now.");
                    break;

                case UserIntent.ViewTasks:
                    RefreshTaskGrid();
                    AppendMessage("Bot", "I have refreshed your security task dashboard with the latest tracking records from your database.");
                    break;

                case UserIntent.StartQuiz:
                    activeQuiz = new QuizEngine();
                    logger.LogAction("User started a new quiz session.");

                    // Hide the placeholder text block and show the visual button panel
                    TxtQuizPlaceholder.Visibility = Visibility.Collapsed;
                    QuizControlPanel.Visibility = Visibility.Visible;

                    AppendMessage("Bot", "The interactive cybersecurity quiz engine is initializing. Look over at your dashboard panel to test your knowledge!");
                    ShowNextQuizQuestion();
                    break;

                case UserIntent.ViewLog:
                    var logs = logger.GetRecentLogs();
                    string sessionLogSummary = "Here is a clean summary of our recent session activity history:\n\n" + string.Join("\n", logs);
                    AppendMessage("Bot", sessionLogSummary);
                    break;

                case UserIntent.GeneralCybersecurity:
                    // Rubric Requirement: Use delegates to solve a programming problem
                    Func<string, string> interactionDelegate = new Func<string, string>(_botEngine.HandleInput);
                    string botOutput = interactionDelegate(rawInput);
                    AppendMessage("Bot", botOutput);
                    break;
            }

            ChatScroll.ScrollToEnd();
        }

        // Helper to query MySQL and update your UI DataGrid binding element
        private void RefreshTaskGrid()
        {
            try
            {
                TasksDataGrid.ItemsSource = db.GetTasks().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to local database engine server. Verify port 3306 is open.\nError: " + ex.Message, "Database Offline Error");
            }
        }

        private void ShowNextQuizQuestion()
        {
            currentQuestion = activeQuiz.GetNextQuestion();
            if (currentQuestion != null)
            {
                QuizQuestionText.Text = currentQuestion.QuestionText;
                OptA_Btn.Content = currentQuestion.Options[0];
                OptB_Btn.Content = currentQuestion.Options[1];

                // Dynamically collapse extra UI buttons if it's a simple True/False question layout
                OptC_Btn.Visibility = currentQuestion.Options.Count > 2 ? Visibility.Visible : Visibility.Collapsed;
                OptD_Btn.Visibility = currentQuestion.Options.Count > 3 ? Visibility.Visible : Visibility.Collapsed;

                if (currentQuestion.Options.Count > 2) OptC_Btn.Content = currentQuestion.Options[2];
                if (currentQuestion.Options.Count > 3) OptD_Btn.Content = currentQuestion.Options[3];
            }
            else
            {
                // Quiz completed state handling rules
                string completionMessage = activeQuiz.GetFinalScoreSummary();
                QuizQuestionText.Text = completionMessage;
                AppendMessage("Bot", completionMessage);

                // Reset UI state cleanly
                QuizControlPanel.Visibility = Visibility.Collapsed;
                TxtQuizPlaceholder.Visibility = Visibility.Visible;
                TxtQuizPlaceholder.Text = "Training session evaluation modules completed successfully.";
            }
        }

        // Handles click captures on dashboard game options elements
        public void QuizAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == null) return;

            Button clickedButton = (Button)sender;
            string selectedChoice = clickedButton.Content.ToString();

            // Validate using our Quiz Engine architecture rule methods
            string verificationFeedback = activeQuiz.ValidateAnswer(selectedChoice, currentQuestion);
            logger.LogAction($"User picked answer option: '{selectedChoice}'");

            // Post response details inside the conversational chat template view space
            AppendMessage("Bot", verificationFeedback);
            ChatScroll.ScrollToEnd();

            // Proceed automatically onwards to next index
            ShowNextQuizQuestion();
        }

        private void AppendMessage(string sender, string text)
        {
            bool isUser = sender == "User";
            Messages.Add(new MessageBubble
            {
                MessageText = text,
                Alignment = isUser ? HorizontalAlignment.Right : HorizontalAlignment.Left,
                BackgroundColor = isUser ? "#00FF66" : "#2A2A2A",
                TextColor = isUser ? "#121212" : "#FFFFFF"
            });
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e) => ProcessInteraction();

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                ProcessInteraction();
            }
        }
    }

    public class MessageBubble
    {
        public string MessageText { get; set; }
        public HorizontalAlignment Alignment { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
    }
}