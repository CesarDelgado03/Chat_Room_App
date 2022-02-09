using ChatRoomApp.WorkerBot.Models;
using CsvHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace ChatRoomApp.WorkerBot.Infrastructure.CommandProcessing
{
    public interface ICommandProcessor
    {
        string ProcessCommand(string command);
    }

    public class CommandProcessorService : ICommandProcessor
    {
        private const string CommandPattern = @"(\/(?i)stock(?-i)={1})(\S+\b)$";
        private readonly IConfiguration _configuration;
        private readonly ILogger<CommandProcessorService> _logger;

        public CommandProcessorService(
            IConfiguration configuration,
            ILogger<CommandProcessorService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        private static bool IsValidCommand(string command)
        {
            return !string.IsNullOrWhiteSpace(command) && Regex.Match(command, CommandPattern).Success;
        }

        private static string GetApiCommand(string command)
        {
            var match = Regex.Match(command, CommandPattern);
            return match.Success ? match.Groups[2].Value : null;
        }

        public string ProcessCommand(string command)
        {
            if (!IsValidCommand(command))
            {
                return $"Invalid command \"{command}\"";
            }

            var apiCommand = GetApiCommand(command).ToLower();

            try
            {
                var url = $"{_configuration.GetValue<string>("StockApiUrl")}?s={apiCommand}&f=sd2t2ohlcv&h&e=csv";
                _logger.LogInformation($"Get Command info using URL: {url}");

                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();
                var result = response.GetResponseStream();
                using var reader = new StreamReader(result);
                using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                if (!csvReader.Read()) return $"No results found for command /stock={apiCommand}";

                var record = csvReader.GetRecord<StockResult>();
                var rawRecord = csvReader.GetRecord<object>();
                _logger.LogInformation($"Result of Command : {rawRecord}");
                if (record != null && record.Close != "N/D")
                {
                    return $"{apiCommand} quote is ${record.Close} per share";
                }

                return $"No results found for command /stock={apiCommand}";
            }
            catch (Exception ex)
            {
                return $"Error while processing the command: {command}. Error: {ex.Message}";
            }
        }
    }
}
