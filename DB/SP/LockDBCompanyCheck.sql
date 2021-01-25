alter proc LockDBCompanyCheck
@LockDate datetime, @CompanyID varchar(50)
as
begin
---Kiểm tra ngày sửa hoặc thêm dữ liệu có nằm trong ngày khóa sổ không
	select top(1)* from LockDBCompany where ClockDBDate >= @LockDate and CompanyID = @CompanyID and ClockStatus = 0
end

LockDBCompanyCheck '2020-01-25','CTY0000000003'

