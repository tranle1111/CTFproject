using System;
using System.Data.SQLite;
using System.IO;

namespace CTFproject.Models
{
    public class DatabaseHelper
    {
        private static string dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private static string databasePath = Path.Combine(dataFolder, "CTFDatabase.db");
        private static string connectionString = $"Data Source={databasePath};Version=3;";

        public static void InitializeDatabase()
        {
            try
            {
                // Tạo thư mục "Data" nếu chưa tồn tại
                if (!Directory.Exists(dataFolder))
                {
                    Directory.CreateDirectory(dataFolder);
                    Console.WriteLine("Created missing Data folder at: " + dataFolder);
                }

                // Kiểm tra file database có tồn tại không, nếu không thì tạo mới
                if (!File.Exists(databasePath))
                {
                    SQLiteConnection.CreateFile(databasePath);
                    Console.WriteLine("Database file created at: " + databasePath);
                }

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string createUsersTable = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT NOT NULL UNIQUE,
                            PasswordHash TEXT NOT NULL,
                            Email TEXT NOT NULL UNIQUE,
                            Role TEXT NOT NULL DEFAULT 'User',
                            TotalPoints INTEGER DEFAULT 0
                        );";

                    string createChallengesTable = @"
                        CREATE TABLE IF NOT EXISTS Challenges (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Description TEXT,
                            DownloadLink TEXT,
                            Hints TEXT,
                            Points INTEGER NOT NULL,
                            Category TEXT
                        );";

                    string createUserChallengesTable = @"
                        CREATE TABLE IF NOT EXISTS UserChallenges (
                            UserID INTEGER,
                            ChallengeID INTEGER,
                            IsSolved INTEGER DEFAULT 0,
                            SubmissionTime DATETIME,
                            PRIMARY KEY (UserID, ChallengeID),
                            FOREIGN KEY (UserID) REFERENCES Users(ID),
                            FOREIGN KEY (ChallengeID) REFERENCES Challenges(ID)
                        );";

                    using (SQLiteCommand cmd = new SQLiteCommand(createUsersTable, conn)) { cmd.ExecuteNonQuery(); }
                    using (SQLiteCommand cmd = new SQLiteCommand(createChallengesTable, conn)) { cmd.ExecuteNonQuery(); }
                    using (SQLiteCommand cmd = new SQLiteCommand(createUserChallengesTable, conn)) { cmd.ExecuteNonQuery(); }

                    Console.WriteLine("Database initialized successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing database: " + ex.Message);
                throw;
            }
        }
        public static void InsertSampleData()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra xem admin đã tồn tại chưa
                string checkUserExists = "SELECT COUNT(*) FROM Users WHERE Username = 'admin'";
                using (var cmd = new SQLiteCommand(checkUserExists, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        // Thêm user admin
                        string insertUser = @"
                            INSERT INTO Users (Username, PasswordHash, Email, Role, TotalPoints) 
                            VALUES ('admin', 'hashedpassword', 'admin@example.com', 'Admin', 0);";
                        using (var insertCmd = new SQLiteCommand(insertUser, conn))
                        {
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }

                // Kiểm tra xem challenge đã tồn tại chưa
                string checkChallengeExists = "SELECT COUNT(*) FROM Challenges WHERE Name = 'Basic Challenge'";
                using (var cmd = new SQLiteCommand(checkChallengeExists, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        // Thêm challenge mẫu
                        string insertChallenge = @"
                            INSERT INTO Challenges (Name, Description, DownloadLink, Hints, Points, Category) 
                            VALUES ('Basic Challenge', 'Solve this simple challenge', 'http://example.com', 'Think simple', 100, 'Misc');";
                        using (var insertCmd = new SQLiteCommand(insertChallenge, conn))
                        {
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }

                Console.WriteLine("Sample data inserted successfully!");
            }
        }

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn;
        }

        // Thêm người dùng
        public static void AddUser(string username, string passwordHash, string email, string role)
        {
            using (var conn = GetConnection())
            {
                string insertUser = @"
                    INSERT INTO Users (Username, PasswordHash, Email, Role, TotalPoints)
                    VALUES (@Username, @PasswordHash, @Email, @Role, 0);";

                using (var cmd = new SQLiteCommand(insertUser, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Kiểm tra email tồn tại chưa
        public static bool UserExists(string email)
        {
            using (var conn = GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        // Đăng nhập
        public static bool ValidateUser(string email, string hashedPassword)
        {
            using (var conn = GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND PasswordHash = @PasswordHash";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}
