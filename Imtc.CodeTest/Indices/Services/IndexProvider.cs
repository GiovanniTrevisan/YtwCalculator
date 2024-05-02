using IMTC.CodeTest.Models;

namespace IMTC.CodeTest.Indices.Services
{

    // Class made with the context passed to follow a financial context flow
    public class IndexProvider : IIndexProvider
    {
        public async Task<FinancialIndex> GetIndex(IndexNames indexName, DateTime date)
        {

            FinancialIndex index = new FinancialIndex
            {
                Name = indexName,
                Date = date
            };

            return index;
        }
    }
}
