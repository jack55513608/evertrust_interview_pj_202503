using CardTransactionApi.Models;
using CardTransactionApi.Repository;
using CardTransactionApi.Services; // Adding the using directive for services

var builder = WebApplication.CreateBuilder(args);

// 註冊 Repository 到 DI 容器
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICardService, CardService>(); // Registering the CardService
builder.Services.AddScoped<IUserService, UserService>(); // Registering the UserService
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 可視需求自行加入資料庫初始化或遷移（使用 Dapper 時建表需自行處理）
// 建議您先手動執行下方 SQL 指令建立資料表

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
