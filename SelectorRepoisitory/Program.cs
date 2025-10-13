// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using SelectorRepoisitory;

Console.WriteLine("Hello, World!");

var conn = new BloggingContext();

var repo = new GenericRepository<Blog>(conn);

// defualt select all
var query = repo.ListAsync(
    select: a => a,
    orderBy: a => a.OrderBy(b => b.BlogId));

Console.WriteLine(query.ToQueryString());

var query2 = repo.ListAsync(
    select: a => new BlogDto(a.BlogId, a.Url),
    orderBy: a => a.OrderBy(b => b.BlogId));

Console.WriteLine(query2.ToQueryString());

public record BlogDto(int Id, string Name);