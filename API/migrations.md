## Reflect the current state of DB:

**Step 1:**\
Ensure Your Model Represents the Current Database Schema

**Step 2:**\
Delete the Existing Migrations Folder
```bash
# Navigate to your project directory where the migrations are stored, then delete the Migrations folder
rm -r Migrations
```

**Step 3:**\
Clear the Migrations History Table
```
-- Execute this SQL command in your database management tool
DELETE FROM "__EFMigrationsHistory";
```

**Step 4:**\
Create a New Initial Migration
```bash
dotnet ef migrations add Initial
```

**Step 5: (Optional)**\
Manually Update the Migrations History Table\
```
-- Replace '20240302123456_Initial' with your migration's actual name
-- The version corresponds to the EF Core version you're using, e.g., '8.0.2'
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240302123456_Initial', '8.0.2');
```

## Add migrations
```bash
dotnet ef migrations add new_migration
dotnet ef database update
```