
if DB_ID('DemoGroupBy') is null
	create database DemoGroupBy
go

use DemoGroupBy

drop table if exists Person

create table Person(
	Name varchar(50) not null,
	Country varchar(50),
	Income int
)

insert into Person
values
('Mia', 'Sweden', 20000),
('Olivia', 'Iceland', 50000),
('James', 'Sweden', 25000),
('Liam', 'Sweden', 28000),
('Liam', 'Spain', 28000),
('Ava',	'Iceland', 60000),
('Lisa', 'Spain', 10000)

update p 
set p.Income = p.Income + 1000
from Person p
where Income < 28000


select * from Person

insert into Person
VALUES
('Liam', 'Iceland', 12)

select * from Person

-- Ger 2 och 1 och 3 (inte s� intressant)
-- select count(*) as Inhabitants
-- from Person 
-- group by Country

-- Ger landsnamn + antal person i gruppen
-- select Country, count(*) as Inhabitants -- count(*) räknar hur många rader som finns i varje gruppering, grupperat på namn
-- from Person 
-- group by Country

-- -- Ge snittinkomsten inom gruppen (bara "Income" hade inte funkat)
-- select Country, avg(Income) as AverageIncome, count(*)  as Inhabitants
-- from Person 
-- group by Country

-- -- Filtrera grupper med "having" (detta g�r inte att g�ra med "where")
-- select Country, count(*)  as Inhabitants
-- from Person 
-- group by Country 
-- having count(*)>=2

-- Kan filtrera rader med "where" innan grupperingen sker (detta fall funkar �ven med "having")
-- select Country, count(*) 
-- from Person 
-- where Country like '%S%' -- % är 0 eller flera tecken, ett s.k. wildcard
-- -- where Country like '__E%' -- _ är ett annat wildcard, men matchar enbart ETT tecken
-- group by Country 

-- -- Filtera f�rst de namn som b�rjar p� "L". Gruppera efter det
-- select Country, count(*) 
-- from Person 
-- where Name like 'L%'
-- group by Country 

-- Funkar inte f�r Name kan vara olika inom gruppen
-- select Country, count(*) 
-- from Person 
-- group by Country 
-- having Name like 'L%'

-- Funkar inte f�r Income kan vara olika inom gruppen
-- select count(*), Income 
-- from Person 
-- group by Country
