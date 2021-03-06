# Getting Started

## General Overview

All operations are done through the `DomoClient`. Within the primary domo client are individual classes for each section of the Domo API:
```Csharp
Datasets
Groups
Pages
Streams
Users
```
Initializing the primary `DomoClient` will initialize all other classes within, allowing the user to start operations on any section of the Domo API immediately. 

## Authentication
Authentication is handeled within the individual classes using the IDomoConfig Interface. After initializing `DomoClient` with the IDomoConfig class, authentication will be handled automatically.

## DomoClient Setup
```Csharp
IDomoConfig config = new DomoConfig()
{
    ClientId = "{Your Domo Client App Id}",
    ClientSecret = "{Your Domo Client App Secret}"
};
IGotDomod domo = new DomoClient(config);
```

## Dataset Client
Documentation Coming Soon

## Stream Client

### Create new Stream
```Csharp
// Create a new Stream. This Creates a Stream and the dataset in Domo Associated with that stream

// schema for dataset
IDictionary<string, DomoDataType> tableColumns = new Dictionary<string, DomoDataType>()
{
    { "str Column 1", DomoDataType.STRING },
    { "int Column 2", DomoDataType.LONG },
    { "dt Column 3", DomoDataType.DATETIME },
    { "date Column 4", DomoDataType.DATE },
    { "decimal Column 5", DomoDataType.DECIMAL },
    { "float Column 6", DomoDataType.DOUBLE },
    { "bool Column 7", DomoDataType.STRING } //Bool isn't a supported api col type so you either have to use string or long
};
IDatasetSchema dsSchema = new DatasetSchema() 
{
    Name = "Name for Dataset",
    Description = "Example Dataset for demo",
    Schema = new Schema(tableColumns)
}

StreamDataset streamDataset = await domo.Streams.CreateAsync(dsSchema, UpdateMethod.APPEND); // Executions will append rows to dataset
```

### Insert data into a Stream DataSet 
### (Create Stream Execution, Upload Data Parts, Commit Execution)
```Csharp
int streamId = 1230 // You can use the ListAsync to get a list of Streams and their Ids

// Create a Stream Execution that Data Parts can be uploaded to.
StreamExecution newExecution = await domo.Streams.CreateStreamExecutionAsync(streamId);

// Sample data
string csvContent = "\"Test String\",\"1\",\"2016-06-21T17:20:36Z\",\"2016-06-21\",\"0.1\",\"0.1\",\"TRUE\"";

// Upload Sample data.
var uploadPartHttpResponse = await domo.Streams.UploadDataPartAsync(streamId, newExecution.Id, 1 /*part number*/, csvContent);

if(uploadPartHttpResponse.IsSuccessStatusCode){
    // Commit Stream Execution and insert uploaded data parts into Domo Dataset
    await domo.Streams.CommitExecutionAsync(streamId, newExecution.Id); 
}
```

### Update Stream Dataset Metadata. i.e. Name, Description, DataSet Schema
```Csharp
    StreamDataset updatedStreamDataset = await UpdateMetaAsync(streamId, streamDataset);
```
## User Client
Documentation Coming Soon

## Group Client
Documentation Coming Soon

## Page Client
Documentation Coming Soon

