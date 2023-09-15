using LoveChat.DataAccess.Utils;

namespace LoveChat.DataAccess.Common.Interfaces;

public interface ISearchable<TModel>
{
    public Task<(int ItemCount, IList<TModel>)> SearchAsync(string search,
        PaginationParams @params);
}
