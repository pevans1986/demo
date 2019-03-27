namespace Evans.Demo.Repositories.EntityFramework.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class InitialDbCreation : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.TaskItems",
				c => new
					{
						Id = c.Guid(nullable: false, identity: true),
						Description = c.String(),
						DueDate = c.DateTime(),
						SortOrder = c.Int(nullable: false),
						Status = c.Int(nullable: false),
						CreatedDate = c.DateTime(nullable: false),
						ModifiedDate = c.DateTime(nullable: false),
						List_Id = c.Guid(nullable: false),
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.TaskLists", t => t.List_Id, cascadeDelete: true)
				.Index(t => t.List_Id);
			
			CreateTable(
				"dbo.TaskLists",
				c => new
					{
						Id = c.Guid(nullable: false, identity: true),
						Description = c.String(),
						Status = c.Int(nullable: false),
						Title = c.String(),
						CreatedDate = c.DateTime(nullable: false),
						ModifiedDate = c.DateTime(nullable: false),
					})
				.PrimaryKey(t => t.Id);
			
		}
		
		public override void Down()
		{
			DropForeignKey("dbo.TaskItems", "List_Id", "dbo.TaskLists");
			DropIndex("dbo.TaskItems", new[] { "List_Id" });
			DropTable("dbo.TaskLists");
			DropTable("dbo.TaskItems");
		}
	}
}
