create trigger trg_createCustomerAfterUsersInsert
on Users
after insert
as
begin 
declare @Id int
	select @�d=Id from inserted
	insert Customers(UserId,FindeksScore) values(@Id,1900)
end