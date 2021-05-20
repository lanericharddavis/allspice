

using System;
using System.Collections.Generic;
using System.Data;
using allspice.Models;
using Dapper;

namespace allspice.Repositories
{

  public class RecipesRepository
  {
    private readonly IDbConnection _db;
    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Recipe> GetAll()
    {
      string sql = "SELECT * FROM recipes";
      return _db.Query<Recipe>(sql);
    }

    internal IEnumerable<Recipe> GetAllByCreatorId(string id)
    {
      string sql = "SELECT * FROM recipes WHERE creatorId = @id";
      return _db.Query<Recipe>(sql, new { id });
    }

    internal Recipe GetById(int id)
    {
      string sql = "SELECT * FROM recipes WHERE id = @id";
      return _db.QueryFirstOrDefault<Recipe>(sql, new { id });
    }

    internal Recipe Create(Recipe newRecipe)
    {
      string sql = @"
      INSERT INTO recipes
      (creatorId, title, description)
      VALUES
      (@CreatorId, @Title, @Description);
      SELECT LAST_INSERT_ID()";
      newRecipe.Id = _db.ExecuteScalar<int>(sql, newRecipe);
      return newRecipe;
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM recipes WHERE id = @id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }
  }
}