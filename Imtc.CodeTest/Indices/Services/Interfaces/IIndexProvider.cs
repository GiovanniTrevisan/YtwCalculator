using IMTC.CodeTest.Models;

namespace IMTC.CodeTest.Indices.Services;

public interface IIndexProvider
{
    Task<FinancialIndex> GetIndex(IndexNames indexName, DateTime date);
}