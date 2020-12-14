SP_SoCaiTaiKhoan '2019-01-1','2019-12-31'

alter proc SP_SoCaiTaiKhoan
@StartDate datetime, @EndDate datetime
as
begin

DECLARE @KC911TempTKDU TABLE(VouchersTypeID varchar(50), VouchersID varchar(50), AccountID varchar(50) ,CompanyID varchar(50),Description nvarchar(max),Date datetime,DebitAmount money,CreditAmount money,NV varchar(50),TKDU varchar(50),DebitAmountDU money, CreditAmountDU money)
DECLARE @KC911Temp01 TABLE(RowID bigint,VouchersTypeID varchar(50), VouchersID varchar(50), AccountID varchar(50) ,CompanyID varchar(50),Description nvarchar(max),Date datetime,DebitAmount money,CreditAmount money,NV varchar(50))
DECLARE @KC911Temp TABLE(VouchersTypeID varchar(50), VouchersID varchar(50), AccountID varchar(50) ,CompanyID varchar(50),Description nvarchar(max),Date datetime,DebitAmount money,CreditAmount money)
INSERT INTO @KC911Temp
select B.VouchersTypeID,A.VouchersID, A.AccountID,A.CompanyID,B.Description,B.Date,Sum(ISNULL(DebitAmount, 0 )) as 'DebitAmount',Sum(ISNULL(CreditAmount, 0 )) as 'CreditAmount'
 from VouchersDetail as A
inner join Vouchers as B
on A.VouchersID = B.VouchersID
where B.Date>= @StartDate and B.Date <= @EndDate
group by B.VouchersTypeID,A.VouchersID, A.AccountID,A.CompanyID,B.Description,B.Date
order by A.VouchersID,A.AccountID,b.Date

insert into @KC911Temp01
select ROW_NUMBER() OVER (Order by AccountID) AS RowID,*,case
When DebitAmount - CreditAmount > 0 then 'N'
else 'C'
end as 'NV' from @KC911Temp 

Declare @RowCount bigint
set @RowCount = (Select count (*) from @KC911Temp01)
while (@RowCount > 0)
begin
	Declare @AccountID varchar(50)
	Declare @NV varchar(50)
	Declare @DebitAmount money
	Declare @CreditAmount money
	Declare @VouchersID varchar(50)
	Declare @VouchersTypeID varchar(50)
	Declare @CompanyID varchar(50)
	Declare @Description nvarchar(max)
	Declare @Date datetime
	select @Description = Description, @Date = Date, @CompanyID= CompanyID, @VouchersTypeID = VouchersTypeID, @AccountID = AccountID,@NV = NV,@DebitAmount = DebitAmount,@CreditAmount = CreditAmount,@VouchersID = VouchersID 
	from @KC911Temp01
	where RowID = @RowCount

	DECLARE @KC911Temp01_While TABLE(RowID bigint,VouchersTypeID varchar(50), VouchersID varchar(50), AccountID varchar(50) ,CompanyID varchar(50),Description nvarchar(max),Date datetime,DebitAmount money,CreditAmount money,NV varchar(50))
	insert into @KC911Temp01_While
	select ROW_NUMBER() OVER (Order by AccountID) AS RowID,
	VouchersTypeID, VouchersID , AccountID ,CompanyID ,Description ,Date ,DebitAmount ,CreditAmount ,NV 
	 from @KC911Temp01 where VouchersID = @VouchersID and NV <> @NV

	Declare @RowCountWhile bigint
	set @RowCountWhile = (select count(*) from @KC911Temp01_While where VouchersID = @VouchersID)
	Declare @RowCountCheckWhile bigint
	set @RowCountCheckWhile = @RowCountWhile

	while (@RowCountWhile > 0)
	begin
		--------insert table tk đối ứng.
			Declare @AccountIDWhile varchar(50)
			Declare @NVWhile varchar(50)
			Declare @DebitAmountWhile money
			Declare @CreditAmountWhile money
			Declare @VouchersIDWhile varchar(50)

			select @AccountIDWhile = AccountID,@NVWhile = NV,@DebitAmountWhile = DebitAmount,@CreditAmountWhile = CreditAmount,@VouchersIDWhile = VouchersID 
			from @KC911Temp01_While
			where RowID = @RowCountWhile

			if(@RowCountCheckWhile=1)
			begin
						insert into @KC911TempTKDU(VouchersTypeID, VouchersID , AccountID ,CompanyID ,Description ,Date ,DebitAmount,CreditAmount ,NV ,TKDU,DebitAmountDU , CreditAmountDU )
						values(@VouchersTypeID,@VouchersID,@AccountID,@CompanyID,@Description,@Date,@DebitAmount,@CreditAmount,@NV,@AccountIDWhile,@CreditAmount,@DebitAmount)
			end
			else 
			begin
						insert into @KC911TempTKDU(VouchersTypeID, VouchersID , AccountID ,CompanyID ,Description ,Date ,DebitAmount,CreditAmount ,NV ,TKDU,DebitAmountDU , CreditAmountDU )
						values(@VouchersTypeID,@VouchersID,@AccountID,@CompanyID,@Description,@Date,@DebitAmount,@CreditAmount,@NV,@AccountIDWhile,@DebitAmountWhile,@CreditAmountWhile)
			end
			Set @RowCountWhile = @RowCountWhile - 1
	end
	delete  @KC911Temp01_While
	set @RowCount = @RowCount - 1
end
select VouchersTypeID, VouchersID , AccountID ,CompanyID ,Description ,Date  ,TKDU,DebitAmountDU , CreditAmountDU from @KC911TempTKDU 
order by VouchersID, AccountID
End