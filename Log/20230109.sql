alter PROCEDURE ImportData
@Company   nvarchar(100) ='EPIC06'  
	
AS
BEGIN

select
'ps_depot',1,CustID,Name,0,BTName,BTPhoneNum, BTFaxNum, BTAddress1,1,1,Comment,CustID,CustNum,Name,Address1,Address2,Address3,City,State,Zip,Country
from [Erp].[Customer]
where Company='EPIC06'
and CustNum not in 
(
select CustNum from PS_DB..ps_depot
)

select * 
into PS_DB..ps_depot_temp
from PS_DB..ps_depot

select * 
from PS_DB..ps_depot

delete PS_DB..ps_depot_temp

insert into PS_DB..ps_depot_temp
(category_id, code, title, manage_id, contact_name, contact_tel, contact_mobile, contact_address, status, sort_id, remark, CustID, CustNum, 
CustName, Address1, Address2, Address3, City, State, Zip,  Country,Company)
select
1,CustID,Name,0,BTName,BTPhoneNum, BTFaxNum, BTAddress1, 1,1,Comment,CustID,CustNum,Name,Address1,Address2,Address3,City,State,Zip,Country,Company
from [Erp].[Customer]

select * from  [Erp].[Customer]
--delete PS_DB..ps_depot

--dbcc checkident('PS_DB..ps_depot',reseed,0)

insert into PS_DB..ps_depot
(category_id, code, title, manage_id, contact_name, contact_tel, contact_mobile, contact_address, status, sort_id, remark, CustID, CustNum, 
CustName, Address1, Address2, Address3, City, State, Zip,  Country,Company)
select
category_id, code, title, manage_id, contact_name, contact_tel, contact_mobile, contact_address, status, sort_id, remark, CustID, CustNum, 
CustName, Address1, Address2, Address3, City, State, Zip,  Country,Company
from PS_DB..ps_depot_temp
where 1=1
--and Company<>'EPIC06'
and CustID not in 
(
select CustID from PS_DB..ps_depot
)

select  * from PS_DB..ps_depot_category
select  * from[Erp].[Company]


--delete PS_DB..ps_depot_category

--dbcc checkident('PS_DB..ps_depot_category',reseed,0)

insert into PS_DB..ps_depot_category
(title, sort_id,  name,remark)
select  Company,1,Name,'' from[Erp].[Company]

select contact_tel, * from PS_DB..ps_depot 

update A
set A.category_id = B.id
from PS_DB..ps_depot  A
inner join PS_DB..ps_depot_category B on A.Company = B.title



--update PS_DB..ps_orders set depot_id=45
--select contact_tel, * from PS_DB..ps_depot order by Code
--select  * from[Erp].[Customer]





update PS_DB..ps_depot
set contact_address=Address1
where isnull(contact_address,'')='' 

delete PS_DB..ps_part

insert into PS_DB..ps_part
(product_no, product_category_id, product_name, product_desc, product_url, go_price, salse_price, product_num, dw, is_qh, is_zt, remark, add_time, user_id, status, is_xs,classid,company)
select PartNum,1,PartDescription,PartDescription,'/upload/Part.jpg',InternalUnitPrice,UnitPrice, 99999,PUM,1,1,'',GETDATE(),1,InActive,0,ClassID ,Company
from [Erp].[Part]  A
--where Company='EPIC06'


select  * from PS_DB..ps_depot_category

--delete PS_DB..ps_here_depot
--dbcc checkident('PS_DB..ps_here_depot',reseed,0)

--delete PS_DB..ps_join_depot
--dbcc checkident('PS_DB..ps_join_depot',reseed,0)

--delete PS_DB..ps_orders
--dbcc checkident('PS_DB..ps_orders',reseed,0)

--delete PS_DB..ps_order_goods
--dbcc checkident('PS_DB..ps_order_goods',reseed,0)


--delete PS_DB..ps_salse_depot
--dbcc checkident('PS_DB..ps_salse_depot',reseed,0)

--delete PS_DB..ps_manager_log
--dbcc checkident('PS_DB..ps_manager_log',reseed,0)


insert into PS_DB..ps_here_depot
(product_no, product_category_id, product_name, product_desc, product_url, go_price, salse_price, product_num, dw, is_qh, is_zt, remark, add_time, user_id, status, is_xs,classid,company)
select *
from PS_DB..ps_part
where product_no+'-'+company not in
(
select product_no+'-'+company from PS_DB..ps_here_depot
)

update A
set product_category_id=B.ID
from PS_DB..ps_here_depot A 
inner join PS_DB..ps_product_category B on A.classid = B.classid

delete PS_DB..ps_product_category_temp


insert into PS_DB..ps_product_category_temp
select Description,1,'' ,ClassID
from [Erp].PartClass
where Company='EPIC06'

select *
from [Erp].PartClass

--delete PS_DB..ps_product_category

--dbcc checkident('PS_DB..ps_product_category',reseed,0)

select * from PS_DB..ps_product_category

update PS_DB..ps_product_category
set remark=classid

insert into PS_DB..ps_product_category
(classid, title, sort_id, remark)
select classid,title,1,''  from PS_DB..ps_product_category_temp
where classid not in
(
select classid from PS_DB..ps_product_category
)

select * from PS_DB..[ps_manager_log]

delete PS_DB..[ps_manager_log]

delete PS_DB..[ps_manager_log]



END