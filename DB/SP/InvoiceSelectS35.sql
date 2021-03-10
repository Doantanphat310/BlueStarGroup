alter PROCEDURE [dbo].[InvoiceSelectS35] (
	@StartDate Datetime,
	@EndDate Datetime,
	@CompanyID varchar(50),
	@StatusLink int
)
AS	
	begin

		if(@StatusLink = 0)
		begin
		--select no link
				select * from Invoice 
				Where CompanyID = @CompanyID 
				and InvoiceDate >= @StartDate and InvoiceDate <= @EndDate
				and S35Type = 1
				and (IsDelete is Null)
				and VouchersID is null
		end
		else if(@StatusLink = 1)
		begin
					--select linked
				select * from Invoice 
				Where CompanyID = @CompanyID 
				and InvoiceDate >= @StartDate and InvoiceDate <= @EndDate
				and S35Type = 1
				and (IsDelete is Null)
				and VouchersID is not null
		end
		else if(@StatusLink = 2)
		begin
					--select all
				select * from Invoice 
				Where CompanyID = @CompanyID 
				and InvoiceDate >= @StartDate and InvoiceDate <= @EndDate
				and S35Type = 1
				and (IsDelete is Null)
		end
		else if(@StatusLink = 10)
		begin
				--select no link warehouse
				select * from Invoice 
				Where CompanyID = @CompanyID 
				and InvoiceDate >= @StartDate and InvoiceDate <= @EndDate
				and S35Type = 1
				and (IsDelete is Null)
				and InvoiceID not in (select InvoiceID from WareHouse where CompanyID = @CompanyID and IsDelete is null)
		end
		else if(@StatusLink = 11)
		begin
					--select link warehouse
				select * from Invoice 
				Where CompanyID = @CompanyID 
				and InvoiceDate >= @StartDate and InvoiceDate <= @EndDate
				and S35Type = 1
				and (IsDelete is Null)
				and InvoiceID in (select InvoiceID from WareHouse where CompanyID = @CompanyID and IsDelete is null)
		end
	end
