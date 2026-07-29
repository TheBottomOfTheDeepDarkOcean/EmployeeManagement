# 🏢 Employees Management System (HRMS) - ASP.NET Core MVC

Một hệ thống **Quản lý Nhân sự & Quy trình Duyệt đơn Nghỉ phép (HRMS)** cấp doanh nghiệp được xây dựng bằng **ASP.NET Core 8 MVC**, **Entity Framework Core (Code First)** và **Microsoft SQL Server**. 

Dự án tập trung vào việc xử lý các bài toán nghiệp vụ nhân sự thực tế, phân quyền bảo mật đa cấp và tự động hóa quy trình quản trị.

---

## 🚀 Các Tính Năng Cốt Lõi

### 1. 🔐 Hệ Thống Phân Quyền Ma Trận (Permission Matrix System)
- **Phân quyền động đa cấp:** Phân tách rõ ràng theo Module $\rightarrow$ Sub-module $\rightarrow$ Actions (`View`, `Create`, `Edit`, `Delete`, `Approve`, `Reject`).
- **Quản lý trạng thái phân quyền (Role Profiles Matrix):** Tự động tải và đồng bộ trạng thái gán quyền (`Checked/Unchecked`) cho từng Vai trò (Role) trong hệ thống.
- **Tối ưu luồng lưu dữ liệu:** Áp dụng phương thức `RemoveRange` để dọn dẹp quyền cũ và gán lại mảng quyền mới, tránh trùng lặp dữ liệu CSDL.

### 2. 👤 Quản Lý Hồ Sơ Nhân Sự Chi Tiết (HR & Payroll Profiles)
- **Hồ sơ nhân viên mở rộng:** Quản lý chi tiết Ngày vào làm (`EmploymentDate`), Ngân hàng (`BankId`), Số tài khoản, IBAN, Swift Code, Mã số thuế (`TaxPin`), Mã BHXH/BHYT, Email công ty, Hộ chiếu, Hình thức hợp đồng (`EmploymentTerms`).
- **Tải lên & Quản lý Ảnh đại diện (`IFormFile`):** Xử lý upload file ảnh thẻ, đổi tên file tự động theo Timestamp (`DateTime`) để tránh trùng lặp tệp tin trên server, cấu hình thư mục lưu trữ linh hoạt qua `appsettings.json` (`IConfiguration`).
- **Trạng thái nhân viên tự động:** Tự động gắn trạng thái mặc định (`Active`) cho nhân viên mới khởi tạo.

### 3. 📅 Quy Trình Duyệt Đơn Nghỉ Phép (Leave Approval Workflow)
- **Luồng duyệt khép kín:** Nhân viên tạo đơn nghỉ phép $\rightarrow$ Quản lý xem chi tiết $\rightarrow$ Duyệt (`Approve`) hoặc Từ chối (`Reject`).
- **Tự động tính toán quỹ phép:** Tự động trừ số ngày nghỉ vào quỹ phép còn lại của nhân viên khi đơn được duyệt.
- **Quản lý Ngày lễ (`Holidays Management`):** Xây dựng danh mục ngày nghỉ lễ toàn công ty để phục vụ tính toán ngày làm việc.

### 4. 🛡 Hệ Thống Audit Log & Danh Mục Động
- **Nhật ký thao tác (`Audit Trail`):** Tự động ghi vết người khởi tạo/chỉnh sửa (`CreatedBy`, `ModifiedBy`, `CreatedOn`, `ModifiedOn`), lưu lại dữ liệu cũ (`Old Values`) và dữ liệu mới (`New Values`) phục vụ truy vết bảo mật.
- **Danh mục hệ thống động (`System Codes`):** Cho phép Admin tùy chỉnh linh hoạt các loại danh mục như Giới tính, Phòng ban, Chức vụ, Trạng thái đơn, Hình thức hợp đồng không cần hardcode.

---

## 🛠 Công Nghệ & Kiến Trúc Sử Dụng

- **Backend:** C# (.NET 10), ASP.NET Core MVC, Entity Framework Core (EF Core Code-First & Migrations), LINQ, Data Annotations (`[DisplayName]`).
- **Database:** Microsoft SQL Server.
- **Frontend:** HTML5, CSS3, JavaScript, jQuery, AdminLTE v3 Dashboard Template, Bootstrap.
- **Tools & Version Control:** Visual Studio 2022, Git, GitHub.

---

## 📸 Giao Diện Dự Án

<img width="1855" height="962" alt="image" src="https://github.com/user-attachments/assets/af708ed2-0017-4e89-9eb3-1afefaa233e9" />
<img width="1901" height="965" alt="image" src="https://github.com/user-attachments/assets/ce5d4a3f-07e7-4c8b-a849-beba2554b910" />


