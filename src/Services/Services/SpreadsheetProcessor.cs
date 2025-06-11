using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;
using Common.Interfaces;
using Common.Items;
using Unity;

namespace Services.Services
{
    internal class SpreadsheetProcessor : ISpreadsheetProcessor
    {
        private const string RowSeparator = "\r\n";

        private static readonly Dictionary<DelimiterEnum, string> InputDelimiterMap =
            new()
            {
                {DelimiterEnum.Comma, ","},
                {DelimiterEnum.Semicolon, ";"},
                {DelimiterEnum.Tab, "\t"},
                {DelimiterEnum.Whitespace, " "}
            };

        private static readonly Dictionary<DelimiterEnum, string> OutputDelimiterMap =
            new()
            {
                {DelimiterEnum.Comma, ","},
                {DelimiterEnum.Semicolon, ";"},
                {DelimiterEnum.Tab, "\t"},
                {DelimiterEnum.Whitespace, " "}
            };

        public SpreadsheetProcessor(IUnityContainer container)
        {
        }

        public SpreadsheetInputProcessResult ProcessInput(string text, SpreadsheetInputProcessParameters parameters)
        {
            var result = new List<IEnumerable<string>>();
            var maxRowLength = 0;

            var delimiter = parameters.Delimiter == DelimiterEnum.Custom ?
                parameters.CustomDelimiter :
                InputDelimiterMap[parameters.Delimiter];

            var splitOptions = parameters.Delimiter == DelimiterEnum.Whitespace ?
                StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries :
                StringSplitOptions.TrimEntries;

            var rows = text.Split(RowSeparator, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            if (parameters.ShouldPullInLine)
            {
                var resultLine = new List<string>();

                foreach (var row in rows)
                {
                    var words = row
                               .Split(delimiter, splitOptions)
                               .Where(x => !string.IsNullOrEmpty(x))
                               .ToArray();

                    var rowLength = words.Length;
                    maxRowLength += rowLength;
                    resultLine.AddRange(words);
                }

                if (resultLine.Count > 0)
                {
                    result.Add(resultLine);
                }
            }
            else
            {
                foreach (var row in rows)
                {
                    var words = row.Split(delimiter, splitOptions);
                    var rowLength = words.Length;

                    if (maxRowLength == 0)
                    {
                        maxRowLength = rowLength;
                    }
                    else if (rowLength > maxRowLength)
                    {
                        maxRowLength = rowLength;
                    }

                    if (words.Length > 0)
                    {
                        result.Add(words);
                    }
                }
            }

            return new SpreadsheetInputProcessResult(result, result.Count, maxRowLength);
        }

        public SpreadsheetOutputProcessResult ProcessOutput(GridParsingResult gridParsingResult,
            SpreadsheetOutputProcessParameters parameters)
        {
            var resultRows = new List<string>();
            var rows = gridParsingResult.Rows;
            var columnInfo = gridParsingResult.ColumnInfo;

            var delimiter = parameters.Delimiter == DelimiterEnum.Custom ?
                parameters.CustomDelimiter :
                OutputDelimiterMap[parameters.Delimiter];

            foreach (var row in rows)
            {
                var words = new List<string>();

                for (var i = 0; i < columnInfo.Count; i++)
                {
                    var word = row[i];
                    string formattedWord;

                    if (columnInfo[i].IsFormattingDisabled)
                    {
                        formattedWord = word;
                    }
                    else
                    {
                        formattedWord = $"{parameters.WordLeft}{word}{parameters.WordRight}";
                    }

                    words.Add(formattedWord);
                }

                resultRows.Add($"{parameters.RowLeft}{string.Join(delimiter, words)}{parameters.RowRight}");
            }

            return new SpreadsheetOutputProcessResult
            {
                RowCount = rows.Count,
                Text = string.Join(RowSeparator, resultRows)
            };
        }

        public SpreadsheetOutputProcessResult RemoveRowDuplicates(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException(nameof(text));
            }

            var rows = text.Split(RowSeparator);
            var distinctRows = rows.Distinct();
            var rowCount = 0;
            var resultRows = new List<string>();

            foreach (var row in distinctRows)
            {
                resultRows.Add(row);
                rowCount++;
            }

            return new SpreadsheetOutputProcessResult
            {
                RowCount = rowCount,
                Text = string.Join(RowSeparator, resultRows)
            };
        }
    }
}