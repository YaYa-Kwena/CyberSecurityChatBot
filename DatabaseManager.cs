using System;
using MySql.Data.MySqlClient;
using System.Data;

public class DatabaseManager
{
    // Change "yourpassword" to the MySQL Root Password you created earlier
    private string connectionString = "Server=localhost;Database=CybersecurityBotDB;Uid=root;Pwd=matsatsitk9;";

    // Inserts a new task into the database table
    public void AddTask(string title, string description, int? reminderDays)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO UserTasks (title, description, reminder_days) VALUES (@title, @desc, @days)";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@days", (object)reminderDays ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Fetches all uncompleted tasks from the database table
    public DataTable GetTasks()
    {
        DataTable dt = new DataTable();
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM UserTasks WHERE is_completed = FALSE";
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                adapter.Fill(dt);
            }
        }
        return dt;
    }
}