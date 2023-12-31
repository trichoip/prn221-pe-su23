create database [MovieManagementDB]
go


USE [MovieManagementDB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 6/24/2023 11:25:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [nchar](10) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[AccoutRole] [int] NOT NULL,
	[Status] [nvarchar](20) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 6/24/2023 11:25:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[MovieID] [int] NOT NULL,
	[MovieName] [nvarchar](50) NOT NULL,
	[ActorName] [nvarchar](100) NOT NULL,
	[Duration] [int] NOT NULL,
	[DirectorName] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 6/24/2023 11:25:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[TicketID] [nvarchar](50) NOT NULL,
	[Amount] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Slot] [nchar](10) NOT NULL,
	[MovieID] [int] NOT NULL,
	[Seat] [nvarchar](5) NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[AccountID] [nchar](10) NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[TicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([AccountID], [Email], [Password], [AccoutRole], [Status]) VALUES (N'admin     ', N'admin@gmail.com', N'admin', 0, N'active')
INSERT [dbo].[Account] ([AccountID], [Email], [Password], [AccoutRole], [Status]) VALUES (N'customer  ', N'customer@gmail.com', N'customer', 2, N'active')
INSERT [dbo].[Account] ([AccountID], [Email], [Password], [AccoutRole], [Status]) VALUES (N'customer01', N'customer01@gmail.com', N'customer01', 2, N'active')
INSERT [dbo].[Account] ([AccountID], [Email], [Password], [AccoutRole], [Status]) VALUES (N'customer02', N'customer02@gmail.com', N'customer02', 2, N'active')
INSERT [dbo].[Account] ([AccountID], [Email], [Password], [AccoutRole], [Status]) VALUES (N'customer03', N'customer03@gmail.com', N'customer03', 2, N'active')
INSERT [dbo].[Account] ([AccountID], [Email], [Password], [AccoutRole], [Status]) VALUES (N'manager   ', N'manager@gmail.com', N'manager', 1, N'active')
GO
INSERT [dbo].[Movie] ([MovieID], [MovieName], [ActorName], [Duration], [DirectorName], [CreatedAt], [UpdatedAt]) VALUES (1, N'Titanic', N'	
Leonardo DiCaprio,Kate Winslet', 195, N'James Cameron', CAST(N'2023-06-23T00:00:00.000' AS DateTime), CAST(N'2023-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Movie] ([MovieID], [MovieName], [ActorName], [Duration], [DirectorName], [CreatedAt], [UpdatedAt]) VALUES (2, N'Tom and Jerry
', N'Tom, Jerry', 120, N'Tim Story', CAST(N'2023-06-25T00:00:00.000' AS DateTime), CAST(N'2023-06-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Movie] ([MovieID], [MovieName], [ActorName], [Duration], [DirectorName], [CreatedAt], [UpdatedAt]) VALUES (3, N'THE FLASH', N'Michael Keaton, Ben Affleck, Ezra', 144, N'Andy Muschietti', CAST(N'2023-06-26T00:00:00.000' AS DateTime), CAST(N'2023-06-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Movie] ([MovieID], [MovieName], [ActorName], [Duration], [DirectorName], [CreatedAt], [UpdatedAt]) VALUES (4, N'ELEMENTAL', N'Mamoudou Athie, Leah Lewis, Wendi McLendon-Covey', 109, N'Peter Sohn', CAST(N'2023-06-27T00:00:00.000' AS DateTime), CAST(N'2023-06-27T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Ticket] ([TicketID], [Amount], [StartTime], [EndTime], [Slot], [MovieID], [Seat], [Status], [AccountID]) VALUES (N'1', 85000, CAST(N'2023-06-27T15:00:00.000' AS DateTime), CAST(N'2023-06-27T17:00:00.000' AS DateTime), N'1         ', 4, N'2', N'active', N'customer01')
INSERT [dbo].[Ticket] ([TicketID], [Amount], [StartTime], [EndTime], [Slot], [MovieID], [Seat], [Status], [AccountID]) VALUES (N'2', 85000, CAST(N'2023-06-27T15:00:00.000' AS DateTime), CAST(N'2023-06-27T17:00:00.000' AS DateTime), N'2         ', 4, N'1', N'active', N'customer02')
INSERT [dbo].[Ticket] ([TicketID], [Amount], [StartTime], [EndTime], [Slot], [MovieID], [Seat], [Status], [AccountID]) VALUES (N'3', 90000, CAST(N'2023-06-27T09:00:00.000' AS DateTime), CAST(N'2023-06-27T12:00:00.000' AS DateTime), N'3         ', 3, N'1', N'active', N'customer  ')
INSERT [dbo].[Ticket] ([TicketID], [Amount], [StartTime], [EndTime], [Slot], [MovieID], [Seat], [Status], [AccountID]) VALUES (N'4', 90000, CAST(N'2023-06-27T09:00:00.000' AS DateTime), CAST(N'2023-06-27T12:00:00.000' AS DateTime), N'3         ', 3, N'2', N'active', N'customer  ')
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Account]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Movie] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movie] ([MovieID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Movie]
GO
