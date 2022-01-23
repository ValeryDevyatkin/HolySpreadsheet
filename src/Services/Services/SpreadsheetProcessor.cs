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
                { DelimiterEnum.Comma, "," },
                { DelimiterEnum.Semicolon, ";" },
                { DelimiterEnum.Tab, "\t" },
                { DelimiterEnum.Whitespace, " " }
            };

        private static readonly Dictionary<DelimiterEnum, string> OutputDelimiterMap =
            new()
            {
                { DelimiterEnum.Comma, ", " },
                { DelimiterEnum.Semicolon, "; " },
                { DelimiterEnum.Tab, "\t" },
                { DelimiterEnum.Whitespace, " " }
            };

        public SpreadsheetProcessor(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        public SpreadsheetInputProcessResult ProcessInput(string text, SpreadsheetInputProcessParameters parameters)
        {
            var result = new List<string[]>();
            var maxRowLength = -1;
            var hasEmptyCells = false;
            var delimiter = parameters.Delimiter == DelimiterEnum.Custom ?
                                parameters.CustomDelimiter :
                                InputDelimiterMap[parameters.Delimiter];

            var rows = text.Split(RowSeparator, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            foreach (var row in rows)
            {
                var words = row.Split(
                    delimiter, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                var rowLength = words.Length;

                if (maxRowLength == -1)
                {
                    maxRowLength = rowLength;
                }
                else
                {
                    if (rowLength != maxRowLength)
                    {
                        hasEmptyCells = true;

                        if (rowLength > maxRowLength)
                        {
                            maxRowLength = rowLength;
                        }
                    }
                }

                if (words.Length > 0)
                {
                    result.Add(words);
                }
            }

            return new SpreadsheetInputProcessResult(result, result.Count, maxRowLength, hasEmptyCells);
        }

        public SpreadsheetOutputProcessResult ProcessOutput(IReadOnlyList<IEnumerable<string>> rows,
                                                            SpreadsheetOutputProcessParameters parameters)
        {
            var resultRows = new List<string>();

            var delimiter = parameters.Delimiter == DelimiterEnum.Custom ?
                                parameters.CustomDelimiter :
                                OutputDelimiterMap[parameters.Delimiter];

            foreach (var row in rows)
            {
                var words = new List<string>();

                foreach (var word in row)
                {
                    words.Add($"{parameters.WordLeft}{word}{parameters.WordRight}");
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