USE [registration]
GO

/****** Object:  Table [dbo].[Funcionarios]    Script Date: 27/10/2021 14:24:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Funcionarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](80) NOT NULL,
	[sexo] [varchar](9) NOT NULL,
	[Pis] [char](11) NOT NULL,
	[Cpf] [char](11) NOT NULL,
	[Salario] [varchar](6) NOT NULL,
	[Email] [varchar](256) NULL,
	[DataAdmissao] [nvarchar](20) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


