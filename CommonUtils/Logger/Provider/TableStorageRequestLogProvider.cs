using Ardalis.GuardClauses;
using CommonUtils.Abstractions.Interface;
using CommonUtils.Models;
using CommonUtils.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtils.Logger.Provider
{
    internal class TableStorageRequestLogProvider : IRequestLogProvider
    {
        private readonly StorageLoggerOptions _options;
        private readonly CloudStorageAccount _cloudStorageAccount;
        private readonly ILogger<TableStorageRequestLogProvider> _logger;
        private readonly CloudTable _table;

        public TableStorageRequestLogProvider(IOptions<StorageLoggerOptions> options, ILogger<TableStorageRequestLogProvider> logger)
        {
            _options = options.Value;
            _logger = logger;

            try
            {
                _cloudStorageAccount = CloudStorageAccount.Parse(_options.ConnectionString);
            }
            catch (FormatException)
            {
                _logger.LogError("Invalid storage account config provided. Please verify the storage account config and restart the application");
                throw;
            }
            catch (ArgumentException)
            {
                _logger.LogError("Invalid storage account config provided. Please verify the storage account config and restart the application");
                throw;
            }

            if (_cloudStorageAccount != null)
            {
                CloudTableClient client = _cloudStorageAccount.CreateCloudTableClient();

                _table = client.GetTableReference(_options.TableName);

                if (_table.CreateIfNotExistsAsync().Result)
                {
                    _logger.LogInformation("Created Request Log Table");
                }
            }
        }

        public async Task LogAsync(RequestLogEntity logItem)
        {
            Guard.Against.Null(logItem, nameof(logItem));

            try
            {
                var operation = TableOperation.Insert(logItem);

                await _table.ExecuteAsync(operation);
            }
            catch (StorageException)
            {
                _logger.LogError($"Error inserting log with correlationId {logItem.CorrelationId}");
            }
        }
    }
}
