USE [CariHesapOtomasyonu]
GO
/****** Object:  Table [dbo].[Kategori]    Script Date: 3.12.2019 02:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategori](
	[KategoriID] [int] IDENTITY(1,1) NOT NULL,
	[KategoriAdi] [nvarchar](50) NOT NULL,
	[KategoriAciklama] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[KategoriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 3.12.2019 02:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[KullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [nvarchar](50) NOT NULL,
	[KullaniciSifre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[KullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 3.12.2019 02:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[MusteriID] [int] IDENTITY(1,1) NOT NULL,
	[MusteriAdi] [nvarchar](50) NOT NULL,
	[MüsteriSoyadi] [nvarchar](50) NOT NULL,
	[MüsteriTelefon] [nvarchar](50) NOT NULL,
	[MüsteriAdres] [nvarchar](50) NOT NULL,
	[KullaniciID] [int] NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[MusteriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Satis]    Script Date: 3.12.2019 02:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satis](
	[SatisID] [int] IDENTITY(1,1) NOT NULL,
	[MusteriID] [int] NULL,
	[UrunID] [int] NULL,
	[SatisFiyati] [int] NOT NULL,
 CONSTRAINT [PK_Satis] PRIMARY KEY CLUSTERED 
(
	[SatisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urun]    Script Date: 3.12.2019 02:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urun](
	[UrunID] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [nvarchar](50) NOT NULL,
	[KategoriID] [int] NULL,
	[AlisFiyati] [int] NOT NULL,
	[SatisFiyati] [int] NOT NULL,
	[UrunStok] [int] NULL,
	[UrunAciklama] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Urun] PRIMARY KEY CLUSTERED 
(
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kategori] ON 

INSERT [dbo].[Kategori] ([KategoriID], [KategoriAdi], [KategoriAciklama]) VALUES (1, N'Gıda', N'yenilebilir içilebilir')
INSERT [dbo].[Kategori] ([KategoriID], [KategoriAdi], [KategoriAciklama]) VALUES (2, N'Kırtasiye', N'okul araç gereç')
INSERT [dbo].[Kategori] ([KategoriID], [KategoriAdi], [KategoriAciklama]) VALUES (3, N'beyaz eşya', N'ev araç gereç')
INSERT [dbo].[Kategori] ([KategoriID], [KategoriAdi], [KategoriAciklama]) VALUES (9, N'Beyaz Eşya', N'Küçük ev aletleri')
INSERT [dbo].[Kategori] ([KategoriID], [KategoriAdi], [KategoriAciklama]) VALUES (10, N'Ambalaj', N'Paketleme Yöntemleri')
INSERT [dbo].[Kategori] ([KategoriID], [KategoriAdi], [KategoriAciklama]) VALUES (11, N'Dekorayon', N'Ev Düzenleme')
SET IDENTITY_INSERT [dbo].[Kategori] OFF
SET IDENTITY_INSERT [dbo].[Kullanici] ON 

INSERT [dbo].[Kullanici] ([KullaniciID], [KullaniciAdi], [KullaniciSifre]) VALUES (1, N'admin', N'123456')
INSERT [dbo].[Kullanici] ([KullaniciID], [KullaniciAdi], [KullaniciSifre]) VALUES (2, N'nagihan', N'010101')
INSERT [dbo].[Kullanici] ([KullaniciID], [KullaniciAdi], [KullaniciSifre]) VALUES (3, N'aa', N'000')
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
SET IDENTITY_INSERT [dbo].[Musteri] ON 

INSERT [dbo].[Musteri] ([MusteriID], [MusteriAdi], [MüsteriSoyadi], [MüsteriTelefon], [MüsteriAdres], [KullaniciID]) VALUES (25, N'burcu', N'deniz', N'(535) 695-8688', N'bursa', NULL)
INSERT [dbo].[Musteri] ([MusteriID], [MusteriAdi], [MüsteriSoyadi], [MüsteriTelefon], [MüsteriAdres], [KullaniciID]) VALUES (26, N'Burcu', N'yılmaz', N'(535) 666-6666', N'1606.Sokak', NULL)
INSERT [dbo].[Musteri] ([MusteriID], [MusteriAdi], [MüsteriSoyadi], [MüsteriTelefon], [MüsteriAdres], [KullaniciID]) VALUES (30, N'Nagihan', N'Ballıoğlu', N'Ballıoğlu', N'16606.Sokak', NULL)
INSERT [dbo].[Musteri] ([MusteriID], [MusteriAdi], [MüsteriSoyadi], [MüsteriTelefon], [MüsteriAdres], [KullaniciID]) VALUES (31, N'ahmet', N'kuzu', N'kuzu', N'1652.Sokak', NULL)
INSERT [dbo].[Musteri] ([MusteriID], [MusteriAdi], [MüsteriSoyadi], [MüsteriTelefon], [MüsteriAdres], [KullaniciID]) VALUES (32, N'Fatma', N'Kaplan', N'Kaplan', N'1520.Sokak', NULL)
INSERT [dbo].[Musteri] ([MusteriID], [MusteriAdi], [MüsteriSoyadi], [MüsteriTelefon], [MüsteriAdres], [KullaniciID]) VALUES (33, N'Osman', N'Koç', N'Koç', N'1607.Sokak', NULL)
INSERT [dbo].[Musteri] ([MusteriID], [MusteriAdi], [MüsteriSoyadi], [MüsteriTelefon], [MüsteriAdres], [KullaniciID]) VALUES (38, N'Kerem', N'Kırca', N'Kırca', N'1745.Sokak', NULL)
INSERT [dbo].[Musteri] ([MusteriID], [MusteriAdi], [MüsteriSoyadi], [MüsteriTelefon], [MüsteriAdres], [KullaniciID]) VALUES (39, N'özlem', N'Özdemir', N'Özdemir', N'1234.Sokak', NULL)
INSERT [dbo].[Musteri] ([MusteriID], [MusteriAdi], [MüsteriSoyadi], [MüsteriTelefon], [MüsteriAdres], [KullaniciID]) VALUES (40, N'Nil', N'Üngeldi', N'(535) 622-2222', N'1234.Sokak', NULL)
INSERT [dbo].[Musteri] ([MusteriID], [MusteriAdi], [MüsteriSoyadi], [MüsteriTelefon], [MüsteriAdres], [KullaniciID]) VALUES (41, N'Osman', N'Konak', N'(522) 222-2222', N'1607.Sokak', NULL)
INSERT [dbo].[Musteri] ([MusteriID], [MusteriAdi], [MüsteriSoyadi], [MüsteriTelefon], [MüsteriAdres], [KullaniciID]) VALUES (42, N'Nagihan', N'Ballıoğlu', N'(545) 555-5555', N'1606.Sokak', NULL)
INSERT [dbo].[Musteri] ([MusteriID], [MusteriAdi], [MüsteriSoyadi], [MüsteriTelefon], [MüsteriAdres], [KullaniciID]) VALUES (43, N'Ali', N'Vali', N'(054) 552-2222', N'1520.Sokak', NULL)
SET IDENTITY_INSERT [dbo].[Musteri] OFF
SET IDENTITY_INSERT [dbo].[Satis] ON 

INSERT [dbo].[Satis] ([SatisID], [MusteriID], [UrunID], [SatisFiyati]) VALUES (2, NULL, NULL, 0)
INSERT [dbo].[Satis] ([SatisID], [MusteriID], [UrunID], [SatisFiyati]) VALUES (3, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Satis] OFF
SET IDENTITY_INSERT [dbo].[Urun] ON 

INSERT [dbo].[Urun] ([UrunID], [UrunAdi], [KategoriID], [AlisFiyati], [SatisFiyati], [UrunStok], [UrunAciklama]) VALUES (3, N'bisküvi', 3, 2, 5, 850, N'gıda ')
INSERT [dbo].[Urun] ([UrunID], [UrunAdi], [KategoriID], [AlisFiyati], [SatisFiyati], [UrunStok], [UrunAciklama]) VALUES (8, N'asit', 2, 50, 500, 20, N'kimyasal')
INSERT [dbo].[Urun] ([UrunID], [UrunAdi], [KategoriID], [AlisFiyati], [SatisFiyati], [UrunStok], [UrunAciklama]) VALUES (17, N'kalem', 2, 5, 35, 850, N'ders')
INSERT [dbo].[Urun] ([UrunID], [UrunAdi], [KategoriID], [AlisFiyati], [SatisFiyati], [UrunStok], [UrunAciklama]) VALUES (18, N'kuzu', 1, 500, 1500, 950, N'kıymalık')
INSERT [dbo].[Urun] ([UrunID], [UrunAdi], [KategoriID], [AlisFiyati], [SatisFiyati], [UrunStok], [UrunAciklama]) VALUES (19, N'çanta', 3, 52, 150, 500, N'çanta')
INSERT [dbo].[Urun] ([UrunID], [UrunAdi], [KategoriID], [AlisFiyati], [SatisFiyati], [UrunStok], [UrunAciklama]) VALUES (20, N'Ruj', 3, 2, 50, 500, N'Makyaj')
INSERT [dbo].[Urun] ([UrunID], [UrunAdi], [KategoriID], [AlisFiyati], [SatisFiyati], [UrunStok], [UrunAciklama]) VALUES (21, N'Mouse', 3, 5, 15, 60, N'bilgisayar')
INSERT [dbo].[Urun] ([UrunID], [UrunAdi], [KategoriID], [AlisFiyati], [SatisFiyati], [UrunStok], [UrunAciklama]) VALUES (22, N'Su', 1, 1, 7, 1500, N'İçecek')
SET IDENTITY_INSERT [dbo].[Urun] OFF
ALTER TABLE [dbo].[Musteri]  WITH CHECK ADD  CONSTRAINT [FK_Musteri_Kullanici] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanici] ([KullaniciID])
GO
ALTER TABLE [dbo].[Musteri] CHECK CONSTRAINT [FK_Musteri_Kullanici]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Musteri] FOREIGN KEY([MusteriID])
REFERENCES [dbo].[Musteri] ([MusteriID])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Musteri]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Urun] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urun] ([UrunID])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Urun]
GO
ALTER TABLE [dbo].[Urun]  WITH CHECK ADD  CONSTRAINT [FK_Urun_Kategori] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[Kategori] ([KategoriID])
GO
ALTER TABLE [dbo].[Urun] CHECK CONSTRAINT [FK_Urun_Kategori]
GO
