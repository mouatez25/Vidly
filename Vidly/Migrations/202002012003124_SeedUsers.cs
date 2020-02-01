namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1824ed49-f6e5-45a1-99ac-04d111a4e150', N'admin@gmail.com', 0, N'ACGxgU+g5jn5C8Dwt4cVLdPAerTaHG8fHD1s/pQspsa+n7sLJGuElr3RR2EWCQYs8w==', N'd7467d98-556b-4cd4-bd06-986064fdba47', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3c916798-4cf1-41cf-ac93-20bbd64aaac8', N'mouatezkitouni@gmail.com', 0, N'AB/QLA3uGSA9qDgud2Vh/OJqtec8rYRWA72ff2C/WzTxtjsdHYA03BHCDPTe8CuiZw==', N'd2197d62-f735-4b64-9cfa-7ac5e8753f7f', NULL, 0, 0, NULL, 1, 0, N'mouatezkitouni@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bcecf45d-6892-4b8f-a3f5-c7fd932f5463', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1824ed49-f6e5-45a1-99ac-04d111a4e150', N'bcecf45d-6892-4b8f-a3f5-c7fd932f5463')


");
        }
        
        public override void Down()
        {
        }
    }
}
