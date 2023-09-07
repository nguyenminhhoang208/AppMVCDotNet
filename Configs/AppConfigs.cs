using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controller_View.Models;
using Microsoft.EntityFrameworkCore;

namespace Controller_View.Configs
{
    public static class AppConfigs
    {
        public static void ConnectDatabase(this WebApplicationBuilder builder)
        {
            // Đăng ký AppDbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                // Đọc chuỗi kết nối
                string connectstring = builder.Configuration.GetConnectionString("AppDbContext") ?? throw new Exception("Không tìm thấy cấu hình chuỗi kết nối (connect string)");
                // Sử dụng MS SQL Server
                options.UseMySql(connectstring, ServerVersion.Parse("10.4.28-MariaDB"));
            });
        }
    }
}