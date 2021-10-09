using System;
using System.Collections.Generic;
using System.Text;
using Common.Enums;
using Common.Interfaces;
using Common.Items;
using Unity;

namespace Services.Services
{
    internal class SpreadsheetProcessor : ISpreadsheetProcessor
    {
        private static readonly Dictionary<DelimiterEnum, string> InputDelimiterMap =
            new Dictionary<DelimiterEnum, string>
            {
                {DelimiterEnum.Comma, ","},
                {DelimiterEnum.Semicolon, ";"},
                {DelimiterEnum.Tab, "\t"},
                {DelimiterEnum.Whitespace, " "}
            };

        private static readonly Dictionary<DelimiterEnum, string> OutputDelimiterMap =
            new Dictionary<DelimiterEnum, string>
            {
                {DelimiterEnum.Comma, ", "},
                {DelimiterEnum.Semicolon, "; "},
                {DelimiterEnum.Tab, "\t"},
                {DelimiterEnum.Whitespace, " "}
            };

        public SpreadsheetProcessor(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        public SpreadsheetProcessResult ProcessInput(string text, SpreadsheetInputProcessParameters parameters)
        {
            var result = new List<List<string>>();
            var maxRowLength = -1;
            var hasEmptyCells = false;
            var delimiter = parameters.Delimiter == DelimiterEnum.Custom ?
                                parameters.CustomDelimiter :
                                InputDelimiterMap[parameters.Delimiter];

            var rows = text.Split("\r\n", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            foreach (var row in rows)
            {
                var editedRow = CutString(row, parameters.RowLeft, parameters.RowRight);

                var words = editedRow.Split(
                    delimiter, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                var editedWords = new List<string>();

                foreach (var word in words)
                {
                    var editedWord = CutString(word, parameters.WordLeft, parameters.WordRight);
                    editedWords.Add(editedWord);
                }

                var rowLength = editedWords.Count;

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

                if (editedWords.Count > 0)
                {
                    result.Add(editedWords);
                }
            }

            return new SpreadsheetProcessResult(result, result.Count, maxRowLength, hasEmptyCells);
        }

        public string ProcessOutput(IEnumerable<IEnumerable<string>> rows,
                                    SpreadsheetOutputProcessParameters parameters)
        {
            var rowsBuilder = new StringBuilder();

            var delimiter = parameters.Delimiter == DelimiterEnum.Custom ?
                                parameters.CustomDelimiter :
                                OutputDelimiterMap[parameters.Delimiter];

            foreach (var row in rows)
            {
                var wordsBuilder = new StringBuilder();
                var wordsEnumerator = row.GetEnumerator();

                if (wordsEnumerator.MoveNext())
                {
                    wordsBuilder.Append(ApplyWordFormatting(wordsEnumerator.Current, parameters));

                    while (wordsEnumerator.MoveNext())
                    {
                        wordsBuilder.Append(delimiter);
                        wordsBuilder.Append(ApplyWordFormatting(wordsEnumerator.Current, parameters));
                    }
                }

                rowsBuilder.AppendLine($"{parameters.RowLeft}{wordsBuilder}{parameters.RowRight}");
            }

            return rowsBuilder.ToString();
        }

        private static string ApplyWordFormatting(string str, SpreadsheetOutputProcessParameters parameters) =>
            $"{parameters.WordLeft}{ApplyTextCaseFormatting(str, parameters.TextCase)}{parameters.WordRight}";

        private static string ApplyTextCaseFormatting(string str, TextCaseEnum formatting)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            switch (formatting)
            {
                case TextCaseEnum.AllLower: return str.ToLower();
                case TextCaseEnum.AllUpper: return str.ToUpper();

                case TextCaseEnum.FirstUpper:
                    return str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1).ToLower();

                default: return str;
            }
        }

        private static string CutString(string str, string left, string right)
        {
            str = str?.Trim();
            left = left?.Trim();
            right = right?.Trim();

            if (!string.IsNullOrEmpty(str) &&
                !string.IsNullOrEmpty(left) &&
                left.Length <= str.Length &&
                str.IndexOf(left) == 0)
            {
                str = str.Substring(left.Length);
            }

            if (!string.IsNullOrEmpty(str) &&
                !string.IsNullOrEmpty(right) &&
                right.Length <= str.Length)
            {
                var leftSideLength = str.Length - right.Length;

                if (str.IndexOf(right) == leftSideLength)
                {
                    str = str.Substring(0, leftSideLength);
                }
            }

            return str?.Trim();
        }
    }
}