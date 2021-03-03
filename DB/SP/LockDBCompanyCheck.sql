alter proc LockDBCompanyCheck
@LockDate datetime, @CompanyID varchar(50)
as
begin
---Kiểm tra ngày sửa hoặc thêm dữ liệu có nằm trong ngày khóa sổ không
	select top(1)* from LockDBCompany where ClockDBDate >= @LockDate and CompanyID = @CompanyID and ClockStatus = 0 and IsDelete is null
end

LockDBCompanyCheck '2021-01-15','CTY0000000003'



