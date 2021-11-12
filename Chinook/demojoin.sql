use master

--drop database DemoJoin
if DB_ID('DemoJoin') is null
	create database DemoJoin
go

use DemoJoin

drop table if exists Person
drop table if exists Color

create table Person(
	Name varchar(50),
	FavoriteColor int,
)

create table Color(
	Id int,
	Name varchar(50),
)

-- Mia och Olivia gillar r�tt
-- James gillar gr�nt
-- Liam gillar bl�tt
-- Ava vet inte

insert into Person
values
('Mia', 91),
('Olivia', 91),
('James', 92),
('Liam', 95),
('Ava',	null)

insert into Color 
values
(91, 'Red'),
(92, 'Green'),
(93, 'Blue'),
(94, 'Purple'),
(95, 'Indigo')

select * from Person
select * from Color

-- inner join: Endast de personer som har en favoritf�rg kommer med (Ava f�r inte vara med)
-- select *
-- from Person 
-- join Color 
-- on Person.FavoriteColor = Color.Id

-- left join: "Ava" kommer med �ven om hon inte har en favoritf�rg
-- select * 
-- from Person 
-- left join Color 
-- on Person.FavoriteColor = Color.Id

-- right join: Purple och Indigo kommer med �ven om ingen person har det som favoritf�rg (Ava �r inte med)
-- select * 
-- from Person 
-- right join Color 
-- on Person.FavoriteColor = Color.Id
-- where Person.FavoriteColor is null


-- Full join
-- - Allt �r med �ven de rader som inte matchar. Ex Ava �r med. Purple och Indigo �r med.
-- - Must have "on"
-- - All rows in left (inluding Mary, even if she has no favorite color)
-- - All rows in right (including Green, even if no one likes green)
-- - All people + a nullrow for green = 3+1=4 rows
-- - You don't need the word "outer" or "inner" (full outer join = full join)

-- */
-- select * 
-- from Person 
-- full join Color 
-- on Person.FavoriteColor = Color.Id


/*
Cross join
- Can't use "on"
- All combinations: 5x5 rows
- Usually this gives a lot of rows. Note: if one table has no rows => the result will have zero rows (so in this case "full join" will give more rows)
*/
-- SELECT *
--   FROM Person
--   CROSS JOIN Color; 





