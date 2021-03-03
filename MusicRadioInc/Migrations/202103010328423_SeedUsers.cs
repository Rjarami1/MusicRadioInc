namespace MusicRadioInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'105c5108-5550-4e20-914f-5cba1b1e703e', N'admin@musicradioinc.com', 0, N'ABISYtWDQPaz5x+sI17QpCDb5WVFrbdAj9w9IcwW5LBEGkxzf64qefAVJ3TOf4Pe1A==', N'4829a2e7-ddd1-42a7-8d44-3b4b0b59a048', NULL, 0, 0, NULL, 1, 0, N'admin@musicradioinc.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'350557e8-44e5-4600-a150-1cbfda089b1a', N'guest@musicradioinc.com', 0, N'ANPexdEe29YVLkZK7YNu9eTtejHOicsYA+W2zNc5oZnMLwSM9M7TSKe+7oXfqi957g==', N'8a5dd4d7-fbab-44a8-b893-6a031f91a7ba', NULL, 0, 0, NULL, 1, 0, N'guest@musicradioinc.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f56dfd53-8d25-487d-a0d7-d3931b68b1f5', N'CanManageAlbums')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'105c5108-5550-4e20-914f-5cba1b1e703e', N'f56dfd53-8d25-487d-a0d7-d3931b68b1f5')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
