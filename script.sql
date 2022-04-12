/****** Object:  Database [DbMvcDemo]    Script Date: 12.04.2022 15:43:05 ******/
CREATE DATABASE [DbMvcDemo]   WITH CATALOG_COLLATION = DATABASE_DEFAULT;
GO
ALTER DATABASE [DbMvcDemo] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [DbMvcDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbMvcDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbMvcDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbMvcDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbMvcDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbMvcDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbMvcDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbMvcDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbMvcDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbMvcDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbMvcDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbMvcDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbMvcDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbMvcDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbMvcDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbMvcDemo] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DbMvcDemo] SET  MULTI_USER 
GO
ALTER DATABASE [DbMvcDemo] SET QUERY_STORE = OFF
GO
/****** Object:  Table [dbo].[Abouts]    Script Date: 12.04.2022 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abouts](
	[AboutId] [int] IDENTITY(1,1) NOT NULL,
	[AboutDetails1] [nvarchar](1000) NULL,
	[AboutDetails2] [nvarchar](1000) NULL,
	[AboutImageUrl1] [nvarchar](250) NULL,
	[AboutImageUrl2] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Abouts] PRIMARY KEY CLUSTERED 
(
	[AboutId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 12.04.2022 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[AdminPassword] [nvarchar](500) NULL,
	[AdminRole] [nvarchar](1) NULL,
	[AdminEmail] [nvarchar](50) NULL,
	[AdminStatus] [bit] NOT NULL,
	[AdminFirstName] [nvarchar](50) NULL,
	[AdminLastName] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Admins] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12.04.2022 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
	[CategoryDescription] [nvarchar](250) NULL,
	[CategoryStatus] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 12.04.2022 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[ContactUserName] [nvarchar](50) NULL,
	[ContactUserEmail] [nvarchar](50) NULL,
	[ContactSubject] [nvarchar](100) NULL,
	[ContactMessage] [nvarchar](1000) NULL,
	[ContactDate] [datetime] NOT NULL,
	[ContactStatus] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contents]    Script Date: 12.04.2022 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contents](
	[ContentId] [int] IDENTITY(1,1) NOT NULL,
	[ContentText] [nvarchar](1000) NULL,
	[ContentDate] [datetime] NOT NULL,
	[HeadingId] [int] NOT NULL,
	[WriterId] [int] NULL,
	[ContentStatus] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Contents] PRIMARY KEY CLUSTERED 
(
	[ContentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drafts]    Script Date: 12.04.2022 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drafts](
	[DraftId] [int] IDENTITY(1,1) NOT NULL,
	[SenderEmail] [nvarchar](50) NULL,
	[ReceiverEmail] [nvarchar](50) NULL,
	[MessageSubject] [nvarchar](100) NULL,
	[MessageContent] [nvarchar](1000) NULL,
 CONSTRAINT [PK_dbo.Drafts] PRIMARY KEY CLUSTERED 
(
	[DraftId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Headings]    Script Date: 12.04.2022 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Headings](
	[HeadingId] [int] IDENTITY(1,1) NOT NULL,
	[HeadingName] [nvarchar](50) NULL,
	[HeadingDate] [datetime] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[WriterId] [int] NOT NULL,
	[HeadingStatus] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Headings] PRIMARY KEY CLUSTERED 
(
	[HeadingId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 12.04.2022 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [nvarchar](50) NULL,
	[ImagePath] [nvarchar](250) NULL,
	[ImageDescription] [nvarchar](1000) NULL,
 CONSTRAINT [PK_dbo.Images] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 12.04.2022 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[MessageSubject] [nvarchar](100) NULL,
	[MessageContent] [nvarchar](1000) NULL,
	[SenderEmail] [nvarchar](50) NULL,
	[ReceiverEmail] [nvarchar](50) NULL,
	[MessageDate] [datetime] NOT NULL,
	[MessageStatus] [bit] NOT NULL,
	[MessageIsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Messages] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Writers]    Script Date: 12.04.2022 15:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Writers](
	[WriterId] [int] IDENTITY(1,1) NOT NULL,
	[WriterFirstName] [nvarchar](50) NULL,
	[WriterLastName] [nvarchar](50) NULL,
	[WriterImageUrl] [nvarchar](250) NULL,
	[WriterEmail] [nvarchar](50) NULL,
	[WriterPassword] [nvarchar](500) NULL,
	[WriterAbout] [nvarchar](250) NULL,
	[WriterTitle] [nvarchar](50) NULL,
	[WriterStatus] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Writers] PRIMARY KEY CLUSTERED 
(
	[WriterId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Abouts] ON 

INSERT [dbo].[Abouts] ([AboutId], [AboutDetails1], [AboutDetails2], [AboutImageUrl1], [AboutImageUrl2]) VALUES (6, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed rutrum, nisi in semper tempus, erat magna ultricies enim, ut sollicitudin urna diam ut arcu. Nunc odio arcu, facilisis vel ipsum eget, rhoncus condimentum purus. Phasellus eleifend congue dui, a laoreet dui egestas ut. Duis ac lacus ultrices lectus malesuada cursus. Ut placerat tellus non arcu efficitur, vitae consequat sapien dapibus. Proin aliquet bibendum orci, in finibus dolor aliquet ut. Sed orci leo, tristique id semper sed, mollis sed est. Maecenas laoreet, neque id viverra rhoncus, est nibh iaculis velit, quis sagittis ante risus vel ante. Nunc id erat placerat, dignissim neque quis, dictum nulla.', N'Aliquam placerat aliquam dignissim. Vestibulum sollicitudin urna semper commodo bibendum. Nunc mattis vel urna eu faucibus. Etiam porta, libero sed imperdiet rutrum, augue justo mattis diam, ac tempus sapien odio finibus justo. Sed augue metus, ornare eu fringilla eget, porttitor nec magna. Vestibulum sodales nulla metus. Mauris blandit ante sodales quam commodo eleifend. Nam ornare volutpat ipsum, efficitur aliquam eros fringilla vitae. Phasellus non leo sed justo ornare mollis. Nullam vitae dui a erat dignissim ornare. Quisque tincidunt dictum pellentesque. Cras placerat lobortis nisi, eget efficitur libero facilisis sit amet. Etiam egestas mauris vitae orci luctus, ut tincidunt purus sollicitudin.', N'/Images/about/about1.jpg', N'/Images/about/about1.jpg')
SET IDENTITY_INSERT [dbo].[Abouts] OFF
GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([AdminId], [AdminPassword], [AdminRole], [AdminEmail], [AdminStatus], [AdminFirstName], [AdminLastName]) VALUES (1, N'12345678', N'A', N'admin@mail.com', 1, N'Furkan', N'Yazar')
SET IDENTITY_INSERT [dbo].[Admins] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CategoryStatus]) VALUES (20, N'Film', N'Burası film kategorisidir', 1)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CategoryStatus]) VALUES (21, N'Tiyatro', N'Burası tiyatro kategorisidir', 1)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CategoryStatus]) VALUES (22, N'Kitap', N'Burası kitap kategorisidir', 1)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CategoryStatus]) VALUES (23, N'Spor', N'Burası spor kategorisidir', 1)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CategoryStatus]) VALUES (24, N'Dizi', N'Burası dizi kategorisidir', 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([ContactId], [ContactUserName], [ContactUserEmail], [ContactSubject], [ContactMessage], [ContactDate], [ContactStatus]) VALUES (3, N'Ahmet', N'ahmet@mail.com', N'Site', N'Site içeriği oldukça güzel. Bazı eksikler var. Geliştirme yapılabilir', CAST(N'2022-04-12T02:58:13.853' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[Contents] ON 

INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (37, N'Dwayne Johnson''ın başrolünde olacağı aksiyon macera filmi. Yönetmenliğini Rawson Marshall Thurber yapacak. 13 kasım 2020''de vizyona girecek', CAST(N'2022-04-12T01:42:26.670' AS DateTime), 26, 29, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (38, N'Yabancı konusunu kafaya takmaması gereken futbol takımı. Seneye yabancı sayısı ya sabit kalacak yada daha da yükselecek. Bu yazı burada dursun şayet olmazsa mesaj kutum açık inşallah ölmezsek görürüz', CAST(N'2022-04-12T01:50:47.200' AS DateTime), 31, 29, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (39, N'Victor Hugo''nun dramatik romanının adı', CAST(N'2022-04-12T01:52:03.067' AS DateTime), 34, 29, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (40, N'Uğur Dündar gibi aydın ve entelektüel bir bilgenin rehberliğinde başarıdan başarıya koşacağından en ufak bir şüphe duymadığım kulüp', CAST(N'2022-04-12T01:59:19.683' AS DateTime), 29, 30, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (41, N'Tolstoy''un beş senede yazdığı benim de neredeyse beş ayda okuduğum kitap. İki cilt, 1776 sayfa', CAST(N'2022-04-12T01:59:53.967' AS DateTime), 35, 30, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (42, N'The Batman filminin Joker''ini Barry Keoghan canlandırıyor. Fiziksel olarak en korkuncu diyebiliriz', CAST(N'2022-04-12T02:02:53.900' AS DateTime), 28, 31, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (43, N'İlk sezonu izledikten sonra bırakmıştım, bu gün yeniden izlemeye başladım. İzlemeye değer bir yapıt', CAST(N'2022-04-12T02:03:47.887' AS DateTime), 32, 31, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (44, N'Alexandre Dumas’ın şaheseri. İroni ve mizah yüklü serüven kitaplarının babası', CAST(N'2022-04-12T02:04:31.703' AS DateTime), 36, 31, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (45, N'Fatih Terim sayesinde büyük olmuş takım. Sorunu Fatih Terim zannedenler yıllar içinde gerçekle yüzleşecek', CAST(N'2022-04-12T02:05:43.497' AS DateTime), 30, 32, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (46, N'Bu oyunda, Ophelia; Hamlet''e sadakat sembolü olarak biberiye uzatmaktadır. Öyle ince bir oyundur, öyle şahane bir başyapıttır', CAST(N'2022-04-12T02:06:20.937' AS DateTime), 37, 32, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (47, N'Seyir zevki olan eğlenceli film. Konu olarak kızım sana söylüyorum gelinim sen anla filmi', CAST(N'2022-04-12T02:07:36.530' AS DateTime), 27, 33, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (48, N'Başrolde Berdan Mardini bile daha doğal oynardı sanırım. Sevgili Henry Cavill; Hollwood''da dayın mı var oğlum senin, nedir senden çekilen?', CAST(N'2022-04-12T02:08:51.700' AS DateTime), 33, 33, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (49, N'İnsanların, başka insanlar tarafından ne kadar aşağılandığını anlatan çok güzel bir oyun. Özellikle kadınların aşağılanmasını çok iyi anlatmış Henrik Ibsen', CAST(N'2022-04-12T02:09:38.720' AS DateTime), 38, 33, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (50, N'İlk 20 dakika dolu dolu olan film. Bence güzel, izleyin', CAST(N'2022-04-12T02:11:21.643' AS DateTime), 27, 29, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (51, N'Filmin en can alıcı sahnesi canlı canlı, canlı yayında can alması Joker''in', CAST(N'2022-04-12T02:12:21.977' AS DateTime), 28, 29, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (52, N'Acıların takımı', CAST(N'2022-04-12T02:13:34.333' AS DateTime), 29, 29, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (53, N'Bu takımın kaybedecek daha neyi var? Hiç mi altyapıdan oyuncusu yok, bir tane çıkartıp oynatsın. Ya artık aynı isimler aynı hatalar, bitmediniz be', CAST(N'2022-04-12T02:14:39.663' AS DateTime), 30, 29, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (55, N'Satın aldığım ikinci Tolstoy kitabıdır. İlki Anna Karenina. O kitap hiç sıkmamıştı, umarım bu da sıkmaz. İki hafta civarında bitirebilirim umarım', CAST(N'2022-04-12T02:16:01.383' AS DateTime), 35, 29, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (56, N'Roman gibi roman, klasik gibi klasik, kapı gibi 750 sayfalık bir eser', CAST(N'2022-04-12T02:16:53.450' AS DateTime), 36, 29, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (57, N'Eski Türkiye''nin büyük takımı, zamanla çoğu şey gibi Galatasaray''ında tadı kalmadı', CAST(N'2022-04-12T02:18:21.100' AS DateTime), 30, 30, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (58, N'Uzun bir aradan sonra bugün kavuşacağım biricik sevgilim. Hava güzel, sen güzelsin, ben güzelim. Daha ne olsun', CAST(N'2022-04-12T02:18:54.600' AS DateTime), 31, 30, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (59, N'Hiç sevmediğim yazarın bilindik eseri', CAST(N'2022-04-12T02:19:24.810' AS DateTime), 34, 30, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (60, N'Alexander Dumas’nın "Üç Silahşor" kitabının, kötü bir çeviri hatası sonucu ülkemizde “Üç Silahşörler” olarak bilinen ismidir', CAST(N'2022-04-12T02:20:32.817' AS DateTime), 36, 30, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (61, N'Aksiyon sahnelerinde sürekli kameranın hareket etmesi sebebiyle rahatsız olup kapattığım aksiyon filmi', CAST(N'2022-04-12T02:21:31.680' AS DateTime), 27, 31, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (62, N'Çerezlik yahu, çok bir şey beklememek lazım', CAST(N'2022-04-12T02:21:57.730' AS DateTime), 26, 31, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (63, N'2. sezonda konuyu toparlamışlar ve odaklanmışlar, sanırım 3. sezonda konuyu kapatırlar', CAST(N'2022-04-12T02:22:35.750' AS DateTime), 33, 31, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (64, N'Sadece barış olması daha sevimli olur kanımca...', CAST(N'2022-04-12T02:23:02.083' AS DateTime), 35, 31, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (65, N'Victor Hugo''nun en önemli kitabının Türkçe ismi', CAST(N'2022-04-12T02:23:24.560' AS DateTime), 34, 31, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (66, N'Lise 1''de okutmuşlardı bu eseri, filmi de var, Jane Fonda''nın oynadığı', CAST(N'2022-04-12T02:24:37.817' AS DateTime), 38, 32, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (67, N'Bu sene ne yapıp edip ligde Avrupa kupalarına katılabileceği bir sırayı alması gereken takım', CAST(N'2022-04-12T02:25:48.270' AS DateTime), 31, 32, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (68, N'Kendini zaman zaman Fenerbahçe Cumhuriyeti diye de adlandıran güzide kulübümüz...', CAST(N'2022-04-12T02:26:13.580' AS DateTime), 29, 32, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (69, N'Sinema tarihinde iki kere akademi ödülü kazandırmış iki karakterden biridir (2008, 2019).', CAST(N'2022-04-12T02:28:06.743' AS DateTime), 28, 33, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (70, N'Benim gibi kötü film sevenleri zevkten dört köşe eden film', CAST(N'2022-04-12T02:28:35.873' AS DateTime), 26, 33, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (71, N'Tam bir Alman mühendisliği ile bizlere sunulmuş dizidir. Netflix yapımı ilk Almanca orijinal dizidir aynı zamanda', CAST(N'2022-04-12T02:29:51.387' AS DateTime), 32, 33, 1)
INSERT [dbo].[Contents] ([ContentId], [ContentText], [ContentDate], [HeadingId], [WriterId], [ContentStatus]) VALUES (72, N'Öldürülmüş bir babası, kirletilmiş bir anası olan Danimarka prensi', CAST(N'2022-04-12T02:30:43.453' AS DateTime), 37, 33, 1)
SET IDENTITY_INSERT [dbo].[Contents] OFF
GO
SET IDENTITY_INSERT [dbo].[Drafts] ON 

INSERT [dbo].[Drafts] ([DraftId], [SenderEmail], [ReceiverEmail], [MessageSubject], [MessageContent]) VALUES (9, N'ali@mail.com', N'murat@mail.com', NULL, N'<p>Merhaba Murat.&nbsp;</p>')
SET IDENTITY_INSERT [dbo].[Drafts] OFF
GO
SET IDENTITY_INSERT [dbo].[Headings] ON 

INSERT [dbo].[Headings] ([HeadingId], [HeadingName], [HeadingDate], [CategoryId], [WriterId], [HeadingStatus]) VALUES (26, N'Red Notice', CAST(N'2022-04-12T01:34:34.897' AS DateTime), 20, 29, 1)
INSERT [dbo].[Headings] ([HeadingId], [HeadingName], [HeadingDate], [CategoryId], [WriterId], [HeadingStatus]) VALUES (27, N'6 Underground', CAST(N'2022-04-12T01:35:08.370' AS DateTime), 20, 33, 1)
INSERT [dbo].[Headings] ([HeadingId], [HeadingName], [HeadingDate], [CategoryId], [WriterId], [HeadingStatus]) VALUES (28, N'Joker', CAST(N'2022-04-12T01:35:25.353' AS DateTime), 20, 31, 1)
INSERT [dbo].[Headings] ([HeadingId], [HeadingName], [HeadingDate], [CategoryId], [WriterId], [HeadingStatus]) VALUES (29, N'Fenerbahçe', CAST(N'2022-04-12T01:36:33.290' AS DateTime), 23, 30, 1)
INSERT [dbo].[Headings] ([HeadingId], [HeadingName], [HeadingDate], [CategoryId], [WriterId], [HeadingStatus]) VALUES (30, N'Galatasaray', CAST(N'2022-04-12T01:36:41.140' AS DateTime), 23, 32, 1)
INSERT [dbo].[Headings] ([HeadingId], [HeadingName], [HeadingDate], [CategoryId], [WriterId], [HeadingStatus]) VALUES (31, N'Beşiktaş', CAST(N'2022-04-12T01:36:52.033' AS DateTime), 23, 29, 1)
INSERT [dbo].[Headings] ([HeadingId], [HeadingName], [HeadingDate], [CategoryId], [WriterId], [HeadingStatus]) VALUES (32, N'Dark', CAST(N'2022-04-12T01:37:39.480' AS DateTime), 24, 31, 1)
INSERT [dbo].[Headings] ([HeadingId], [HeadingName], [HeadingDate], [CategoryId], [WriterId], [HeadingStatus]) VALUES (33, N'The Witcher', CAST(N'2022-04-12T01:38:10.400' AS DateTime), 24, 33, 1)
INSERT [dbo].[Headings] ([HeadingId], [HeadingName], [HeadingDate], [CategoryId], [WriterId], [HeadingStatus]) VALUES (34, N'Sefiller', CAST(N'2022-04-12T01:39:13.990' AS DateTime), 22, 29, 1)
INSERT [dbo].[Headings] ([HeadingId], [HeadingName], [HeadingDate], [CategoryId], [WriterId], [HeadingStatus]) VALUES (35, N'Savaş ve Barış', CAST(N'2022-04-12T01:39:26.747' AS DateTime), 22, 30, 1)
INSERT [dbo].[Headings] ([HeadingId], [HeadingName], [HeadingDate], [CategoryId], [WriterId], [HeadingStatus]) VALUES (36, N'Üç Silahşörler', CAST(N'2022-04-12T01:39:40.953' AS DateTime), 22, 31, 1)
INSERT [dbo].[Headings] ([HeadingId], [HeadingName], [HeadingDate], [CategoryId], [WriterId], [HeadingStatus]) VALUES (37, N'Hamlet', CAST(N'2022-04-12T01:40:24.417' AS DateTime), 21, 32, 1)
INSERT [dbo].[Headings] ([HeadingId], [HeadingName], [HeadingDate], [CategoryId], [WriterId], [HeadingStatus]) VALUES (38, N'Bir Bebek Evi', CAST(N'2022-04-12T01:40:44.070' AS DateTime), 21, 33, 1)
SET IDENTITY_INSERT [dbo].[Headings] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([ImageId], [ImageName], [ImagePath], [ImageDescription]) VALUES (12, N'Amsterdam', N'/Images/gallery/amsterdam.jpg', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In orci.')
INSERT [dbo].[Images] ([ImageId], [ImageName], [ImagePath], [ImageDescription]) VALUES (13, N'Berlin', N'/Images/gallery/berlin.jpg', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In orci.')
INSERT [dbo].[Images] ([ImageId], [ImageName], [ImagePath], [ImageDescription]) VALUES (14, N'Brüksel', N'/Images/gallery/bruksel.jpg', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In orci.')
INSERT [dbo].[Images] ([ImageId], [ImageName], [ImagePath], [ImageDescription]) VALUES (15, N'Budapeşte', N'/Images/gallery/budapeste.jpg', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In orci.')
INSERT [dbo].[Images] ([ImageId], [ImageName], [ImagePath], [ImageDescription]) VALUES (16, N'Dublin', N'/Images/gallery/dublin.jpg', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In orci.')
INSERT [dbo].[Images] ([ImageId], [ImageName], [ImagePath], [ImageDescription]) VALUES (17, N'Edinburg', N'/Images/gallery/edinburg.jpg', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In orci.')
INSERT [dbo].[Images] ([ImageId], [ImageName], [ImagePath], [ImageDescription]) VALUES (18, N'Kopenhag', N'/Images/gallery/kopenhag.jpg', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In orci.')
INSERT [dbo].[Images] ([ImageId], [ImageName], [ImagePath], [ImageDescription]) VALUES (19, N'Roma', N'/Images/gallery/roma.jpg', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In orci.')
INSERT [dbo].[Images] ([ImageId], [ImageName], [ImagePath], [ImageDescription]) VALUES (20, N'Saraybosna', N'/Images/gallery/saraybosna.jpg', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In orci.')
INSERT [dbo].[Images] ([ImageId], [ImageName], [ImagePath], [ImageDescription]) VALUES (21, N'Venedik', N'/Images/gallery/venedik.jpg', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In orci.')
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([MessageId], [MessageSubject], [MessageContent], [SenderEmail], [ReceiverEmail], [MessageDate], [MessageStatus], [MessageIsDeleted]) VALUES (20, N'Dark', N'<p><span style="font-family: &quot;Arial Black&quot;;">Merhaba </span><b>Emel</b>. <span style="background-color: rgb(255, 255, 0);">Dark </span>başlığı altında yazdığın yazı çok ilgimi çekti. <u>Bir ara birlikte izlemeliyiz</u></p>', N'ali@mail.com', N'emel@mail.com', CAST(N'2022-04-12T02:50:28.210' AS DateTime), 1, 1)
INSERT [dbo].[Messages] ([MessageId], [MessageSubject], [MessageContent], [SenderEmail], [ReceiverEmail], [MessageDate], [MessageStatus], [MessageIsDeleted]) VALUES (21, N'Kitap', N'<p><b>Merhaba Ali,</b></p><p>Sanırım kitap okumayı seviyorsun. Bir kaç kitap başlığı altında yazı yazdığını gördüm. Kitap önerisinde bulunur musun?</p><p><span style="font-family: &quot;Comic Sans MS&quot;; background-color: rgb(255, 255, 0);">İyi günler</span></p>', N'asli@mail.com', N'ali@mail.com', CAST(N'2022-04-12T02:53:48.473' AS DateTime), 0, 0)
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
SET IDENTITY_INSERT [dbo].[Writers] ON 

INSERT [dbo].[Writers] ([WriterId], [WriterFirstName], [WriterLastName], [WriterImageUrl], [WriterEmail], [WriterPassword], [WriterAbout], [WriterTitle], [WriterStatus]) VALUES (29, N'Ali', N'Yıldız', N'/Images/profiles/c45a0f2d-4630-4d1e-9591-2c00ab51de15.jpg', N'ali@mail.com', N'ali102030', N'Selamlar. Ben Ali Yıldız. 35 yaşındayım. İstanbul''da yaşıyorum. Yazılım geliştiriciyim', N'Yazılım Geliştirici', 1)
INSERT [dbo].[Writers] ([WriterId], [WriterFirstName], [WriterLastName], [WriterImageUrl], [WriterEmail], [WriterPassword], [WriterAbout], [WriterTitle], [WriterStatus]) VALUES (30, N'Mehmet', N'Çınar', N'/Images/profiles/929850cd-43bb-414f-999c-30dec0971036.jpg', N'mehmet@mail.com', N'mehmet102030', NULL, NULL, 1)
INSERT [dbo].[Writers] ([WriterId], [WriterFirstName], [WriterLastName], [WriterImageUrl], [WriterEmail], [WriterPassword], [WriterAbout], [WriterTitle], [WriterStatus]) VALUES (31, N'Emel', N'Öztürk', N'/Images/profiles/b6e2308e-0e13-496b-968b-6782f8ab2b1c.jpg', N'emel@mail.com', N'emel102030', NULL, N'Bloger', 1)
INSERT [dbo].[Writers] ([WriterId], [WriterFirstName], [WriterLastName], [WriterImageUrl], [WriterEmail], [WriterPassword], [WriterAbout], [WriterTitle], [WriterStatus]) VALUES (32, N'Murat', N'Yılmaz', NULL, N'murat@mail.com', N'murat102030', NULL, NULL, 1)
INSERT [dbo].[Writers] ([WriterId], [WriterFirstName], [WriterLastName], [WriterImageUrl], [WriterEmail], [WriterPassword], [WriterAbout], [WriterTitle], [WriterStatus]) VALUES (33, N'Aslı', N'Kaya', N'/Images/profiles/8da22de3-9d46-44f8-b3f0-4fa4849c02d9.jpg', N'asli@mail.com', N'asli102030', N'Herkese selam. Ben Aslı. Buraya eğlenmeye geldim', NULL, 1)
SET IDENTITY_INSERT [dbo].[Writers] OFF
GO
/****** Object:  Index [IX_HeadingId]    Script Date: 12.04.2022 15:43:05 ******/
CREATE NONCLUSTERED INDEX [IX_HeadingId] ON [dbo].[Contents]
(
	[HeadingId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_WriterId]    Script Date: 12.04.2022 15:43:05 ******/
CREATE NONCLUSTERED INDEX [IX_WriterId] ON [dbo].[Contents]
(
	[WriterId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryId]    Script Date: 12.04.2022 15:43:05 ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[Headings]
(
	[CategoryId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_WriterId]    Script Date: 12.04.2022 15:43:05 ******/
CREATE NONCLUSTERED INDEX [IX_WriterId] ON [dbo].[Headings]
(
	[WriterId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Admins] ADD  DEFAULT ((0)) FOR [AdminStatus]
GO
ALTER TABLE [dbo].[Contacts] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [ContactDate]
GO
ALTER TABLE [dbo].[Contacts] ADD  DEFAULT ((0)) FOR [ContactStatus]
GO
ALTER TABLE [dbo].[Contents] ADD  DEFAULT ((0)) FOR [ContentStatus]
GO
ALTER TABLE [dbo].[Headings] ADD  DEFAULT ((0)) FOR [HeadingStatus]
GO
ALTER TABLE [dbo].[Messages] ADD  DEFAULT ((0)) FOR [MessageStatus]
GO
ALTER TABLE [dbo].[Messages] ADD  DEFAULT ((0)) FOR [MessageIsDeleted]
GO
ALTER TABLE [dbo].[Writers] ADD  DEFAULT ((0)) FOR [WriterStatus]
GO
ALTER TABLE [dbo].[Contents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Contents_dbo.Headings_HeadingId] FOREIGN KEY([HeadingId])
REFERENCES [dbo].[Headings] ([HeadingId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contents] CHECK CONSTRAINT [FK_dbo.Contents_dbo.Headings_HeadingId]
GO
ALTER TABLE [dbo].[Contents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Contents_dbo.Writers_WriterId] FOREIGN KEY([WriterId])
REFERENCES [dbo].[Writers] ([WriterId])
GO
ALTER TABLE [dbo].[Contents] CHECK CONSTRAINT [FK_dbo.Contents_dbo.Writers_WriterId]
GO
ALTER TABLE [dbo].[Headings]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Headings_dbo.Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Headings] CHECK CONSTRAINT [FK_dbo.Headings_dbo.Categories_CategoryId]
GO
ALTER TABLE [dbo].[Headings]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Headings_dbo.Writers_WriterId] FOREIGN KEY([WriterId])
REFERENCES [dbo].[Writers] ([WriterId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Headings] CHECK CONSTRAINT [FK_dbo.Headings_dbo.Writers_WriterId]
GO
ALTER DATABASE [DbMvcDemo] SET  READ_WRITE 
GO
