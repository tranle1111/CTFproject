using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using CTFproject.Models;

namespace CTFproject
{
    public partial class dangnhap : Window
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void login_bt_Click(object sender, RoutedEventArgs e)
        {
            string email = email_text.Text.Trim();
            string password = password_text.Password; // Lấy mật khẩu từ PasswordBox

            // Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Mã hóa mật khẩu để kiểm tra
            string hashedPassword = HashPassword(password);

            if (DatabaseHelper.ValidateUser(email, hashedPassword))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);

                // Mở trang chính sau khi đăng nhập
                home main = new home();
                main.Show();
                this.Close();  // Đóng cửa sổ đăng nhập
            }
            else
            {
                MessageBox.Show("Sai email hoặc mật khẩu!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void register_bt_Click(object sender, RoutedEventArgs e)
        {
            dangky registerPage = new dangky();
            registerPage.Show();
            this.Close(); // Đóng cửa sổ hiện tại
        }

        private void forgot_bt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tính năng quên mật khẩu chưa được triển khai!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
