# O Projeto é feito em code-first, ou seja, o banco é criado automaticamente 

# Comando para criação da migration inicial
dotnet ef migrations add Initial

# Comando de criação do banco de dados com o EF Core
dotnet ef database update

# Comando para execução da api
dotnet run