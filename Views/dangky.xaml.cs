using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using CTFproject.Models;

namespace CTFproject
{
    public partial class dangky : Window
    {
        public dangky()
        {
            InitializeComponent();
        }

        private void register_bt_Click(object sender, RoutedEventArgs e)
        {
            string email = email_text.Text.Trim();
            string password = password_text.Password;  // Lấy mật khẩu từ PasswordBox
            string repassword = repassword_text.Password;  // Lấy mật khẩu nhập lại từ PasswordBox

            // Kiểm tra hợp lệ
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password != repassword)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (DatabaseHelper.UserExists(email))
            {
                MessageBox.Show("Email đã tồn tại, vui lòng chọn email khác!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Mã hóa mật khẩu
            string hashedPassword = HashPassword(password);

            // Thêm vào database
            DatabaseHelper.AddUser(email, hashedPassword, email, "User");
            MessageBox.Show("Đăng ký thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Mở cửa sổ đăng nhập
            dangnhap loginWindow = new dangnhap();
            loginWindow.Show();
            this.Close(); // Đóng cửa sổ đăng ký
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        private void login_bt_Click(object sender, RoutedEventArgs e)
        {
            dangnhap loginPage = new dangnhap();
            loginPage.Show();
            this.Close(); // Đóng cửa sổ đăng ký
        }
    }
}
