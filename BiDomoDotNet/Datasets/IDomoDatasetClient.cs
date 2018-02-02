﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiDomoDotNet.Datasets
{
    public interface IDomoDatasetClient
    {
        Task<IEnumerable<Dataset>> ListDatasetsAsync(int limit, int offset /*Sorting as optional param or overload*/);
        Task<Dataset> CreateDatasetAsync(DatasetSchemaBase schema);
        Task<bool> UpdateDatasetAsync(string datasetId, DatasetSchemaBase schema);
        Task<bool> DeleteDatasetAsync(string datasetId);
        Task<string> RetrieveCsvAsync(string datasetId, bool includeHeader = false);
        Task<IEnumerable<T>> RetrieveDataAsync<T>(string datasetId, bool includeHeader = false);
        Task ExportToCsvFile(string datasetId, string path, bool includeHeader, string fileName);
        Task<Dataset> RetrieveDatasetAsync(string datasetId);
        Task<bool> UpdateDatasetAsync(string datasetId, Dataset datasetSchema);
    }
}