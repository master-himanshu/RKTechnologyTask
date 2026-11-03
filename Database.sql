USE [DbRKTechnology]
GO
/****** Object:  Table [dbo].[City]    Script Date: 13-04-2026 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](100) NOT NULL,
	[StateId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 13-04-2026 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeTable]    Script Date: 13-04-2026 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeTable](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[MobileNumber] [nvarchar](15) NULL,
	[DOB] [datetime] NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[CityId] [int] NULL,
	[Hobbies] [nvarchar](max) NULL,
	[Gendar] [nvarchar](10) NULL,
	[Isdelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 13-04-2026 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](100) NOT NULL,
	[CountryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON 
GO
INSERT [dbo].[City] ([CityId], [CityName], [StateId]) VALUES (1, N'Pune', 1)
GO
INSERT [dbo].[City] ([CityId], [CityName], [StateId]) VALUES (2, N'Mumbai', 1)
GO
INSERT [dbo].[City] ([CityId], [CityName], [StateId]) VALUES (3, N'Ahmedabad', 2)
GO
INSERT [dbo].[City] ([CityId], [CityName], [StateId]) VALUES (4, N'Surat', 2)
GO
INSERT [dbo].[City] ([CityId], [CityName], [StateId]) VALUES (5, N'Los Angeles', 3)
GO
INSERT [dbo].[City] ([CityId], [CityName], [StateId]) VALUES (6, N'San Francisco', 3)
GO
INSERT [dbo].[City] ([CityId], [CityName], [StateId]) VALUES (7, N'Houston', 4)
GO
INSERT [dbo].[City] ([CityId], [CityName], [StateId]) VALUES (8, N'Dallas', 4)
GO
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 
GO
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (1, N'India')
GO
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (2, N'USA')
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeTable] ON 
GO
INSERT [dbo].[EmployeeTable] ([EmployeeId], [EmployeeName], [Email], [MobileNumber], [DOB], [CountryId], [StateId], [CityId], [Hobbies], [Gendar], [Isdelete]) VALUES (1, N'Mayur Badgujar', N'mayur@gmail.com', N'9365693656', CAST(N'2026-04-13T00:00:00.000' AS DateTime), 1, 1, 2, N'Cricket,Music', N'Male', 1)
GO
INSERT [dbo].[EmployeeTable] ([EmployeeId], [EmployeeName], [Email], [MobileNumber], [DOB], [CountryId], [StateId], [CityId], [Hobbies], [Gendar], [Isdelete]) VALUES (2, N'Rakesh', N'rakesh@gmail.com', N'7893645852', CAST(N'2026-04-13T00:00:00.000' AS DateTime), 1, 2, 4, N'Cricket,Reading,Traveling', N'Male', 1)
GO
INSERT [dbo].[EmployeeTable] ([EmployeeId], [EmployeeName], [Email], [MobileNumber], [DOB], [CountryId], [StateId], [CityId], [Hobbies], [Gendar], [Isdelete]) VALUES (3, N'Vishal', N'vishu@gmail.com', N'8525639635', CAST(N'2026-04-13T00:00:00.000' AS DateTime), 1, 1, 1, N'Cricket,Reading,Traveling', N'Male', 1)
GO
SET IDENTITY_INSERT [dbo].[EmployeeTable] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 
GO
INSERT [dbo].[State] ([StateId], [StateName], [CountryId]) VALUES (1, N'Maharashtra', 1)
GO
INSERT [dbo].[State] ([StateId], [StateName], [CountryId]) VALUES (2, N'Gujarat', 1)
GO
INSERT [dbo].[State] ([StateId], [StateName], [CountryId]) VALUES (3, N'California', 2)
GO
INSERT [dbo].[State] ([StateId], [StateName], [CountryId]) VALUES (4, N'Texas', 2)
GO
SET IDENTITY_INSERT [dbo].[State] OFF
GO
/****** Object:  StoredProcedure [dbo].[SpEmployee]    Script Date: 13-04-2026 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[SpEmployee]
@EmployeeId int ,
@EmployeeName nvarchar(100),
@Email nvarchar(100),
@MobileNumber nvarchar(15),
@DOB datetime ,
@CountryId int ,
@StateId int ,
@CityId int ,
@Hobbies nvarchar(max),
@Gendar nvarchar(10),

@flag nvarchar(1)
  as
     Begin 
     If(@flag='I')
     Begin 
       Insert Into EmployeeTable (EmployeeName,Email,MobileNumber,DOB,CountryId,StateId,CityId,Hobbies,Gendar,Isdelete)
       Values(@EmployeeName,@Email,@MobileNumber,@DOB,@CountryId,@StateId,@CityId,@Hobbies,@Gendar,1)
       End 
 If(@flag='U')
   begin 
     Update EmployeeTable set 
     EmployeeName=@EmployeeName,Email=@Email,MobileNumber=@MobileNumber,
     DOB=@DOB,CountryId=@CountryId,StateId=@StateId,CityId=@CityId,Hobbies=@Hobbies,Gendar=@Gendar,Isdelete=1
     Where EmployeeId=@EmployeeId
     End 
     End
GO
