USE [TrainReservationDb]

DELETE FROM dbo.Cars
DELETE FROM dbo.Connections
DELETE FROM dbo.Graphics
DELETE FROM dbo.PlaceReservations
DELETE FROM dbo.Places
DELETE FROM dbo.Reservations
DELETE FROM dbo.Stations
DELETE FROM dbo.Stops
DELETE FROM dbo.TicketTypes
DELETE FROM dbo.TrainCars
DELETE FROM dbo.Trains
DELETE FROM dbo.Users

SET IDENTITY_INSERT [dbo].[Trains] ON 
INSERT [dbo].[Trains] ([TrainId], [name], [number]) VALUES (1, N'Train1', 546)
INSERT [dbo].[Trains] ([TrainId], [name], [number]) VALUES (2, N'Testowy', 45)
INSERT [dbo].[Trains] ([TrainId], [name], [number]) VALUES (3, N'Nowy', 45)
SET IDENTITY_INSERT [dbo].[Trains] OFF

SET IDENTITY_INSERT [dbo].[Cars] ON 
INSERT [dbo].[Cars] ([CarId], [Name]) VALUES (1, N'Test')
INSERT [dbo].[Cars] ([CarId], [Name]) VALUES (2, N'halo')
INSERT [dbo].[Cars] ([CarId], [Name]) VALUES (6, N'car')
SET IDENTITY_INSERT [dbo].[Cars] OFF

SET IDENTITY_INSERT [dbo].[TrainCars] ON 
INSERT [dbo].[TrainCars] ([TrainCarsId], [Order], [number], [TrainId], [CarId]) VALUES (1, 1, 15, 1, 6)
INSERT [dbo].[TrainCars] ([TrainCarsId], [Order], [number], [TrainId], [CarId]) VALUES (2, 4, 16, 1, 6)
INSERT [dbo].[TrainCars] ([TrainCarsId], [Order], [number], [TrainId], [CarId]) VALUES (3, 3, 17, 1, 1)
INSERT [dbo].[TrainCars] ([TrainCarsId], [Order], [number], [TrainId], [CarId]) VALUES (4, 6, 18, 1, 6)
INSERT [dbo].[TrainCars] ([TrainCarsId], [Order], [number], [TrainId], [CarId]) VALUES (5, 7, 19, 1, 6)

INSERT [dbo].[TrainCars] ([TrainCarsId], [Order], [number], [TrainId], [CarId]) VALUES (6, 1, 7, 2, 6)
INSERT [dbo].[TrainCars] ([TrainCarsId], [Order], [number], [TrainId], [CarId]) VALUES (7, 2, 8, 2, 1)

INSERT [dbo].[TrainCars] ([TrainCarsId], [Order], [number], [TrainId], [CarId]) VALUES (8, 1, 7, 3, 6)
INSERT [dbo].[TrainCars] ([TrainCarsId], [Order], [number], [TrainId], [CarId]) VALUES (9, 2, 8, 3, 1)
SET IDENTITY_INSERT [dbo].[TrainCars] OFF

SET IDENTITY_INSERT [dbo].[Places] ON 
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (1, 0.15, 0.25, 1, 0.054, 0.135, 1)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (2, 0.15, 0.5125, 2, 0.054, 0.135, 1)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (3, 0.15, 0.25, 1, 0.054, 0.135, 2)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (4, 0.15, 0.5125, 2, 0.054, 0.135, 2)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (11, 0.287, 0.6475, 1, 0.054, 0.135, 6)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (12, 0.287, 0.505, 2, 0.054, 0.135, 6)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (13, 0.287, 0.36, 3, 0.054, 0.135, 6)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (14, 0.418, 0.36, 4, 0.054, 0.135, 6)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (15, 0.418, 0.5, 5, 0.054, 0.135, 6)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (16, 0.419, 0.6425, 6, 0.054, 0.135, 6)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (17, 0.489, 0.65, 7, 0.054, 0.135, 6)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (18, 0.489, 0.505, 8, 0.054, 0.135, 6)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (19, 0.489, 0.3625, 9, 0.054, 0.135, 6)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (20, 0.622, 0.6475, 10, 0.054, 0.135, 6)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (21, 0.622, 0.505, 11, 0.054, 0.135, 6)
INSERT [dbo].[Places] ([PlaceId], [X], [Y], [Number], [Width], [Height], [CarId]) VALUES (22, 0.622, 0.365, 12, 0.054, 0.135, 6)
SET IDENTITY_INSERT [dbo].[Places] OFF

SET IDENTITY_INSERT [dbo].[Users] ON 
INSERT [dbo].[Users] ([Id], [Login], [UserType], [Password], [Email], [IsAdmin]) VALUES (1, N'test', 1, N'RjHftZvTJ9OhO8ZsgBin6ABaZr4vLSLue2DIZpNQUCjqWWlf', N'sender.246695@gmail.com', 0)
INSERT [dbo].[Users] ([Id], [Login], [UserType], [Password], [Email], [IsAdmin]) VALUES (8, N'sender.246695@gmail.com', 2, NULL, N'sender.246695@gmail.com', 0)
INSERT [dbo].[Users] ([Id], [Login], [UserType], [Password], [Email], [IsAdmin]) VALUES (9, N'kojonek2@gmail.com', 2, NULL, N'kojonek2@gmail.com', 0)
INSERT [dbo].[Users] ([Id], [Login], [UserType], [Password], [Email], [IsAdmin]) VALUES (10, N'246695@student.pwr.edu.pl', 2, NULL, N'246695@student.pwr.edu.pl', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF

SET IDENTITY_INSERT [dbo].[Graphics] ON 
INSERT [dbo].[Graphics] ([GraphicId], [X], [Y], [Type], [Width], [Height], [CarId]) VALUES (1, 0.15, 0.375, N'rect', 0.2, 0.5, 1)
INSERT [dbo].[Graphics] ([GraphicId], [X], [Y], [Type], [Width], [Height], [CarId]) VALUES (2, 0.15, 0.375, N'rect', 0.2, 0.5, 2)
INSERT [dbo].[Graphics] ([GraphicId], [X], [Y], [Type], [Width], [Height], [CarId]) VALUES (6, 0.49050174160342452, 0.49876059323323674, N'rect', 0.56500348320684879, 0.59247881353352649, 6)
INSERT [dbo].[Graphics] ([GraphicId], [X], [Y], [Type], [Width], [Height], [CarId]) VALUES (7, 0.38, 0.57248634049444125, N'rect', 0.2, 0.44502731901111764, 6)
INSERT [dbo].[Graphics] ([GraphicId], [X], [Y], [Type], [Width], [Height], [CarId]) VALUES (8, 0.58150495049504947, 0.572486035307294, N'rect', 0.200990099009901, 0.44502792938541197, 6)
SET IDENTITY_INSERT [dbo].[Graphics] OFF

SET IDENTITY_INSERT [dbo].[Stations] ON 
INSERT [dbo].[Stations] ([StationId], [Name]) VALUES (1, N'Leszno')
INSERT [dbo].[Stations] ([StationId], [Name]) VALUES (2, N'Rydzyna')
INSERT [dbo].[Stations] ([StationId], [Name]) VALUES (3, N'Kaczkowo')
INSERT [dbo].[Stations] ([StationId], [Name]) VALUES (4, N'Bojanowo')
INSERT [dbo].[Stations] ([StationId], [Name]) VALUES (5, N'Rawicz')
SET IDENTITY_INSERT [dbo].[Stations] OFF

SET IDENTITY_INSERT [dbo].[Connections] ON 
INSERT [dbo].[Connections] ([ConnectionId], [FirstStationId], [SecondStationId], [Distance]) VALUES (1, 1, 2, 7)
INSERT [dbo].[Connections] ([ConnectionId], [FirstStationId], [SecondStationId], [Distance]) VALUES (2, 2, 3, 3)
INSERT [dbo].[Connections] ([ConnectionId], [FirstStationId], [SecondStationId], [Distance]) VALUES (3, 3, 4, 9)
INSERT [dbo].[Connections] ([ConnectionId], [FirstStationId], [SecondStationId], [Distance]) VALUES (4, 4, 5, 14)
SET IDENTITY_INSERT [dbo].[Connections] OFF

SET IDENTITY_INSERT [dbo].[Stops] ON 
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (1, 1, 1, '2021-06-20T15:00:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (2, 2, 1, '2021-06-20T15:12:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (3, 3, 1, '2021-06-20T15:17:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (4, 4, 1, '2021-06-20T15:25:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (5, 5, 1, '2021-06-20T15:40:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (6, 1, 2, '2021-06-20T15:30:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (7, 2, 2, '2021-06-20T15:25:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (8, 3, 2, '2021-06-20T15:20:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (9, 4, 2, '2021-06-20T15:15:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (10, 5, 2, '2021-06-20T15:10:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (11, 1, 3, '2021-06-19T15:00:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (12, 2, 3, '2021-06-19T15:12:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (13, 3, 3, '2021-06-19T15:17:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (14, 4, 3, '2021-06-19T15:25:00')
INSERT [dbo].[Stops] ([StopId], [StationId], [TrainId], [StopDateTime]) VALUES (15, 5, 3, '2021-06-19T15:40:00')
SET IDENTITY_INSERT [dbo].[Stops] OFF

SET IDENTITY_INSERT [dbo].[TicketTypes] ON 
INSERT [dbo].[TicketTypes] ([TicketTypeId], [PricePercentage], [Name]) VALUES (1, 1, N'Normalny')
INSERT [dbo].[TicketTypes] ([TicketTypeId], [PricePercentage], [Name]) VALUES (2, 0.51, N'Studencki 51%')
SET IDENTITY_INSERT [dbo].[TicketTypes] OFF

SET IDENTITY_INSERT [dbo].[Reservations] ON 
INSERT [dbo].[Reservations] ([ReservationId], [UserId], [FromId], [ToId]) VALUES (1, 1, 10, 6)
INSERT [dbo].[Reservations] ([ReservationId], [UserId], [FromId], [ToId]) VALUES (2, 1, 7, 6)
INSERT [dbo].[Reservations] ([ReservationId], [UserId], [FromId], [ToId]) VALUES (3, 1, 11, 15)
SET IDENTITY_INSERT [dbo].[Reservations] OFF

SET IDENTITY_INSERT [dbo].[PlaceReservations] ON 
INSERT [dbo].[PlaceReservations] ([PlaceReservationId], [ReservationId], [PlaceId], [TicketTypeId], [TrainCarsId]) VALUES (1, 1, 20, 1, 6)
INSERT [dbo].[PlaceReservations] ([PlaceReservationId], [ReservationId], [PlaceId], [TicketTypeId], [TrainCarsId]) VALUES (2, 1, 2, 2, 7)

INSERT [dbo].[PlaceReservations] ([PlaceReservationId], [ReservationId], [PlaceId], [TicketTypeId], [TrainCarsId]) VALUES (3, 2, 1, 1, 7)

INSERT [dbo].[PlaceReservations] ([PlaceReservationId], [ReservationId], [PlaceId], [TicketTypeId], [TrainCarsId]) VALUES (4, 3, 11, 1, 8)
SET IDENTITY_INSERT [dbo].[PlaceReservations] OFF