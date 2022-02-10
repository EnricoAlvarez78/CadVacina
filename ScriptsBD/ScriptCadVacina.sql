USE [master]
GO
/****** Object:  Database [CadVacina]    Script Date: 09/02/2022 21:40:20 ******/
CREATE DATABASE [CadVacina]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CadVacina', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CadVacina.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CadVacina_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CadVacina_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CadVacina] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CadVacina].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CadVacina] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CadVacina] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CadVacina] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CadVacina] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CadVacina] SET ARITHABORT OFF 
GO
ALTER DATABASE [CadVacina] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CadVacina] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CadVacina] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CadVacina] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CadVacina] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CadVacina] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CadVacina] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CadVacina] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CadVacina] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CadVacina] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CadVacina] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CadVacina] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CadVacina] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CadVacina] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CadVacina] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CadVacina] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CadVacina] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CadVacina] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CadVacina] SET  MULTI_USER 
GO
ALTER DATABASE [CadVacina] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CadVacina] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CadVacina] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CadVacina] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CadVacina] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CadVacina]
GO
/****** Object:  Table [dbo].[Agenda]    Script Date: 09/02/2022 21:40:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agenda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Manha] [bit] NOT NULL,
	[Tarde] [bit] NOT NULL,
	[QuantidadeManha] [int] NULL,
	[QuantidadeTarde] [int] NULL,
	[IdLote] [int] NOT NULL,
	[IdPosto] [int] NOT NULL,
 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Agendamento]    Script Date: 09/02/2022 21:40:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agendamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](256) NOT NULL,
	[Cpf] [varchar](14) NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Telefone] [varchar](11) NOT NULL,
	[Mae] [varchar](256) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Turno] [char](1) NOT NULL,
	[IdEndereco] [int] NOT NULL,
	[IdGrupo] [int] NOT NULL,
	[IdPosto] [int] NOT NULL,
 CONSTRAINT [PK_Agendamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Endereco]    Script Date: 09/02/2022 21:40:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Endereco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rua] [varchar](256) NOT NULL,
	[Numero] [varchar](10) NULL,
	[Bairro] [varchar](100) NOT NULL,
	[Cep] [varchar](10) NULL,
	[Cidade] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 09/02/2022 21:40:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[IdadeMinima] [int] NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lote]    Script Date: 09/02/2022 21:40:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPosto] [int] NOT NULL,
	[Numero] [varchar](20) NOT NULL,
	[DataRecebimento] [datetime] NOT NULL,
	[Fabricante] [varchar](100) NOT NULL,
	[DiasSegundaDose] [int] NOT NULL,
	[QuantidadeDoses] [int] NOT NULL,
	[DosesReservadas] [int] NOT NULL,
	[DosesAplicadas] [int] NOT NULL,
 CONSTRAINT [PK_Lote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 09/02/2022 21:40:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](45) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posto]    Script Date: 09/02/2022 21:40:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[IdEndereco] [int] NOT NULL,
 CONSTRAINT [PK_Posto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 09/02/2022 21:40:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](256) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
	[Email] [varchar](120) NOT NULL,
	[IdPerfil] [int] NOT NULL,
	[IdPosto] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Agenda] ON 
GO
INSERT [dbo].[Agenda] ([Id], [Data], [Manha], [Tarde], [QuantidadeManha], [QuantidadeTarde], [IdLote], [IdPosto]) VALUES (9, CAST(N'2021-11-10T00:00:00.000' AS DateTime), 1, 1, 11, 12, 1, 1)
GO
INSERT [dbo].[Agenda] ([Id], [Data], [Manha], [Tarde], [QuantidadeManha], [QuantidadeTarde], [IdLote], [IdPosto]) VALUES (10, CAST(N'2021-11-11T00:00:00.000' AS DateTime), 1, 0, 52, 0, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Agenda] OFF
GO
SET IDENTITY_INSERT [dbo].[Agendamento] ON 
GO
INSERT [dbo].[Agendamento] ([Id], [Nome], [Cpf], [DataNascimento], [Telefone], [Mae], [Data], [Turno], [IdEndereco], [IdGrupo], [IdPosto]) VALUES (7, N'noem teste', N'12131313213', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'24789451236', N'mãe teste', CAST(N'2021-11-10T00:00:00.000' AS DateTime), N'T', 18, 6, 1)
GO
INSERT [dbo].[Agendamento] ([Id], [Nome], [Cpf], [DataNascimento], [Telefone], [Mae], [Data], [Turno], [IdEndereco], [IdGrupo], [IdPosto]) VALUES (8, N'noem teste', N'12345679812', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'24789451237', N'mãe teste', CAST(N'2021-11-10T00:00:00.000' AS DateTime), N'M', 19, 6, 1)
GO
SET IDENTITY_INSERT [dbo].[Agendamento] OFF
GO
SET IDENTITY_INSERT [dbo].[Endereco] ON 
GO
INSERT [dbo].[Endereco] ([Id], [Rua], [Numero], [Bairro], [Cep], [Cidade]) VALUES (1, N'rua posto', N'num posto', N'bairro posto', N'12456789', N'cidade posto')
GO
INSERT [dbo].[Endereco] ([Id], [Rua], [Numero], [Bairro], [Cep], [Cidade]) VALUES (2, N'rua posto 2', N'22', N'bairro posto 2', N'22222222', N'cidade posto 2')
GO
INSERT [dbo].[Endereco] ([Id], [Rua], [Numero], [Bairro], [Cep], [Cidade]) VALUES (9, N'rua teste3', N'123', N'bairro mae2', N'12456789', N'cidade teset2')
GO
INSERT [dbo].[Endereco] ([Id], [Rua], [Numero], [Bairro], [Cep], [Cidade]) VALUES (10, N'rua teste', N'123', N'bairro mae', N'12456789', N'cideade teset')
GO
INSERT [dbo].[Endereco] ([Id], [Rua], [Numero], [Bairro], [Cep], [Cidade]) VALUES (11, N'rua teste', N'num teste', N'bairro teste', N'12312313', N'cidade teste')
GO
INSERT [dbo].[Endereco] ([Id], [Rua], [Numero], [Bairro], [Cep], [Cidade]) VALUES (12, N'rua teste', N'num teste', N'bairro teste', N'12312313', N'cidade teste')
GO
INSERT [dbo].[Endereco] ([Id], [Rua], [Numero], [Bairro], [Cep], [Cidade]) VALUES (13, N'rua teste', N'num teste', N'bairro teste', N'12312313', N'cidade teste')
GO
INSERT [dbo].[Endereco] ([Id], [Rua], [Numero], [Bairro], [Cep], [Cidade]) VALUES (14, N'rua teste', N'num teste', N'bairro teste', N'12312313', N'cidade teste')
GO
INSERT [dbo].[Endereco] ([Id], [Rua], [Numero], [Bairro], [Cep], [Cidade]) VALUES (15, N'rua teste', N'num teste', N'bairro teste', N'12312313', N'cidade teste')
GO
INSERT [dbo].[Endereco] ([Id], [Rua], [Numero], [Bairro], [Cep], [Cidade]) VALUES (16, N'rua teste', N'num teste', N'bairro teste', N'12312313', N'cidade teste')
GO
INSERT [dbo].[Endereco] ([Id], [Rua], [Numero], [Bairro], [Cep], [Cidade]) VALUES (17, N'rua teste', N'num teste', N'bairro teste', N'12312313', N'cidade teste')
GO
INSERT [dbo].[Endereco] ([Id], [Rua], [Numero], [Bairro], [Cep], [Cidade]) VALUES (18, N'rua teste', N'num teste', N'bairro teste', N'12312313', N'cidade teste')
GO
INSERT [dbo].[Endereco] ([Id], [Rua], [Numero], [Bairro], [Cep], [Cidade]) VALUES (19, N'rua teste', N'', N'bairro teste', N'12312313', N'cidade teste')
GO
SET IDENTITY_INSERT [dbo].[Endereco] OFF
GO
SET IDENTITY_INSERT [dbo].[Grupo] ON 
GO
INSERT [dbo].[Grupo] ([Id], [Nome], [IdadeMinima], [Ativo]) VALUES (1, N'Prioridade 0', 90, 1)
GO
INSERT [dbo].[Grupo] ([Id], [Nome], [IdadeMinima], [Ativo]) VALUES (2, N'Prioridade 1', 80, 1)
GO
INSERT [dbo].[Grupo] ([Id], [Nome], [IdadeMinima], [Ativo]) VALUES (3, N'Prioridade 2', 70, 0)
GO
INSERT [dbo].[Grupo] ([Id], [Nome], [IdadeMinima], [Ativo]) VALUES (4, N'Prioridade 3', 60, 0)
GO
INSERT [dbo].[Grupo] ([Id], [Nome], [IdadeMinima], [Ativo]) VALUES (5, N'Prioridade 4', 50, 1)
GO
INSERT [dbo].[Grupo] ([Id], [Nome], [IdadeMinima], [Ativo]) VALUES (6, N'Todos', 15, 1)
GO
SET IDENTITY_INSERT [dbo].[Grupo] OFF
GO
SET IDENTITY_INSERT [dbo].[Lote] ON 
GO
INSERT [dbo].[Lote] ([Id], [IdPosto], [Numero], [DataRecebimento], [Fabricante], [DiasSegundaDose], [QuantidadeDoses], [DosesReservadas], [DosesAplicadas]) VALUES (1, 1, N'11', CAST(N'2021-11-01T00:00:00.000' AS DateTime), N'Lote 1', 30, 2, -4, 4)
GO
INSERT [dbo].[Lote] ([Id], [IdPosto], [Numero], [DataRecebimento], [Fabricante], [DiasSegundaDose], [QuantidadeDoses], [DosesReservadas], [DosesAplicadas]) VALUES (2, 1, N'123', CAST(N'2021-09-22T00:00:00.000' AS DateTime), N'bb', 99, 2, 0, 0)
GO
INSERT [dbo].[Lote] ([Id], [IdPosto], [Numero], [DataRecebimento], [Fabricante], [DiasSegundaDose], [QuantidadeDoses], [DosesReservadas], [DosesAplicadas]) VALUES (3, 2, N'222', CAST(N'2021-10-01T00:00:00.000' AS DateTime), N'teste', 100, 2, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Lote] OFF
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON 
GO
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (2, N'Gerente')
GO
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (3, N'Recepcionista')
GO
SET IDENTITY_INSERT [dbo].[Perfil] OFF
GO
SET IDENTITY_INSERT [dbo].[Posto] ON 
GO
INSERT [dbo].[Posto] ([Id], [Nome], [IdEndereco]) VALUES (1, N'Posto1', 1)
GO
INSERT [dbo].[Posto] ([Id], [Nome], [IdEndereco]) VALUES (2, N'Posto 2', 2)
GO
SET IDENTITY_INSERT [dbo].[Posto] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Senha], [Email], [IdPerfil], [IdPosto]) VALUES (2, N'Admin', N'E10ADC3949BA59ABBE56E057F20F883E', N'admin@teste.com', 1, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Senha], [Email], [IdPerfil], [IdPosto]) VALUES (3, N'Gerente', N'E10ADC3949BA59ABBE56E057F20F883E', N'gerente@teste.com', 2, 1)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Senha], [Email], [IdPerfil], [IdPosto]) VALUES (4, N'Recepcionista', N'E10ADC3949BA59ABBE56E057F20F883E', N'recep@teste.com', 3, 2)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Agenda] ADD  CONSTRAINT [DF_Agenda_Manha_Default]  DEFAULT ((0)) FOR [Manha]
GO
ALTER TABLE [dbo].[Agenda] ADD  CONSTRAINT [DF_Agenda_Tarde_Default]  DEFAULT ((0)) FOR [Tarde]
GO
ALTER TABLE [dbo].[Agendamento] ADD  DEFAULT (NULL) FOR [Cpf]
GO
ALTER TABLE [dbo].[Grupo] ADD  CONSTRAINT [DF_Grupo_Ativo_Default]  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Agenda]  WITH CHECK ADD  CONSTRAINT [FK_Agenda_Lote] FOREIGN KEY([IdLote])
REFERENCES [dbo].[Lote] ([Id])
GO
ALTER TABLE [dbo].[Agenda] CHECK CONSTRAINT [FK_Agenda_Lote]
GO
ALTER TABLE [dbo].[Agenda]  WITH CHECK ADD  CONSTRAINT [FK_Agenda_Posto] FOREIGN KEY([IdPosto])
REFERENCES [dbo].[Posto] ([Id])
GO
ALTER TABLE [dbo].[Agenda] CHECK CONSTRAINT [FK_Agenda_Posto]
GO
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_Endereco] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[Endereco] ([Id])
GO
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_Endereco]
GO
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_Grupo] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupo] ([Id])
GO
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_Grupo]
GO
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_Posto] FOREIGN KEY([IdPosto])
REFERENCES [dbo].[Posto] ([Id])
GO
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_Posto]
GO
ALTER TABLE [dbo].[Lote]  WITH CHECK ADD  CONSTRAINT [FK_Lote_Posto] FOREIGN KEY([IdPosto])
REFERENCES [dbo].[Posto] ([Id])
GO
ALTER TABLE [dbo].[Lote] CHECK CONSTRAINT [FK_Lote_Posto]
GO
ALTER TABLE [dbo].[Posto]  WITH CHECK ADD  CONSTRAINT [FK_Posto_Endereco] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[Endereco] ([Id])
GO
ALTER TABLE [dbo].[Posto] CHECK CONSTRAINT [FK_Posto_Endereco]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Posto] FOREIGN KEY([IdPosto])
REFERENCES [dbo].[Posto] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Posto]
GO
USE [master]
GO
ALTER DATABASE [CadVacina] SET  READ_WRITE 
GO
