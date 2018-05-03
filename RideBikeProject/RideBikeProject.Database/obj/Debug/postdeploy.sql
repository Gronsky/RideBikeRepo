/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--insert into Roles ([Name])
--values (N'Admin'), (N'User'), (N'Chief');

--insert into [BikeTypes] ([Type])
--values (N'MTB'), (N'Road'), (N'BMX'), (N'Other');

--insert into [BikeSubtypes] (Subtype, TypeId)
--values (N'Downhill', 1), (N'Enduro', 1), (N'Freeride', 1), (N'DirtJump', 1), (N'XCTrail', 1), (N'XCRace', 1),
--(N'Race', 2), (N'Sport', 2), (N'Aero', 2), (N'Touring', 2),
--(N'Flat', 3), (N'Street', 3), (N'Park', 3), (N'Race', 3),
--(N'Custom', 4)

--insert into EventTypes([Type], [LongType], [Description])
--values 
--(N'XCO', N'Olympic Cross Country', N'is a race in which riders are released in groups. It takes place on a special circuit, over 4-10 km with a duration of about 2 hours. The contestants have to cover a number of laps and the race is over when the first contestant finishes the track. It is the most popular form of race and is present even in the summer olympics.'),
--(N'XCM', N'Cross Country Marathon', N'is a race in which the riders are released in groups. The circuit has between 60 and 160 km, with a duration of 3 hours tops. It is the most popular race for amateur riders.'),
--(N'XCC', N'Cross Country Short Circuit', N'is a race on a short circuit of 2 km and a duration of less than 60 minutes.'),
--(N'XCE', N'Cross Country Eliminator', N'is a race in which riders are released in groups of 4 or 6, on a short circuit of maximum 1000 m. The fastest riders get to the next round while the slower ones are eliminated from the race. The circuit can be spectacular with artificial obstacles placed on the way.'),
--(N'XCS', N'Cross Country Stage Race', N'is a race with several stages. Different races are permitted with the exception of XCE. The favoured ones are XCP and XCT races.'),
--(N'XCP', N'Point-to-point Cross Country', N' is a race that starts in one place and ends in another, in which riders are released in group. The circuit is smaller than that of a marathon.'),
--(N'XCT', N'Cross Country Time Trial', N'is a race against the clock and only takes place during an XCS.'),
--(N'XCR', N'Cross Country Relay', N'as the name says is a relay race, between teams that include a junior rider, an U23, a male and a woman elite racer. Each covers a single round on XCO track. The order of participation is decided by each team’s strategy.'),
--(N'DHI', N'Downhill Individual', N'The most famous format, also seen at World Cup and World Championships is DHI, on a track of 3500 m long and a duration of 5 minutes tops. Interesting is the fact that UCI forbids the XC riders’ equipment and the video cameras installed on their helmets or bikes.'),
--(N'DHM', N'Downhill Multi', N'DH group start.'),
--(N'4X', N'Four Cross', N'is a downhill test on a technical track where the riders are released in groups of 4 and has a duration of 60 seconds tops.'),
--(N'Dual Slalom', N'Dual Slalom', N'is a downhill test in which two riders start at the same time on two relatively identical routes. Today this type of race is no longer included in UCI’s list.'),
--(N'Enduro', N'Enduro', N'is the most popular type of gravity test. This takes place on a long track that contains both transitional areas (usually uphill) and timed areas (downhill). The contestants must cover the entire track, but they are timed only in the areas established from the very beginning. Lately this is one of the most popular MTB disciplines.'),
--(N'Trial', N'Trial', N'is sometimes considered a MTB discipline, but in fact it is a separate thing altogether with special bikes and techniques, even UCI considers it as completely separate discipline.This race includes the covering of a track with big obstacles, implying a lot of technical jumping and equilibrium.'),
--(N'DJ', N'Dirt Jumping', N'is also a discipline derived from MTB. There are races of this type, but they take place without UCI’s approval. It takes place on a special track with platforms, involving a lot of jumping and tricks. Similar to this race is Pump Track.'),
--(N'24h MTB', N'24h Mountain Bike', N'are races that take place during a 24 hours circuit, the winner is the one that covers the biggest number of laps. This also has no UCI approvement but is becoming extremely popular.'),
--(N'MTB-O', N'Mountain Bike Orienteering', N'is a race similar to foot orienteering that implies navigation tactics. As the biker reaches higher speed, map reading becomes more challenging.')

--insert into Producers
--values (N'Other'), (N'Specialized'), (N'Giant'),(N'Cannondale'),(N'Focus'),(N'Author'),(N'YT'),(N'Canyon'),(N'BMC'),(N'Cube'),
--(N'GT'),(N'Merida'),(N'SCOTT'),(N'Yeti'),(N'Alutech'), (N'Trek'), (N'Santa Cruz')

--insert into Users ([FirstName], [LastName], [Email], [Password], [BirthDate])
--Values( N'Brandon', N'Semenuk', 'brandonsemenuk@gmail.com', N'123456', GETDATE()),
--( N'Rachel', N'Atherton', 'rachelatherton@gmail.com', N'123456', GETDATE()),
--( N'Danny', N'MacAskill', 'macaskill@gmail.com', N'123456', GETDATE()),
--( N'Nicholi', N'Rogatkin', 'nrogatkin@gmail.com', N'123456', GETDATE()),
--( N'Dmitry', N'Topal', 'topal@gmail.com', N'123456', GETDATE()),
--( N'Tatiana', N'Cotiga', 'tanea@gmail.com', N'123456', GETDATE()),
--( N'Eduard', N'Dovicenco', 'edovicenco@gmail.com', N'123456', GETDATE())

--insert into Teams ([Name],[ChiefId],[Location],[Description])
--Values 
--(N'Trek Bicycle Corporation', 1, N'Whistler, British Columbia, Canada', N'We are driven by adventure, guided by our history, inspired by community, enchanted by the freedom of the open road and committed, always, to creating the world’s greatest bicycles.'),
--(N'At the Edge', 3, N'Skye, Scotland', N'Scottish trials team.'),
--(N'Trail Park VM', 5, N'Moldova, Chisinau, "Valea Morilor" Pump Treck', N'Группа, освещающая жизнь молдавских маунтинбайкеров. 
--Новости велоиндустрии, информация о строительстве спотов, катании, обсуждение поездок и планов. 
--Не ЗОЖники и не спортсмены, там, где нет гор - мы копаем то, что называем трейлами, только ради фана!'),
--(N'MTB.MD', 7, N'Moldova, Chisinau', N'Clubul Sportiv MTB.md');

--update [Users]
--set TeamId = 1
--Where Id = 1

--update [Users]
--set TeamId = 2
--Where Id = 3

--update [Users]
--set TeamId = 3
--Where Id = 5

--update [Users]
--set TeamId = 4
--Where Id = 7

--update [Users]
--set RoleId = 3
--Where Id IN (1, 3, 5, 7)

--Insert into [Events] ([Name], [DateTime], [CreatedBy], TypeId, [Location], [Description])
--Values (N'Orheiul Vechi 2018', '2018-05-05 08:00:00', 3, 2, N'Republica Moldova. Complexul muzeal Orheiul Vechi', N'Evenimentul «Orheiul Vechi» XCM 2018 reprezintă o competiție pe biciclete MTB, disciplina cross-country și cursele la rezistență. Scopurile și obiectivele — promovarea ciclismului în Moldova, în special MTB. Identificarea celor mai puternici și menționarea categoriilor Mountain Bike cu premii și medalii meritate.'),
--(N'Eluminator seria 1', '2018-06-08 09:00:00', 3, 11, N'Republica Moldova, Chisinau, parcul "Valea Morilor"', N'Bike race format in which four riders compete against each other in each heat, similar to Four-cross.')

--insert into [dbo].[EventUsers] VALUES(1, 5, null),(1, 6, null),(1, 7, null);


--insert into Images
--Values (N'C:/Users/anastasia.gronscaia/Pictures/Saved Pictures/123.JPG'),
--(N'C:/Users/anastasia.gronscaia/Pictures/Saved Pictures/trek.JPG'),
--(N'C:/Users/anastasia.gronscaia/Pictures/Saved Pictures/brandon.JPG'),
--(N'C:/Users/anastasia.gronscaia/Pictures/Saved Pictures/edge.JPEG'),
--(N'C:/Users/anastasia.gronscaia/Pictures/Saved Pictures/tp.JPEG');

--Update Teams
--set ImageId = 2
--Where [Name] Like N'%Trek%'

--Update Teams
--set ImageId = 4
--Where [Name] Like N'%Edge%'

--update Teamsset ImageId = 5
--Where [Name] Like N'%Trail Park%'

--Update [Users]
--set ImageId = 3
GO
