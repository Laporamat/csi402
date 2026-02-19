# Quiz_6XXXXXX_Student - ASP.NET Core MVC

## วิธีการใช้งาน
1. เปลี่ยนชื่อ Project และ Namespace จาก `Quiz_6XXXXXX_Student` เป็น `Quiz_รหัสนักศึกษา_ชื่อจริง`
2. เปิด Visual Studio 2022 หรือ VS Code
3. รัน dotnet restore แล้ว dotnet run

## โครงสร้างโปรเจกต์
- Controllers/
  - AccountController.cs  → Login, StudentList, CalculateForm
  - StudentController.cs  → Index, MyDetails
- Models/ViewModels/
  - LoginViewModel.cs
  - StudentViewModel.cs
  - ScoreViewModel.cs
- Views/
  - Account/ → Login.cshtml, StudentList.cshtml, CalculateForm.cshtml
  - Student/ → Index.cshtml, MyDetails.cshtml
  - Shared/ → _blankLayout.cshtml, _StudentLayout.cshtml
- wwwroot/css/site.css

## การทำงาน
1. หน้าแรก: Login (ใช้ _blankLayout)
2. หลัง Login → Student/Index แสดงยินดีต้อนรับ
3. Student List: แสดงตารางนักศึกษา 8 คน
4. Calculate Form: กรอกคะแนน 10 ครั้ง คำนวณ Grade
5. My Details: แสดงข้อมูลนักศึกษาผ่าน ViewBag

## คำอธิบายโค้ดตามโจทย์ข้อ 1–10

1. สร้าง Project ASP.NET Core MVC  
   - โปรเจกต์เป็นแบบ ASP.NET Core MVC ใช้ไฟล์ `Program.cs` ตั้งค่า `WebApplication`, เพิ่ม `AddControllersWithViews()` และ map route หลักไปที่ `Account/Login`
   - ชื่อปัจจุบันคือ `Quiz_6XXXXXX_Student` สามารถเปลี่ยนเป็น `Quiz_รหัสนักศึกษา_ชื่อจริง` ตามโจทย์ได้

2. Controller: Account, Student  
   - โฟลเดอร์ `Controllers/` มี `AccountController` และ `StudentController` ซึ่งสืบทอดจาก `Controller` สำหรับจัดการหน้าต่าง ๆ

3. ViewModels  
   - `LoginViewModel` เก็บ `UserId`, `Password` สำหรับหน้า Login  
   - `StudentViewModel` เก็บข้อมูลนักศึกษา เช่น รหัส ชื่อ นามสกุล คณะ สาขา ปี GPA สำหรับ Student List  
   - `ScoreViewModel` เก็บคะแนน `Score1`–`Score10` ใช้ในหน้า Calculate Form

4. Layout: `_blankLayout` และ `_StudentLayout`  
   - `_blankLayout.cshtml` เป็น layout แบบหน้าเปล่า มีแค่โครง HTML + Bootstrap และ `@RenderBody()` ใช้กับหน้า Login  
   - `_StudentLayout.cshtml` เป็น layout หลักหลัง Login มีเมนู Index, Calculate Form, Student List, My Details และแสดง `UserId : X` จาก `ViewBag.UserId`

5. View Login (Account/Login)  
   - ใช้ model `LoginViewModel` และ `Layout = _blankLayout`  
   - ฟอร์มมี input `UserId`, `Password` และปุ่ม Login ส่งแบบ POST ไปที่ `Account/Login`  
   - ใน `AccountController` เมื่อ POST จะเก็บ `UserId` ลง `TempData` แล้ว `RedirectToAction("Index","Student", new { userId = model.UserId })`

6. View Index (Student/Index)  
   - เมธอด `Index(string userId)` ใน `StudentController` จะเซ็ต `ViewBag.UserId` จาก parameter หรือ `TempData["UserId"]`  
   - View `Student/Index.cshtml` ใช้ `_StudentLayout` และแสดงข้อความ “ยินดีต้อนรับคุณ : [UserId] เข้าสู่ระบบ”

7. View StudentList (Account/StudentList)  
   - ใน `AccountController.StudentList()` สร้าง `List<StudentViewModel>` จำนวนอย่างน้อย 8 คนแล้วส่งให้ View  
   - View `Account/StudentList.cshtml` ใช้ `_StudentLayout` และแสดงข้อมูลทั้งหมดในรูปแบบตาราง Bootstrap

8. View Calculate Form (Account/CalculateForm)  
   - GET: คืน View พร้อม `new ScoreViewModel()`  
   - POST: รวมคะแนน 10 ครั้ง หาค่าเฉลี่ย และกำหนดเกรด A–F จากช่วงคะแนน  
   - เก็บผลรวม (`Total`), ค่าเฉลี่ย (`Average`), เกรด (`Grade`) ลง `ViewBag` และ View ใช้แสดงผลพร้อมตกแต่งด้วย badge/การ์ด

9. View MyDetails (Student/MyDetails)  
   - เมธอด `MyDetails()` ใน `StudentController` ประกาศค่าต่าง ๆ ของนักศึกษาอย่างน้อย 8 ค่า (เช่น รหัส ชื่อ นามสกุล Email คณะ สาขา ปี GPA ที่อยู่) ผ่าน `ViewBag`  
   - View `Student/MyDetails.cshtml` ใช้ `_StudentLayout` และดึงค่า `ViewBag` มาแสดงใน card สวยงาม

10. การตกแต่งด้วย Bootstrap / CSS  
    - ทั้งสอง layout import Bootstrap 5 และ Font Awesome  
    - View ทุกหน้ามีการใช้ class ของ Bootstrap เช่น `container`, `row`, `col`, `card`, `btn`, `table`, `badge`  
    - ไฟล์ `wwwroot/css/site.css` ปรับแต่งเพิ่มเติม เช่น เงา card, navbar, ปุ่ม, ตาราง และกล่องข้อมูล ให้เหมาะกับหน้าจอ
