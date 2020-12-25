Create table KetChuyentable
(
GroupCode varchar(50),
KetChuyenDebitAccountID varchar(50),
KetChuyernCreditAccountID varchar(50),
CreateDate datetime,
CreateUser varchar(50),
UpdateDate datetime,
UpdateUser varchar(50),
CONSTRAINT  UC_KetChuyen UNIQUE (KetChuyenDebitAccountID,KetChuyernCreditAccountID)
)