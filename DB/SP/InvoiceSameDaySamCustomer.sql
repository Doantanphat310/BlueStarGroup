alter proc InvoiceSameDaySamCustomer
@CompanyID varchar(50)
as
begin
--select * from View_InvoiceSameDaySamCustomer where CompanyID = @CompanyID
select * from Invoice where CompanyID = @CompanyID and IsDelete is null and S35Type is null
end


