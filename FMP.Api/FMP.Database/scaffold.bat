@echo off

REM   +------------------------------------------------+
REM  /   Install EF tool using the command below      /
REM /    dotnet tool install --global dotnet-ef      /
REM +-----------------------------------------------+

REM --project
set project=FMP.Database.csproj

REM --startup-project
set startupProject=FMP.Database.csproj

REM <CONNECTION>
REM The connection string to the database. For ASP.NET Core 2.x projects, the value can be 
REM name=<name of connection string>. In that case the name comes from the configuration sources 
REM that are set up for the project. This is a positional parameter and is required.
set connection=Server=localhost;Database=FindMyPharmacy;Integrated Security=true;

REM <PROVIDER>
REM The provider to use. Typically this is the name of the NuGet package, for example: 
REM Microsoft.EntityFrameworkCore.SqlServer. This is a positional parameter and is required.
set provider=Microsoft.EntityFrameworkCore.SqlServer

REM --output-dir <PATH> 	
REM The directory to put files in. Paths are relative to the project directory.
set outputDir=Database/Models

REM --context-dir <PATH>
REM The directory to put the DbContext file in. Paths are relative to the project directory.
set contextDir=Database/Contexts

REM --context <NAME>
REM The name of the DbContext class to generate.
set context=FindMyPharmacyDbContext

REM --schema <SCHEMA_NAME>..
REM The schemas of tables to generate entity types for. To specify multiple schemas, 
REM repeat --schema for each one. If this option is omitted, all schemas are included.
set schema=

REM --table <TABLE_NAME>.. 	
REM The tables to generate entity types for. To specify multiple tables, repeat -t or 
REM --table for each one. If this option is omitted, all tables are included.
set tables=

REM --data-annotations
REM Use attributes to configure the model (where possible). If this parameter is omitted, only the fluent API is used.
set dataAnnotations=

REM --use-database-names 	
REM Use table and column names exactly as they appear in the database. If this option is omitted, database names are 
REM changed to more closely conform to C# name style conventions.
set useDatabaseNames=

REM --force
REM Overwrite existing files.
REM '--force' means force, 'empty' means no-force
set force=--force

@echo on

dotnet ef dbcontext scaffold ^
 "%connection%" %provider% ^
--project "%project%" ^
--startup-project "%startupProject%" ^
--context-dir "%contextDir%" ^
--output-dir "%outputDir%" ^
--context "%context%" ^
--use-database-names ^
%tables% ^
%force%

@echo off
