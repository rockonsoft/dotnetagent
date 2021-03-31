## Tips

```cli
dotnet add [<PROJECT>] reference [-f|--framework <FRAMEWORK>]
     [--interactive] <PROJECT_REFERENCES>

dotnet add reference -h|--help
```

Example: (done in the current projects folder so the 'to' project is seached for in the current folder)

```
dotnet add reference  ../models/models.csproj

```

dotnet add package Microsoft.Data.Sqlite
Microsoft.EntityFrameworkCore.Sqlite.Core
