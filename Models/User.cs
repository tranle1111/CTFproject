﻿namespace CTFproject.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int TotalPoints { get; set; }
    }
}
