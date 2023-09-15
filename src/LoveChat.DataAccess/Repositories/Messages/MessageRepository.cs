using Dapper;
using LoveChat.DataAccess.Interfaces;
using LoveChat.DataAccess.Interfaces.Messages;
using LoveChat.DataAccess.Utils;
using LoveChat.Domain.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.DataAccess.Repositories.Messages;

public class MessageRepository : BaseRepository, IMessagesRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from messages";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<long> CreateAsync(Message entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO messages( sender_id, reseiver_id,image_path, created_at, updated_at)" +
                "VALUES(@SenderId, @ReseiverId,@ImagePath, @CreatedAt, @UpdatedAt); ";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM messages WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<IList<Message>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<Message?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM messages where id=@Id";
            var result = await _connection.QuerySingleAsync<Message>(query, new { Id = id });
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<(int ItemCount, IList<Message>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Message entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.messages" +
                $"SET sender_id = @SenderId, reseiver_id = @ReseiverId,image_path = @ImagePath, created_at = @CreatedAt, updated_at = @UpdatedAt" +
                $"WHERE id={id};";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    Task<int> IRepository<Message, Message>.CreateAsync(Message entity)
    {
        throw new NotImplementedException();
    }
}
