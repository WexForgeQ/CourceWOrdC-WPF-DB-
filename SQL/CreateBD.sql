create table Transport(
id int not null primary key,
number int not null,
trastype nvarchar(10) not null
)

create table TransRoute(
id int not null primary key,
transid int not null foreign key references Transport(id),
name nvarchar(50) not null)

create table Stops(
id int not null primary key,
name nvarchar(50) not null)

create table StopsRoute(
id int not null primary key,
routeid int not null foreign key references TransRoute(id),
stopid int not null foreign key references Stops(id),
quenum int not null)

create table StopsTime(
id int not null primary key,
stoprouteid int not null foreign key references StopsRoute(id),
timeval time not null)

create table Users(
id int not null primary key,
usertype nvarchar(10) not null,
uslogin nvarchar(10) not null unique,
uspass nvarchar(8) not null,
email nvarchar(50) not null unique)

create table FavoriteStops(
id int not null primary key,
userid int not null foreign key references Users(id),
stopid int not null foreign key references Stops(id))

create table FavoriteTransport(
id int not null primary key,
userid int not null foreign key references Users(id),
transid int not null foreign key references Transport(id))



