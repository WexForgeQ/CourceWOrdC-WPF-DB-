--����� ������� �� ��������
select Transport.number, Stops.name, StopsTime.timeval from StopsTime
inner join StopsRoute
on stoprouteid = StopsRoute.id 
inner join Stops
on StopsRoute.stopid = Stops.id
inner join TransRoute
on StopsRoute.routeid = TransRoute.id
inner join Transport
on TransRoute.transid = Transport.id
where Transport.number = 1

select * from StopsTime
inner join StopsRoute
on stoprouteid = StopsRoute.id 
inner join Stops
on StopsRoute.stopid = Stops.id
inner join TransRoute
on StopsRoute.routeid = TransRoute.id
inner join Transport
on TransRoute.transid = Transport.id

select distinct Transport.number, TransRoute.name from StopsTime
inner join StopsRoute
on stoprouteid = StopsRoute.id 
inner join Stops
on StopsRoute.stopid = Stops.id
inner join TransRoute
on StopsRoute.routeid = TransRoute.id
inner join Transport
on TransRoute.transid = Transport.id
where Transport.number = 1

--����� ��������� 
select Stops.name from StopsTime
inner join StopsRoute
on stoprouteid = StopsRoute.id 
inner join Stops
on StopsRoute.stopid = Stops.id
inner join TransRoute
on StopsRoute.routeid = TransRoute.id
inner join Transport
on TransRoute.transid = Transport.id
where TransRoute.name = '����������-������'

--����� ��������� 
select Transport.number, StopsTime.timeval from StopsTime
inner join StopsRoute
on stoprouteid = StopsRoute.id 
inner join Stops
on StopsRoute.stopid = Stops.id
inner join TransRoute
on StopsRoute.routeid = TransRoute.id
inner join Transport
on TransRoute.transid = Transport.id
where Stops.name = '��������' and TransRoute.name = '��������-����������'

drop table FavoriteStops