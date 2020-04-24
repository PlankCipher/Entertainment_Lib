namespace Entertainment_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDatabaseWithMoviesAndTVPrograms : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[TVPrograms] ON;" +
               "INSERT INTO [dbo].[TVPrograms] ([Id], [Name], [Description], [Owner_Id]) VALUES (1, N'Mr. Robot', N'Mr. Robot is an American drama thriller television series created by Sam Esmail for USA Network. It stars Rami Malek as Elliot Alderson, a cybersecurity engineer and hacker with social anxiety disorder and clinical depression. Elliot is recruited by an insurrectionary anarchist known as ''Mr. Robot'', played by Christian Slater, to join a group of hacktivists called ''fsociety''.The group aims to destroy all debt records by encrypting the financial data of E Corp, the largest conglomerate in the world.', N'0e213098-1a93-4c8e-bece-3a36fbd108bd');" +
               "INSERT INTO[dbo].[TVPrograms]([Id], [Name], [Description], [Owner_Id]) VALUES(2, N'Mission: Impossible', N'Mission: Impossible is an American television series, created and initially produced by Bruce Geller, chronicling the exploits of a team of secret government agents known as the Impossible Missions Force (IMF). In the first season the team is led by Dan Briggs, played by Steven Hill; Jim Phelps, played by Peter Graves, takes charge for the remaining seasons. Each episode opens with a fast-paced montage of shots from that episode that unfolds as the series'' theme music composed by Lalo Schifrin plays, after which in a prologue Briggs or Phelps receives his instructions from a voice delivered on a recording which then self-destructs.', N'0e213098-1a93-4c8e-bece-3a36fbd108bd');" +
               "INSERT INTO[dbo].[TVPrograms] ([Id], [Name], [Description], [Owner_Id]) VALUES(3, N'Friends', N'Friends is an American television sitcom, created by David Crane and Marta Kauffman, which aired on NBC from September 22, 1994, to May 6, 2004, lasting ten seasons. With an ensemble cast starring Jennifer Aniston, Courteney Cox, Lisa Kudrow, Matt LeBlanc, Matthew Perry and David Schwimmer, the show revolved around six friends in their 20s and 30s who lived in Manhattan, New York City. The series was produced by Bright/Kauffman/Crane Productions, in association with Warner Bros. Television. The original executive producers were Kevin S. Bright, Kauffman, and Crane.', N'0e213098-1a93-4c8e-bece-3a36fbd108bd');" +
               "INSERT INTO[dbo].[TVPrograms] ([Id], [Name], [Description], [Owner_Id]) VALUES(4, N'Supernatural', N'Supernatural is an American dark fantasy television series created by Eric Kripke. It was first broadcast on September 13, 2005, on The WB, and subsequently became part of successor The CW''s lineup. Starring Jared Padalecki as Sam Winchester and Jensen Ackles as Dean Winchester, the series follows the two brothers as they hunt demons, ghosts, monsters, and other supernatural beings. The series is produced by Warner Bros.Television, in association with Wonderland Sound and Vision. Along with Kripke, executive producers have been McG, Robert Singer, Phil Sgriccia, Sera Gamble, Jeremy Carver, John Shiban, Ben Edlund and Adam Glass.Former executive producer and director Kim Manners died of lung cancer during production of the fourth season.', N'0e213098-1a93-4c8e-bece-3a36fbd108bd');" +
               "SET IDENTITY_INSERT [dbo].[TVPrograms] OFF;");

            Sql("SET IDENTITY_INSERT [dbo].[Movies] ON;" +
                "INSERT INTO [dbo].[Movies] ([Id], [Name], [Description], [Owner_Id]) VALUES (4, N'Avengers: Endgame', N'Avengers: Endgame is a 2019 American superhero film based on the Marvel Comics superhero team the Avengers, produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures.It is the sequel to 2012''s The Avengers, 2015''s, and 2018''s, and the twenty - second film in the Marvel Cinematic  Universe.', N'0e213098-1a93-4c8e-bece-3a36fbd108bd');" +
                "INSERT INTO[dbo].[Movies]([Id], [Name], [Description], [Owner_Id]) VALUES(7, N'Spider-Man: Homecoming', N'Spider-Man: Homecoming is a 2017 American superhero film based on the Marvel Comics character Spider-Man, co-produced by Columbia Pictures and Marvel Studios, and distributed by Sony Pictures Releasing.It is the second Spider - Man film reboot and the sixteenth film in the Marvel Cinematic Universe.The film is directed by Jon Watts, from a screenplay by the writing teams of Jonathan Goldstein and John Francis Daley, Watts and Christopher Ford, and Chris McKenna and Erik Sommers.', N'0e213098-1a93-4c8e-bece-3a36fbd108bd');" +
                "INSERT INTO[dbo].[Movies]([Id], [Name], [Description], [Owner_Id]) VALUES(9, N'Who Am I', N'Benjamin, a young German computer whiz, is invited to join a subversive hacker group that wants to be noticed on the world''s stage.', N'0e213098-1a93-4c8e-bece-3a36fbd108bd');" +
                "INSERT INTO[dbo].[Movies]([Id], [Name], [Description], [Owner_Id]) VALUES(10, N'A Quiet Place', N'A Quiet Place is a 2018 American post-apocalyptic horror film directed by John Krasinski, who wrote the screenplay with Bryan Woods and Scott Beck. The film stars Krasinski, alongside Emily Blunt, Millicent Simmonds, and Noah Jupe.', N'0e213098-1a93-4c8e-bece-3a36fbd108bd');" +
                "SET IDENTITY_INSERT [dbo].[Movies] OFF;");
        }
        
        public override void Down()
        {
        }
    }
}
