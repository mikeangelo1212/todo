#!/bin/bash
set -a
source .env
set +a

dotnet tool install -g dotnet-ef
dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Database=todo;Username=postgres;Password=postgres" Npgsql.EntityFrameworkCore.PostgreSQL \
    --output-dir ./Entities \
    --context-dir . \
    --context MyDbContext \
    --no-onconfiguring \
    --namespace efscaffold.Entities \
    --context-namespace Infrastructure.Postgres.Scaffolding \
    --schema todosystem \
    --force