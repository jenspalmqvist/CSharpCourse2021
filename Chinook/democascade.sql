if DB_ID('DemoCascade') is null
	create database DemoCascade
go

use DemoCascade

drop table if exists Book
drop table if exists Author 

create table Author(
	Id int primary key,
	Name varchar(50),
)

-- ange vad som h�nder med mig n�r min förälder tas bort

create table Book(
	Id int primary key,
	Title varchar(50),
	AuthorId int foreign key references Author(Id) 
	-- AuthorId int foreign key references Author(Id) on delete set null
	-- AuthorId int foreign key references Author(Id) on delete cascade
)

insert into Author values (5, 'Herman Melville'),(6, 'Leo Tolstoy')
insert into Book values (1000, 'Moby-Dick', 5),(1001, 'War and Peace', 6),(1002, 'Anna Karenina', 6)

delete from Author where Id=6 
delete from Book where Title = 'Moby-Dick'

select * from Author
select * from Book
