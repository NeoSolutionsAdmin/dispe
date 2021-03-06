USE [SistemaDis[pensario]
GO
/****** Object:  Table [dbo].[AntecedentesPatologicosPersonales]    Script Date: 11/19/2017 16:48:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AntecedentesPatologicosPersonales](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [bigint] NOT NULL,
	[Patologia] [varchar](255) NOT NULL,
 CONSTRAINT [PK_AntecedentesPatologicosPersonales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AntecedentesPatologicosPersonales] ON

SET IDENTITY_INSERT [dbo].[AntecedentesPatologicosPersonales] OFF
/****** Object:  Table [dbo].[AntecedentesPatologicosFamiliares]    Script Date: 11/19/2017 16:48:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AntecedentesPatologicosFamiliares](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [bigint] NOT NULL,
	[Patologia] [varchar](255) NOT NULL,
 CONSTRAINT [PK_AntecedentesPatologicosFamiliares] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AntecedentesPatologicosFamiliares] ON

SET IDENTITY_INSERT [dbo].[AntecedentesPatologicosFamiliares] OFF
/****** Object:  Table [dbo].[AntecedentesCirugias]    Script Date: 11/19/2017 16:48:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AntecedentesCirugias](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [bigint] NOT NULL,
	[Cirugia] [varchar](255) NOT NULL,
 CONSTRAINT [PK_AntecedentesCirugias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AntecedentesCirugias] ON

SET IDENTITY_INSERT [dbo].[AntecedentesCirugias] OFF
/****** Object:  Table [dbo].[AntecedentesAlergias]    Script Date: 11/19/2017 16:48:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AntecedentesAlergias](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [bigint] NOT NULL,
	[Alergia] [varchar](255) NOT NULL,
 CONSTRAINT [PK_AntecedentesAlergias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AntecedentesAlergias] ON

SET IDENTITY_INSERT [dbo].[AntecedentesAlergias] OFF
/****** Object:  Table [dbo].[CIE10]    Script Date: 11/19/2017 16:48:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CIE10](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Codigo] [text] NOT NULL,
	[Etiqueta] [text] NOT NULL,
	[Counter] [bigint] NOT NULL,
 CONSTRAINT [PK_CIE10] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CIE10] ON

GO
print 'Processed 100 total records'

GO
print 'Processed 200 total records'

SET IDENTITY_INSERT [dbo].[CIE10] OFF
/****** Object:  Table [dbo].[Diagnosticos]    Script Date: 11/19/2017 16:48:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Diagnosticos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [bigint] NOT NULL,
	[IdUser] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[HUID] [varchar](200) NOT NULL,
	[Diagnostico] [text] NOT NULL,
 CONSTRAINT [PK_Diagnosticos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Diagnosticos] ON

SET IDENTITY_INSERT [dbo].[Diagnosticos] OFF
/****** Object:  Table [dbo].[Pacientes]    Script Date: 11/19/2017 16:48:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pacientes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[GUID] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[NroDocumento] [varchar](9) NOT NULL,
	[Domicilio] [varchar](255) NOT NULL,
	[Localidad] [varchar](255) NOT NULL,
	[Telefono] [varchar](15) NOT NULL,
	[IdObraSocial] [bigint] NOT NULL,
	[NroObraSocial] [varchar](255) NOT NULL,
	[Sexo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Pacientes] ON
SET IDENTITY_INSERT [dbo].[Pacientes] OFF
/****** Object:  Table [dbo].[ObrasSociales]    Script Date: 11/19/2017 16:48:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ObrasSociales](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
 CONSTRAINT [PK_ObrasSociales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ObrasSociales] ON
INSERT [dbo].[ObrasSociales] ([Id], [Nombre]) VALUES (1, N'OsDePrueba')
SET IDENTITY_INSERT [dbo].[ObrasSociales] OFF
/****** Object:  Table [dbo].[MedicacionHabitual]    Script Date: 11/19/2017 16:48:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MedicacionHabitual](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [bigint] NOT NULL,
	[Medicacion] [varchar](255) NOT NULL,
 CONSTRAINT [PK_MedicacionHabitual] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[MedicacionHabitual] ON

SET IDENTITY_INSERT [dbo].[MedicacionHabitual] OFF
/****** Object:  Table [dbo].[Turnos]    Script Date: 11/19/2017 16:48:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Turnos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[PacienteId] [bigint] NOT NULL,
	[HoraRecepcion] [datetime] NOT NULL,
	[HoraComienzoConsulta] [datetime] NOT NULL,
	[HoraFinalConsulta] [datetime] NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[IdDerivado] [bigint] NOT NULL,
	[Indicaciones] [text] NOT NULL,
	[DiagnosticoFinal] [text] NULL,
	[CIE10] [bigint] NULL,
	[ControlEmbarazo] [bit] NULL,
 CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Turnos] ON

SET IDENTITY_INSERT [dbo].[Turnos] OFF
/****** Object:  StoredProcedure [dbo].[Update_Paciente]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Paciente](
@Id bigint,
@Apellido varchar(50),
@Nombre varchar(50),
@FechaNacimiento varchar(50),
@NroDocumento varchar(9),
@Domicilio varchar(255),
@Localidad varchar(255),
@Telefono varchar(15),
@IdObraSocial bigint,
@NroObraSocial varchar(255),
@Sexo varchar(50)

) 
as
begin
Update Pacientes set 
Apellido=@Apellido, 
Nombre=@Nombre,
FechaNacimiento=convert(date,@FechaNacimiento,120),
NroDocumento = @NroDocumento,
Domicilio = @Domicilio,
Localidad = @Localidad,
Telefono = @Telefono,
IdObraSocial = @IdObraSocial,
NroObraSocial = @NroObraSocial,
Sexo = @Sexo
where
Id=@Id
end
GO
/****** Object:  StoredProcedure [dbo].[Update_Diagnostico_In_Turno]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Update_Diagnostico_In_Turno](@IdTurno bigint, @Diagnostico text,@CIE10 bigint, @ControlEmbarazo bit)
as
begin
update Turnos set DiagnosticoFinal=@Diagnostico, CIE10=@CIE10, ControlEmbarazo=@ControlEmbarazo where Id=@IdTurno
end
GO
/****** Object:  StoredProcedure [dbo].[Select_Turnos_By_Period]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Select_Turnos_By_Period](@IdUser bigint, @Start varchar(50), @End varchar(50), @Estado varchar(50))
as
begin
select * from Turnos where UserId=@IdUser and Estado = @Estado and HoraFinalConsulta between @Start and @End
end
GO
/****** Object:  StoredProcedure [dbo].[Select_TurnoById]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Select_TurnoById](@IdTurno bigint)
as
begin
select * from Turnos where Id=@IdTurno
end
GO
/****** Object:  StoredProcedure [dbo].[Select_PacienteByID]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Select_PacienteByID](@IdPaciente bigint)
as
begin
select * from Pacientes where Id=@IdPaciente
end
GO
/****** Object:  StoredProcedure [dbo].[Select_Paciente_By_GUI]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Select_Paciente_By_GUI](@GUI varchar(255))
as
begin
select * from Pacientes where [GUID]=@GUI
end
GO
/****** Object:  StoredProcedure [dbo].[SELECT_PACIENTE_BY_DNI]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SELECT_PACIENTE_BY_DNI] (@DNI varchar(255))
as
begin
select * from Pacientes where NroDocumento=@DNI
end
GO
/****** Object:  StoredProcedure [dbo].[Select_ObraSocial_By_ID]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Select_ObraSocial_By_ID](@IdObraSocial bigint)
as
begin
select * from ObrasSociales where Id=@IdObraSocial
end
GO
/****** Object:  StoredProcedure [dbo].[Select_MedicacionHabitual]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Select_MedicacionHabitual](@IdPaciente bigint)
as
begin
Select * from MedicacionHabitual where IdPaciente=@IdPaciente
end
GO
/****** Object:  StoredProcedure [dbo].[Select_Diagnosticos_By_IdPaciente]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Select_Diagnosticos_By_IdPaciente](@IdPaciente bigint)
as
begin
select * from Diagnosticos where IdPaciente=@IdPaciente
end
GO
/****** Object:  StoredProcedure [dbo].[Select_CirugiasByIdPaciente]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Select_CirugiasByIdPaciente](@IdPaciente bigint)
as
begin
select * from AntecedentesCirugias where IdPaciente=@IdPaciente
end
GO
/****** Object:  StoredProcedure [dbo].[Select_APP]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Select_APP](@IdPaciente bigint)
as
begin
Select * from AntecedentesPatologicosPersonales where IdPaciente=@IdPaciente
end
GO
/****** Object:  StoredProcedure [dbo].[Select_APF]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Select_APF](@IdPaciente bigint)
as
begin
Select * from AntecedentesPatologicosFamiliares where IdPaciente=@IdPaciente
end
GO
/****** Object:  StoredProcedure [dbo].[Select_AllTurnosByIdUser]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Select_AllTurnosByIdUser](@IdUser bigint)
as
begin
select * from Turnos where UserId=@Iduser
end
GO
/****** Object:  StoredProcedure [dbo].[Select_AlergiasByIdPaciente]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Select_AlergiasByIdPaciente](@idPaciente bigint)
as
begin
select * from AntecedentesAlergias where IdPaciente=@idPaciente
end
GO
/****** Object:  StoredProcedure [dbo].[Search_ObrasSocial]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Search_ObrasSocial](@stringSearch varchar(255))
as
begin
select *  from ObrasSociales where Nombre like '%' + @stringSearch + '%' order by Nombre ASC
end
GO
/****** Object:  StoredProcedure [dbo].[Insertar_Medicacion]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Insertar_Medicacion](@IdPaciente bigint, @Medicacion varchar(255))
as
begin
insert into MedicacionHabitual(IdPaciente,Medicacion) values (@IdPaciente,@Medicacion)
end
GO
/****** Object:  StoredProcedure [dbo].[Insertar_Cirugia]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Insertar_Cirugia](@IdPaciente bigint, @Cirugia varchar(255))
as
begin
insert into AntecedentesCirugias(IdPaciente,Cirugia) values (@IdPaciente,@Cirugia)
end
GO
/****** Object:  StoredProcedure [dbo].[Insert_Turno]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insert_Turno](
@IdUser bigint, 
@PacienteID bigint, 
@HoraRecepcion varchar(50),
@HoraComienzoConsulta varchar(50),
@HoraFinalConsulta varchar(50))
as
begin
	Insert into Turnos(
	UserId,
	PacienteId,
	HoraRecepcion,
	HoraComienzoConsulta,
	HoraFinalConsulta,
	Estado,
	IdDerivado,
	Indicaciones
	) values (
	@IdUser,
	@PacienteID,
	convert(datetime,@HoraRecepcion,120),
	convert(datetime,@HoraComienzoConsulta,120),
	convert(datetime,@HoraFinalConsulta,120),
	'Espera',
	0,'Sin Indicaciones')
end
GO
/****** Object:  StoredProcedure [dbo].[Insert_Paciente]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insert_Paciente](
@Apellido varchar(50),
@Nombre varchar(50),
@FechaNacimiento varchar(50),
@NroDocumento varchar(9),
@Domicilio varchar(255),
@Localidad varchar(255),
@Telefono varchar(15),
@IdObraSocial bigint,
@NroObraSocial varchar(255),
@Sexo varchar(50))
as
BEGIN
INSERT INTO [Pacientes]
           (
           [Apellido]
           ,[Nombre]
           ,[FechaNacimiento]
           ,[NroDocumento]
           ,Domicilio
           ,Localidad
           ,[Telefono]
           ,[IdObraSocial]
           ,NroObraSocial
           ,Sexo
           )
     VALUES
           (
           @Apellido,
           @Nombre,
           convert(date,@FechaNacimiento,120),
           @NroDocumento,
           @Domicilio,
           @Localidad,
           @Telefono,
           @IdObraSocial,
           @NroObraSocial,
           @Sexo
           
           )
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_DIAGNOSTICO]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_DIAGNOSTICO] (
@idPaciente bigint, 
@IdUser bigint,
@Fecha varchar(15),
@Diagnostico text)
as
begin
insert into Diagnosticos(IdPaciente,IdUser,Fecha,Diagnostico) values (@idPaciente,@IdUser,convert(datetime,@Fecha,120),@Diagnostico)
select  top 1 * from  Diagnosticos  order by Id DESC
end
GO
/****** Object:  StoredProcedure [dbo].[Insert_APP]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Insert_APP](@IdPaciente bigint, @Patologia varchar(255))
as
begin
insert into AntecedentesPatologicosPersonales(IdPaciente,Patologia) values (@IdPaciente,@Patologia)
end
GO
/****** Object:  StoredProcedure [dbo].[Insert_APF]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Insert_APF](@IdPaciente bigint, @Patologia varchar(255))
as
begin
insert into AntecedentesPatologicosFamiliares(IdPaciente,Patologia) values (@IdPaciente,@Patologia)
end
GO
/****** Object:  StoredProcedure [dbo].[Insert_Alergia]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insert_Alergia](@IdPaciente bigint, @Alergia varchar(255))
as
begin
insert into AntecedentesAlergias(IdPaciente,Alergia) values (@IdPaciente,@Alergia)
end
GO
/****** Object:  StoredProcedure [dbo].[Get_CIE10_by_Id]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_CIE10_by_Id](@Id bigint)
as
begin
select * from CIE10 where Id=@Id
end
GO
/****** Object:  StoredProcedure [dbo].[FinalizarConsulta]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[FinalizarConsulta](@IdConsulta bigint, @Hora varchar(50))
as
begin
update Turnos set HoraFinalConsulta=convert(datetime,@Hora,120),Estado='Finalizado' where Id=@IdConsulta
end
GO
/****** Object:  StoredProcedure [dbo].[DerivarConsulta]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[DerivarConsulta](@IdConsulta bigint, @IdDerivado bigint, @Indicaciones text)
as
begin
update Turnos set IdDerivado=@IdDerivado, Estado='Derivado', Indicaciones=@Indicaciones where Id=@IdConsulta
end
GO
/****** Object:  StoredProcedure [dbo].[ComenzarConsulta]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ComenzarConsulta](@IdConsulta bigint, @Hora varchar(50))
as
begin
update Turnos set HoraComienzoConsulta=Convert(datetime,@Hora,120), Estado='Progreso' where Id=@IdConsulta
end
GO
/****** Object:  StoredProcedure [dbo].[CancelarConsulta]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[CancelarConsulta](@IdConsulta bigint)
as
begin
update Turnos set Estado='Cancelado' where Id=@IdConsulta
end
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Paciente_By_Apellido]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Buscar_Paciente_By_Apellido](@CadenaBusqueda varchar(100))
as
begin
select *  from Pacientes where Apellido like '%' + @CadenaBusqueda + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[Borrar_Medicacion]    Script Date: 11/19/2017 16:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Borrar_Medicacion](@Id bigint)
as
begin
delete MedicacionHabitual where Id=@Id
end
GO
/****** Object:  Default [DF_CIE10_Counter]    Script Date: 11/19/2017 16:48:33 ******/
ALTER TABLE [dbo].[CIE10] ADD  CONSTRAINT [DF_CIE10_Counter]  DEFAULT ((0)) FOR [Counter]
GO
/****** Object:  Default [DF_Diagnosticos_HUID]    Script Date: 11/19/2017 16:48:33 ******/
ALTER TABLE [dbo].[Diagnosticos] ADD  CONSTRAINT [DF_Diagnosticos_HUID]  DEFAULT (newid()) FOR [HUID]
GO
/****** Object:  Default [DF_Table_1_]    Script Date: 11/19/2017 16:48:33 ******/
ALTER TABLE [dbo].[Pacientes] ADD  CONSTRAINT [DF_Table_1_]  DEFAULT (newid()) FOR [GUID]
GO
/****** Object:  Default [DF_Turnos_CIE10]    Script Date: 11/19/2017 16:48:33 ******/
ALTER TABLE [dbo].[Turnos] ADD  CONSTRAINT [DF_Turnos_CIE10]  DEFAULT ((0)) FOR [CIE10]
GO
