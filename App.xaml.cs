using System;
using System.Windows;
using CTFproject.Models;

namespace CTFproject
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                // Khởi tạo database & bảng nếu chưa có
                DatabaseHelper.InitializeDatabase();

                // Thêm dữ liệu mẫu nếu database rỗng
                DatabaseHelper.InsertSampleData();

                Console.WriteLine("Database initialized and sample data inserted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo database: " + ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown(); // Thoát ứng dụng nếu có lỗi nghiêm trọng
                return;
            }

            // Hiển thị cửa sổ đăng nhập
            dangnhap loginWindow = new dangnhap();
            loginWindow.Show();
        }
    }
}
