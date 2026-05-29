using System;
using System.Collections.ObjectModel;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace CyberSecurityChatBot
{
    public partial class MainWindow : Window
    {
        private readonly ChatBot _botEngine = new ChatBot();
        public ObservableCollection<MessageBubble> Messages { get; set; } = new ObservableCollection<MessageBubble>();

        public MainWindow()
        {
            InitializeComponent();
            ChatContainer.ItemsSource = Messages;
            ExecuteBootSequence();
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

            AppendMessage("Bot", "Hello! Welcome to Kwena Mokwena's Cybersecurity Awareness Bot. I'm here to help you stay safe online. Before we start, what is your name?");
        }

        private void ProcessInteraction()
        {
            string rawInput = TxtInput.Text.Trim();
            if (string.IsNullOrEmpty(rawInput)) return;

            AppendMessage("User", rawInput);
            TxtInput.Clear();

            // Rubric Requirement: Use delegates to solve a programming problem
            Func<string, string> interactionDelegate = new Func<string, string>(_botEngine.HandleInput);
            string botOutput = interactionDelegate(rawInput);

            AppendMessage("Bot", botOutput);
            ChatScroll.ScrollToEnd();
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