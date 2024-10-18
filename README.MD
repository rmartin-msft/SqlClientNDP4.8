# Project Description
This is a .NET Framework 4.8.2 using EF6.5.1 and Azure SQL Databases with 
Azure Entra ID Service Principal for authentication.

## Setup

You'll need to create a Service Principal in Azure AD and assign it to the Azure SQL Database.
See the documentation at https://learn.microsoft.com/en-us/azure/azure-sql/database/authentication-aad-service-principal-tutorial?view=azuresql for doing this.

You'll have to update the App.config connectionString section to point to your 
Azure SQL Database and populate the correct connection string.

```xml
<connectionStrings>		
		<add name="metal_dbEntities" connectionString="metadata=res://*/MetalModel.csdl|res://*/MetalModel.ssdl|res://*/MetalModel.msl;provider=Microsoft.Data.SqlClient;provider connection string=&quot;Server=SERVERNAME.database.windows.net;Authentication=Active Directory Service Principal; Encrypt=True;Database=metal_db; User Id={USERID}; Password={PASSWORD}&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>
```

# setting up the sample database

The following is the SQL script to create the database and table for the sample code.

```sql
USE [metal_db]
GO

CREATE TABLE [dbo].[metals](
	[metal_id] [int] IDENTITY(1,1) NOT NULL,
	[metal_name] [varchar](40) NULL,
	[symbol] [varchar](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[metal_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```


## Disclaimer
Copyright 2024 Microsoft Corpotration. All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy of 
this software and associated documentation files (the “Software”), to deal in 
the Software without restriction, including without limitation the rights to 
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
of the Software, and to permit persons to whom the Software is furnished to do 
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in 
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
THE SOFTWARE.
