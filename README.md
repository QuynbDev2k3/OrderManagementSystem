# 📦 Order Management System (OMS)

## 📌 Mô tả
Hệ thống backend quản lý đơn hàng áp dụng **Clean Architecture** và **Domain-Driven Design (DDD)**.  
Các module chính:
- Tạo và xem danh sách sản phẩm
- Tạo đơn hàng, xem danh sách đơn hàng hoặc danh sách đơn hàng có filter theo ngày tạo
- Xem chi tiết đơn hàng 
- Tính toán tự động VAT và tổng tiền

---

## 🛠️ Công nghệ
- **.NET 8 (ASP.NET Core Web API)**
- **Entity Framework Core** (Code First + Migration)
- **SQL Server**
- **Swagger UI** (Test API)
- **FluentValidation** (Validation input)
- **Clean Architecture + DDD**

---

## 🚀 Hướng dẫn chạy

### **Clone dự án**
git clone https://github.com/QuynbDev2k3/OrderManagementSystem.git
cd OrderManagementSystem

### **Tạo Database**
- Sửa lại DefaultConnection của appsettings.json trong Apo Layer
- dotnet ef database update -p OrderManagementSystem.Infrastructure -s OrderManagementSystem.Api

 ### **Chạy API**
dotnet run --project OrderManagementSystem.Api

 ### **Truy cập Swagger**
[dotnet run --project OrderManagementSystem.Api](https://localhost:7154/swagger)

 ### **Lưu ý**
- Hệ thống chưa có đăng nhập nên khi tạo đơn hàng sẽ gán sẵn 1 clientId mặc định.

#
